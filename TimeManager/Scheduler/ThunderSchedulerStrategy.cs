using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;

using System.Numerics;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;


namespace TimeManager.Scheduler
{
    public class TimeOverflowException : Exception
    {
        public TimeOverflowException() { }
        public TimeOverflowException(string msg) : base(msg) { }
        
    }

    public class ThunderSchedulerStrategy : ISchedulerStrategy
    {
        // Know 가용시간, tasks, 현재 날짜
        // W.T.G 1st : greedy timeTable -> 2nd : rearranged timeTable

        // days를 day의 배열(or vector)로 관리
        // day에 0) 해당 날짜
        //       1) 가용시간(int형)
        //       2) 각각의 Task가 몇시간씩 채워져있는지의 정보를 갖고있는 Vector -> 이후 random swap용으로 쓰임
        //       3) 채워진 시간(가용시간을 얼마나 채웠는지)정보
        //       4) 가용시간 만큼의 단위 Block을 갖고 있는(갖게 될) Vector(TaskBlcok을 채워나갈 예정)
        //         (Vector<Task>) ← ∵ TaskBlock에는 Task정보만 들어가면 될듯해서
        // 

        // Day에 여러 정보를 담아 하나로 채우는게 목적인 클래스

        public int least_interval;

        private class TempBlock
        {
            public TempBlock(Data.Model.Task task, int time_interval){
                this.task = task; this.time_interval = time_interval;

            }
            public int time_interval {  get; set; }
            public Data.Model.Task task;

            public bool Exchangable = false;        // Exchange 과정에서 사용하기 위해 만듦.
        }

        private class Day
        {
            public Day(DateTime date, int available)
            {
                dateTime = date;
                availableTime = available;
            }

            // Day 객체가 무슨 날인지
            public DateTime dateTime { get; set; }
            // 가용시간이 몇시간인지(1당 30분)
            public int availableTime {  get; set; }
            // 
            public List<TempBlock> tempBlocks { get; set; }
            // 시간이 얼마나 채워졌는지
            public int time_allocated { get; set; }
            // 시간 위치에 관계없이 앞에서부터 task 쌓기
            public Data.Model.Task[] task_arr = new Data.Model.Task[48];
        }

        private class ReplicaOfTask
        {
            public Data.Model.Task task;
            public DateTime? focusDate;
            public DateTime? endDate;
            public int Duration; // 몇시간만에 끝낼 작업인지
        }


        private List<ReplicaOfTask> duplicateTaskOnShort(List<Data.Model.Task> tasks)
        {
            List<ReplicaOfTask> repl_tasks = new List<ReplicaOfTask>();

            // List<Task>에 있는 Task의 replica를 만들어 List<ReplicaOfTask>를 생성.
            foreach(Data.Model.Task task in tasks)
            {
                if(task.Type == ETaskType.LongTerm) continue;

                ReplicaOfTask repl_task = new ReplicaOfTask();
                repl_task.task = task;
                repl_task.focusDate = task.EndDate?.AddDays(-(double)task.FocusDays);
                repl_task.endDate = task.EndDate;
                repl_task.Duration = task.Duration.Value.Minutes / 30;

                repl_tasks.Add(repl_task);
            }
            return repl_tasks;
        }


        // 전제 : repl_tasks는 마감일이 빠른게 앞으로 오도록 하고
        //        days는 빠른 날이 앞으로 오도록 해야 함.
        private void FillDaysWithTasks(List<ReplicaOfTask> repl_tasks, List<Day> days)
        {
            IEnumerator<ReplicaOfTask> task_iter = repl_tasks.GetEnumerator();
            IEnumerator<Day> day_iter = days.GetEnumerator();

            bool end = false;

            // W.T.D 마감일이 빠른것을 잡아 day_iter 위치에 때려박는다.
            while (!end)
            {
                // 마감일이 빠른게 앞으로 오게 배열되어있음
                // <-> 시작일은 배열 순서와 무관함
                task_iter.Reset();          // Reset을 한다 == 마감일이 빠른것을 보겠다
                // 처음 MoveNext()를 했는데 비어있다 == 남아있는 Task가 없다.
                // ∴ 반복문 빠져나감.
                if (task_iter.MoveNext())   
                {
                    break;
                }
                /* focusDate가 dateTime보다 작아지는 상황을 찾는중*/
                while((task_iter.Current.focusDate > day_iter.Current.dateTime))
                {
                    // repl_tasks에 들어있는 마감일이 가장 빠른것부터 차례로 확인함
                    task_iter.MoveNext();
                }
                // while문을 빠져나와서 여기에 왔다
                // <-> 마감일(endDate)이 빠른 것 중에서 focusDate가 dateTime보다
                //     앞에 있는 것이 task_iter에 들어있다

                // 넣을 수 없는 일정이 발생했을 때(∵ dateTime 앞에 마감일이 지난 일정이 있음.)
                if (day_iter.Current.dateTime > task_iter.Current.endDate)
                {
                    // 강제로 반복문을 빠져나옴.
                    break;
                }

                // 넣을 수 있는 시간공간이 넣으려고 하는 시간보다 더 크거나 같을 때
                if ((day_iter.Current.availableTime - day_iter.Current.time_allocated) >=task_iter.Current.Duration)
                {
                    // 같다면, 작업이 모두 끝난 이후 day_iter.MoveNext();
                    bool MoveNext = false;   // 를 수행하기 위한 선행과정
                    if ((day_iter.Current.availableTime - day_iter.Current.time_allocated) == task_iter.Current.Duration)
                        MoveNext = true;

                    int duration = task_iter.Current.Duration;
                    Data.Model.Task task = task_iter.Current.task;

                    // 0) TempBlock에 정보를 넣어 TempBlocks에 넣음.
                    TempBlock tempBlock = new TempBlock(task, duration);
                    day_iter.Current.tempBlocks.Add(tempBlock);

                    // 2) time_allocated에 duration만큼 더함.
                    AutoAllocatedTimeHandle(day_iter.Current);

                    // 3) task_iter부분을 삭제 & MoveNext가 true라면 day_iter.MoveNext();
                    repl_tasks.Remove(task_iter.Current);
                    if (MoveNext)
                    {
                       end = !day_iter.MoveNext();      // 끝남을 확인하기 위한 if문
                    }
                    
                }
                // 넣을 수 있는 시간공간보다 넣으려고 하는 시간이 더 클때
                else if ((day_iter.Current.availableTime - day_iter.Current.time_allocated) < task_iter.Current.Duration)
                {
                    Data.Model.Task task = task_iter.Current.task;

                    // 0) TempBlock에 정보를 넣어 TempBlocks에 넣음.
                    TempBlock tempBlock = new TempBlock(task, day_iter.Current.availableTime - day_iter.Current.time_allocated);
                    day_iter.Current.tempBlocks.Add(tempBlock);

                    // 2) duration에서 (채운 시간) 만큼 빼야함.
                    //  (채운 시간) = availableTime - time_allocated
                    task_iter.Current.Duration -= (day_iter.Current.availableTime - day_iter.Current.time_allocated);

                    // 3) time_allocated에 duration만큼 더함.
                    AutoAllocatedTimeHandle(day_iter.Current);

                    // 4) 해당 day의 availableTime을 모두 채웠으므로, day_iter.MoveNext();
                    end = !day_iter.MoveNext();
                }
            }

            if (repl_tasks.Count != 0)
            {
                throw new TimeOverflowException("가용 시간이 부족합니다");
            }
        }

        private bool PercentRandom(int percent)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            if (random.Next(1, 101) <= percent) return true;
            else return false;
        }

        private void RandomRange(List<TempBlock> tempBlocks)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int n = tempBlocks.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                TempBlock tempBlock = tempBlocks[k];
                tempBlocks[k] = tempBlocks[n];
                tempBlocks[n] = tempBlock;
            }
        }

        private TempBlock FindExchangableTempBlock(Data.Model.Task task, IEnumerator<Day> day_cursor, int interval)
        {
            day_cursor.MoveNext();

            bool end = false;
            DateTime dateTime = day_cursor.Current.dateTime;

            // task의 EndDate까지의 날짜를 계속 훑어봄.
            while(day_cursor.Current.dateTime <= task.EndDate && !end)
            {
                // 해당 day의 tempBlock들을 확인하며 적합한 task를 찾음.
                    // 해당 task의 FocusDays가 
                foreach (TempBlock tempBlock in day_cursor.Current.tempBlocks)
                {
                    // 적합한 조건을 만족한다면
                    // 1) 뒤의 task를 앞으로 가져올 수 있다.
                    // 2) time_interval이 interval보다 크거나 같다
                    // 3) 뒤의 task와 앞의 task가 같지 않다.
                    if (dateTime >= tempBlock.task.EndDate?.AddDays(-(double)(task.FocusDays - 1))
                        && tempBlock.time_interval >=interval && tempBlock.task != task)
                    {
                        if(PercentRandom(60))   // 여기서도 일단은 확률값은 받음.
                        {
                            return tempBlock;
                        }
                    }
                }
                day_cursor.MoveNext() ;
            }
            return null;
        }

        // Empty 영역에서 바꿀 수 있는 곳이 있는지 찾는 메서드
        private Day FindExchanableDay(Data.Model.Task task, IEnumerator<Day> day_cursor, int interval)
        {
            day_cursor.MoveNext();
            bool end = false;   // end 사실상 쓰진 않았지만 일단 둠.

            while (day_cursor.Current.dateTime <= task.EndDate && !end)
            {
                if(day_cursor.Current.availableTime - day_cursor.Current.time_allocated >= interval)
                {
                    if (PercentRandom(60))   // 여기서도 일단은 확률값은 받음.
                    {
                        return day_cursor.Current;
                    }
                }
                day_cursor.MoveNext();

            }
            return null;
        }

        // 뒤의 빈 시간과 바꾸는 메서드
        private void ExchangeTaskWithEmpty(int interval, TempBlock tempBlock_f, Day day_b)
        {
            // day_b에 tempBlock_f를 옮기고
            TempBlock tempBlock = new TempBlock(tempBlock_f.task, interval);
            day_b.tempBlocks.Add(tempBlock);

            // time_allocate 값 조정하기
            AutoAllocatedTimeHandle(day_b);
        }

        void AutoAllocatedTimeHandle(Day day)
        {
            int time_allocated = 0;

            foreach(TempBlock tempBlock in day.tempBlocks)
            {
                time_allocated += tempBlock.time_interval;
            }

            day.time_allocated = time_allocated;
        }

        // f : front , b : back (day_b는 copied가 x)
        private void ExchangeTask(int interval, TempBlock tempBlock_f, TempBlock tempBlock_b, Day day_f_copied, Day day_b)
        {
            // TempBlock_b에 대해 1) 새로운 Temp_b를 만들어 day_f에 넣는다.
            //                    2) TempBlock_b의 interval을 줄인다.
            TempBlock temp_b = new TempBlock(tempBlock_b.task, interval);
            day_f_copied.tempBlocks.Add(temp_b);

            tempBlock_b.time_interval -= interval;

            // TempBlock_f에 대해

            // 1) day_b에 TempBlock_f.task를 가지고 있는 TempBlock이 있는지 확인한다.
            bool exist = false;
            foreach (TempBlock tempBlock in day_b.tempBlocks)
            {
                // 있다면 찾은 tempBlock의 interval값을 늘리고
                if (tempBlock.task ==  tempBlock_f.task)
                {
                    exist = true;
                    tempBlock.time_interval += interval;
                    break;
                }
            }

            // 없다면 새로운 tempBlock을 만들어 넣음.
            if (!exist)
            {
                TempBlock tempBlock = new TempBlock(tempBlock_f.task, interval);
                day_b.tempBlocks.Add(tempBlock);
            }

            // 2) TempBlock_f의 interval을 줄인다.
            /*tempBlock_f.time_interval -= interval;*/
        }

        private Day FindCorresponedDayOfDaysCopied(DateTime dateTime, List<Day> days_copied)
        {
            foreach(Day day in days_copied)
            {
                if(day.dateTime == dateTime)
                    return day;
            }
            throw new Exception("day가 반환되지 않음");
        }

 


        // W.T.D : n시간으로 등분되길 원한다면, n시간씩 쪼개어 다른곳(다른날)과 위치를 바꿈.
        private List<Day> RandomArrange(List<Day> days, int least_interval)
        {
            // Day를 모두 순회하면서 Task들 또한 순회함.
            // 순회하면서 각각의 Task 시간블럭을 확인함.
            //
            //  (확률을 적용하여 exchange 기능 설정?)
            // if) Task A의 시간이 2n보다 큰가? & 이미 한번 훑은 적이 없는가?
            //      then -> 뒤에 날짜를 보며(Task A의 마감기한까지.)
            //      , 바꿀만한 Task B(Or 빈 시간)가 있는지 확인하기.(조건 : Task B의 마감기한 또한 Task A의 마감기한에 포함되어야 함.)
            //      if) 바꿀 수 있다면, 바꾸는 함수인 Exchange() 적용.
            // 
            
            // Days의 복사본 생성
            List<Day> days_copied = new List<Day>();
            foreach(Day day in days)
            {
                days_copied.Add(new Day(day.dateTime, day.availableTime));
            }

            // days 속 day의 tasks를 랜덤으로 섞기
            foreach (Day day in days)
            {
                RandomRange(day.tempBlocks);
            }

            /* 배치 위치 교환 시작 */
            IEnumerator<Day> day_iter = days.GetEnumerator();
            IEnumerator<Day> day_cursor = days.GetEnumerator();
            day_iter.Reset();

            // bool first = true;

            // day들을 순회하며 tempBlocks의 tempblock들을 바꾸기 위한 반복문
            while(day_iter.MoveNext())
            {
                // While문 처음 들어왔을 때 첫 인덱스(첫날)부터 접근하게 하기 위한 방법
                /*if(first)
                {
                    first = false;
                    day_iter.Reset();
                }*/

                foreach (TempBlock tempBlock in day_iter.Current.tempBlocks)
                {
                    int interval;
                    while (tempBlock.time_interval != 0)
                    {
                        day_cursor = day_iter;
                        // 현재 time_interval 값을 통해 interval값 결정.(interval : 잘라낼 timeblock의 interval)
                        if (tempBlock.time_interval >= 2 * least_interval)
                            interval = least_interval;
                        else interval = tempBlock.time_interval;

                        // 일단 50% 확률로 빈공간에 채우기 or tempblock과 바꾸기
                        if (PercentRandom(50))
                        {
                            // 위치를 바꿀 수 있는 Temp를 찾는다.(changableTemp)
                            TempBlock changableTemp =  FindExchangableTempBlock(tempBlock.task, day_cursor, interval);
                            // 찾았다면, changableTemp는 day_f_copied로, tempBlock은 cursor 위치로 보낸다.
                            if(changableTemp != null)
                            {
                                Day day_f_copied = FindCorresponedDayOfDaysCopied(day_iter.Current.dateTime , days_copied);
                                ExchangeTask(interval, tempBlock, changableTemp, day_f_copied, day_cursor.Current);

                                // time_interval이 0이 된 temp는 지움.
                                if(changableTemp.time_interval == 0)
                                {
                                    day_cursor.Current.tempBlocks.Remove(changableTemp);
                                }
                            }
                        }
                        else
                        {
                            Day changableDay = FindExchanableDay(tempBlock.task, day_cursor, interval);
                            if(changableDay != null)
                            {
                                ExchangeTaskWithEmpty(interval, tempBlock, changableDay);
                            }
                        }
                        // 이후 tempBlock에서 interval만큼 빼주기
                        tempBlock.time_interval -= interval;

                    }

                }
                day_iter.MoveNext();
            }
            return days_copied;
        }








        public void Schedule(TimeTable timeTable, List<Data.Model.Task> tasks)
        {
            // Let We have AvailableTime of each day.
            // 날짜별로 가용시간 총량을 받아옴.
            
            List<DateTimeBlock> dateTimeBlocks =  timeTable.GetAvailableTimesInThisWeekAsOfNow();


            List<Day> days = new List<Day>();
            bool exist = false;

            // days에 day들을 추가하고 availableTime을 결정하는 반복문
            foreach (DateTimeBlock dateTimeBlock in dateTimeBlocks)
            {
                exist = false;
                foreach (Day day in days)
                {   
                    // dateTimeBlock의 날짜와 일치하는것이 존재한다면 exist를 true로 바꿈.
                    if (day.dateTime.Date == dateTimeBlock.StartDate.Date)
                    {
                        exist = true;
                        day.availableTime += dateTimeBlock.Duration.Minutes / 30;
                        // 30 : 시간블록 단위
                    }
                }
                // 날짜에 대한 dateTimeBlock이 없다면 새롭게 추가하기
                
                if (exist == false) // exist가 여전히 false라면 새로운 객체를 생성.
                {
                    Day day = new Day(dateTimeBlock.StartDate.Date, dateTimeBlock.Duration.Minutes/30);
                    // 30 : 시간블록 단위
                    days.Add(day);
                }
            }

            // post : days에 각 day별로 date와 AvailableTime이 들어감

            // W.T.D : 마감 있는 Task의 replica를 List로 만들기(repl_tasks) 
            List<ReplicaOfTask> repl_tasks = duplicateTaskOnShort(tasks);

            // W.T.D : 이제 days의 day에 repl_tasks의 repl_task를 넣기
            FillDaysWithTasks(repl_tasks, days);

            // W.T.D : 덩어리가 큰 것들을 찾아 등분하여 다른곳과 바꿈
            List<Day> daysRandomlyArranged = RandomArrange(days, least_interval);



            throw new NotImplementedException();
        }
    }
}

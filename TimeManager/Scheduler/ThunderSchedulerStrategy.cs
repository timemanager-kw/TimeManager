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


namespace TimeManager.Scheduler
{
    public class TimeOverflowException : Exception
    {
        public TimeOverflowException() { }
        public TimeOverflowException(string msg) : base(msg) { }
        
    }

    class ThunderSchedulerStrategy : ISchedulerStrategy
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
        private class TempBlock
        {
            public TempBlock(Data.Model.Task task, int time_interval){
                this.task = task; this.time_interval = time_interval;
            }
            public int time_interval {  get; set; }
            Data.Model.Task task;
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


        // 전제 : repl_tasks는 focus_date가 빠른게 앞으로 오도록 하고
        //        days는 빠른 날이 앞으로 오도록 해야 함.
        private void FillDaysWithTasks(List<ReplicaOfTask> repl_tasks, List<Day> days)
        {
            // day와 task에 대한 iterator 먼저 설정

            IEnumerator<ReplicaOfTask> task_iter = repl_tasks.GetEnumerator();
            IEnumerator<Day> day_iter = days.GetEnumerator();

            // task_iter가 모두 채워지거나 day_iter가 모두 채워질 때까지 반복

            // 1. day_iter의 current에서의 잔여 가용시간 > task_iter의 duration 이라면
            //      1) duration만큼 채우고 해당 task를 지움
            //      2) 이후 task_iter를 reset하고 다시 조건을 만족하는 task를 찾음.
            //      (조건) -> focusDate < day_iter.date

            // 2. day_iter의 current에서의 잔여 가용시간 < task_iter의 duration 이라면
            //      1) 잔여 가용시간을 전부 채우고 day_iter.MoveNext()함.

            // ** 날짜가 넘어가거나 task를 다 채우면 무조건 task_iter.Reset().**

            // iterator로 마지막 day까지 확인하여 작업을 끝낸 이후에도 task가 남아있다면
            // -> 이는 불가능한 시간표임을 의미하는 것이므로, 오류 내보냄.
            day_iter.Reset();

            bool end = false;

            while (!end)
            {
                // task_iter 초기화
                task_iter.Reset();
                // dateTime을 넣을 수 있는 날까지 MoveNext()하며 이동.
                while((task_iter.Current.focusDate > day_iter.Current.dateTime))
                {
                    // 임의의 day에 대해 그 앞에 마감일이 지난 task가 존재한다는 것은, 이행이 불가능한 시간표라는 것이므로
                    // 작업을 끝내는 동작을 한다.
                    if(day_iter.Current.dateTime > task_iter.Current.endDate)
                    {
                        end = true; break;
                    }
                    // 그런 상황이 아니라면, 이후의 task를 확인하며 채우는 동작을 진행한다.
                    task_iter.MoveNext();
                }

                if (end) break; // (*)의 연장선 상의 작업

                // 넣을 수 있는 시간공간이 넣으려고 하는 시간보다 더 크거나 같을 때
                if ((day_iter.Current.availableTime - day_iter.Current.time_allocated) >=task_iter.Current.Duration)
                {
                    // 같다면, 작업이 모두 끝난 이후 day_iter.MoveNext();
                    bool MoveNext = false;   // 를 수행하기 위한 선행과정
                    if ((day_iter.Current.availableTime - day_iter.Current.time_allocated) == task_iter.Current.Duration)
                        MoveNext = true;

                    int duration = task_iter.Current.Duration;
                    Data.Model.Task task = task_iter.Current.task;
                    int fill_location = day_iter.Current.time_allocated;

                    // 0) TempBlock에 정보를 넣어 TempBlocks에 넣음.
                    TempBlock tempBlock = new TempBlock(task, duration);
                    day_iter.Current.tempBlocks.Add(tempBlock);

                    // 1) [time_allocated]에서부터 duration만큼 array를 채움.
                    for (int i=0; i < duration; i++)
                    {
                        day_iter.Current.task_arr[fill_location + i] = task;
                    }
                    // 2) time_allocated에 duration만큼 더함.
                    day_iter.Current.time_allocated += duration;

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
                    int duration = task_iter.Current.Duration;
                    Data.Model.Task task = task_iter.Current.task;
                    int fill_location = day_iter.Current.time_allocated;

                    // 0) TempBlock에 정보를 넣어 TempBlocks에 넣음.
                    TempBlock tempBlock = new TempBlock(task, day_iter.Current.availableTime - day_iter.Current.time_allocated);
                    day_iter.Current.tempBlocks.Add(tempBlock);

                    // 1) [time_allocated]에서부터 availableTime까지 array를 채움.
                    for (int i = fill_location; i < day_iter.Current.availableTime; i++)
                    {
                        day_iter.Current.task_arr[i] = task;
                    }
                    // 2) duration에서 (채운 시간) 만큼 빼야함.
                    //  (채운 시간) = availableTime - time_allocated
                    task_iter.Current.Duration -= (day_iter.Current.availableTime - day_iter.Current.time_allocated);

                    // 3) 해당 day의 availableTime을 모두 채웠으므로, day_iter.MoveNext();
                    end = !day_iter.MoveNext();
                }
            }

            if (repl_tasks.Count != 0)
            {
                throw new TimeOverflowException("가용 시간이 부족합니다");
            }
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

            // W.T.D : 덩어리가 큰 것들을 찾아 등분하여




            throw new NotImplementedException();
        }
    }
}

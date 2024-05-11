using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Data.Manager;
using TimeManager.Data.Model;

using System.Numerics;
using System.Windows.Forms;


namespace TimeManager.Scheduler
{
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
            public TempBlock(Data.Model.Task task) { this.task = task; }
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
            public long id;
            public DateTime? focusDate;
            public DateTime? endDate;
            public int Duration; // 몇시간만에 끝낼 작업인지
        }


        private List<ReplicaOfTask> duplicate_task(List<Data.Model.Task> tasks)
        {
            List<ReplicaOfTask> repl_tasks = new List<ReplicaOfTask>();

            // List<Task>에 있는 Task의 replica를 만들어 List<ReplicaOfTask>를 생성.
            foreach(Data.Model.Task task in tasks)
            {
                ReplicaOfTask task_dup = new ReplicaOfTask();
                task_dup.id = task.Id;
                task_dup.focusDate = task.EndDate?.AddDays(-(double)task.FocusDays);
                task_dup.endDate = task.EndDate;
                task_dup.Duration = task.Duration.Value.Minutes / 30;

                repl_tasks.Add(task_dup);
            }
            return repl_tasks;
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

            // W.T.D : 마감 있는 Task를 배치하기 
            foreach(Data.Model.Task task in tasks)
            {

            }












            throw new NotImplementedException();
        }
    }
}

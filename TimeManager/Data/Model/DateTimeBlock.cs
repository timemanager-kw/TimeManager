using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Data.Model
{
    public struct DateTimeBlock
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return EndDate - StartDate;
            }
        }

        public DateTimeBlock(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public static IEnumerable<DateTimeBlock> Difference(IEnumerable<DateTimeBlock> minuend, IEnumerable<DateTimeBlock> subtrahend)
        {
            List<DateTimeBlock> difference = new List<DateTimeBlock>();
            foreach(var minuendBlock in minuend)
            {
                bool overlap = false;
                foreach(var subtrahendBlock in subtrahend)
                {
                    if(!(minuendBlock.EndDate < subtrahendBlock.StartDate || minuendBlock.StartDate > subtrahendBlock.EndDate)){
                        overlap = true;
                        if ((minuendBlock.StartDate < subtrahendBlock.StartDate) && minuendBlock.EndDate < subtrahendBlock.EndDate) {
                            DateTimeBlock canTime = new DateTimeBlock();
                            canTime.StartDate = minuendBlock.StartDate;
                            canTime.EndDate = subtrahendBlock.StartDate;
                            difference.Add(canTime);
                        }
                        else if((minuendBlock.StartDate>subtrahendBlock.StartDate) && (minuendBlock.EndDate > subtrahendBlock.EndDate))
                        {
                            DateTimeBlock canTIme = new DateTimeBlock();
                            canTIme.StartDate = minuendBlock.EndDate;
                            canTIme.EndDate = subtrahendBlock.EndDate;
                            difference.Add(canTIme);
                        }
                        else if ((minuendBlock.StartDate <= subtrahendBlock.StartDate) && (subtrahendBlock.EndDate <= minuendBlock.EndDate))
                        {
                            DateTimeBlock canTime = new DateTimeBlock();
                            canTime.StartDate = minuendBlock.StartDate;
                            canTime.EndDate = subtrahendBlock.StartDate;
                            if (canTime.StartDate != canTime.EndDate)
                            {
                                difference.Add(canTime);
                            }
                            canTime.StartDate = subtrahendBlock.EndDate;
                            canTime.EndDate = minuendBlock.EndDate;
                            if (canTime.StartDate != canTime.EndDate)
                            {
                                difference.Add(canTime);
                            }
                        }
                    }
                }
                if (!overlap)
                {
                    difference.Add(minuendBlock);
                }
            }
            return difference;
        }
    }
}

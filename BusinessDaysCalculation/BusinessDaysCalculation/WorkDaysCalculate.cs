using System;

namespace BusinessDays.BusinessDaysCalculation
{
    /// <summary>
    /// The class for get work days, and assume work days is 5 days
    /// </summary>
    public class WorkDaysCalculate: IGetWorkDays
    {
        public int GetWorkDays(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            var totalDays = end.Subtract(start).Days; // days gap, exclude 'start date' and 'end date'

            //Get the days (divide this into two parts: how manys week days in full week + how many days in partial week)
            int businessdays = GetWorkDaysInFullWeek(totalDays) + GetWorkDaysInPartialWeek(start, totalDays);
            return businessdays;
        }

        /// <summary>
        /// Get work days for the full week in the period
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        private int GetWorkDaysInFullWeek(int totalDays)
        {
            return (totalDays / 7) * 5;
        }

        /// <summary>
        /// Find out how may week days for the partial week in the period
        /// </summary>
        /// <param name="start"></param>
        /// <param name="totalDays"></param>
        /// <returns></returns>
        private int GetWorkDaysInPartialWeek(DateTime start, int totalDays)
        {
            int daysInPartialWeek = totalDays % 7;
            var weekDays = 0;
            for (int i = 1; i < daysInPartialWeek; i++)
            {
                DateTime tmp = start.AddDays(i);
                if (tmp.DayOfWeek != DayOfWeek.Saturday && tmp.DayOfWeek != DayOfWeek.Sunday)
                {
                    weekDays++;
                }
            }
            return weekDays;
        }
    }
}

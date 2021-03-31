using System;
using CalculateHolidays.Shared;

namespace CalculateHolidays.WorkDaysCalculate
{
   //public  interface IGetBusinessDays
   //{
   //      int getBusinessDaysInBetween(DateTime start, DateTime end);
   // }

    /// <summary>
    /// Get Business Days
    /// </summary>
    public static class BusinessDaysCalculator
    {
        public static int getWorkDaysInBetween(DateTime start, DateTime end, HolidayType type)
        {
            if (start > end) return -1;
            var businessDays = getWorkDaysInBetween(start, end);
            IHoliday factory = null;
            if (type == HolidayType.Dynamic)
            {
                factory = new DynamicHolidayFactory();
            }
            else if (type == HolidayType.Fixed)
            {
                factory = new FixedHolidayFactory();
            }
            else if(type == HolidayType.Default)
            {
                factory = new HolidaysFactory();
            }
            else
            {
                //factory = null; do nothing
              //  getWorkDaysInBetween(start, end);
            }

            if (factory != null)
                return businessDays - factory.GetHolidayCount(start, end);
            else
                return businessDays;


        }
        
     

        #region Private Methods
        /// <summary>
        /// Get work days for the full week in the period
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        private static int GetWorkDaysInFullWeek(int totalDays)
        {
            return (totalDays / 7) * 5;
        }
        
        /// <summary>
        /// Find out how may week days for the partial week in the period
        /// </summary>
        /// <param name="start"></param>
        /// <param name="totalDays"></param>
        /// <returns></returns>
        private static int GetWorkDaysInPartialWeek(DateTime start, int totalDays)
        {
            int daysInPartialWeek = totalDays % 7;
            var weekDays = 0;
            for(int i=1; i<daysInPartialWeek; i++)
            {
                DateTime tmp = start.AddDays(i);
                if(tmp.DayOfWeek != DayOfWeek.Saturday && tmp.DayOfWeek != DayOfWeek.Sunday)
                {
                    weekDays++;
                }
            }
            return weekDays;
        }


        private static int getWorkDaysInBetween(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            var totalDays = end.Subtract(start).Days; // days gap, exclude 'start date' and 'end date'

            //Get the days (divide this into two parts: how manys week days in full week + how many days in partial week)
            int businessdays = GetWorkDaysInFullWeek(totalDays) + GetWorkDaysInPartialWeek(start, totalDays);
            return businessdays;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nager.Date;
using Nager.Date.Model;

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
        #region Public Method
        /// <summary>
        /// Get week days (exclude start date and end date)
        /// Exclude weekend
        /// Exclude Public Holidays in work days
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int getBusinessDaysInBetween(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            var workDays = getWorkDaysInBetween(start, end);
            var holidaysNotInWeekend = GetAllHolidaysNotInWeekend(start, end);
            return workDays - holidaysNotInWeekend;
           // return getWeekDaysInBetween(start, end) - GetAllHolidaysNotInWeekend(start, end);
        }
        /// <summary>
        /// Get week days (exclude start date, end date, weekend)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int getWorkDaysInBetween(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            var totalDays = end.Subtract(start).Days; // days gap, exclude 'start date' and 'end date'

            //Get the days (divide this into two parts: how manys week days in full week + how many days in partial week)
            int businessdays = GetWorkDaysInFullWeek(totalDays) + GetWorkDaysInPartialWeek(start,totalDays);
            return businessdays;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int getWorkDaysInBetweenFixedHoliday(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            var businessDays = getWorkDaysInBetween(start, end);
           
            HolidaysGenerator generator = new HolidaysGenerator();

            return businessDays - generator.GetFixedHolidaysCount(start, end);
        }

        public static int getWorkDaysInBetweenDynamicHoliday(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            var businessDays = getWorkDaysInBetween(start, end);

            HolidaysGenerator generator = new HolidaysGenerator();

            return businessDays - generator.GetDynamicHolidayCount(start, end);
        }
        #endregion

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

        private static int GetAllHolidaysNotInWeekend(DateTime start, DateTime end)
        {
            var allHolidays = DateSystem.GetPublicHoliday(start.AddDays(1), end.AddDays(-1), CountryCode.AU);
            var countOfHolidaysNotInWeekend = 0;
            foreach (PublicHoliday d in allHolidays)
            {
                if (!DateSystem.IsWeekend(d.Date, CountryCode.AU) )
                {
                    // Curently hard cord to only consider public holidays in all county and NSW public holiday
                    // the function could potentially extended
                    if (d.Counties == null || d.Counties.Contains("AUS-NSW"))
                    {
                        countOfHolidaysNotInWeekend++;
                    }
                }
            }

            return countOfHolidaysNotInWeekend;
        }
        #endregion

    }
}

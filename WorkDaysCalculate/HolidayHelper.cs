using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{
    public static class HolidayHelper
    {

        /// <summary>
        /// check the date is between the start and end
        /// </summary>
        /// <param name="date"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static bool isDateWorkDaysInBetween(DateTime date, DateTime start, DateTime end)
        {
            //If Date is in between, as current date is Date Only, no need to consider the time difference.
            if (date > start && date < end && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                return true;
            }
            else return false;
        }

    }
}

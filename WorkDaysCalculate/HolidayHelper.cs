using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{
    public static class HolidayHelper
    {

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

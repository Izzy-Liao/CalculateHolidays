using System;

namespace BusinessDays.Holidays
{
    public class HolidayHelper
    {

        /// <summary>
        /// check the date is between the start and end
        /// </summary>
        /// <param name="date"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool IsDateWorkDaysInBetween(DateTime date, DateTime start, DateTime end)
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

using System;

namespace BusinessDays.Holidays
{
    public interface IHoliday
    {
        public int GetHolidayCount(DateTime start, DateTime end);
    }
}

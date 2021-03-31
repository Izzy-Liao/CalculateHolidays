using System;


namespace CalculateHolidays.WorkDaysCalculate
{
    public interface IHoliday
    {
        public int GetHolidayCount(DateTime start, DateTime end);
    }
}

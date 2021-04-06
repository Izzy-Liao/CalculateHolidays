using System;


namespace CalculateHolidays.WorkDaysCalculate
{
    public interface IHoliday
    {
        public int GetHolidayCount(DateTime start, DateTime end);
    }

    public  interface IGetBusinessDays
    {
          public int getBusinessDaysInBetween(DateTime start, DateTime end);
     }

    public interface IGetWorkDays
    {
        public int getWorkDays(DateTime start, DateTime end);
    }
}

using System;

namespace BusinessDays.BusinessDaysCalculation
{
    public  interface IGetBusinessDays
    {
          public int GetBusinessDaysInBetween(DateTime start, DateTime end);
     }

    public interface IGetWorkDays
    {
        public int GetWorkDays(DateTime start, DateTime end);
    }
}

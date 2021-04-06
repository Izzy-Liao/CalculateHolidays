using System;
using CalculateHolidays.Shared;

namespace CalculateHolidays.WorkDaysCalculate
{
    /// <summary>
    /// Get Business Days
    /// </summary>
    public class BusinessDaysCalculate : IGetBusinessDays
    {

        private IHoliday factory;

        public BusinessDaysCalculate(IHoliday holidayFactory=null)
        {
            factory = holidayFactory;
        }

        public int getBusinessDaysInBetween(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            IGetWorkDays weekDays = new WorkDaysCalculate();
            int businessDays = weekDays.getWorkDays(start, end);
            int holidays = (factory == null) ? 0 : factory.GetHolidayCount(start, end);
            return businessDays-holidays;

        }
    }
}

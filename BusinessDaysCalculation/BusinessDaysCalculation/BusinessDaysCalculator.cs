using System;
using BusinessDays.Holidays;

namespace BusinessDays.BusinessDaysCalculation
{
    /// <summary>
    /// Get Business Days
    /// </summary>
    public class BusinessDaysCalculate : IGetBusinessDays
    {

        private readonly IHoliday _factory;

        public BusinessDaysCalculate(IHoliday holidayFactory=null)
        {
            _factory = holidayFactory;
        }

        public int GetBusinessDaysInBetween(DateTime start, DateTime end)
        {
            if (start > end) return -1;
            IGetWorkDays weekDays = new WorkDaysCalculate();
            int businessDays = weekDays.GetWorkDays(start, end);
            int holidays = (_factory == null) ? 0 : _factory.GetHolidayCount(start, end);
            return businessDays-holidays;

        }
    }
}

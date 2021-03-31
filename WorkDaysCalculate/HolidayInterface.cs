using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{
    public interface IHoliday
    {
        public int GetHolidayCount(DateTime start, DateTime end);
    }
}

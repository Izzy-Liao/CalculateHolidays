using System;
using System.Globalization;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{

    public abstract class HolidaysFactory
    {
        public abstract int GetHolidaysCount(DateTime start, DateTime end);
        protected abstract bool LoadHolidays(DateTime start, DateTime end);
    }

}

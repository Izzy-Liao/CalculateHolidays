using System;
using System.Globalization;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{

    public interface IHoliday
    {

        public int GetHolidayCount(DateTime start, DateTime end);
    }


    public class HolidaysFactory
    {
        protected List<DateTime> holidays = null;
        //    public  int GetHolidaysCount(DateTime start, DateTime end);
        protected bool LoadHolidays(DateTime start, DateTime end) { return true; }
    }

}

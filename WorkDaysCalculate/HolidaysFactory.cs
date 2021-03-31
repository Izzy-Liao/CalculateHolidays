using System;
using System.Globalization;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nager.Date;
using Nager.Date.Model;

namespace CalculateHolidays.WorkDaysCalculate
{

    public interface IHoliday
    {

        public int GetHolidayCount(DateTime start, DateTime end);
    }


    public class HolidaysFactory:IHoliday
    {
        protected List<DateTime> holidays = null;
        //    public  int GetHolidaysCount(DateTime start, DateTime end);
        protected bool LoadHolidays(DateTime start, DateTime end) { return true; }

        public int GetHolidayCount(DateTime start, DateTime end)
        {
            var allHolidays = DateSystem.GetPublicHoliday(start.AddDays(1), end.AddDays(-1), CountryCode.AU);
            var countOfHolidaysNotInWeekend = 0;
            foreach (PublicHoliday d in allHolidays)
            {
                if (!DateSystem.IsWeekend(d.Date, CountryCode.AU))
                {
                    // Curently hard cord to only consider public holidays in all county and NSW public holiday
                    // the function could potentially extended
                    if (d.Counties == null || d.Counties.Contains("AUS-NSW"))
                    {
                        countOfHolidaysNotInWeekend++;
                    }
                }
            }

            return countOfHolidaysNotInWeekend;
        }


    }

}

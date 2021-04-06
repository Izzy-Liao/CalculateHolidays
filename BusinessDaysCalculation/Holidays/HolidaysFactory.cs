using System;
using System.Collections.Generic;
using System.Linq;
using Nager.Date;
using Nager.Date.Model;

namespace BusinessDays.Holidays
{
    public class HolidaysFactory:IHoliday
    {
        protected List<DateTime> Holidays = null;
 
        protected virtual bool LoadHolidays(DateTime start, DateTime end) { return true; }

        //use the library to get Holiday Count -- default behaviour
       public virtual int GetHolidayCount(DateTime start, DateTime end)
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

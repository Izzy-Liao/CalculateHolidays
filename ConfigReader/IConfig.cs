using System.Collections.Generic;
using BusinessDays.Holidays;

namespace CalculateHolidays.ConfigReader
{
    public interface IConfig
    {
        public string[] GetFixedHoliday();
        public List<HolidayRule> GetHolidayRules();
        public List<HolidayCertainOccurance> GetHolidayCertainOccurance();
    }
}

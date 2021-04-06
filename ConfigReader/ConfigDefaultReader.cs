using BusinessDays.Holidays;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace CalculateHolidays.ConfigReader
{
    /// <summary>
    /// Read Configuration from appsettings.json
    /// </summary>
    public class ConfigDefaultReader : IConfig
    {
        private readonly IConfiguration _config;

        public ConfigDefaultReader(IConfiguration config)
        {
            _config = config;
        }
         public string[] GetFixedHoliday()
        {
            var fixedHolidayConfig = _config.GetValue<string>("FixedHolidays");
            return fixedHolidayConfig.Split(',');
        }

        public List<HolidayCertainOccurance> GetHolidayCertainOccurance()
        {
            //What's the rule for Easter...., need to revisit
            //Made up rule for Father's day.... 
            //Need to re-write read from configuration file if really want to put in use...
            List<HolidayCertainOccurance> certainOccuranceRules = new List<HolidayCertainOccurance>
            {
                new HolidayCertainOccurance { Month = 4, No = 2, DayOfWeek = DayOfWeek.Sunday, Name = "Easter Sunday" },
                new HolidayCertainOccurance { Month = 4, No = 3, DayOfWeek = DayOfWeek.Monday, Name = "Easter Monday" },
                new HolidayCertainOccurance { Month = 9, No = 1, DayOfWeek = DayOfWeek.Sunday, Name = "Father's Day" }
            };

            return certainOccuranceRules;

        }

        public List<HolidayRule> GetHolidayRules()
        {
            List<HolidayRule> holidayRules = new List<HolidayRule>
            {
                new HolidayRule { Day = 1, Month = 1, Movable = true, Name = "New Year" },
                new HolidayRule { Day = 26, Month = 1, Movable = false, Name = "Australia Day" },
                new HolidayRule { Day = 25, Month = 12, Movable = false, Name = "Christmas Day" }
            };

            return holidayRules;

        }
    }
}

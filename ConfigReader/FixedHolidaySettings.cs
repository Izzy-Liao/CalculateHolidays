using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.ConfigReader
{
    public class FixedHolidaySettings
    {
        public const string sectionName = "FixedHolidaySection";

        public string FixedHoliday { get; set; }
    }
}

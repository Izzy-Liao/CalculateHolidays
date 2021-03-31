using System;
using System.Collections.Generic;
using System.Globalization;

using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{
    public class FixedHolidayFactory:HolidaysFactory
    {
 
        /// <summary>
        /// Get Fixed Holidays
        /// </summary>
        /// <returns></returns>
        new protected  bool LoadHolidays(DateTime start, DateTime end)
        {
            //to do
            //Redo this function to load from the configuration file -- extend
            // Currently pre-defined, ideallly need to put into the configuraiton file
            String[] holidayStrings = new String[] {"26/01/2021","02/04/2021","01/06/2021","25/12/2021",
                "26/01/2022","02/04/2022","01/06/2022","25/12/2022",
                "26/01/2023","02/04/2023","01/06/2023","25/12/2023",
                "26/01/2024","02/04/2024","01/06/2024","25/12/2024",
                "26/01/2025","02/04/2025","01/06/2025","25/12/2025",
                "26/01/2026","02/04/2026","01/06/2026","25/12/2026",
                "26/01/2027","02/04/2027","01/06/2027","25/12/2027",
                "26/01/2028","02/04/2028","01/06/2028","25/12/2028",
                "26/01/2029","02/04/2029","01/06/2029","25/12/2029"};

            holidays = new List<DateTime>();

            foreach (String s in holidayStrings)
            {
                DateTime date = DateTime.MinValue;
                if (DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date)) // Convert the string to DateTime, using default locale, 
                    holidays.Add(date);
            }

            return true;
        }

        public override int GetHolidayCount(DateTime start, DateTime end)
        {
            if (holidays == null) LoadHolidays(start, end);

            int count = 0;
            foreach (DateTime date in holidays)
            {
                if (HolidayHelper.isDateWorkDaysInBetween(date, start, end))
                {
                    count++;
                }
            }
            return count;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;

namespace BusinessDays.Holidays
{
    public class FixedHolidayFactory:HolidaysFactory
    {
        private readonly string[] _holidayLists = null;

        public FixedHolidayFactory(string[] holidayList)
        {
            _holidayLists = holidayList;

            Holidays = new List<DateTime>();

            foreach (String s in _holidayLists)
            {
                DateTime date = DateTime.MinValue;
                if (DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out date)) // Convert the string to DateTime, using default locale, 
                    Holidays.Add(date);
            }
        }
        public override int GetHolidayCount(DateTime start, DateTime end)
        {
            if (Holidays == null) LoadHolidays(start, end);
            if (Holidays == null) return 0;
            HolidayHelper helper = new HolidayHelper();

            int count = 0;
            foreach (DateTime date in Holidays)
            {
                if (helper.IsDateWorkDaysInBetween(date, start, end))
                {
                    count++;
                }
            }
            return count;
        }
        
    }
}

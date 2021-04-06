using System;
using System.Collections.Generic;

namespace BusinessDays.Holidays
{
    public class DynamicHolidayFactory:HolidaysFactory
    {
        private readonly List<HolidayRule> _holidayRules;
        private readonly List<HolidayCertainOccurance> _holidayCertainOccurances;
        
        public DynamicHolidayFactory(List<HolidayRule> holidayRules, List<HolidayCertainOccurance> holidayCertainOccurances)
        {
            _holidayRules = holidayRules;
            _holidayCertainOccurances = holidayCertainOccurances;
        }
        public override int GetHolidayCount(DateTime start, DateTime end)
        {
            if (!LoadHolidays(start, end)) return 0;
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

        protected override bool LoadHolidays(DateTime start, DateTime end)
        {

            if (start > end) return false;
            int yearStart = start.Year;
            int yearEnd = end.Year;

            if (yearStart < 2021 || yearStart > 2029 || yearEnd < 2021 || yearEnd > 2029) return false;
            try
            {
                //Always reload the list... need revisit
                Holidays = new List<DateTime>();
               
                LoadFixedDateOrMovableHolidays(yearStart, yearEnd);

                LoadCertainOccuranceHolidays(yearStart, yearEnd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadFixedDateOrMovableHolidays(int yearStart, int yearEnd)
        {
            
            for (int i = yearStart; i <= yearEnd; i++)
            {
                foreach (HolidayRule rule in _holidayRules)
                {
                    DateTime date = new DateTime(i, rule.Month, rule.Day);
                    if (rule.Movable)
                    {
                        if (date.DayOfWeek == DayOfWeek.Saturday) date = date.AddDays(2);
                        else if (date.DayOfWeek == DayOfWeek.Sunday) date = date.AddDays(1);
                        Holidays.Add(date);
                    }
                    else
                    {
                        Holidays.Add(date);
                    }

                }
            }
            return true;
        }

        private bool LoadCertainOccuranceHolidays(int yearStart, int yearEnd)
        {

            for (int i = yearStart; i <= yearEnd; i++)
            {
                foreach (HolidayCertainOccurance rule in _holidayCertainOccurances) 
                {
                    DateTime firstDateOftheMonth = new DateTime(i, rule.Month, 1);

                    int gap = (int)rule.DayOfWeek - (int)firstDateOftheMonth.DayOfWeek;
                    gap = gap < 0 ? gap + 7 : gap;

                    DateTime holidayDate = firstDateOftheMonth.AddDays(gap + (rule.No - 1) * 7);
                    Holidays.Add(holidayDate);
                }
            }
            return true;
        }

    }
}

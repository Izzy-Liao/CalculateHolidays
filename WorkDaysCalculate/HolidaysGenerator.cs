using System;
using System.Globalization;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{
    /// <summary>
    /// Holidays Load/Get 
    /// </summary>
    public class HolidaysGenerator
    {
        /// <summary>
        /// Get Holidays
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetHolidaysCount(DateTime start, DateTime end, string type)
        {
            if(type=="fixed")
            {
                return GetFixedHolidaysCount(start, end);
            }
            else if(type=="dynamic")
            {
                return GetDynamicHolidayCount(start, end);
            }
            else
            {
                return 0;  //by default, not handled, return 0
            }
        }

        #region Fixed Holiday List
        /// <summary>
        /// Pre-loaded Holidays
        /// Currently is hard coded in the code
        /// Can be configured in the configuration file later
        /// </summary>
        private List<DateTime> fixedHolidays = null;
        /// <summary>
        /// Get Fixed Holidays
        /// </summary>
        /// <returns></returns>
        private bool LoadFixedHolidays()
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

            fixedHolidays = new List<DateTime>();

            foreach(String s in holidayStrings)
            {
                DateTime date = DateTime.MinValue;
                if(DateTime.TryParseExact(s,"dd/MM/yyyy",CultureInfo.CurrentCulture, DateTimeStyles.None, out  date)) // Convert the string to DateTime, using default locale, 
                    fixedHolidays.Add(date);
            }

            return true;
        }

        /// <summary>
        /// Get the number of holiday between start date and end date (exclude the date in the weekend)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int GetFixedHolidaysCount(DateTime start, DateTime end)
        {
            if (fixedHolidays == null) LoadFixedHolidays();

            int count = 0;
            foreach(DateTime date in fixedHolidays)
            {
                if (isDateWorkDaysInBetween(date, start, end))
                {
                    count++;
                }
            }
            return count;
        }

        #endregion

        #region Dynamc Holiday List
        private List<DateTime> fixedDateHolidays = null;
        private List<DateTime> movableHolidays = null;
        private List<DateTime> certainOccuranceHolidays = null;

        /// <summary>
        /// Load Dynamic Holiday
        /// </summary>
        /// <param name="yearStart"></param>
        /// <param name="yearEnd"></param>
        /// <returns></returns>
        private bool LoadDynamicHolidays(int yearStart, int yearEnd)
        {
            if (yearStart < 2021 || yearStart > 2029 || yearEnd < 2021 || yearEnd > 2029) return false;
            try
            {
                //Always reload the list... need revisit
                fixedDateHolidays = new List<DateTime>();
                movableHolidays = new List<DateTime>();
                certainOccuranceHolidays = new List<DateTime>();
                LoadFixedDateOrMovableHolidays(yearStart, yearEnd);

               LoadCertainOccuranceHolidays(yearStart, yearEnd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get Dynamics Holidays based on the rule sets - excluded holiday on weekend
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int GetDynamicHolidayCount(DateTime start, DateTime end)
        {
            if (start > end) return 0;
            LoadDynamicHolidays(start.Year, end.Year); // restrict the holiday list to potential period

            int count = 0;
            foreach(DateTime date in fixedDateHolidays)
            {
                if (isDateWorkDaysInBetween(date,start,end))
                {
                    count++;
                }
            }
            foreach(DateTime date in movableHolidays)
            {
                if (isDateWorkDaysInBetween(date, start, end)) count++;
            }
            foreach(DateTime date in certainOccuranceHolidays)
            {
                if (isDateWorkDaysInBetween(date, start, end)) count++;
            }
            return count;
        }

        private bool isDateWorkDaysInBetween(DateTime date,DateTime start, DateTime end)
        {
            //If Date is in between, as current date is Date Only, no need to consider the time difference.
            if (date > start && date < end && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                return true;
            }
            else return false;
        }

        private bool LoadFixedDateOrMovableHolidays(int yearStart, int yearEnd)
        {
            //Bad at Holidays.... what's the rule....
            List<HolidayRule> holidayRules = new List<HolidayRule>();
            holidayRules.Add(new HolidayRule { day = 1, month = 1, movable = true, name = "New Year" });
            holidayRules.Add(new HolidayRule { day = 26, month = 1, movable = false, name = "Australia Day" });
            holidayRules.Add(new HolidayRule { day = 25, month = 12, movable = false, name = "Christmas Day" });

            for (int i= yearStart;  i<=yearEnd; i++)
            {
                foreach(HolidayRule rule in holidayRules)
                {
                    DateTime date = new DateTime(i, rule.month, rule.day);
                    if(rule.movable)
                    {
                        if (date.DayOfWeek == DayOfWeek.Saturday) date = date.AddDays(2);
                        else if (date.DayOfWeek == DayOfWeek.Sunday) date = date.AddDays(1);
                        movableHolidays.Add(date);
                    }
                    else
                    {
                        fixedDateHolidays.Add(date);
                    }

                }
            }
            return true;
        }


        private bool LoadCertainOccuranceHolidays(int yearStart, int yearEnd)
        {

            //What's the rule for Easter...., need to revisit
            //Made up rule for Father's day.... 
            //Need to re-write read from configuration file if really want to put in use...
            List<HolidayCertainOccurance> CertainOccuranceRules = new List<HolidayCertainOccurance>();
            CertainOccuranceRules.Add(new HolidayCertainOccurance{ month=4,no=2,dayOfWeek=DayOfWeek.Sunday,name="Easter Sunday"}); 
            CertainOccuranceRules.Add(new HolidayCertainOccurance { month=4, no=3,dayOfWeek=DayOfWeek.Monday,name="Easter Monday"});
            CertainOccuranceRules.Add(new HolidayCertainOccurance { month = 9, no = 1, dayOfWeek = DayOfWeek.Sunday, name = "Father's Day" });

            for (int i = yearStart; i <= yearEnd; i++)
            {
                foreach (HolidayCertainOccurance rule in CertainOccuranceRules)
                {
                    DateTime firstDateOftheMonth = new DateTime(i, rule.month, 1);

                    int gap = (int)rule.dayOfWeek - (int)firstDateOftheMonth.DayOfWeek;
                    gap = gap < 0 ? gap + 7 : gap;

                    DateTime holidayDate = firstDateOftheMonth.AddDays(gap + (rule.no - 1) * 7);
                    certainOccuranceHolidays.Add(holidayDate);
                }
            }
            return true;
        }
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{
    public class DynamicHolidayFactory:HolidaysFactory
    {
        private List<DateTime> fixedDateHolidays = null;
        private List<DateTime> movableHolidays = null;
        private List<DateTime> certainOccuranceHolidays = null;


        public override bool LoadHolidays(DateTime start, DateTime end)
        {

            if (start > end) return false;
            int yearStart = start.Year;
            int yearEnd = end.Year;

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
        public override int GetHolidaysCount(DateTime start, DateTime end)
        {
            LoadHolidays(start, end);
            int count = 0;
            foreach (DateTime date in fixedDateHolidays)
            {
                if (HolidayHelper.isDateWorkDaysInBetween(date, start, end))
                {
                    count++;
                }
            }
            foreach (DateTime date in movableHolidays)
            {
                if (HolidayHelper.isDateWorkDaysInBetween(date, start, end)) count++;
            }
            foreach (DateTime date in certainOccuranceHolidays)
            {
                if (HolidayHelper.isDateWorkDaysInBetween(date, start, end)) count++;
            }
            return count;
        }


        private bool LoadFixedDateOrMovableHolidays(int yearStart, int yearEnd)
        {
            //Bad at Holidays.... what's the rule....
            List<HolidayRule> holidayRules = new List<HolidayRule>();
            holidayRules.Add(new HolidayRule { day = 1, month = 1, movable = true, name = "New Year" });
            holidayRules.Add(new HolidayRule { day = 26, month = 1, movable = false, name = "Australia Day" });
            holidayRules.Add(new HolidayRule { day = 25, month = 12, movable = false, name = "Christmas Day" });

            for (int i = yearStart; i <= yearEnd; i++)
            {
                foreach (HolidayRule rule in holidayRules)
                {
                    DateTime date = new DateTime(i, rule.month, rule.day);
                    if (rule.movable)
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
            CertainOccuranceRules.Add(new HolidayCertainOccurance { month = 4, no = 2, dayOfWeek = DayOfWeek.Sunday, name = "Easter Sunday" });
            CertainOccuranceRules.Add(new HolidayCertainOccurance { month = 4, no = 3, dayOfWeek = DayOfWeek.Monday, name = "Easter Monday" });
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

    }
}
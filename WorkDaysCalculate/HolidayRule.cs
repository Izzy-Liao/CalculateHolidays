using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.WorkDaysCalculate
{
   
    /// <summary>
    /// Holiday with date (either move or not move to Monday)
    /// </summary>
    public class HolidayRule
    {
        public int month { get; set; }
        public int day { get; set; }
        public string name { get; set; }
        public bool movable { get; set; } 

    
    }

    public class HolidayCertainOccurance
    { 
        public int month { get; set; }  //which month

        public DayOfWeek dayOfWeek { get; set; } // Which Day of the Week (Mon, Tue, Wed, Thur, Fri, Sat, Sun)
        public int no { get; set; }  //the nth dayOfWeek in the selected month, I even couldn't understand myself - 1, 2, 3, 4, 5

        public string name { get; set; } //holiday name
        

    }

    #region Not In Use
    ///// <summary>
    ///// Holiday 
    ///// </summary>
    //public class Holiday
    //{

    //    /// <summary>
    //    /// Public Holiday Name
    //    /// </summary>
    //    public string name { get; set; }

    //    /// <summary>
    //    /// date
    //    /// It can be null, if haven't defined yet
    //    /// </summary>
    //    public DateTime date { get; set; }

    //    /// <summary>
    //    ///  which year
    //    /// </summary>
    //    public int year { get; set; }

    //    /// <summary>
    //    /// Country Code, currently not in use, default as Australia
    //    /// </summary>
    //    public string Country { get; set; } = "AU";

    //    /// <summary>
    //    /// Currently not in use
    //    /// </summary>
    //    public string County { get; set; } = "NSW";

    //    /// <summary>
    //    /// Generate a holiday based on the year, month, day
    //    /// </summary>
    //    /// <param name="year"></param>
    //    /// <param name="month"></param>
    //    /// <param name="day"></param>
    //    public Holiday(int year, int month, int day, string name="generic holiday", bool movable=false)
    //    {
    //        date = generateDate(year, month, day,movable);
    //        this.name = name;
    //    }

    //    #region Private Method
    //    /// <summary>
    //    /// Generate a date
    //    /// </summary>
    //    /// <param name="year"></param>
    //    /// <param name="month"></param>
    //    /// <param name="day"></param>
    //    /// <returns></returns>
    //    private DateTime generateDate(int year, int month, int day, bool movable)
    //    {
    //        DateTime date = DateTime.MinValue;
    //        try
    //        {
    //            date = new DateTime(year, month, day);
    //            //If move this holiday to Monday when in weekend
    //            if (movable)
    //            {
    //                if (date.DayOfWeek == DayOfWeek.Saturday) date = date.AddDays(2);
    //                else if (date.DayOfWeek == DayOfWeek.Sunday) date = date.AddDays(1);
    //            }
    //        }
    //        catch (ArgumentOutOfRangeException ex)
    //        {
    //            // set the date as DateTime.MinValue, it will not take into account in the calculation.
    //            //will need to be redone
    //            date = DateTime.MinValue;
    //        }
    //        return date;
    //    }

    //    /// <summary>
    //    /// Check date if in the weekend
    //    /// </summary>
    //    /// <param name="date"></param>
    //    /// <returns></returns>
    //    private bool isWeekend(DateTime date)
    //    {
    //        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
    //        {
    //            return true;
    //        }
    //        else return false;
    //    }
    //    #endregion
    //}

    ///// <summary>
    ///// Current only consider 3 different type of holiday
    ///// Fixed - always on same date every year
    ///// Movable - move to next Monday if in the weekend
    ///// </summary>
    //public enum HolidayType { 
    //    Fixed,
    //    Movable,

    //}
    #endregion
}

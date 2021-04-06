using System;

namespace BusinessDays.Holidays
{
   
    /// <summary>
    /// Holiday with date (either move or not move to Monday)
    /// </summary>
    public class HolidayRule
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public string Name { get; set; }
        public bool Movable { get; set; } 

    
    }

    public class HolidayCertainOccurance
    { 
        public int Month { get; set; }  //which month

        public DayOfWeek DayOfWeek { get; set; } // Which Day of the Week (Mon, Tue, Wed, Thur, Fri, Sat, Sun)
        public int No { get; set; }  //the nth dayOfWeek in the selected month, I even couldn't understand myself - 1, 2, 3, 4, 5

        public string Name { get; set; } //holiday name
        

    }

}

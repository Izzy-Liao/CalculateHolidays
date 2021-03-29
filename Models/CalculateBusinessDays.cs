using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculateHolidays.Models
{
    /// <summary>
    /// Main class and logic to calculate business days
    /// Calculate the business days in between of startDate and endDate
    /// Start date and end date are not included
    /// </summary>
    public class CalculateBusinessDays
    {
        /// <summary>
        /// Calculation Result
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// The period start date
        /// </summary>
        public DateTime startDate { get; set; }

        /// <summary>
        /// The period end date
        /// </summary>
        public DateTime endDate { get; set; }

        public CalculateBusinessDays(DateTime start, DateTime end, int result)
        {
            Result = result;
            startDate = start;
            endDate = end;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using CalculateHolidays.WorkDaysCalculate;
using CalculateHolidays.Shared;

namespace CalculateHolidays.Controllers
{
    /// <summary>
    /// Calculate Business Days
    /// </summary>
    public class CalculateBusinessDays : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Calculation Logic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Calculate(string action)
        {
            try
            {
                DateTime start = Convert.ToDateTime(Request.Form["startDate"]);
                DateTime end = Convert.ToDateTime(Request.Form["endDate"]);

                int weekdays = -1;
                if (action.Equals("Default", StringComparison.OrdinalIgnoreCase))
                {
                    weekdays = BusinessDaysCalculator.getWorkDaysInBetween(start, end,HolidayType.Default);
                    var message = String.Format("There are {0} business days between {1} and {2}! (Excluded weekends and NSW public holidays)", weekdays, start.ToShortDateString(), end.ToShortDateString());
                    //   TempData["ResultMessage"] = "there are " + weekdays + " days  between " + start.ToShortDateString() + " and " + end.ToShortDateString() ;
                    SetTempDataMessage(weekdays, message);
                }
                else if (action.Equals("GetWorkDays", StringComparison.OrdinalIgnoreCase))
                {
                    weekdays = BusinessDaysCalculator.getWorkDaysInBetween(start, end,HolidayType.None);
                    var message = String.Format("There are {0} days between {1} and {2}! (Excludes weekends)", weekdays, start.ToShortDateString(), end.ToShortDateString());
                    SetTempDataMessage(weekdays, message);
                }
                else if (action.Equals("GetWorkDaysFixedHoliday", StringComparison.OrdinalIgnoreCase))
                {
                    weekdays = BusinessDaysCalculator.getWorkDaysInBetween(start, end, HolidayType.Fixed );
                    var message = String.Format("There are {0} days between {1} and {2}! (Excludes weekends and Fixed Holiday {3})", weekdays, start.ToShortDateString(), end.ToShortDateString(), "1st Jan, 26th Jan, 1st Jun, 25th Dec");
                    SetTempDataMessage(weekdays, message);
                }
                else if (action.Equals("GetWorkDaysDynamicHoliday", StringComparison.OrdinalIgnoreCase))
                {
                    weekdays = BusinessDaysCalculator.getWorkDaysInBetween(start, end,HolidayType.Dynamic);
                    var message = String.Format("There are {0} days between {1} and {2}! (Excludes weekends and Dynamic Holiday {3})", weekdays, start.ToShortDateString(), end.ToShortDateString(), "1st Jan(New Year - Move to Monday), 26th Jan(Australia Day), 25th Dec(Christmas), Easter Sunday (Apr second Sunday), Easter Monday(Apr third Monday), Father's Day(Sep first Sunday)");
                    SetTempDataMessage(weekdays, message);
                }

                SetSuccess("Get results");

            } 
            catch(Exception ex)
            {
                SetError(ex.Message);
            }

            return RedirectToAction("Index");
        }

        private void SetTempDataMessage(int result, string message)
        {
            if (result > 0)
            {
                TempData["ResultMessage"] = message;
            }
            else
            {
                TempData["ResultMessage"] = "Error!";
            }
        }
    }
}

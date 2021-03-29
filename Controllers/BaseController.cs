using Microsoft.AspNetCore.Mvc;

namespace CalculateHolidays.Controllers
{
    public class BaseController : Controller
    {
       public void SetError(string message)
        {
            TempData["Error"] = message;
        }
        public void SetSuccess(string message)
        {
            TempData["Success"] = message;
        }

    }
}

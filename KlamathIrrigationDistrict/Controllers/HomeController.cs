using System.Web.Mvc;

namespace KlamathIrrigationDistrict.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Office Specialist"))
            {
                return RedirectToAction("Index", "OfficeStaff");
            }
            else if (User.IsInRole("Ride 1"))
            {
                return RedirectToAction("_ActiveRequestsOn4/1", "DitchRiders");
            }
            else if (User.IsInRole("Ride 2"))
            {
                return RedirectToAction("_ActiveRequestsOn4/2", "DitchRiders");
            }
            else if (User.IsInRole("Ride 3"))
            {
                return RedirectToAction("_ActiveRequestsOn4/3", "DitchRiders");
            }
            else if (User.IsInRole("Ride 4"))
            {
                return RedirectToAction("_ActiveRequestsOn4/4", "DitchRiders");
            }
            else if (User.IsInRole("Ride 5"))
            {
                return RedirectToAction("_ActiveRequestsOn4/5", "DitchRiders");
            }
            else if (User.IsInRole("Ride 6"))
            {
                return RedirectToAction("_ActiveRequestsOn4/6", "DitchRiders");
            }
            else if (User.IsInRole("Ride 7"))
            {
                return RedirectToAction("_ActiveRequestsOn4/7", "DitchRiders");
            }
            else if (User.IsInRole("Ride 8"))
            {
                return RedirectToAction("_ActiveRequestsOn4/8", "DitchRiders");
            }
            else if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                ViewBag.Message = "Did not work";
                return View();
            }
            //return RedirectToLocal(returnUrl);
            return RedirectToAction("Login", "Account");
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
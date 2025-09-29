using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}

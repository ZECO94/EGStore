using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Customer.Controllers
{
    public class checkoutController : Controller
    {
        public IActionResult success()
        {
            return View();
        }
        public IActionResult cancel()
        {
            return View();
        }
    }
}

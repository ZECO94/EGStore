using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CheckoutController : Controller
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

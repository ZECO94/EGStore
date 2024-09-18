using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Admin.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

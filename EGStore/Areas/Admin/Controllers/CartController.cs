using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}

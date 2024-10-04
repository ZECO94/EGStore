using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Display()
        {
            var products = _productRepository.Get(null, x => x.Brand, x => x.Category);
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetOne(x => x.Id == id,x => x.Brand, x => x.Category);
            return View(product);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blogs()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }

    }
}

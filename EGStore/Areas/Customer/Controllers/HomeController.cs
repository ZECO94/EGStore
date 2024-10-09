using EGStore.DataAccess.Repository;
using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<IdentityUser> _userManager;




        public HomeController(ILogger<HomeController> logger,
            IProductRepository productRepository,
            IReviewRepository reviewRepository, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
            _userManager = userManager;
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
            var product = _productRepository.GetOne(x => x.Id == id,x => x.Brand, x => x.Category,x=>x.Reviews);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReview(Review model)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {
                var review = new Review
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Rating = model.Rating,
                    Comment = model.Comment,
                    PostedOn = DateTime.Now,
                    ApplicationUserId = userId
                };

                _reviewRepository.Add(review);
                return RedirectToAction("Details", new { id = model.ProductId });
            }
            var product = _productRepository.GetOne(x => x.Id == model.ProductId, x => x.Brand, x => x.Category, x => x.Reviews);
            return View("Details", product);

        }
        public IActionResult Search(string query)
        {
            var product = _productRepository.Get(x=>x.ProductName == query,x=>x.Category,x=>x.Brand);
            return View("Display", product);
        }


    }
}

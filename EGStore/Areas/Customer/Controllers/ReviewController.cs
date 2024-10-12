using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ReviewController(IReviewRepository reviewRepository, IProductRepository productRepository,
            UserManager<IdentityUser> userManager, IApplicationUserRepository applicationUserRepository)
        {
            _reviewRepository = reviewRepository;
            _productRepository = productRepository;
            _userManager = userManager;
            _applicationUserRepository = applicationUserRepository;
        }
        public IActionResult WriteReview(int productId)
        {
            var product = _productRepository.GetOne(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(User);
            var appUser1 = _applicationUserRepository.GetOne(x => x.Id == userId);
            ViewData["user"] = appUser1;
            var review = new Review
            {
                ProductId = productId,
                Product = product,
                PostedOn = DateTime.Now
            };

            return View(review);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WriteReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                var product = _productRepository.GetOne(p => p.Id == review.ProductId);
                review.Product = product;
                return View(review);
            }
            var user = await _userManager.GetUserAsync(User);
            
            if (user != null)
            {
                review.ApplicationUserId = user.Id;
                review.PostedOn = DateTime.Now;
                _reviewRepository.Add(review);
            }
            return RedirectToAction("Index", "Home");
        }




    }


}


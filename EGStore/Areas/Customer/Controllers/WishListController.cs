using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class WishListController : Controller
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public WishListController(IWishListRepository wishListRepository, IProductRepository productRepository, UserManager<IdentityUser> userManager)
        {
            _wishListRepository = wishListRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            if(userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var wishList = _wishListRepository.Get(x=>x.ApplicationUserId== userId,x=>x.Product);
            return View(wishList);
        }
        [HttpPost]
        public IActionResult AddToWishList(int productId)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var product = _productRepository.GetOne(p => p.Id == productId,x=>x.Category,x=>x.Brand);
            if (product == null)
            {
                return NotFound();
            }

            var wishListItem = new WishList
            {
                ProductId = productId,
                ApplicationUserId = userId,
                CreatedDate = DateTime.Now
            };

            _wishListRepository.Add(wishListItem);

            return RedirectToAction("Display", "Home"); 
        }
        [HttpPost]
        public IActionResult RemoveFromWishList(int productId)
        {
            var userId = _userManager.GetUserId(User);

            var wishListItem = _wishListRepository.GetOne(w => w.ApplicationUserId == userId && w.ProductId == productId);
            if (wishListItem != null)
            {
                _wishListRepository.Remove(wishListItem);
            }

            return RedirectToAction("Index");
        }


    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EGStore.Models;
using System.Linq;
using System.Threading.Tasks;
using EGStore.DataAccess.Repository.IRepository;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository, UserManager<IdentityUser> userManager)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (id != 0)
            {
                if (userId == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                Cart newCart = new Cart()
                {
                    ProductId = id,
                    Count = 1,
                    ApplicationUserId = userId,
                };
                _cartRepository.Add(newCart);
                return RedirectToAction("Display", "Home");
            }
            var result = _cartRepository.Get(x => x.ApplicationUserId == userId,x=>x.Product);
            return View(result); 
        }
        public IActionResult Increment(int id)
        {
            var cartItem = _cartRepository.Get(c => c.Id == id).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
                _cartRepository.Update(cartItem);
            }
            return RedirectToAction(nameof(Index));
        }

        // Decrease Product Quantity in Cart
        public IActionResult DecreaseQuantity(int id)
        {
            var cartItem = _cartRepository.Get(c => c.Id == id).FirstOrDefault();
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    _cartRepository.Update(cartItem);
                }
                else
                {
                    _cartRepository.Remove(cartItem);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // Remove Product from Cart
        public IActionResult Remove(int id)
        {
            var cartItem = _cartRepository.Get(c => c.Id == id).FirstOrDefault();
            if (cartItem != null)
            {
                _cartRepository.Remove(cartItem);
            }
            return RedirectToAction(nameof(Index));
        }










    }
}


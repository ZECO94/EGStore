using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EGStore.Models;
using System.Linq;
using System.Threading.Tasks;
using EGStore.DataAccess.Repository.IRepository;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository, UserManager<ApplicationUser> userManager)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }

        // Index action to display cart items
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var userId = user.Id;
            var cartItems = _cartRepository.Get(c => c.ApplicationUserId == userId, c => c.Product);
            ViewBag.Total = cartItems.Sum(x => x.Count * x.Product.Price);

            return View(cartItems);
        }

        // Add a product to the cart
        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var userId = user.Id;
            var product = _productRepository.GetOne(p => p.Id == productId);

            if (product != null)
            {
                Cart cart = new()
                {
                    ProductId = product.Id,
                    ApplicationUserId = userId,
                    Count = 1
                };

                _cartRepository.Add(cart);
            }

            return RedirectToAction(nameof(Index));
        }

        // Remove an item from the cart
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = _cartRepository.GetOne(c => c.Id == id);
            if (cartItem != null)
            {
                _cartRepository.Remove(cartItem);
            }
            return RedirectToAction(nameof(Index));
        }

        // Update item quantity in the cart
        public async Task<IActionResult> UpdateQuantity(int id, int quantity)
        {
            var cartItem = _cartRepository.GetOne(c => c.Id == id);
            if (cartItem != null && quantity > 0)
            {
                cartItem.Count = quantity;
                _cartRepository.Update(cartItem);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EGStore.Models;
using System.Linq;
using System.Threading.Tasks;
using EGStore.DataAccess.Repository.IRepository;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
//using EGStore.Models.ViewModels;
using EGStore.DataAccess.Repository;
using EGStore.Utility;
using Stripe.Checkout;
//using EGStore.Models.ViewModel;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;



        public CartController(ICartRepository cartRepository, IProductRepository productRepository,
            UserManager<IdentityUser> userManager, IOrderRepository orderRepository, IOrderDetailsRepository orderDetailsRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userManager = userManager;
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }
        public IActionResult Index(int id)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (id != 0)
            {

                Cart newCart = new Cart()
                {
                    ProductId = id,
                    Count = 1,
                    ApplicationUserId = userId,
                };
                _cartRepository.Add(newCart);
                return RedirectToAction("Display", "Home");
            }
            var result = _cartRepository.Get(x => x.ApplicationUserId == userId, x => x.Product);
            TempData["Cart"] = JsonConvert.SerializeObject(result);
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

        //Payment Simulation Using Stripe
        public IActionResult Payment()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = $"{Request.Scheme}://{Request.Host}/checkout/success",


                CancelUrl = $"{Request.Scheme}://{Request.Host}/checkout/cancel",
            };
            string cart = (string)TempData["Cart"];
            var items = JsonConvert.DeserializeObject<IEnumerable<Cart>>(cart);
            foreach (var model in items)
            {
                var result = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = model.Product.ProductName,
                            Description = model.Product.ProductDescription,
                        },
                        UnitAmount = (long)model.Product.Price
                    },
                    Quantity = model.Count,
                };
                options.LineItems.Add(result);
            }
            var service = new SessionService();
            var session = service.Create(options);
            return Redirect(session.Url);
        }















    }
}


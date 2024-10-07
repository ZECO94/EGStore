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
            UserManager<IdentityUser> userManager, IOrderRepository orderRepository,
            IOrderDetailsRepository orderDetailsRepository)
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
        public IActionResult ReviewOrder()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Get cart items for the current user
            var cartItems = _cartRepository.Get(c => c.ApplicationUserId == userId, x => x.Product);

            if (cartItems == null || !cartItems.Any())
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction("Index");
            }

            return View(cartItems); // Navigate to the Review view
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(string name,string address,string city,string postalCode)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Retrieve the logged-in user
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "User not found!";
                return RedirectToAction("Index", "Cart");
            }

            // Retrieve the cart items
            var cartItems = _cartRepository.Get(c => c.ApplicationUserId == userId, x => x.Product);
            if (cartItems == null || !cartItems.Any())
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction("Index");
            }

            // Calculate total price
            double totalPrice = cartItems.Sum(item => item.Product.Price * item.Count);

            // Create a new order with user data
            var newOrder = new Order
            {
                ApplicationUserId = userId,
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(3),
                TotalPrice = totalPrice,
                Name = name,
                Address = address,
                City = city,
                PostalCode = postalCode,
                PhoneNumber = user.PhoneNumber,  
                OrderStatus = OrderStatus.Processing,
                PaymentDate = DateTime.Now
            };

            // Save the order to the database
            _orderRepository.Add(newOrder);

            // Create order details from cart items
            foreach (var item in cartItems)
            {
                var orderDetails = new OrderDetails
                {
                    OrderId = newOrder.Id,
                    ProductId = item.ProductId,
                    ProductsQuantity = item.Count,
                    UnitPrice = item.Product.Price
                };
                _orderDetailsRepository.Add(orderDetails);
            }

            // Clear the cart after placing the order
            foreach (var item in cartItems)
            {
                _cartRepository.Remove(item);
            }

            // Navigate to payment action
            TempData["Cart"] = JsonConvert.SerializeObject(cartItems); // Save cart items in TempData for payment
            return RedirectToAction("Payment");
        }

        public IActionResult Payment()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = $"{Request.Scheme}://{Request.Host}/Customer/checkout/success",
                CancelUrl = $"{Request.Scheme}://{Request.Host}/Customer/checkout/cancel",
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
                        UnitAmount = (long)(model.Product.Price * 100), // Stripe expects the amount in cents
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


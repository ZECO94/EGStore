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
        public IActionResult Summary()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var cartItems =  _cartRepository.Get(x => x.ApplicationUserId == userId, x => x.Product);
            
            if (!cartItems.Any())
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction("Index", "Cart");
            }
            return View(cartItems);
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            // Get the current user's cart
            var userId = _userManager.GetUserId(User); // Assuming you're using Identity
            var cartItems = _cartRepository.Get(x => x.ApplicationUserId == userId, c => c.Product);
            if (cartItems == null || !cartItems.Any())
            {
                return RedirectToAction("Summary", "Cart"); // Redirect if the cart is empty
            }

            // Calculate the total price
            double totalPrice = cartItems.Sum(c => c.Count * c.Product.Price);

            // Create a new Order
            var order = new Order
            {
                ApplicationUserId = userId,
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now.AddDays(3), // Assume 3 days shipping
                TotalPrice = totalPrice,
                OrderStatus = OrderStatus.Processing,
                Name = "User Name", 
                Address = "User Address", 
                PhoneNumber = "User Phone",
                PaymentDate = DateTime.Now,
                PaymentDueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30)) 
            };

            // Save the order to the database
            _orderRepository.Add(order);

            // Save the order details
            foreach (var item in cartItems)
            {
                var orderDetails = new OrderDetails
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    ProductsQuantity = item.Count,
                    UnitPrice = item.Product.Price
                };

                _orderDetailsRepository.Add(orderDetails);
            }

            // Optionally, clear the cart
            _cartRepository.RemoveRange(cartItems);

            // Redirect to OrderDetails page with the newly created OrderId
            return RedirectToAction("OrderDetails", "Order", new { id = order.Id });
        }














    }
}


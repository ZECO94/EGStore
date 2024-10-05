using EGStore.DataAccess.Repository;
using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
//using EGStore.Models.ViewModels;
using EGStore.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using Stripe;
using Newtonsoft.Json;

namespace EGStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderController(ICartRepository cartRepository, IOrderRepository orderRepository,
            UserManager<IdentityUser> userManager, IOrderDetailsRepository orderDetailsRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
            _orderDetailsRepository = orderDetailsRepository;
        }
        public async Task<IActionResult> OrderDetails(int id)
        {
            var orderDetails = _orderDetailsRepository.Get(x => x.OrderId == id, x => x.Product,x=>x.Order);

            if (orderDetails == null || !orderDetails.Any())
            {
                return NotFound();
            }

            
            return View(orderDetails);
        }
        


        //public IActionResult Index()
        //{
        //    return View();
        //}
        //public IActionResult Summary()
        //{
        //    var userId = _userManager.GetUserId(User);
        //    if (userId == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    var cartItems = _cartRepository.Get(x => x.ApplicationUserId == userId, x => x.Product);

        //    if (!cartItems.Any())
        //    {
        //        TempData["Error"] = "Your cart is empty!";
        //        return RedirectToAction("Index", "Cart");
        //    }
        //    return View(cartItems);
        //}

        //[HttpPost]
        //public async Task<IActionResult> PlaceOrder()
        //{
        //    // Get the current user's cart
        //    var userId = _userManager.GetUserId(User); // Assuming you're using Identity
        //    var cartItems = _cartRepository.Get(x => x.ApplicationUserId == userId, c => c.Product);
        //    if (cartItems == null || !cartItems.Any())
        //    {
        //        return RedirectToAction("Summary", "Cart"); // Redirect if the cart is empty
        //    }

        //    // Calculate the total price
        //    double totalPrice = cartItems.Sum(c => c.Count * c.Product.Price);

        //    // Create a new Order
        //    var order = new Order
        //    {
        //        ApplicationUserId = userId,
        //        OrderDate = DateTime.Now,
        //        ShippingDate = DateTime.Now.AddDays(3), // Assume 3 days shipping
        //        TotalPrice = totalPrice,
        //        OrderStatus = OrderStatus.Processing,
        //        Name = "User Name",
        //        Address = "User Address",
        //        PhoneNumber = "User Phone",
        //        PaymentDate = DateTime.Now,
        //        PaymentDueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30))
        //    };

        //    // Save the order to the database
        //    _orderRepository.Add(order);

        //    // Save the order details
        //    foreach (var item in cartItems)
        //    {
        //        var orderDetails = new OrderDetails
        //        {
        //            OrderId = order.Id,
        //            ProductId = item.ProductId,
        //            ProductsQuantity = item.Count,
        //            UnitPrice = item.Product.Price
        //        };

        //        _orderDetailsRepository.Add(orderDetails);
        //    }

        //    // Optionally, clear the cart
        //    _cartRepository.RemoveRange(cartItems);

        //    // Redirect to OrderDetails page with the newly created OrderId
        //    return RedirectToAction("OrderDetails", "Order", new { id = order.Id });
        //}
    }
}

using EGStore.DataAccess.Repository;
using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
//using EGStore.Models.ViewModels;
using EGStore.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var orderDetails = _orderDetailsRepository.Get(x => x.OrderId == id, x => x.Product);

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
    }
}

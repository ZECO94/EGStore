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
    }
        

}


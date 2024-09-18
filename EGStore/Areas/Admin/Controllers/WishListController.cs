using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Admin.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListRepository _wishListRepository;
        public WishListController(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }
        public IActionResult Index()
        {
            var wishLists = _wishListRepository.Get(null);
            return View(wishLists);
        }
        public IActionResult Edit(int id)
        {
            var wishList = _wishListRepository.GetOne(x => x.Id == id);
            if (wishList != null)
            {
                return View(wishList);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(WishList wishList)
        {
            if (ModelState.IsValid)
            {
                _wishListRepository.Update(wishList);
                return RedirectToAction("Index", "WishList");
            }
            return View(wishList);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(WishList wishList)
        {
            if (ModelState.IsValid)
            {
                _wishListRepository.Add(wishList);
                return RedirectToAction("Index", "Product");
            }
            return View(wishList);
        }
        public IActionResult Delete(int id)
        {
            var wishList = _wishListRepository.GetOne(x => x.Id == id);
            if (wishList != null)
            {
                _wishListRepository.Remove(wishList);
                return RedirectToAction("Index", "WishList");
            }
            return NotFound();
        }
    }
}

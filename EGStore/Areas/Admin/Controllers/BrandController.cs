using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public IActionResult Index()
        {
            var brands = _brandRepository.Get(null);
            return View(brands);
        }
        public IActionResult Edit(int id) 
        {
            var brand = _brandRepository.GetOne(x=>x.Id == id);
            if (brand != null)
            {
                return View(brand);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Brand brand) 
        {
            if(ModelState.IsValid)
            {
                _brandRepository.Update(brand);
                return RedirectToAction("Index", "Brand");
            }
            return View(brand);

        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandRepository.Add(brand);
                return RedirectToAction("Index", "Brand");
            }
            return View(brand);
        }
        public IActionResult Delete(int id)
        {
            var brand = _brandRepository.GetOne(x=>x.Id==id);
            if (brand != null)
            {
                _brandRepository.Remove(brand);
                return RedirectToAction("Index", "Brand");
            }
            return NotFound();
        }
    }
}

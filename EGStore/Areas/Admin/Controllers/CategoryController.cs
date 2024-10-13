using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var brands = _categoryRepository.Get(null);
            return View(brands);
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryRepository.GetOne(x => x.Id == id);
            if (category != null)
            {
                return View(category);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                return RedirectToAction("Index", "Category");
            }
            return View(category);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetOne(x => x.Id == id);
            if (category != null)
            {
                _categoryRepository.Remove(category);
                return RedirectToAction("Index", "Category");
            }
            return NotFound();
        }
    }
}

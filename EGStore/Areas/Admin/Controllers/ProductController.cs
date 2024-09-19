using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EGStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository,
            IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.Get(null,x=>x.Category,x=>x.Brand);
            return View(products);
        }
        public IActionResult Edit(int id)
        {
            var categoryList = _categoryRepository.Get(null).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CategoryName
            }).ToList();
            ViewBag.CategoryList = categoryList;
            var brandList = _brandRepository.Get(null).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.BrandName
            }).ToList();
            ViewBag.BrandList = brandList;
            var product = _productRepository.GetOne(x => x.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction("Index", "Product");
            }
            return View(product);

        }
        public IActionResult Create()
        {
            var categoryList = _categoryRepository.Get(null).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CategoryName
            }).ToList();
            ViewBag.CategoryList = categoryList;
            var brandList = _brandRepository.Get(null).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.BrandName
            }).ToList();
            ViewBag.BrandList = brandList;
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetOne(x => x.Id == id);
            if (product != null)
            {
                _productRepository.Remove(product);
                return RedirectToAction("Index", "Product");
            }
            return NotFound();
        }
    }
}


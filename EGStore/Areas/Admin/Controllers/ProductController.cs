using EGStore.DataAccess.Repository.IRepository;
using EGStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.Get(null);
            return View(products);
        }
        public IActionResult Edit(int id)
        {
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
            return View();
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


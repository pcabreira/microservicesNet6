using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(product);
                if (response != null) return RedirectToAction("Index");
            }

            return View(product);
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.FindProductById(id);

            if(product != null)
                return View(product);

            return NotFound();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(product);
                if (response != null) return RedirectToAction("Index");
            }

            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> Delete(ProductModel product)
        {
            var response = await _productService.DeleteProductById(product.Id);

            if (response)
                return RedirectToAction("Index");

            return View(product);
        }
    }
}

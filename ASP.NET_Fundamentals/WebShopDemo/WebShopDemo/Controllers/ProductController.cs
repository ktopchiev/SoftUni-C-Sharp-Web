﻿
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers
{   
    /// <summary>
    /// Web shop products
    /// </summary>
    // v praktikata shte polzvame dosta prazni kontroleri
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_productService"></param>

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        /// <summary>
        /// List all products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDto> products = await productService.GetAll();
            ViewData["Title"] = "Products";
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductDto();
            ViewData["Title"] = "Add new product";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.Add(model); 

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]Guid id)
        {
            await productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

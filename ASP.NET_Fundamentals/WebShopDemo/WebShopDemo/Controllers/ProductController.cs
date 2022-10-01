
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
            return View(products);
        }
    }
}

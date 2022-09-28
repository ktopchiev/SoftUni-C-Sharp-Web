using Microsoft.AspNetCore.Mvc;
using SimplePage.Models;
using System.Text.Json;

namespace SimplePage.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductsViewModel> products =
            new List<ProductsViewModel>()
            {
                new ProductsViewModel
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 7.00
                },
                new ProductsViewModel
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50
                },
                new ProductsViewModel
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.50
                }
            };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            return View(this.products);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            string text = string.Empty;

            foreach (var pr in this.products)
            {
                text += $"Product 1: {pr.Name} - {pr.Price}lv.";
                text += "\r\n";
            }

            return Content(text);
        }

        public IActionResult ById(int id)
        {
            var product = this.products.FirstOrDefault(i => i.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }
    }
}

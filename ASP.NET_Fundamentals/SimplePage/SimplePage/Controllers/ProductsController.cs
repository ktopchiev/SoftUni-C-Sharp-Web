using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SimplePage.Models;
using System.Text;
using System.Text.Json;

namespace SimplePage.Controllers
{
    /// <summary>
    /// Products controller
    /// </summary>
    public class ProductsController : Controller
    {
        /// <summary>
        /// IEnumerable List of Products
        /// </summary>
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

        /// <summary>
        /// Shows all products
        /// </summary>
        /// <returns></returns>
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = this.products
                    .Where(p => p.Name.ToLower()
                    .Contains(keyword.ToLower()));
                return View(foundProducts);
            }
            return View(this.products);
        }


        /// <summary>
        /// Shows all products as json in browser
        /// </summary>
        /// <returns></returns>
        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }


        /// <summary>
        /// Shows all products as text in browser
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Download all products as text file
        /// </summary>
        /// <returns></returns>
        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pr in products)
            {
                sb.AppendLine($"Product {pr.Id}: {pr.Name} - {pr.Price:f2}lv");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition,
                @"attachment;filename=products.txt");
            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }

        /// <summary>
        /// Show product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

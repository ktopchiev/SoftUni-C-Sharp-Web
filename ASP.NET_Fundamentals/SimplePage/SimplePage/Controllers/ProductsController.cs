using Microsoft.AspNetCore.Mvc;
using SimplePage.Models;

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
    }
}

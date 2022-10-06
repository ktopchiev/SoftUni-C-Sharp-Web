using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShoppingListDbContext data;

        public ProductsController(ShoppingListDbContext _data)
        {
            data = _data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            var products = data
                .Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();

            return View(products);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data;
using ShoppingList.Models;
using System.Net;

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

        public IActionResult Add() => View();

        /// <summary>
        /// Adds new product to ShoppingListDb
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(ProductFormModel model)
        {
            var product = new Product()
            {
                Name = model.Name
            };

            data.Products.Add(product);
            data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = data.Products.Find(id);

            return View(new ProductFormModel()
            {
                Name = product.Name
            });
        }

        /// <summary>
        /// Edit product in ShoppingListDb
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            var product = data.Products.Find(id);
            product.Name = model.Name;

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        /// <summary>
        /// Deletes product from ShoppingListDb
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Product product)
        {
            data.Products.Remove(product);
            data.SaveChanges();

            return RedirectToAction(nameof(All));
        }
    }
}

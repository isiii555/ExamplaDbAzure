using ExampleDbHomework.Data;
using ExampleDbHomework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleDbHomework.Controllers
{
    public class HomeController(ExampledbContext dbContext) : Controller
    {
        private readonly ExampledbContext _dbContext = dbContext;

        public async Task<IActionResult> Index()
        {
            var products = await _dbContext.Products.ToListAsync();
            var categories = await _dbContext.ProductCategories.ToListAsync();
            ViewData["categories"] = categories;
            ViewData["products"] = products;
            return View();
        }

        public async Task<IActionResult> FilterByCategory(int categoryId)
        {
            var products = await _dbContext.Products.Where(p => p.ProductCategoryId == categoryId).ToListAsync();
            var categories = await _dbContext.ProductCategories.ToListAsync();
            ViewData["products"] = products;
            ViewData["categories"] = categories;
            return View("Index");
        }
    }
}

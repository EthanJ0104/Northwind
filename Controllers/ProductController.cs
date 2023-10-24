using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
          // this controller depends on the BloggingRepository
        private DataContext _dataContext;
        public ProductController(DataContext db) => _dataContext = db;

        public ActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));

        public IActionResult CategoryDetail(int id) => View(new ProductViewModel
        {
            category = _dataContext.Categories.FirstOrDefault(c => c.CategoryId == id),
            Products = _dataContext.Products.Where(p => p.ProductId == id)
        });
    }
}
using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {
        private DataContext _dataContext;
        public CustomerController(DataContext db) => _dataContext = db;
        public ActionResult Customer() => View(_dataContext.Customers.OrderBy(b => b.CompanyName));
        public IActionResult AddCustomer(int id)
        {
            ViewBag.CustomerId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(int id, Customer model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.AddCustomer(model);
                return RedirectToAction("Customer");
            }
            @ViewBag.CustomerId = id;
            return View();
        }
    }
}
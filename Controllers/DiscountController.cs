using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Northwind.Controllers
{
    public class DiscountController : Controller
    {
        private DataContext _dataContext;
        public DiscountController(DataContext db) => _dataContext = db;
        public ActionResult Discount() => View(_dataContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    }
}
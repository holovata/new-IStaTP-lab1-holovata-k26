using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewHolovataLab1WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace NewHolovataLab1WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly DblibraryLab1Context _context;
        public ChartController(DblibraryLab1Context context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var types = _context.ProductTypes.Include(a => a.Products).ToList();
            List<object> typeProd = new List<object>();
            typeProd.Add(new[] { "Тип товарів", "Кількість товарів" });
            foreach (var type in types)
            {
                typeProd.Add(new object[] { type.Name, type.Products.Count() });
            }
            return new JsonResult(typeProd);
        }

        [HttpGet("JsonData1")]
        public JsonResult JsonData1()
        {
            var orderDates = _context.Orders.Select(o => o.Time.Date).Distinct().ToList();
            var ordersByDate = _context.Orders.GroupBy(o => o.Time.Date).Select(g => new { Date = g.Key, OrderCount = g.Count() }).ToList();

            List<object> orders = new List<object>();
            orders.Add(new[] { "Дата", "К-ть замовлень" });
            foreach (var orDate in ordersByDate)
            {
                orders.Add(new object[] { orDate.Date, orDate.OrderCount });
            }
            return new JsonResult(orders);
        }
    }
}

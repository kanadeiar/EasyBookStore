using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = User.Identity!.Name;
            return View();
        }

        public async Task<IActionResult> Orders([FromServices] IOrderService orderService)
        {
            var orders = await orderService.GetUserOrders(User.Identity!.Name);

            var models = orders.Select(o => new UserOrderWebModel
            {
                Id = o.Id,
                Address = o.Address,
                Phone = o.Phone,
                Description = o.Description,
                TotalPrice = o.TotalPrice,
                Count = o.Items.Count,
                Date = o.Date,
            });

            return View(models);
        }
    }
}

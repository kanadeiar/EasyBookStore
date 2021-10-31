using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels.Order;
using Microsoft.AspNetCore.Authorization;

namespace EasyBookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CartOrderWebModel { Cart = await _cartService.GetWebModelAsync() };
            return View(model);
        }

        public IActionResult Add(int id)
        {
            _cartService.Add(id);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Decrement(int id)
        {
            _cartService.Decrement(id);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Remove(int id)
        {
            _cartService.Remove(id);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Clear()
        {
            _cartService.Clear();
            return RedirectToAction("Index", "Cart");
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(OrderWebModel orderModel, [FromServices] IOrderService orderService)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index), new CartOrderWebModel { Cart = await _cartService.GetWebModelAsync(), Order = orderModel });

            var order = await orderService.CreateOrder(User.Identity.Name, await _cartService.GetWebModelAsync(), orderModel);

            _cartService.Clear();

            return RedirectToAction(nameof(OrderConfirmed), new { order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}

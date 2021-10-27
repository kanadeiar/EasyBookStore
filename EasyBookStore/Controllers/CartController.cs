using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Interfaces.Services;

namespace EasyBookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var model = _cartService.GetWebModel();
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
    }
}

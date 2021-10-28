using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyBookStore.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;
        public CartViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.ProductsInCartCount = (_cartService.GetWebModel()).ItemsSum;
            return View();
        }
    }
}

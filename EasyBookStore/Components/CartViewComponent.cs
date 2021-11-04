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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.ProductsInCartCount = (await _cartService.GetWebModelAsync()).ItemsSum;
            return View();
        }
    }
}

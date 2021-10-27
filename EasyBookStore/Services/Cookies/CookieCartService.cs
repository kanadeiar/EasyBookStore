using System;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels.Cart;
using Microsoft.AspNetCore.Http;

namespace EasyBookStore.Services.Cookies
{
    public class CookieCartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductData _productData;
        private readonly string _CartName;

        public CookieCartService(IHttpContextAccessor HttpContextAccessor, IProductData ProductData)
        {
            _httpContextAccessor = HttpContextAccessor;
            _productData = ProductData;

            var user = HttpContextAccessor.HttpContext!.User;
            var userName = user.Identity!.IsAuthenticated ? $"-{user.Identity.Name}" : null;

            _CartName = $"BookStore.Cart{userName}";
        }

        public void Add(int id)
        {
            throw new NotImplementedException();
        }

        public void Decrement(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public CartWebModel GetWebModel()
        {
            throw new NotImplementedException();
        }
    }
}

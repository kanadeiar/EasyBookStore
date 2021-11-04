using System;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models.Cart;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels;
using EasyBookStore.WebModels.Cart;
using Microsoft.Extensions.Logging;

namespace EasyBookStore.Services
{
    public class CartService : ICartService
    {
        private readonly ICartStore _cartStore;
        private readonly IProductData _productData;
        private readonly ILogger<CartService> _logger;

        public CartService(ICartStore cartStore, IProductData productData, ILogger<CartService> logger)
        {
            _cartStore = cartStore;
            _productData = productData;
            _logger = logger;
        }

        public void Add(int id)
        {
            var cart = _cartStore.Cart;

            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is { })
                item.Quantity++;
            else
                cart.Items.Add(new CartItem{ProductId = id, Quantity = 1});

            _cartStore.Cart = cart;
        }

        public void Decrement(int id)
        {
            var cart = _cartStore.Cart;

            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null)
                return;

            if (item.Quantity > 0)
                item.Quantity--;

            if (item.Quantity == 0)
                cart.Items.Remove(item);

            _cartStore.Cart = cart;
        }

        public void Remove(int id)
        {
            var cart = _cartStore.Cart;

            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null)
                return;

            cart.Items.Remove(item);

            _cartStore.Cart = cart;
        }

        public void Clear()
        {
            var cart = _cartStore.Cart;

            cart.Items.Clear();

            _cartStore.Cart = cart;
        }

        public async Task<CartWebModel> GetWebModelAsync()
        {
            var products = await _productData.GetProductsAsync(new ProductFilter
            {
                Ids = _cartStore.Cart.Items.Select(i => i.ProductId).ToArray()
            });

            var productWebs = products.Select(p => new ProductWebModel
            {
                Id = p.Id,
                AuthorName = p.Author?.Name,
                GenreName = p.Genre?.Name,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Message = p.Message,
            }).ToDictionary(p => p.Id);

            return new CartWebModel
            {
                Items = _cartStore.Cart.Items
                    .Where(p => productWebs.ContainsKey(p.ProductId))
                    .Select(p => (productWebs[p.ProductId], p.Quantity, productWebs[p.ProductId].Price * p.Quantity))
            };
        }
    }
}

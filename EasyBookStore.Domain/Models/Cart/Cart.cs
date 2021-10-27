using System.Collections.Generic;
using System.Linq;

namespace EasyBookStore.Domain.Models.Cart
{
    /// <summary> Корзина с товарами </summary>
    public class Cart
    {
        /// <summary> Товары корзины </summary>
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        /// <summary> Количество товаров </summary>
        public int ItemsCount => Items?.Sum(item => item.Quantity) ?? 0;
    }
}

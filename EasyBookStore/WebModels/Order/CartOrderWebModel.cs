using EasyBookStore.WebModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.WebModels.Order
{
    /// <summary> Вебмодель корзины с заказом </summary>
    public class CartOrderWebModel
    {
        public CartWebModel Cart { get; set; }
        public OrderWebModel Order { get; set; } = new();
    }
}

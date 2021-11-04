using EasyBookStore.Domain.Models.Cart;

namespace EasyBookStore.Interfaces.Services
{
    /// <summary> Хранилище корзины </summary>
    public interface ICartStore
    {
        /// <summary> Корзина товаров </summary>
        Cart Cart { get; set; }
    }
}

using EasyBookStore.Domain.Models.Order;
using EasyBookStore.WebModels.Cart;
using EasyBookStore.WebModels.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyBookStore.Interfaces.Services
{
    /// <summary> Сервис заказов </summary>
    public interface IOrderService
    {
        /// <summary> Получить заказы пользователя </summary>
        Task<IEnumerable<Order>> GetUserOrders(string userName);

        /// <summary> Получить заказ </summary>
        Task<Order> GetOrder(int id);

        /// <summary> Создать новый заказ </summary>
        Task<Order> CreateOrder(string userName, CartWebModel cart, OrderWebModel order);
    }
}

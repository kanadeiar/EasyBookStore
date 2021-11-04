using EasyBookStore.Dal.Context;
using EasyBookStore.Domain.Models.Identity;
using EasyBookStore.Domain.Models.Order;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.WebModels.Cart;
using EasyBookStore.WebModels.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Services.Database
{
    public class DatabaseOrderData : IOrderService
    {
        private readonly BookStoreContext _context;
        private readonly UserManager<User> _userManager;
        public DatabaseOrderData(BookStoreContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Order>> GetUserOrders(string userName)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .Where(o => o.User.UserName == userName).ToArrayAsync().ConfigureAwait(false);
            return order;
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id).ConfigureAwait(false);
            return order;
        }

        public async Task<Order> CreateOrder(string userName, CartWebModel cart, OrderWebModel orderModel)
        {
            var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);

            if (user is null)
                throw new InvalidOperationException($"Пользователь {userName} не найден");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var order = new Order
            {
                User = user,
                Address = orderModel.Address,
                Phone = orderModel.Phone,
                Description = orderModel.Description,
            };
            var productIds = cart.Items.Select(i => i.Product.Id).ToArray();

            var cartProducts = await _context.Products
                .Where(p => productIds.Contains(p.Id)).ToArrayAsync();

            order.Items = cart.Items.Join(
                cartProducts, 
                cartI => cartI.Product.Id, 
                cartP => cartP.Id, 
                (cartI, cartP) => new OrderItem
                {
                    Order = order,
                    Product = cartP,
                    Price = cartP.Price,
                    Quantity = cartI.Quantity
                }).ToArray();

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            return order;
        }
    }
}

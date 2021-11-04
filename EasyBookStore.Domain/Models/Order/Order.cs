using EasyBookStore.Domain.Models.Base;
using EasyBookStore.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EasyBookStore.Domain.Models.Order
{
    /// <summary> Заказ </summary>
    public class Order : Entity
    {
        /// <summary> Пользователь </summary>
        [Required]
        public User User { get; set; }

        /// <summary> Адрес доставки </summary>
        [Required, MaxLength(500)]
        public string Address { get; set; }

        /// <summary> Телефон </summary>
        [Required, MaxLength(200)]
        public string Phone { get; set; }

        /// <summary> Описание заказа </summary>
        public string Description { get; set; }

        /// <summary> Дата заказа </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary> Элементы этого заказа </summary>
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        /// <summary> Стоимость суммы заказов </summary>
        [NotMapped]
        public decimal TotalPrice => Items?.Sum(i => i.TotalItemPrice) ?? 0m;
    }
}

using EasyBookStore.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBookStore.Domain.Models.Order
{
    /// <summary> Элемент заказа </summary>
    public class OrderItem : Entity
    {
        /// <summary> Заказ </summary>
        public Order Order { get; set; }

        /// <summary> Товар - книга </summary>
        [Required]
        public Product Product { get; set; }

        /// <summary> Цена </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary> Количество </summary>
        public int Quantity { get; set; }

        /// <summary> Стоимость суммы товаров </summary>
        [NotMapped]
        public decimal TotalItemPrice => Price * Quantity;
    }
}

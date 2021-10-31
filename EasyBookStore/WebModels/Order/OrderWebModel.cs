using System.ComponentModel.DataAnnotations;

namespace EasyBookStore.WebModels.Order
{
    public class OrderWebModel
    {
        /// <summary> Адрес доставки </summary>
        [Required(ErrorMessage = "Нужно ввести адрес доставки товаров")]
        public string Address { get; set; }

        /// <summary> Телефон </summary>
        [Required(ErrorMessage = "Нужно ввести свой телефон для связи")]
        public string Phone { get; set; }

        /// <summary> Описание заказа </summary>
        [Required(ErrorMessage = "Нужно ввести описание заказа")]
        public string Description { get; set; }
    }
}

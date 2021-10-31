using System.ComponentModel.DataAnnotations;

namespace EasyBookStore.WebModels.Order
{
    public class OrderWebModel
    {
        /// <summary> Адрес доставки </summary>
        [Display(Name = "Адрес доставки")]
        [Required(ErrorMessage = "Обязательно нужно ввести адрес доставки товаров")]
        public string Address { get; set; }

        /// <summary> Телефон </summary>
        [Display(Name = "Ваш телефон для связи")]
        [Required(ErrorMessage = "Обязательно нужно ввести свой телефон для связи")]
        public string Phone { get; set; }

        /// <summary> Описание заказа </summary>
        [Display(Name = "Описание заказа")]
        [Required(ErrorMessage = "Обязательно Нужно ввести описание заказа")]
        public string Description { get; set; }
    }
}

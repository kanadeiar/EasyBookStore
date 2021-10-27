namespace EasyBookStore.Domain.Models.Cart
{
    /// <summary> Элемент корзины товаров </summary>
    public class CartItem
    {
        /// <summary> Идентификатор товара </summary>
        public int ProductId { get; set; }
        /// <summary> Количество </summary>
        public int Quantity { get; set; }
    }
}
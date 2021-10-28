using EasyBookStore.WebModels.Cart;

namespace EasyBookStore.Interfaces.Services
{
    /// <summary> Сервис управления корзиной </summary>
    public interface ICartService
    {
        /// <summary> Добавить товар в корзину </summary>
        void Add(int id);
        /// <summary> Убавить товар в корзине на еденицу </summary>
        void Decrement(int id);
        /// <summary> Удалить товар из корзины </summary>
        void Remove(int id);
        /// <summary> Очистить корзину </summary>
        void Clear();
        /// <summary> Получить вебмодель корзины </summary>
        CartWebModel GetWebModel();
    }
}

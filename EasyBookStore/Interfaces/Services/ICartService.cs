using EasyBookStore.WebModels.Cart;

namespace EasyBookStore.Interfaces.Services
{
    public interface ICartService
    {
        void Add(int id);
        void Decrement(int id);
        void Remove(int id);
        void Clear();
        CartWebModel GetWebModel();
    }
}

namespace EasyBookStore.Domain.Models.Base
{
    public interface IOrderedEntity : IEntity
    {
        int Order { get; }
    }
}

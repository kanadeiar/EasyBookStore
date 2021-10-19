namespace EasyBookStore.Domain.Models.Base
{
    public interface INamedEntity : IEntity
    {
        string Name { get; }
    }
}

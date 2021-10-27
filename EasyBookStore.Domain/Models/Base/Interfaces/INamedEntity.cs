namespace EasyBookStore.Domain.Models.Base.Interfaces
{
    public interface INamedEntity : IEntity
    {
        /// <summary> Название </summary>
        string Name { get; }
    }
}

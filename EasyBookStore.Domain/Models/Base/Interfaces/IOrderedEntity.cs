namespace EasyBookStore.Domain.Models.Base.Interfaces
{
    public interface IOrderedEntity : IEntity
    {
        /// <summary> Позиция в сортировке </summary>
        int Order { get; }
    }
}

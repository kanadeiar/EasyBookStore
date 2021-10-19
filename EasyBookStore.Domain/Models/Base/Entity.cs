using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models.Base
{
    /// <summary> Базовая сущность </summary>
    public abstract class Entity : IEntity
    {
        public int Id { get; }
    }
}

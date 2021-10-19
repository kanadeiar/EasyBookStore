using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        public string Name { get; set; }
    }
}

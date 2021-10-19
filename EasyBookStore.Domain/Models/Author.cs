using EasyBookStore.Domain.Models.Base;
using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Автор книги </summary>
    public class Author : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}

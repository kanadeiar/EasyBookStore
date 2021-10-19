using EasyBookStore.Domain.Models.Base;
using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Жанр книги </summary>
    public class Genre : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        /// <summary> Идентификатор родительского элемента </summary>
        public int? ParentId { get; set; }
    }
}

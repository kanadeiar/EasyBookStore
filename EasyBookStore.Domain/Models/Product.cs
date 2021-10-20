using EasyBookStore.Domain.Models.Base;
using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Товар - книга </summary>
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; }
        /// <summary> Жанр </summary>
        public int GenreId { get; set; }
        /// <summary> Автор </summary>
        public int? AuthorId { get; set; }
        /// <summary> Изображение книги </summary>
        public string ImageUrl { get; set; }
        /// <summary> Стоимость книги </summary>
        public decimal Price { get; set; }
    }
}

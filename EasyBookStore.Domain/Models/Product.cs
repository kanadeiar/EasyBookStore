using System.ComponentModel.DataAnnotations.Schema;
using EasyBookStore.Domain.Models.Base;
using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Товар - книга </summary>
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary> Жанр </summary>
        public int GenreId { get; set; }
        /// <summary> Жанр </summary>
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        /// <summary> Автор </summary>
        public int? AuthorId { get; set; }
        /// <summary> Автор </summary>
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        /// <summary> Изображение книги </summary>
        public string ImageUrl { get; set; }

        /// <summary> Стоимость книги </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary> Краткое сообщение о книге </summary>
        public string Message { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasyBookStore.Domain.Models.Base;
using EasyBookStore.Domain.Models.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Жанр книги </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class Genre : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        /// <summary> Идентификатор родительского элемента </summary>
        public int? ParentId { get; set; }
        /// <summary> Родительский элемент </summary>
        [ForeignKey(nameof(ParentId))]
        public Genre Parent { get; set; }
        /// <summary> Товары этого жанра </summary>
        public ICollection<Product> Products { get; set; }
    }
}

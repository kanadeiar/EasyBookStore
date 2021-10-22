using System.Collections.Generic;
using EasyBookStore.Domain.Models.Base;
using EasyBookStore.Domain.Models.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Автор книги </summary>
    [Index(nameof(Name), IsUnique = true)]
    public class Author : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        /// <summary> Товары этого автора </summary>
        public ICollection<Product> Products { get; set; }
    }
}

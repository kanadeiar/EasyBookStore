using System.ComponentModel.DataAnnotations;
using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}

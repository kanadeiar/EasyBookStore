using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyBookStore.Domain.Models.Base.Interfaces;

namespace EasyBookStore.Domain.Models.Base
{
    /// <summary> Базовая сущность </summary>
    public abstract class Entity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}

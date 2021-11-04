using System.ComponentModel.DataAnnotations;
using EasyBookStore.Domain.Models.Base;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Сотрудник </summary>
    public class Worker : Entity
    {
        /// <summary> Фамилия </summary>
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        /// <summary> Имя </summary>
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        /// <summary> Отчество </summary>
        [Required, MaxLength(100)]
        public string Patronymic { get; set; }
        /// <summary> Возраст </summary>
        public int Age { get; set; }
    }
}

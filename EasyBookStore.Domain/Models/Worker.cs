using EasyBookStore.Domain.Models.Base;

namespace EasyBookStore.Domain.Models
{
    /// <summary> Сотрудник </summary>
    public class Worker : Entity
    {
        /// <summary> Фамилия </summary>
        public string LastName { get; set; }
        /// <summary> Имя </summary>
        public string FirstName { get; set; }
        /// <summary> Отчество </summary>
        public string Patronymic { get; set; }
        /// <summary> Возраст </summary>
        public int Age { get; set; }
    }
}

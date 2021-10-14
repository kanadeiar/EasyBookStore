using System.ComponentModel.DataAnnotations;

namespace EasyBookStore.WebModels
{
    public class WorkerDetailsWebModel
    {
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
    }
}

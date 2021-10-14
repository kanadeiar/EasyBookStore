using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EasyBookStore.WebModels
{
    public class WorkerEditWebModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Необходимо ввести имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длинна имени должна быть от 2 до 200 символов")]
        [RegularExpression("([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Строка имени имела неверный формат (Либо русские, либо латинские символы, начиная с заглавной буквы)")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Необходимо ввести фамилию")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длинна фамилии должна быть от 2 до 200 символов")]
        [RegularExpression("([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Строка фамилии имела неверный формат (Либо русские, либо латинские символы, начиная с заглавной буквы)")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(200, ErrorMessage = "Длинна отчества должна быть не более 200 символов")]
        [RegularExpression("([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Строка отчества имела неверный формат (Либо русские, либо латинские символы, начиная с заглавной буквы)")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Range(10, 200, ErrorMessage = "Возраст должен быть в диапазоне от 10 до 200 лет")]
        public int Age { get; set; }
    }
}

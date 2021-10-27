using System.ComponentModel.DataAnnotations;

namespace EasyBookStore.WebModels.Identity
{
    public class RegisterWebModel
    {
        [Required(ErrorMessage = "Нужно обязательно ввести имя пользователя")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Нужно обязательно ввести свой пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Нужно обязательно ввети подтверждение своего пароля")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароли должны совпадать")]
        public string PasswordConfirm { get; set; } 
    }
}

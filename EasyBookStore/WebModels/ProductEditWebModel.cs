using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;

namespace EasyBookStore.WebModels
{
    /// <summary> Вебмодель редактирования товаров </summary>
    public class ProductEditWebModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Необходимо ввести имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длинна имени должна быть от 2 до 200 символов")]
        public string Name { get; set; }

        [Display(Name = "Сортировка")]
        [Range(0, 90000, ErrorMessage = "Пожалуйста, только без отрицательных значений")]
        public int Order { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Нужно обязательно выбрать жанр книги")]
        public int GenreId { get; set; }

        [Display(Name = "Жанр")]
        public string GenreName { get; set; }

        [Display(Name = "Автор")]
        public int? AuthorId { get; set; }

        [Display(Name = "Автор")]
        public string AuthorName { get; set; }

        [Display(Name = "Изображение")]
        public string ImageUrl { get; set; }

        [Display(Name = "Стоимость")]
        [Range(0.0, 90000.0, ErrorMessage = "Стоимость может быть только от 0 до 90000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Сообщение о книге")]
        public string Message { get; set; }
    }
}

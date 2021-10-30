namespace EasyBookStore.WebModels
{
    public class ProductWebModel
    {
        public int Id { get; set; }
        /// <summary> Название книги </summary>
        public string Name { get; set; }
        /// <summary> Жанр книги </summary>
        public string GenreName { get; set; }
        /// <summary> Автор книги </summary>
        public string AuthorName { get; set; }
        /// <summary> Изображение книги </summary>
        public string ImageUrl { get; set; }
        /// <summary> Стоимость книги </summary>
        public decimal Price { get; set; }
        /// <summary> Краткое сообщение о книге </summary>
        public string Message { get; set; }
    }
}

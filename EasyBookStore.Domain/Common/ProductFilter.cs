namespace EasyBookStore.Domain.Common
{
    /// <summary> Фильтр товаров </summary>
    public class ProductFilter
    {
        /// <summary> Фильтр по жанрам книг </summary>
        public int? GenreId { get; set; }
        /// <summary> Фильтр по авторам книг </summary>
        public int? AuthorId { get; set; }
        /// <summary> Идентификаторы товаров, которые нужно показать </summary>
        public int[] Ids { get; set; }
    }
}

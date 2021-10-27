using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Models.Data;

namespace EasyBookStore.Services.Memory
{
    /// <summary> Сервис хранения данных по товарам в памяти </summary>
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Genre> GetGenres()
        {
            return StaticData.Genres;
        }

        public Genre GetGenre(int id)
        {
            return StaticData.Genres.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Genre> GetGenresWithProducts() => GetGenres();
        public IEnumerable<Author> GetAuthors()
        {
            return StaticData.Authors;
        }

        public Author GetAuthor(int id)
        {
            return StaticData.Authors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAuthorsWithProducts() => GetAuthors();

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IEnumerable<Product> query = StaticData.Products;

            if (filter?.GenreId is { } genre)
                query = query.Where(p => p.GenreId == genre);

            if (filter?.AuthorId is { } author)
                query = query.Where(p => p.AuthorId == author);

            return query;
        }

        public Product GetProduct(int id)
        {
            return StaticData.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Models;
using EasyBookStore.WebModels;

namespace EasyBookStore.Services
{
    /// <summary> Обычный маппер </summary>
    /// <typeparam name="TOut">Требуемый тип</typeparam>
    public interface IMapper<out TOut>
    {
        /// <summary> Преобразование типа </summary>
        /// <param name="source">Исходный тип</param>
        /// <returns>Требуемый тип</returns>
        TOut Map(object source);
    }

    public class WebMapperService : IMapper<ProductWebModel>, IMapper<WorkerDetailsWebModel>, IMapper<WorkerEditWebModel>, IMapper<Worker>, 
        IMapper<ProductEditWebModel>, IMapper<Product>
    {
        public ProductWebModel Map(object source)
        {
            var product = (Product)source;
            var result = new ProductWebModel
            {
                Id = product.Id,
                GenreName = product.Genre.Name,
                AuthorName = product.Author?.Name ?? "<Неизвестный>",
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Message = product.Message,
            };
            return result;
        }
        WorkerDetailsWebModel IMapper<WorkerDetailsWebModel>.Map(object source)
        {
            var worker = (Worker)source;
            var result = new WorkerDetailsWebModel
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Patronymic = worker.Patronymic,
                Age = worker.Age,
            };
            return result;
        }
        WorkerEditWebModel IMapper<WorkerEditWebModel>.Map(object source)
        {
            var worker = (Worker)source;
            var result = new WorkerEditWebModel
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Patronymic = worker.Patronymic,
                Age = worker.Age,
            };
            return result;
        }
        Worker IMapper<Worker>.Map(object source)
        {
            var model = (WorkerEditWebModel)source;
            var worker = new Worker
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Age = model.Age,
            };
            return worker;
        }

        ProductEditWebModel IMapper<ProductEditWebModel>.Map(object source)
        {
            var product = (Product)source;
            var result = new ProductEditWebModel
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                GenreId = product.GenreId,
                GenreName = product.Genre?.Name,
                AuthorId = product.AuthorId,
                AuthorName = product.Author?.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Message = product.Message,
            };
            return result;
        }

        Product IMapper<Product>.Map(object source)
        {
            var model = (ProductEditWebModel)source;
            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Order = model.Order,
                GenreId = model.GenreId,                
                AuthorId = model.AuthorId,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Message = model.Message,
            };
            return product;
        }
    }
}

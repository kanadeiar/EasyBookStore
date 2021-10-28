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

    public class WebMapperService : IMapper<ProductWebModel>, IMapper<WorkerDetailsWebModel>, IMapper<WorkerEditWebModel>, IMapper<Worker>
    {
        public ProductWebModel Map(object source)
        {
            var product = (Product)source;
            var result = new ProductWebModel
            {
                Id = product.Id,
                Genre = product.Genre.Name,
                Author = product.Author?.Name ?? "<Неизвестный>",
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
    }

    //public class MapperService
    //{
    //    public ProductWebModel MapToWeb(Product product)
    //    {
    //        var result = new ProductWebModel
    //        {
    //            Id = product.Id,
    //            Genre = product.Genre.Name,
    //            Author = product.Author?.Name ?? "<Неизвестный>",
    //            Name = product.Name,
    //            ImageUrl = product.ImageUrl,
    //            Price = product.Price,
    //            Message = product.Message,
    //        };
    //        return result;
    //    }

    //    public WorkerDetailsWebModel MapToWeb(Worker worker)
    //    {
    //        var result = new WorkerDetailsWebModel
    //        {
    //            Id = worker.Id,
    //            FirstName = worker.FirstName,
    //            LastName = worker.LastName,
    //            Patronymic = worker.Patronymic,
    //            Age = worker.Age,
    //        };
    //        return result;
    //    }

    //    public WorkerEditWebModel MapToEditWeb(Worker worker)
    //    {
    //        var result = new WorkerEditWebModel
    //        {
    //            Id = worker.Id,
    //            FirstName = worker.FirstName,
    //            LastName = worker.LastName,
    //            Patronymic = worker.Patronymic,
    //            Age = worker.Age,
    //        };
    //        return result;
    //    }

    //    public Worker MapFromEditWeb(WorkerEditWebModel model)
    //    {
    //        var worker = new Worker
    //        {
    //            Id = model.Id,
    //            FirstName = model.FirstName,
    //            LastName = model.LastName,
    //            Patronymic = model.Patronymic,
    //            Age = model.Age,
    //        };
    //        return worker;
    //    }
    //}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.WebModels.Order
{
    public class UserOrderWebModel
    {
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public int Count { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}

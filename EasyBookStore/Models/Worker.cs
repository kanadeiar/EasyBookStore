using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Models.Base;

namespace EasyBookStore.Models
{
    public class Worker : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }


    }
}

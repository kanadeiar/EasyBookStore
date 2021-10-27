using System.Collections.Generic;

namespace EasyBookStore.WebModels
{
    public class GenreWebModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public GenreWebModel Parent { get; set; }
        public List<GenreWebModel> Child { get; set; } = new();
        public int CountProducts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.WebApi.Models.NewsModels
{
    public class TagViewModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool? active { get; set; }
    }
}

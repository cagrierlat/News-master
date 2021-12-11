using News.DAL.Classes.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Classes.NewsClasses
{
    [Table("Category")]
    public class Category : BaseObject
    {
        public string description { get; set; }
        public bool? active { get; set; }
    }
}

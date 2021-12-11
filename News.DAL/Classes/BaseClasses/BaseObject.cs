using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Classes.BaseClasses
{
    public class BaseObject
    {
        [Key]
        public int id { get; set; }
    }
}

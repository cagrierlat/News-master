using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.WebApi.StringInformations
{
    public class ConnectionStringInformations : IConnectionStringInformations
    {
        public string DefaultConnection { get; set; }
        public string APIBaseURLConnection { get; set; }

    }
    public interface IConnectionStringInformations
    {
        public string DefaultConnection { get; set; }
        public string APIBaseURLConnection { get; set; }
    }
}

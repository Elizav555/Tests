using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen.model
{
    public class Site
    {
        public Site(string domain, string name, string desc, string keyWords)
        {
            Domain = domain;
            Name = name;
            Description = desc;
            KeyWords = keyWords;
        }

        public string Domain { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string KeyWords { get; set; }

        public string Address { get { return $"https://{Domain}.mirtesen.ru"; } }

    }
}

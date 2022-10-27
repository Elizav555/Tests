using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirTesen.model
{
    public class Site
    {
        public Site(string domain, string name, string tag, string desc, string keyWords)
        {
            Domain = domain;
            Name = name;
            Tag = tag;
            Description = desc;
            KeyWords = keyWords;
        }

        public string Domain { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }

        public string Address { get { return $"https://{Domain}.mirtesen.ru/?utm_referrer=mirtesen.ru"; } }

    }
}

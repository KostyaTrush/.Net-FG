using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsItem
    {
        public long Id { get; set; }

        public String Title { get; set; }

        public String Body { get; set; }

        public String Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

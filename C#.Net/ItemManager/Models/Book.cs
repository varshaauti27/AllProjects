using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManager.Models
{
    public class Book
    {
        public string BookName { get; set; }

        public string Author { get; set; }

        public string Type { get; set; }
        public int NoOfPages { get; set; }

        public DateTime YearPublished { get; set; }
    }
}

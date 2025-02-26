using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityPrincipleDemo.modol
{
     class Book: IBook
    {
        public string author {  get; set; }
        public string title { get; set; }
        public double price { get; set; }

    }
}

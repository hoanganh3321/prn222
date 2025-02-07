using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_ClosedPrincipleDemo.Model
{
     class Book :Ibook
    {
        public string author { get; set; }
        public string title { get; set; }
        public double price { get; set; }
    }
}

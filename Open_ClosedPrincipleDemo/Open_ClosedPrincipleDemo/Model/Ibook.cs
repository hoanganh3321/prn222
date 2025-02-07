using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_ClosedPrincipleDemo.Model
{
     interface Ibook
    {
        string author { get; set; }
        string title { get; set; }
        double price { get; set; }
    }
}

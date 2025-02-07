using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Pattern_Demo.Model
{
    public class Movies
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string oscarnominations { get; set; }

        public string oscarwins { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Segregation_Principle_Demo.Model
{
    public class Book : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }

    public class TopicBook : Book, ITopic
    {
        public string Topic { get; set; }
    }

    public class Video : Book, ITopic, IDuration
    {
        public string Duration { get; set; }
        public string Topic { get; set; }
    }
}

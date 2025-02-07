using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Pattern_Demo.Model
{
    using System.Xml.Linq;
    using IoC_Pattern_Demo.Model;


    namespace Demo_IoC
    {
        public class XMLMovieReader : IMoviesReader
        {
            static string url = @"Data\";
            static XDocument films = XDocument.Load(url + "MoviesDB.xml");
            static List<Movies> movies = new List<Movies>();

            public List<Movies> ReadMoives()
            {
                var movieCollection =
                    (from f in films.Descendants("Movie")
                     select new Movies
                     {
                         Id = f.Element("ID").Value,
                         title = f.Element("Title").Value,
                         oscarnominations = f.Element("OscarNominations").Value,
                         oscarwins = f.Element("OscarWins").Value
                     }).ToList();
                return movieCollection;
            }

        }
    }
}

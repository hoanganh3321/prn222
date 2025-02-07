using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Pattern_Demo.Model
{
    using System.Text.Json;
    using IoC_Pattern_Demo.Model;

    namespace Demo_IoC
    {
        public class JSONMovieReader : IMoviesReader
        {
            static string file = @"Data\MoviesDB.json";
            static List<Movies> movies = new List<Movies>();

            public List<Movies> ReadMoives()
            {
                throw new NotImplementedException();
            }

            public List<Movies> ReadMovies()
            {
                var moviesText = File.ReadAllText(file);
                return JsonSerializer.Deserialize<List<Movies>>(moviesText);
            }
        }
    }

}

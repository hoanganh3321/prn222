namespace ResponsibilityPrincipleDemo
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using ResponsibilityPrincipleDemo.modol;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" List of Books");
            Console.WriteLine(" ----------------------------");

            // Read the JSON file content
            var cadJSON = File.ReadAllText("Data/BookStore.json");

            // Deserialize the JSON content into a list of books
            var bookList = JsonConvert.DeserializeObject<Book[]>(cadJSON);

            // Print the list of books to the console
            foreach (var item in bookList)
            {
                Console.WriteLine($"{item.title.PadRight(39, ' ')} {item.author.PadRight(15, ' ')} {item.price}");
            }

            Console.Read();
        }
    }
   
  
}

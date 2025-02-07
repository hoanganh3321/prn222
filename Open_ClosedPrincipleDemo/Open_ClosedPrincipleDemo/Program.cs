namespace Open_ClosedPrincipleDemo
{
    using System;
    using System.Collections.Generic;
    using Open_ClosedPrincipleDemo.Model;
    

    class Program
    {
        static List<Book> bookList;

        static void PrintBooks(List<Book> books)
        {
            Console.WriteLine(" List of Books");
            Console.WriteLine(" -----------------------------");
            foreach (var item in books)
            {
                Console.WriteLine($"{item.title.PadRight(39, ' ')} " +
                $"{item.author.PadRight(20, ' ')} {item.price}");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please, press 'yes' to read an extra file, ");
            Console.WriteLine("or any other key for a single file");
            var ans = Console.ReadLine();
            bookList = (ans.ToLower() != "yes") ? Utilities.Utilities.ReadData() :
            Utilities.Utilities.ReadDataExtra();
            PrintBooks(bookList);
        }
    }

}

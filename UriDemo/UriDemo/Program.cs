namespace UriDemo
{
    // các phương thức và thuộc tính giúp phân tích và thao tác với địa chỉ URL
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri info = new Uri("http://www.domain.com:80/info?id=123#fragment");
            Uri page = new Uri("http://www.domain.com/info/page.html");
            Console.WriteLine($"Host:{info.Host}");
            Console.WriteLine($"Port:{info.Port}");
            Console.WriteLine($"PathAndQuery:{info.PathAndQuery}");
            Console.WriteLine($"Query:{info.Query}");
            Console.WriteLine($"fragment:{info.Fragment}");
            Console.WriteLine($"Default HTTP port:{page.Port}");
            Console.WriteLine($"IsBaseOf:{info.IsBaseOf(page)}");
            Uri relative = info.MakeRelativeUri(page);
            Console.WriteLine($"IsAbsoluteUri:{relative.IsAbsoluteUri}");
            Console.WriteLine($"RelativeUri:{relative.ToString()}");
            Console.ReadLine();
        }
    }
}

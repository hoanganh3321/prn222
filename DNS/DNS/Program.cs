using System.Net;
//truy vấn thông tin DNS (Domain Name System) cho hai tên miền: www.contoso.com và 127.0.0.1 (localhost).
namespace DNS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('*', 30));
            var domainEntry = Dns.GetHostEntry("www.contoso.com");
            Console.WriteLine(domainEntry.HostName);
            foreach (var ip in domainEntry.AddressList)
            {
                Console.WriteLine(ip);
            }
            Console.WriteLine(new string('*', 30));
            var domainEntryAddress = Dns.GetHostEntry("127.0.0.1");
            Console.WriteLine(domainEntryAddress.HostName);
            foreach (var ip in domainEntryAddress.AddressList)
            {
                Console.WriteLine(ip);
            }
            Console.ReadLine();

        }
    }
}

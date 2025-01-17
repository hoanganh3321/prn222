namespace HTTPClientDemo
{
    // thực hiện một HTTP GET request đến một URL và in ra nội dung phản hồi từ máy chủ
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            String uri = "http://www.contoso.com";
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("message:{0}", ex.Message);
            }
        }
    }
}

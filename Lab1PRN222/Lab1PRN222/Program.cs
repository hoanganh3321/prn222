namespace server
{

    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    class ServerApp
    {
        static void Main()
        {
            //Khởi tạo Server và Cấu hình TCP Listener:

            string serverIp = "127.0.0.1"; // Localhost
            int port = 8080;

            // Khởi động và Lắng nghe Kết nối Client:
            TcpListener listener = new TcpListener(IPAddress.Parse(serverIp), port);

            try
            {
                listener.Start();
                Console.WriteLine($"Server started. Listening on {serverIp}:{port}...");

                //Xử Lý Kết Nối Client:
                while (true)
                {
                    //Chờ đợi và chấp nhận kết nối từ một client. Sau khi có kết nối, đối tượng TcpClient được tạo ra để quản lý kết nối này.
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client connected.");

                    //NetworkStream từ kết nối client, giúp đọc và ghi dữ liệu qua mạng.
                    NetworkStream stream = client.GetStream();

                    //Đọc Dữ Liệu từ Client:
                    //bộ đệm (buffer) lưu trữ dữ liệu
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    //trả về số byte thực tế đã đọc.
                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received from client: {receivedData}");


                    //Xử Lý Dữ Liệu và Gửi Phản Hồi:
                    string responseData = receivedData.ToUpper();

                   
                    byte[] responseBytes = Encoding.UTF8.GetBytes(responseData);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                    Console.WriteLine($"Sent to client: {responseData}");

                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Coffee_Shop_Socket_Programming_Server
{
       internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            server.Start();
            Console.WriteLine("CoffeeShop is waiting for customer orders...");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Customer connected!");

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                string customerOrder = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Order received: " + customerOrder);
                string response = "Order processed: " + customerOrder;
                byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }
        }
    }
}

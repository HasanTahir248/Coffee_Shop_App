using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Coffee_Shop_Socket_Programming_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 8888);
            NetworkStream stream = client.GetStream();
            Console.WriteLine("Enter Your Order: ");
            string order = Console.ReadLine();
            byte[] orderBytes = Encoding.ASCII.GetBytes(order);
            stream.Write(orderBytes, 0, orderBytes.Length);
            Console.WriteLine("Order sent: " + order);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            Console.WriteLine("Response from CoffeeShop: " + response);
        }
    }
}

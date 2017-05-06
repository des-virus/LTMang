using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LTMang {
    class Program {
        static void Main(string[] args) {
            // B1: Khai bao socket server, IPEndPoint, dulieunhan
            Socket server, client;
            IPEndPoint IPE_Server, IPE_Client;
            string receiveString, sendString;
            int receiveNumber;
            byte[] receiveBytes, sendBytes;

            // B2: Khoi tao socket server, IPEndPoint
            IPE_Server = new IPEndPoint(IPAddress.Any, 2017);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // B3: bind IPE cho socket server, so luong listen cung luc
            server.Bind(IPE_Server);
            server.Listen(10);
            Console.WriteLine("Bat dau lang nghe");

            // B4: Chap nhan ket noi tu client
            client = server.Accept();
            IPE_Client = (IPEndPoint) client.RemoteEndPoint;
            Console.WriteLine("Da nhan ket noi tu client: {0}:{1}", IPE_Client.Address, IPE_Client.Port);

            // B5: Nhan du lieu tu client
            while (true)
            {
                receiveBytes = new byte[1024 * 5];
                sendBytes = new byte[1024 * 5];
                receiveNumber = client.Receive(receiveBytes);
                receiveString = Encoding.ASCII.GetString(receiveBytes, 0, receiveNumber);
                Console.WriteLine($"Nhan duoc chuoi: {receiveString}");
                sendString = Console.ReadLine();
                sendBytes = Encoding.ASCII.GetBytes(sendString);
                client.Send(sendBytes);
            }

            // B6: Dong ket noi
            server.Close();
            client.Close();
        }
    }
}

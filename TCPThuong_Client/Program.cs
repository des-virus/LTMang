using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPThuong_Client {
    class Program {
        static void Main(string[] args) {
            // B1: Khai bao socket client, IPEndPoint server
            Socket clientSocket;
            IPEndPoint IPE_Server;
            string sendString, receiveString;
            byte[] receiveBytes, sendBytes;
            int receiveNumber;

            // B2: Khoi tao socket client, IPEndPoint server
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPE_Server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2017);

            // B3: Client connect den IPEndPoint cua server
            clientSocket.Connect(IPE_Server);
            if (clientSocket.Connected)
            {
                Console.WriteLine("Da ket noi thanh cong");
            }
            else
            {
                Console.WriteLine("Ket noi loi");
                Console.Read();
                return;
            }

            // B4: Doi nguoi dung nhap, gui sang server
            //      Lang nghe tu server va in chuoi ra
            while (true) {
                sendBytes = new byte[1024 * 5];
                receiveBytes = new byte[1024 * 5];
                sendString = Console.ReadLine();
                sendBytes = Encoding.ASCII.GetBytes(sendString);
                clientSocket.Send(sendBytes);
                receiveNumber = clientSocket.Receive(receiveBytes);
                receiveString = Encoding.ASCII.GetString(receiveBytes, 0, receiveNumber);
                Console.WriteLine($"Da nhan chuoi: {receiveString}");
            }

            // Dong ket noi
            clientSocket.Close();
        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(11000);

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            Console.WriteLine("Waiting for broadcast");

            try
            {
                while (true)
                {
                    byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("Received Message: " + receivedData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                udpClient.Close();
            }
        }
    }
}

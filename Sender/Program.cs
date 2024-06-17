using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect("127.0.0.1", 11000);

                Console.WriteLine("Enter the message to send:");
                string message = Console.ReadLine();
                byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                udpClient.Send(sendBytes, sendBytes.Length);
                Console.WriteLine("Message sent to the Receiver.");
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

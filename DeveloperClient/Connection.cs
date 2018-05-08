using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace DeveloperClient
{
    public class Connection
    {
        private Form1 loginForm { get; set; }
        private TcpClient client { get; set; }
        private NetworkStream netStream { get; set; }
        private byte[] bytes { get; set; }
        private string response{get; set;}

        private const string IP_ADDR = "134.129.125.246";
        private const int PORT = 39000;


        public Connection(Form1 sender)
        {
            loginForm = sender;
            bytes = new byte[1024];
        }

        private void ConnectToRemote()
        {
            client = new TcpClient(IP_ADDR, PORT);
            netStream = client.GetStream();
        }

        private bool GetResponse()
        {
            try
            {
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int bytesRead = netStream.Read(buffer, 0, client.ReceiveBufferSize);
                response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                return true;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: No response from client");
                return false;
            }
            
        }

        public bool Login(string userName, string password, string IDE)
        {
            try
            {
                ConnectToRemote();
                char[] tempChars = userName.ToCharArray();
                int length = tempChars.Length;
                List<Byte> byteList = ASCIIEncoding.ASCII.GetBytes(tempChars).ToList();
                byteList.AddRange(ASCIIEncoding.ASCII.GetBytes(":" + password));
                byteList.AddRange(ASCIIEncoding.ASCII.GetBytes(":" + IDE));
                byte[] bytesToSend = byteList.ToArray();
                netStream.Write(bytesToSend, 0, bytesToSend.Length);
                if (GetResponse())
                {
                    MessageBox.Show("Success!");
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to connect to server");
                return false;
            }
            return false;
            
        }









    }
}

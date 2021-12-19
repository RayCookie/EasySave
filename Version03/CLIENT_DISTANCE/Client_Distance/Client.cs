using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_Distance
{
    class DataModule
    {
        public string Action { get; set; }
        public string Name { get; set; }
    }
    class SocketClient
    {
        private static SocketClient instance = null;
        private static string serverip = "127.0.0.1";
        private static int port = 1100;
        private static Socket sender;

        public static string SetServerip
        {
            set
            {
                serverip = value;
                ClientInit();
            }
        }

        public static SocketClient GetInstance()
        {
            if (instance == null)
            {
                instance = new SocketClient();
            }

            return instance;
        }

        static SocketClient()
        {
            ClientInit();
        }

        private static void ClientInit()
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(serverip), port);
                sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
            }
            catch
            {
                //erreur
            }
        }

        public string GetDataTableRunning()
        {

            byte[] bytes = new byte[1048576];
            byte[] msg = Encoding.UTF8.GetBytes("GetDataTableRunning<EOF>");
            sender.Send(msg);
            int bytesRec = sender.Receive(bytes);
            var rep = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            //System.Diagnostics.Debug.WriteLine(rep);
            return rep;
        }

      /*  public string GetDataTableWaiting()
        {
            byte[] bytes = new byte[1048576];
            byte[] msg = Encoding.UTF8.GetBytes("GetDataTableWaiting<EOF>");
            int bytesSent = sender.Send(msg);
            int bytesRec = sender.Receive(bytes);
            var rep = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            //System.Diagnostics.Debug.WriteLine(rep);
            return rep;
        }*/

        public void Stop(string name)
        {
            var datastop = new DataModule() { Action = "Stop", Name = name };
            var datastopstring = JsonConvert.SerializeObject(datastop);
            byte[] msg = Encoding.UTF8.GetBytes(datastopstring + "<EOF>");
            sender.Send(msg);
        }

        public void Playpause(string name)
        {
            var datastop = new DataModule() { Action = "PlayPause", Name = name };
            var datastopstring = JsonConvert.SerializeObject(datastop);
            byte[] msg = Encoding.UTF8.GetBytes(datastopstring + "<EOF>");
            sender.Send(msg);
        }

        public void PlayX(string name)
        {
            var datastop = new DataModule() { Action = "PlayX", Name = name };
            var datastopstring = JsonConvert.SerializeObject(datastop);
            byte[] msg = Encoding.UTF8.GetBytes(datastopstring + "<EOF>");
            sender.Send(msg);
        }

        public void PlayAll()
        {
            var datastop = new DataModule() { Action = "PlayAll" };
            var datastopstring = JsonConvert.SerializeObject(datastop);
            byte[] msg = Encoding.UTF8.GetBytes(datastopstring + "<EOF>");
            sender.Send(msg);
        }

    }
}

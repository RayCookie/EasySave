using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Version03.ViewModel;



namespace Version03.Models
{
    class DataModule
    {
        public string Action { get; set; }
        public string Name { get; set; }
    }
    class Server
    {
        viewmodel es_save = new viewmodel();
        private static Server instance = null;
        private Socket listener;
        private List<Socket> handler = new List<Socket>();
        private int port = 1100;
        private string address;

        public static Server GetInstance()
        {
            if (instance == null)
            {
                instance = new Server();
            }
            return instance;
        }

        public void StartServer()
        {
            InitServer();
        }

        private void InitServer()
        {
            address = "127.0.0.1";
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(1);
            Debug.WriteLine("Server start on ip:{0}", address);
            new Thread(new ThreadStart(AddNewClients)).Start();
        }

        private void AddNewClients() //Pour accepter une demande de connexion
        {
            while (true)
            {
                Debug.WriteLine("Waiting for a connection...");
                var tamp = listener.Accept();
                handler.Add(tamp);
                Thread thread = new Thread(() => ReceiveDataClient(tamp));
                thread.Start();
            }
        }

        // communication avec un client X
        private void ReceiveDataClient(Socket handler)
        {
            bool stop = true;
            while (stop)
            {
                string data = null;
                byte[] bytes = null;

                while (true)
                {
                    bytes = new byte[1048576];
                    int bytesRec = 0;
                    try
                    {
                        bytesRec = handler.Receive(bytes);
                        data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            data = data.Replace("<EOF>", "");
                            switch (data)
                            {

                                case "GetDataTableRunning": //string (l'envoie pour display partie server)

                                    var tampo = es_save.ListBackup();
                                    handler.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tampo)));

                                    break;
                                
                                default:
                                    var rep = JsonConvert.DeserializeObject<DataModule>(data);
                                    switch (rep.Action)
                                    {
                                        case "Stop": //button stop 
                                           /* List<(string Nom, Thread t)> ls_thread = MainWindow.ls_thread;


                                            //x._manualR.Reset();
                                            EasySave execWork = EasySave.Getinstance();
                                            foreach ((string Nom, Thread t) x in ls_thread)
                                            {

                                                if (x.Nom == rep.Name)
                                                {
                                                    for (int i = 0; i < execWork.fullBackups.Count; i++)
                                                    {
                                                        if (execWork.fullBackups[i].Name == rep.Name)
                                                        {
                                                            execWork.fullBackups[i].Condition_pause = !execWork.fullBackups[i].Condition_pause;
                                                        }

                                                    }

                                                }

                                            }*/
                                            break;
                                        case "PlayPause":
                                           /* List<(string Nom, Thread t)> ls_thread2 = MainWindow.ls_thread;


                                            //x._manualR.Reset();
                                            EasySave execWorkr = EasySave.Getinstance();
                                            foreach ((string Nom, Thread t) x in ls_thread2)
                                            {

                                                if (x.Nom == rep.Name)
                                                {
                                                    for (int i = 0; i < execWorkr.fullBackups.Count; i++)
                                                    {
                                                        if (execWorkr.fullBackups[i].Name == rep.Name)
                                                        {
                                                            execWorkr.fullBackups[i].Condition_pause = !execWorkr.fullBackups[i].Condition_pause;
                                                        }

                                                    }

                                                }


                                                if (x.Nom == rep.Name)
                                                {
                                                    for (int i = 0; i < execWorkr.Diffbck.Count; i++)
                                                    {
                                                        if (execWorkr.Diffbck[i].Name == rep.Name)
                                                        {
                                                            execWorkr.Diffbck[i].Condition_pause = !execWorkr.Diffbck[i].Condition_pause;
                                                        }

                                                    }

                                                }

                                            }*/
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                            }

                            break;
                        }
                    }
                    catch
                    {
                        stop = false;
                        break;
                    }
                }
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void SendAll(byte[] data)
        {
            foreach (var client in this.handler)
            {
                client.Send(data);
            }
        }
    }
}

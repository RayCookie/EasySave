using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client_Distance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class Etat_Inactive
    {
        public static string filePath = @"C:\Users\hp\source\repos\RayCookie\EasySave\Version03\Version03\bin\Debug\netcoreapp3.0\State\state.json";

        // Declaration of properties that are used for saving information for the report file in JSON
        public string SaveName { get; set; }
        public string BackupDate { get; set; }
        public bool SaveState { get; set; }
        public string SourceFile { get; set; }
        public string TargetFile { get; set; }
        public float TotalFile { get; set; }
        public long TotalSize { get; set; }
        public float Progress { get; set; }
        public long FileRest { get; set; }
        public long TotalSizeRest { get; set; }

       

    }

    public partial class MainWindow : Window
    {
        Etat_Inactive list;
        List<string> etat;
        SocketClient Sk_client = SocketClient.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
            
            Thread Recup_Etat = new Thread(Suivit_Loaded);
            Recup_Etat.Start();
        }
        private void Suivit_Loaded()
        {
            while (true)
            {

                Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Send, new Action(delegate ()
                {

                    listName.Items.Clear();

                    var names = JsonConvert.DeserializeObject<List<string>>(Sk_client.GetDataTableRunning());
                    foreach (var name in names)
                    {
                        listName.Items.Add(name);
                    }

                   /* test_grid.ItemsSource = null;
                    test_grid.ItemsSource = JsonConvert.DeserializeObject<List<Etat_Inactive>>(Sk_client.GetDataTableRunning());
                   */

                }));
                Thread.Sleep(200);
            }
        }
        private void Works_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void Datagris_LoadingRaw(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void test_grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                list = (Etat_Inactive)test_grid.SelectedItems[0];
                //test_labs.Content = list.SaveName;
            }
            catch
            {

            }
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            Sk_client.Stop(list.SaveName);
        }

        private void pause_button_Click(object sender, RoutedEventArgs e)
        {
            Sk_client.Playpause(list.SaveName);
        }

        private void listName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

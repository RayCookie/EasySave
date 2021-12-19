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
        public static string filePath = @"..\..\..\state.json";

        public string Name { get; set; }
        public string Progression { get; set; }
        public string State = "INACTIVE";
    }

    public partial class MainWindow : Window
    {
        Etat_Inactive list;
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

                    
                    test_grid.ItemsSource = null;
                    test_grid.ItemsSource = JsonConvert.DeserializeObject<List<Etat_Inactive>>(Sk_client.GetDataTableRunning());


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
                test_labs.Content = list.Name;
            }
            catch
            {

            }
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            Sk_client.Stop(list.Name);
        }

        private void pause_button_Click(object sender, RoutedEventArgs e)
        {
            Sk_client.Playpause(list.Name);
        }
    }
}

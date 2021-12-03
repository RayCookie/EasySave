using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfPROJECT.ViewModel;

namespace WpfPROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private viewmodel viewmodel;
        public MainWindow()
        {
            InitializeComponent();
            viewmodel = new viewmodel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string saveName = "";
            string sourceDir = "";
            string targetDir = "";
            //string mirrorDir = "";

            saveName = tName.Text;
            sourceDir = tSource.Text;
            targetDir = tDestination.Text;
            if (tName.Text.Length.Equals(0) || tSource.Text.Length.Equals(0) || tDestination.Text.Length.Equals(0))
            {


                result.Text = " Please complete all fields !  ";
            }
            else
            {
                 viewmodel.MenuSub(saveName, sourceDir, targetDir, 1, "");
                result.Text = " BACKUP Added! ";
            }
           
        }

        
    }
}

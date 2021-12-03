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
            ShowListBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//add work button
        {
            string saveName = "";
            string sourceDir = "";
            string targetDir = "";
            string mirrorDir = "";


            saveName = tName.Text;
            sourceDir = tSource.Text;
            targetDir = tDestination.Text;
            if (Complete_Save_Button.IsChecked.Value)//If the button of the full backup is selected
            {
                if (tName.Text.Length.Equals(0) || tSource.Text.Length.Equals(0) || tDestination.Text.Length.Equals(0))
                {


                    result.Text = " Please complete all fields !  ";
                }
                else
                {
                    int type = 1;
                    viewmodel.MenuSub(saveName, sourceDir, targetDir, type, "");
                    result.Text = "Complete BACKUP Added! ";
                    ShowListBox();
                }
            }
            else if (diff_button.IsChecked.Value)//If the button of the differentiel backup is selected
            {
                if (tName.Text.Length.Equals(0) || tSource.Text.Length.Equals(0) || tDestination.Text.Length.Equals(0) || tMirror.Text.Length.Equals(0))
                {


                    result.Text = " Please complete all fields !  ";
                }
                else
                {
                    int type = 2;
                    mirrorDir = tMirror.Text;
                    viewmodel.MenuSub(saveName, sourceDir, targetDir, type, mirrorDir);
                    result.Text = "Differentiel BACKUP Added! ";
                    ShowListBox();
                }
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//excute work button
        {
            if (listName.SelectedItem != null)
            {
                foreach (string filename in listName.SelectedItems)
                {
                    viewmodel.loadSave(filename);
                    result.Text = " BACKUP SELECTED Saved Succefully! ";
                }
            }
            else
            {
                result.Text = " please add or select a name in the list ";
            }
        }
        private void ShowListBox() //Function that displays the names of the backups in the list.
        {

            listName.Items.Clear();

            List<string> names = viewmodel.ListBackup();
            foreach(string name in names)
            {
                listName.Items.Add(name);
            }
        }
    }
}

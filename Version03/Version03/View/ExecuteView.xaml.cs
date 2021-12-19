using System;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Version03.ViewModel;

namespace Version03.View
{
    /// <summary>
    /// Logique d'interaction pour ExecuteView.xaml
    /// </summary>
    ///  private viewmodel viewmodel;

    public partial class ExecuteView : UserControl
    {
        private viewmodel viewmodel;
        int langue = 1;
        public ExecuteView()
        {
            InitializeComponent();
            viewmodel = new viewmodel();
            ShowListBox();
            Models.Server server = Models.Server.GetInstance();
            server.StartServer();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)//excute work button
        {
            if (listName.SelectedItem != null)
            {
                if (Process.GetProcessesByName("Calculator").Length == 0)
                {
                    foreach (string filename in listName.SelectedItems)
                    {
                        viewmodel.loadSave(filename);
                        

                    }
                    if (langue == 1)
                    {
                        MessageBox.Show("BACKUP SELECTED Saved Succefully!", "SAVE BackUp");
                    }
                    else if (langue == 2)
                    {
                        MessageBox.Show("travailles sélectionées ajouté ! ", "ERREUR");
                    }
                }
                else

                {
                    if (langue == 1)
                    {
                        MessageBox.Show("close calculator and try again", "ERROR");
                    }
                    else if (langue == 2)
                    {
                        MessageBox.Show("fermez la calculatrice et réesseyez ", "ERREUR");
                    }

                }

            }
            else
            {
                if (langue == 1)
                {
                    MessageBox.Show(" please add or select a name in the list", "ERROR");
                }
                else if (langue == 2)
                {
                    MessageBox.Show("crée ou choisissez un travail", "ERREUR");
                }


            }
        }
        private void ShowListBox() //Function that displays the names of the backups in the list.
        {

            listName.Items.Clear();

            List<string> names = viewmodel.ListBackup();
            foreach (string name in names)
            {
                listName.Items.Add(name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.pause();
            if (langue == 1)
            {
                MessageBox.Show(" load work paused ", "!!!");
            }
            else if (langue == 2)
            {
                MessageBox.Show("travail en pause", "!!!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            viewmodel.stop();
            if (langue == 1)
            {
                MessageBox.Show(" load work stoped ", "!!!");
            }
            else if (langue == 2)
            {
                MessageBox.Show("travail arreter", "!!!");
            }
        }

        private void listName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

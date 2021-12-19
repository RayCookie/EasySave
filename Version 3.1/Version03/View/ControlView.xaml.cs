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
    /// Logique d'interaction pour ControlView.xaml
    /// </summary>
    public partial class ControlView : UserControl
    {
        private viewmodel viewmodel;
        int langue = 0;
        public ControlView()
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

                    if (langue == 1)
                    {
                        MessageBox.Show(" Please complete all fields !!", "ERROR");
                    }
                    else if (langue == 2)
                    {
                        MessageBox.Show("Remplisser tous les champs !!", "ERREUR");
                    }

                }
                else
                {
                    int type = 1;
                    viewmodel.MenuSub(saveName, sourceDir, targetDir, type, "");
                    if (langue == 1)
                    {
                        MessageBox.Show("Complete BACKUP Added!", "BackUp ADD");
                    }
                    else if (langue == 2)
                    {
                        MessageBox.Show("Travaill complet ajouté!");
                    }
                    ShowListBox();
                }
            }
            else if (diff_button.IsChecked.Value)//If the button of the differentiel backup is selected
            {
                if (tName.Text.Length.Equals(0) || tSource.Text.Length.Equals(0) || tDestination.Text.Length.Equals(0) || tMirror.Text.Length.Equals(0))
                {
                    if (langue == 1)
                    {
                        MessageBox.Show(" Please complete all fields !!", "ERROR");
                    }
                    else if (langue == 2)
                    {
                        MessageBox.Show("Remplisser tous les champs !!", "ERREUR");
                    }

                }
                else
                {
                    int type = 2;
                    mirrorDir = tMirror.Text;
                    viewmodel.MenuSub(saveName, sourceDir, targetDir, type, mirrorDir);
                    if (langue == 1)
                    {
                        MessageBox.Show("differentiel BACKUP Added!", "BackUp ADD");
                    }
                    else if (langue == 2)
                    {
                        MessageBox.Show("Travaill différentielle ajouté!");
                    }

                    ShowListBox();
                }
            }
            else
            {
                if (langue == 1)
                {
                    MessageBox.Show(" Please complete all fields !!", "ERROR");
                }
                else if (langue == 2)
                {
                    MessageBox.Show("Remplisser tous les champs !!", "ERREUR");
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog(); //Declaration of the method to open the window to choose the folder path.
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tSource.Text = dialog.FileName; //Displays the path in the window text.
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog(); //Declaration of the method to open the window to choose the folder path.
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tDestination.Text = dialog.FileName; //Displays the path in the window text.
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog(); //Declaration of the method to open the window to choose the folder path.
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                tMirror.Text = dialog.FileName; //Displays the path in the window text.
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"..\..\..\Ressources\CryptExtension.json");
        }
        
    }
}

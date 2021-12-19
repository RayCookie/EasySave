﻿using System;
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
                while (Process.GetProcessesByName("Calculator").Length != 0)
                {
                    
                        MessageBox.Show("Work paused ,close SoftwareWork to continue", "ERROR");
                    
                }
                    foreach (string filename in listName.SelectedItems)
                    {
                        viewmodel.loadSave(filename);
                        

                    }
                   
                        MessageBox.Show("BACKUP SELECTED Saved Succefully!", "SAVE BackUp");
                    
                    
              

            }
            else
            {
               
                    MessageBox.Show(" please add or select a name in the list", "ERROR");
                
                

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
            
                MessageBox.Show(" load work paused ", "!!!");
            
           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            viewmodel.stop();
            
                MessageBox.Show(" load work stoped ", "!!!");
          
            
        }

        private void listName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

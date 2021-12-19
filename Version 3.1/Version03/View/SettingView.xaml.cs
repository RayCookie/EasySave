using System;
using Microsoft.WindowsAPICodePack.Dialogs;

using System.Collections.Generic;
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
using System.Diagnostics;

namespace Version03.View
{
    /// <summary>
    /// Logique d'interaction pour SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        private ControlView controlView;
        public SettingView()
        {
            controlView = new ControlView();
            InitializeComponent();

        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", @"..\..\..\Ressources\CryptExtension.json");
        }

    }
}

using System;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            controlView.english(1);
        }

        private void french_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

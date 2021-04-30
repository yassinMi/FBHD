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
using System.Windows.Shapes;

namespace fbhd
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = (Config)mw.mainSession.MainConfig;
            ConfigObj = (Config)mw.mainSession.MainConfig;
        }

        static MainWindow mw = (MainWindow)App.Current.MainWindow;




        public Config ConfigObj
        {
            get { return (Config)GetValue(ConfigObjProperty); }
            set { SetValue(ConfigObjProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConfigObj.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfigObjProperty =
            DependencyProperty.Register("ConfigObj", typeof(Config), typeof(SettingsWindow), new PropertyMetadata(null));

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void SaveConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigObj.Save();
        }
    }
}

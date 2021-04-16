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

namespace fbhd
{
    /// <summary>
    /// Interaction logic for CLWControl.xaml
    /// </summary>
    public partial class CLWControl : UserControl
    {
        public CLWControl()
        {
            InitializeComponent();
            CoreCustomListWatcher = (CustomLW)DataContext;
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CoreCustomListWatcher = (CustomLW)DataContext;
            
        }







        public CustomLW CoreCustomListWatcher
        {
            get { return (CustomLW)GetValue(CoreCustomListWatcherProperty); }
            set { SetValue(CoreCustomListWatcherProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CoreCustomListWatcher.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoreCustomListWatcherProperty =
            DependencyProperty.Register("CoreCustomListWatcher", typeof(CustomLW), typeof(CLWControl), new PropertyMetadata(null));



        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            mainPopup.IsOpen = true;

        }

        private void intervalIncTb_OnDecrease(object sender, RoutedEventArgs e)
        {
            CoreCustomListWatcher.Interval -= 30000;

        }

        private void intervalIncTb_OnIncrease(object sender, RoutedEventArgs e)
        {
                CoreCustomListWatcher.Interval += 30000;

        }

        private void intervalIncTb_Loaded(object sender, RoutedEventArgs e)
        {
            intervalIncTb.IncreaseFunction = null; //important to override the default int increaser
            return;
        }

       
        private void StartStopButt_Click(object sender, RoutedEventArgs e)
        {
            if (CoreCustomListWatcher.IsWatching)
            {
                CoreCustomListWatcher.StopWatching();
            }
            else
            {
                CoreCustomListWatcher.StartWatching();
            }
        }

        static MainWindow mw = (MainWindow)Application.Current.MainWindow;
        private void UnreadNewsButt_Click(object sender, RoutedEventArgs e)
        {
            mw.PopupNews(CoreCustomListWatcher.UnreadNews, CoreCustomListWatcher, CoreCustomListWatcher.Name, false);
        }
    }
}

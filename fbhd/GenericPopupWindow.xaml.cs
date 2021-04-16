using fbhd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for GenericPopupWindow.xaml
    /// </summary>
    public partial class GenericPopupWindow : Window
    {
        public GenericPopupWindow()
        {
            InitializeComponent();
        }

        MainWindow mw =(MainWindow) Application.Current.MainWindow;

        public void setItemsSource(IEnumerable<INotifableItem> itemsSource_, IWatch listWatcher,string windowTitle)
        {

            Title = windowTitle;
            mainItemsControl.ItemsSource = itemsSource_;
            // if( listWatcher.GetType()== typeof(ListWatcher<ExpandoLWItemObject>))
            try
            {
                ListWatcherObj = listWatcher;

            }
            catch (Exception)
            {

                
            }
        }

        private void ok_Butt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public IWatch ListWatcherObj { get; set; }

        private void MarkAsRead_Butt_Click(object sender, RoutedEventArgs e)
        {
            Trace.Assert(ListWatcherObj != null, "mi: cannot save changes because ListWatcherObj is null");
            if (ListWatcherObj == null) { Close(); return; }
            
            ListWatcherObj.MarkAllAsRead();
        
            Close();
            
        }

        
    }
}

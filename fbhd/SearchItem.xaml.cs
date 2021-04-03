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
    /// Interaction logic for SearchItem.xaml
    /// </summary>
    public partial class SearchItem : UserControl
    {
        public SearchItem()
        {
            InitializeComponent();
            mw  =  (MainWindow)Application.Current.MainWindow;
        }


        public static MainWindow mw;

        public SearchElement CoreSearchElement
        {
            get { return (SearchElement)GetValue(CoreSearchElementProperty); }
            set { SetValue(CoreSearchElementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CoreSearchElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoreSearchElementProperty =
            DependencyProperty.Register("CoreSearchElement", typeof(SearchElement), typeof(SearchItem), new PropertyMetadata(null));

        private void download_butt_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext == null) return;
            if (string.IsNullOrWhiteSpace(((SearchElement)DataContext).Url)) return;
            mw.addNewFBHDTask(((SearchElement)DataContext).Url, TaskType.mp4Task);
        }
    }
}

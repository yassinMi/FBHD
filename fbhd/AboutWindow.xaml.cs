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
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationInfo();
        }



        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DragableHead_DragEnter(object sender, DragEventArgs e)
        {

        }


        

        private void DragableHead_DragOver(object sender, DragEventArgs e)
        {
            this.DragMove();
        }
    }
}

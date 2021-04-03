using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace fbhd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void x_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// closes the parent window, which is the templated parent of this x_button,
       ///  since its a part of a tmeplate
        /// </summary>
        private void x_Click_1(object sender, RoutedEventArgs e)
        {
            ((Window)((System.Windows.Controls.Button)sender).TemplatedParent).Close();
        }
    }
}

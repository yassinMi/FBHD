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
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public NewTaskWindow()
        {
            InitializeComponent();
        }

        static MainWindow mw = ((MainWindow)Application.Current.MainWindow); 


        private void proceed()
        {
            //return;
            if(tb_url.Text == "")
            {
                tb_url.Text = "https://www.facebook.com/1018880351564908/posts/3119790674807188/https://www.facebook.com/274711329850736/videos/1885892988208359/https://www.facebook.com/fatty0028/videos/446807919611792/https://www.facebook.com/ChillKKoMusic/videos/542385369786669/https://www.facebook.com/TheGalaxyNS/videos/899251123836087/;https://www.facebook.com/247282553161497/posts/306715487218203/https://www.facebook.com/TheGalaxyNS/videos/243434217053056/https://www.facebook.com/103828303794732/videos/108587426652153/https://www.facebook.com/backgroundmusicstore/videos/1088943091584575/https://www.facebook.com/backgroundmusicstore/videos/776990662996052/";
            }
            List<string> urls =  Fucs.extractUrls(tb_url.Text);
            foreach (string url_item in urls)
            {
                //mw.addNewTask(url_item, typecommbo_type.Value );
                mw.addNewFBHDTask(url_item, typecommbo_type.Value);

            }


            DialogResult = true;
            this.Close();
        }

        private void okButt_Click(object sender, RoutedEventArgs e)
        {
            proceed();

        }

        private void CancelButt_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tb_url.Focus();
        }

        

        private void x_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void tb_url_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                proceed();
            }
        }
    }

    
}

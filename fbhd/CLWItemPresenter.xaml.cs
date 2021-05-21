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
    /// Interaction logic for CLWItemPresenter.xaml
    /// </summary>
    public partial class CLWItemPresenter : UserControl
    {
        public CLWItemPresenter()
        {
            InitializeComponent();
        }

        private void moreActionsButton_Click(object sender, RoutedEventArgs e)
        {
            moreActionsPopup.IsOpen = true;
            
        }

        private void CopyUrlButt_Click(object sender, RoutedEventArgs e)
        {

            Clipboard.SetText(this.linklbl.Text);
            MI.Verbose("URL copied", 2);
        }

        private async void DloadButton_Click(object sender, RoutedEventArgs e)
        {


            var url = linklbl.Text;
            //url = "http://fsdmfes.ac.ma/uploads/Docs/Files/2021-05-20-01-54-05_183bddf1b0d6b398ccf9be4dfe32f87bb0364a09.pdf";

            Uri asUri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out asUri))
            {
                MessageBox.Show("bad url"); return;
            }


            var filename = asUri.LocalPath;
            filename = System.IO. Path.GetFileName(filename);

            var saveDlg = new Ookii.Dialogs.Wpf.VistaSaveFileDialog();
            saveDlg.FileName = filename;

            var notCanceled = saveDlg.ShowDialog();
            if ((!notCanceled.HasValue) || !notCanceled.Value)
            {
                // action canceled
                return;
            }

            
            filename = saveDlg.FileName;

            var crl = new WebClient.cURL();
            var downloadResult= await crl.DownloadBinary(url, filename);
            if (downloadResult.Success)
            {
                MessageBox.Show($"Successfully saved {filename}", "downloaded", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"couldn't save file, curl exited with code {downloadResult.agentReturnCode}", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void title_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(this.title.Text);
            MI.Verbose("Title copied", 2);
        }
    }
}

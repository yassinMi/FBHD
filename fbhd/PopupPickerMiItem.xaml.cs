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
    /// Interaction logic for PopupPickerMiItem.xaml
    /// </summary>
    /// 


    public partial class PopupPickerMiItem : UserControl
    {
        public PopupPickerMiItem()
        {
            InitializeComponent();
        }



        public KeyValuePair<string,string> myPairItem
        {
            get { return (KeyValuePair<string, string>)GetValue(myPairItemProperty); }
            set { SetValue(myPairItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for myPairItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty myPairItemProperty =
            DependencyProperty.Register("myPairItem", typeof(KeyValuePair<string, string>), typeof(PopupPickerMiItem), new PropertyMetadata(null));




        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Key.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(string), typeof(PopupPickerMiItem), new PropertyMetadata(null));




        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(PopupPickerMiItem), new PropertyMetadata(null));




        public event EventHandler Click;

        private void Border_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState( this,"Highlighted", false);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "normal", false);

        }
    }
}

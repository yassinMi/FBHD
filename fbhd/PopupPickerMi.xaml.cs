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
    /// Interaction logic for PopupPickerMi.xaml
    /// </summary>
    public partial class PopupPickerMi : UserControl 
    {


        public event EventHandler<KeyValuePair<string,string>> Picked ;




        public List<KeyValuePair<string,string>> PairItems
        {
            get { return (List<KeyValuePair<string, string>>)GetValue(PairItemsProperty); }
            set { SetValue(PairItemsProperty, value);


            }
        }

        // Using a DependencyProperty as the backing store for PairItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PairItemsProperty =
            DependencyProperty.Register("PairItems", typeof(List<KeyValuePair<string, string>>), typeof(PopupPickerMi), new PropertyMetadata(null));



        public ItemCollection ItemsMi
        {
            get { return (ItemCollection)GetValue(ItemsMiProperty); }
            set { SetValue(ItemsMiProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsMi.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsMiProperty =
            DependencyProperty.Register("ItemsMi", typeof(ItemCollection), typeof(PopupPickerMi), new PropertyMetadata(null));



        public PopupPickerMi()
        {
            InitializeComponent();

       
            
            
        }

        private void PopupPickerMiItem_Click(object sender, EventArgs e)
        {
            if(Picked != null)
            {
                Picked(this, ((PopupPickerMiItem) sender).myPairItem );
            }
        }

        internal void updateMyBindings()
        {
            this.GetBindingExpression(PopupPickerMi.PairItemsProperty).UpdateTarget();
        }
    }
}

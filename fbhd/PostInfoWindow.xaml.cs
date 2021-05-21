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
    /// Interaction logic for PostInfoWindow.xaml
    /// </summary>
    public partial class PostInfoWindow : Window
    {
        public PostInfoWindow()
        {
            InitializeComponent();
            
        }


        public void Init(Post PostObj)
        {
            this.PostObject = PostObj;
            this.DataContext = PostObj;
        }


        public Post PostObject
        {
            get { return (Post)GetValue(PostObjectProperty); }
            set { SetValue(PostObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PostObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostObjectProperty =
            DependencyProperty.Register("PostObject", typeof(Post), typeof(PostInfoWindow), new PropertyMetadata(new Post()));



        private void UrlLbl_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

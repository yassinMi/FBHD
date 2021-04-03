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
    /// Interaction logic for ButtonMi.xaml
    /// </summary>
    public partial class ButtonMi : UserControl 
    {
        public ButtonMi()
        {
            InitializeComponent();


        }







        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == ButtonMi.isDisabledProperty)
            {
                VisualStateManager.GoToState(this, (bool) e.NewValue ? "disabled" : "Normal", false);

            }
        }

        public bool isDisabled
        {
            get { return (bool)GetValue(isDisabledProperty); }
            set { SetValue(isDisabledProperty, value);

                //MessageBox.Show(value.ToString());
            }
        }

        // Using a DependencyProperty as the backing store for isDisabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isDisabledProperty =
            DependencyProperty.Register("isDisabled", typeof(bool), typeof(ButtonMi), new PropertyMetadata(false));




        public string textcaption
        {
            get { return (string)GetValue(textcaptionProperty); }
            set { SetValue(textcaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty textcaptionProperty =
            DependencyProperty.Register("textcaption", typeof(string), typeof(ButtonMi), new PropertyMetadata(null));





        public Visibility captionVisibility
        {
            get { return (Visibility)GetValue(captionVisibilityProperty); }
            set { SetValue(captionVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for captionVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty captionVisibilityProperty =
            DependencyProperty.Register("captionVisibility", typeof(Visibility), typeof(ButtonMi), new PropertyMetadata(Visibility.Collapsed));





        public System.Windows.Thickness captionMargin
        {
            get { return (Thickness)GetValue(captionMarginProperty); }
            set { SetValue(captionMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for captionMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty captionMarginProperty =
            DependencyProperty.Register("captionMargin", typeof(Thickness), typeof(ButtonMi), new PropertyMetadata(new Thickness(0)));





        public System.Windows.Media.ImageSource iconSource
        {
            get { return (System.Windows.Media.ImageSource)GetValue(iconSourceProperty); }
            set { SetValue(iconSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for iconSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty iconSourceProperty =
            DependencyProperty.Register("iconSource", typeof(System.Windows.Media.ImageSource), typeof(Ybutt), new PropertyMetadata(null));



       
        //
        // Summary:
        //     Occurs when a System.Windows.Controls.Button is clicked.
       
        public event RoutedEventHandler Click;

        private void typeSwitchClick(object sender, RoutedEventArgs e)
        {
           
        }

        public void coreButton_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void userControl_MouseEnter(object sender, MouseEventArgs e)
        {
           // MessageBox.Show(VisualStateGroup.CurrentState.Name);

            if (VisualStateGroup.CurrentState.Name == "disabled")
            {
                return;
            }
            VisualStateManager.GoToState(this, "Hover", false);

        }

        private void userControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.VisualStateGroup.CurrentState.Name == "disabled")
            {

                return;
            }
            VisualStateManager.GoToState(this, "Normal", false);
        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, isDisabled ? "disabled" : "Normal", false);

        }

        private void userControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.VisualStateGroup.CurrentState.Name == "disabled")
            {
                return;
            }
            if (Click != null)
                this.Click.Invoke(this, e);
            
        }
    }
}

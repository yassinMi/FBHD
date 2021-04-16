using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for ResolutionPicker.xaml
    /// </summary>
    public partial class ResolutionPicker : UserControl
    {

        public struct ResolutionPickedArgs
        {
           public Resolution Picked;

        }

        public event EventHandler<ResolutionPickedArgs> PickedResolutionChanged;


        static MainWindow mw;
        public class lightGreyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return ((bool)value)== true ? (new SolidColorBrush(Colors.Orange)  ) : (new SolidColorBrush(Colors.MediumOrchid));
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public ResolutionPicker()
        {
            InitializeComponent();


            Resolution[] arrofresos =
                {

                new Resolution(720) ,
                Resolution.Source ,
                new Resolution(360) ,
             new Resolution(1080) ,
                new Resolution(144)

            };

            List<Resolution> li = new List<Resolution>();
            foreach (Resolution item in arrofresos)
            {
                li.Add(item);
            }



            mw= (MainWindow)Application.Current.MainWindow;
            //this.Resolutions = li;


        }


        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);


            if(e.Property == selectedResolutionProperty)
            {
                
                 
            }

            /*if(e.Property != ResolutionPicker.ResolutionsProperty)
            {
                return;
            }


            List<Resolution> new_list = (List <Resolution>) e.NewValue;
              //  this.clearResoItems();
            foreach (Resolution item in new_list)
            {
                return;
                appendResoItem(item, false);

            }*/

        }

        private void reso1_Checked(object sender, RoutedEventArgs e)
        {
            
        }


        private void on_item_checked(object sender, RoutedEventArgs e)
        {
            this.selectedResolution = (Resolution)((RadioButton)sender).Tag;
            //MessageBox.Show(this.selectedResolution._String());
            if (PickedResolutionChanged != null)
            {

                PickedResolutionChanged(this, new ResolutionPickedArgs() {Picked= (Resolution)((RadioButton)sender).Tag });
            }
             
        }

        private void appendResoItem(Resolution resolution, bool isCheched)
        {
            /*RadioButton rb = new RadioButton();

            rb.IsChecked = isCheched;
            rb.Content = resolution._String();
            rb.Tag = resolution;
            rb.Margin = new Thickness(4,0,4,0);
            rb.VerticalAlignment = VerticalAlignment.Center;
            rb.HorizontalAlignment = HorizontalAlignment.Center;
            rb.Template = mainreso.Template;
            rb.Checked += on_item_checked;

  
            Binding b = new Binding();
            b.Source = rb;
            b.Path = new PropertyPath(RadioButton.IsCheckedProperty);
            b.Converter = new lightGreyConverter();
            rb.SetBinding(RadioButton.ForegroundProperty, b);

            resosCountainer.Children.Add(rb);

            */


        }

        private void clearResoItems()
        {
            //resosCountainer.Children.Clear();
        }

        public List<Resolution> Resolutions
        {
            get { return (List<Resolution>)GetValue(ResolutionsProperty); }
            set {


                SetValue(ResolutionsProperty, value);

                return;
                //the folowing code is moved to the onPropertyChanged event so that it gets executed also when the binding controles the Reesolutions property
                this.clearResoItems();
                foreach (Resolution item in value)
                {

                    appendResoItem(item, false);

                }
               

              

                
            }
        }

        

        // Using a DependencyProperty as the backing store for Resolutions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ResolutionsProperty =
            DependencyProperty.Register("Resolutions", typeof(List<Resolution>), typeof(ResolutionPicker), new PropertyMetadata(new List<Resolution>()

                ));






        public Resolution selectedResolution
        {
            get { return (Resolution)GetValue(selectedResolutionProperty); }
            set { SetValue(selectedResolutionProperty, value);

                //foreach (RadioButton item in resosCountainer.Children)
               // {
                //    if(item.Tag == value) {
                //        item.IsChecked = true;
                //    }

               // }
               // mw.selectedTask.taskProperties.resolutionSettings.UserPicked = value;
               // mw.selectedTask.taskProperties.resolutionSettings.isChoiceTargeted =
              //     mw.selectedTask.isResolved;


            }
        }

        // Using a DependencyProperty as the backing store for selectedResolution.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedResolutionProperty =
            DependencyProperty.Register("selectedResolution", typeof(Resolution), typeof(ResolutionPicker), new PropertyMetadata(null));










        public static Brush DefaultPickedForeground  = new SolidColorBrush( (Color) ColorConverter.ConvertFromString("#FF20C9BF"));
        public static Brush DefaultUnpickedForeground = new SolidColorBrush(Colors.WhiteSmoke);

        public Brush ForegroundPicked
        {
            get { return (Brush)GetValue(ForegroundPickedProperty); }
            set { SetValue(ForegroundPickedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForegroundPicked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundPickedProperty =
            DependencyProperty.Register("ForegroundPicked", typeof(Brush), typeof(ResolutionPicker), new PropertyMetadata(DefaultPickedForeground));


        public Brush ForegroundUnpicked
        {
            get { return (Brush)GetValue(ForegroundUnpickedProperty); }
            set { SetValue(ForegroundUnpickedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ForegroundPicked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundUnpickedProperty =
            DependencyProperty.Register("ForegroundUnPicked", typeof(Brush), typeof(ResolutionPicker), new PropertyMetadata(DefaultUnpickedForeground));









        internal void updateMyBindings()
        {

            GetBindingExpression(ResolutionPicker.ResolutionsProperty).UpdateTarget();
        }
    }
}

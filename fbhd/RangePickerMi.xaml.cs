using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fbhd
{


    public class RangePickerPercentToPosition : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;

            RangePickerMi val = (RangePickerMi)value;
            string param = (string)parameter;

            return (param == "min") ? (val.Width * val.Min) : (val.Width * val.Max);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Interaction logic for RangePickerMi.xaml
    /// </summary>
    public partial class RangePickerMi : UserControl
    {
        public RangePickerMi()
        {
            InitializeComponent();
            RangeChanged += (s, e) =>
            {
                Min = e.NewValue.Min; Max = e.NewValue.Max;
                Range = new Range(Min, Max);

            };

            Loaded += (s, e) =>
            {
                Min = 0;
                Max = 1;
            };
        }





        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.Property == MaxProperty)
            {
                Thickness InnerBorderMargin = InnerBorder.Margin;
                InnerBorderMargin.Right = -1 + (  (1-(double)e.NewValue) * this.ActualWidth);
                InnerBorder.Margin = InnerBorderMargin;
               
            }
            if (e.Property == MinProperty)
            {

                Thickness InnerBorderMargin = InnerBorder.Margin;
                InnerBorderMargin.Left = -1 + ( (double)e.NewValue * this.ActualWidth);
                InnerBorder.Margin = InnerBorderMargin;
            }

            if (e.Property == RangeProperty)
            {
                Min = ((Range)e.NewValue).Min;
                Max = ((Range)e.NewValue).Max;
            }
        }

        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value);

                double center = ThumbMax.ActualWidth / 2;
                Canvas.SetLeft(ThumbMax, (double)value * this.ActualWidth - center);



            }
        }

        // Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(double), typeof(RangePickerMi), new PropertyMetadata((double)1));



        public double Min
        {
            get { return (double)GetValue(MinProperty); }
            set { SetValue(MinProperty, value);

                double center = ThumbMin.ActualWidth / 2;
                Canvas.SetLeft(ThumbMin, (double)value * this.ActualWidth - center);


            }
        }

        // Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(double), typeof(RangePickerMi), new PropertyMetadata((double)0));

        private void MaxHandle_DragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine("drag over");

            var pos = e.GetPosition(OutterBorder);
            //Canvas.SetLeft(MaxHandle, pos.X);
            Debug.WriteLine(pos);
            
        }

        private void MaxHandle_DragLeave(object sender, DragEventArgs e)
        {
            Debug.WriteLine("drag leave");

            var pos = e.GetPosition(OutterBorder);
            //Canvas.SetLeft(MaxHandle, pos.X);
            Debug.WriteLine(pos);
            
        }


        public event EventHandler<RangeChangedEventArgs> RangeChanged;
        public event MouseEventHandler MinHandlerMouseEntered;








        public Range Range
        {
            get { return (Range)GetValue(RangeProperty); }
            set { SetValue(RangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Range.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RangeProperty =
            DependencyProperty.Register("Range", typeof(Range), typeof(RangePickerMi), new PropertyMetadata(new Range(0,1)));




        private void MaxHandle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }



        private void thumb_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            Debug.WriteLine("thumb drag started");
           
        }

        private void thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var thumb = (Thumb)sender;
            if(thumb.Name == "ThumbMax")
            {
                Canvas.SetLeft(thumb,  Math.Min( Canvas.GetLeft(thumb) + e.HorizontalChange ,
                    OutterBorder.ActualWidth - (ThumbMin.ActualWidth / 2)));

            }
            else if(thumb.Name == "ThumbMin")
            {
                Canvas.SetLeft(thumb, Math.Max(Canvas.GetLeft(thumb) + e.HorizontalChange,
                 - (ThumbMin.ActualWidth / 2)));


            }




            RangeChanged?.Invoke(this, new RangeChangedEventArgs(
                new Range(
                    (Canvas.GetLeft(ThumbMin) + (ThumbMin.ActualWidth/2)) / OutterBorder.ActualWidth,
                   ( Canvas.GetLeft(ThumbMax) + (ThumbMax.ActualWidth / 2)) / OutterBorder.ActualWidth

                ), new Range()));
        }

        private void ThumbMin_MouseEnter(object sender, MouseEventArgs e)
        {
           // BeginStoryboard((Storyboard)Resources["minHandleFocus"]);

        }

        private void ThumbMin_MouseLeave(object sender, MouseEventArgs e)
        {
           // BeginStoryboard((Storyboard)Resources["minHandleUnfocus"]);

            
        }

        private void ThumbMax_MouseEnter(object sender, MouseEventArgs e)
        {
           // BeginStoryboard((Storyboard)Resources["maxHandleFocus"]);

        }

        private void ThumbMax_MouseLeave(object sender, MouseEventArgs e)
        {
           // BeginStoryboard((Storyboard)Resources["maxHandleUnfocus"]);

        }
    }





    public class RangeChangedEventArgs
    {
        public RangeChangedEventArgs(Range newVal, Range oldVal)
        {
            NewValue = newVal; OldValue = oldVal;
        }
        public Range OldValue { get; set; }
        public Range NewValue { get; set; }

    }

    public struct Range
    {
        public Range(double min, double max)
        {
            Min = min; Max = max;
        }

        public double Min { get; set; }
        public double Max { get; set; }

        public override string ToString()
        {
            return $"Min:{Min}, Max:{Max}";
        }

    }
}

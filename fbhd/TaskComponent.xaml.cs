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
using System.Timers;
using System.Windows.Media.Animation;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;


namespace fbhd
{
    /// <summary>
    /// Interaction logic for TaskComponent.xaml
    /// </summary>
    public partial class TaskComponent : UserControl, INotifyPropertyChanged
    {

        public TaskComponent()
        {
            InitializeComponent();

          


            animateDownloadingIcon();
           animateResolvingIcon();


        }

        

        private void animateResolvingIcon()
        {
           
            resolving_ico.RenderTransform = new RotateTransform();

            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromSeconds(1));
            DoubleAnimation ra = new DoubleAnimation() { From = 0, To = 360, Duration = sb.Duration };
            Storyboard.SetTarget(ra, resolving_ico);
            Storyboard.SetTargetProperty(ra, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            sb.Children.Add(ra);
            Resources.Add("Storyboard", sb);
            
            //((Storyboard)Resources["Storyboard"]).Begin();
            //ra.BeginTime =  TimeSpan.FromMilliseconds(((((double)DateTime.Now.Ticks / 10000) % 10000)));
            //sb.AutoReverse = true;
            //MessageBox.Show(((((double)DateTime.Now.Ticks/10000) %10000) ).ToString());
            sb.RepeatBehavior = new RepeatBehavior(54354);
            // sb.BeginTime =  TimeSpan.FromMilliseconds((DateTime.Now.Millisecond/360) % 1000000);
            double offset = 360 * ((((double)DateTime.Now.Ticks / 10000) % 1000)) / 1000;
            ra.From = offset;
            ra.To = 360 + offset; 
            sb.Begin();
            
            
        }






        private void animateDownloadingIcon()
        {

            downloading_ico.RenderTransform = new TranslateTransform();
            //downloading_ico.LayoutTransform = new TranslateTransform(-10, 0);

            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromSeconds(1));
            ThicknessAnimation ra = new ThicknessAnimation() { From = new Thickness(0, 0, 0, 0), To = new Thickness(-100, 0, 0, 0), Duration = sb.Duration
                , EasingFunction = new dl_thick_anim()
            };

            Storyboard.SetTarget(ra, downloading_ico);
            Storyboard.SetTargetProperty(ra, new PropertyPath("(FrameworkElement.Margin)"));
            sb.Children.Add(ra);
            //Resources.Add("Storyboard", sb);
            
            //((Storyboard)Resources["Storyboard"]).Begin();
            //ra.BeginTime =  TimeSpan.FromMilliseconds(((((double)DateTime.Now.Ticks / 10000) % 10000)));
            //sb.AutoReverse = true;
            //MessageBox.Show(((((double)DateTime.Now.Ticks/10000) %10000) ).ToString());
            sb.RepeatBehavior = new RepeatBehavior(54354);
            // sb.BeginTime =  TimeSpan.FromMilliseconds((DateTime.Now.Millisecond/360) % 1000000);
            double offset = 360 * ((((double)DateTime.Now.Ticks / 10000) % 1000)) / 1000;
            
            sb.Begin();



        }
        public static Color COLOR_HOVER_STATE = (Color)ColorConverter.ConvertFromString("#FF2c2c2c");
        public static Color COLOR_SELECTEd_STATE = (Color)ColorConverter.ConvertFromString("#FF2c2c2c");
        public static Color COLOR_SELECTEd_STATE_border = (Color)ColorConverter.ConvertFromString("#FF5f5f5f");




        private void notif(string propName)
        {
            if (PropertyChanged != null)
            {
                
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

                //MessageBox.Show("a listener to "+ propName);
                    
            }
        }





       


      



    



       



        public string url
        {
            get { return (string)GetValue(urlProperty); }
            set { SetValue(urlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for url.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty urlProperty =
            DependencyProperty.Register("url", typeof(string), typeof(TaskComponent), new PropertyMetadata(null));




        public TaskStatus taskStatus
        {
            get { return (TaskStatus)GetValue(taskStatusProperty); }
            set { SetValue(taskStatusProperty, value);

            }
        }

        // Using a DependencyProperty as the backing store for taskStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty taskStatusProperty =
            DependencyProperty.Register("taskStatus", typeof(TaskStatus), typeof(TaskComponent), new PropertyMetadata(TaskStatus.pending));























        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == isResolvedProperty)
            {
                VisualStateManager.GoToState(this, ((bool)e.NewValue) ? "Resolved" : "NotResolved", false);

            }
        }




        public bool isResolved
        {
            get { return (bool)GetValue(isResolvedProperty); }
            set { SetValue(isResolvedProperty, value);
                VisualStateManager.GoToState(this, value? "Resolved": "NotResolved", false);

            }
        }

        // Using a DependencyProperty as the backing store for isResolved.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isResolvedProperty =
            DependencyProperty.Register("isResolved", typeof(bool), typeof(TaskComponent), new PropertyMetadata(false));


       







        // Using a DependencyProperty as the backing store for ffmpeg_process_ref.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ffmpeg_process_refProperty =
            DependencyProperty.Register("ffmpeg_process_ref", typeof(Process), typeof(TaskComponent), new PropertyMetadata(null));




        public string outputFile
        {
            get { return (string)GetValue(outputFileProperty); }
            set { SetValue(outputFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for outputFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty outputFileProperty =
            DependencyProperty.Register("outputFile", typeof(string), typeof(TaskComponent), new PropertyMetadata(null));




        public override string ToString()
        {
            return url.Substring((url.Length - 4))+ $", isResolved: {isResolved.ToString()}";
        }



       



      

        private void buttonoptionsdrop_Click(object sender, RoutedEventArgs e)
        {


            if ((string) buttonoptionsdrop.Tag == "opened")
            {
                popup.IsOpen = false;
            }
            else
            {
                popup.IsOpen = true;
            }
           


        }


       

       



       


        static MainWindow mw = (MainWindow)Application.Current.MainWindow;





        



        public bool isSelected
        {
            get { return (bool)GetValue(isSelectedProperty); }
            set {

      
                SetValue(isSelectedProperty, value);
                if (value)
                {
                    if (mw.TaskWiewTabSwitch.IsChecked.HasValue)
                    {
                        if (!mw.TaskWiewTabSwitch.IsChecked.Value)
                            mw.TaskWiewTabSwitch.IsChecked = true;
                    }
                }

                notif(nameof(isSelected));

            }
        }

        public bool isAborted { get; private set; } = false;













        // Using a DependencyProperty as the backing store for isSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isSelectedProperty =
            DependencyProperty.Register("isSelected", typeof(bool), typeof(TaskComponent), new PropertyMetadata(false));

        public event PropertyChangedEventHandler PropertyChanged;





       /* private void onTypeSwitch(object sender, RoutedEventArgs e)
        {
            var strs = new List<string> { "mp3", "mp4", "mkv", "jpg" };


            this.taskType = (TaskType)((strs.IndexOf((string)((UserControl)sender).Tag)+1)%4);
            //MessageBox.Show(this.taskType. ToString());
        }*/

      


       







        private void popup_Closed(object sender, EventArgs e)
        {
            buttonoptionsdrop.Tag = "closed";
        }

        private void popup_Opened(object sender, EventArgs e)
        {
            buttonoptionsdrop.Tag = "opened";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            taskStatus  = (TaskStatus) (((int) taskStatus+1)%5);
        }

        private void userControl_MouseEnter(object sender, MouseEventArgs e)
        {
            return; // 26-04 listBox 
            VisualStateManager.GoToState(this, "Hover", true);

        }

        private void userControl_MouseLeave(object sender, MouseEventArgs e)
        {
            return; //// 26-04 listBox 
            VisualStateManager.GoToState(this, "normal", true);

        }

        private void userControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void userControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            return; // 26-04 listBox 
            // select
            this.isSelected = !this.isSelected;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            mw.removeTask((FBHDTask)this.DataContext);
        }

        private void MediaTypeSwitch_Shifted(object sender, int direction)
        {
           ((FBHDTask) this.DataContext). Type = Fucs.MediaTypeToType(  MediaTypeSwitch.shiftValue() );
        }
    }
}

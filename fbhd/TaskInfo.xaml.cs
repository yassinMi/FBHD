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
using System.Windows.Media.Animation;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace fbhd
{
    /// <summary>
    /// Interaction logic for TaskInfo.xaml
    /// </summary>
    public partial class TaskInfo : UserControl, INotifyPropertyChanged
    {
        public TaskInfo()
        {
            InitializeComponent();


            animate_big_resolving_ico();
            animateBigDownloadingIcon();

           
        }


        

        public void updateMyBiindings()
        {



            return;

            progressBar_download.GetBindingExpression(ProgressBar.ValueProperty).UpdateTarget();
            graphics_done.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();
            graphics_down.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();

            graphics_failed.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();

            graphics_resolving.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();
            lblTaskName.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }


        private void animateBigDownloadingIcon()
        {
            dowloadAnim_drive.RenderTransform = new TranslateTransform();

            //downloading_ico.LayoutTransform = new TranslateTransform(-10, 0);

            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromSeconds(1));
            ThicknessAnimation lineAnimation = new ThicknessAnimation()
            {
                From = new Thickness(2, 0, 0, 0),
                To = new Thickness(2, 24, 0, 0),
                Duration = sb.Duration
                ,
                EasingFunction = new dl_thick_anim()
            };

            DoubleAnimation driveAnimation = new DoubleAnimation()
            {
                From = 0.7,
                To = 3,
                Duration = sb.Duration,
                BeginTime = TimeSpan.FromSeconds(0.4)

            };

            Storyboard.SetTarget(lineAnimation, dowloadAnim_line);
            Storyboard.SetTargetProperty(lineAnimation, new PropertyPath("(FrameworkElement.Margin)"));
            sb.Children.Add(lineAnimation);

            Storyboard.SetTarget(driveAnimation, dowloadAnim_drive);
            Storyboard.SetTargetProperty(driveAnimation, new PropertyPath("(FrameworkElement.Opacity)"));
            sb.Children.Add(driveAnimation);
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





        private void animate_big_resolving_ico()
        {

            rotatingRect.RenderTransform = new RotateTransform();
            resolvingGridc.RenderTransform = new RotateTransform();
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromSeconds(1.8));
            DoubleAnimation ra = new DoubleAnimation() { From = 0, To = 360, Duration = sb.Duration };
            Storyboard.SetTarget(ra, rotatingRect);
            Storyboard.SetTargetProperty(ra, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));
            sb.Children.Add(ra);
            //Resources.Add("Storyboard", sb);

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






        public FBHDTask coreTaskObject
        {
            get { return (FBHDTask)GetValue(coreTaskObjectProperty); }
            set { SetValue(coreTaskObjectProperty, value);

                updateMyBiindings();
            }
        }

        // Using a DependencyProperty as the backing store for coreTaskComponent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty coreTaskObjectProperty =
            DependencyProperty.Register("coreTaskObject", typeof(FBHDTask), typeof(TaskInfo), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;











        public ImageSource IconAudio
        {
            get { return (ImageSource)GetValue(IconAudioProperty); }
            set { SetValue(IconAudioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconAudio.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconAudioProperty =
            DependencyProperty.Register("IconAudio", typeof(ImageSource), typeof(TaskInfo), new PropertyMetadata(null));



        public ImageSource IconVideo
        {
            get { return (ImageSource)GetValue(IconVideoProperty); }
            set { SetValue(IconVideoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconVideo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconVideoProperty =
            DependencyProperty.Register("IconVideo", typeof(ImageSource), typeof(TaskInfo), new PropertyMetadata(null));




        public ImageSource IconImage
        {
            get { return (ImageSource)GetValue(IconImageProperty); }
            set { SetValue(IconImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconImageProperty =
            DependencyProperty.Register("IconImage", typeof(ImageSource), typeof(TaskInfo), new PropertyMetadata(null));





        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(TaskInfo), new PropertyMetadata(null));




        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.Property == MediaTypeProperty)
            {
                switch ((MediaType)e.NewValue)
                {
                    case MediaType.Audio:
                        this.Image = IconAudio;
                        break;
                    case MediaType.Video:
                        this.Image = IconVideo;
                        break;
                    case MediaType.Image:
                        this.Image = IconImage;
                        break;
                    default:
                        break;
                }
            }
        }


        public MediaType MediaType
        {
            get { return (MediaType)GetValue(MediaTypeProperty); }
            set { SetValue(MediaTypeProperty, value);

               
            }
        }

        // Using a DependencyProperty as the backing store for MediaType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MediaTypeProperty =
            DependencyProperty.Register("MediaType", typeof(MediaType), typeof(TaskInfo), new PropertyMetadata(MediaType.Audio));



        void switchProgressInfo()
        {
            

            // MessageBox.Show(this.coreTaskComponent.ffmpegProgress.ToString());
            // MessageBox.Show(progress_info.GetBindingExpression(TextBlock.TextProperty).ResolvedSource.ToString());


            /*
            string targetProp = "";
            switch (current)
            {
                case 0:
                    targetProp = "Size";
                    //b.Source = this.coreTaskComponent.ffmpegProgress.frame;
                    break;
                case 1:
                    targetProp = "Fps";
                    //b.Source = this.coreTaskComponent.ffmpegProgress.fps;
                    break;
                case 2:
                    targetProp = "Bitrate";
                   // b.Source = this.coreTaskComponent.ffmpegProgress.bitrate;
                    break;
                case 3:
                    targetProp = "Time";
                    //b.Source = this.coreTaskComponent.ffmpegProgress.time;
                    break;
                case 4:
                    targetProp = "Frame";
                    //b.Source = this.coreTaskComponent.ffmpegProgress.size;
                    break;
                default: {
                        targetProp = "Size";
                    }
                    break;
            }

    */
         

         



        }


        private void progress_info_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switchProgressInfo();
        }




        /// <summary>
        /// opensStuff with powershell's invoke-item cmdlet, returns the powershell exit code 
        /// </summary>
        /// <returns></returns>
        public async Task<int> openFile() // obsolete, new implementation in the task class
        {
            //MessageBox.Show("invoke-item \"" +
              //  coreTaskComponent.outputFile + "\"");
           Process p =  Fucs.constructProcess("powershell", " -c invoke-item '"+coreTaskObject.OutputFile+"'");


           await Task.Run(new Action(()=> {
                p.Start();
                p.WaitForExit();
            }));
            return p.ExitCode;

        }


        private async void miOpenFile_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            missingFileFlag.Visibility = Visibility.Hidden;

            bool success = await coreTaskObject.OpenOutputFile();
            if (!success)
            {
                //show error feedback
                missingFileFlag.Visibility = Visibility.Visible;
                missingFileFlag.ToolTip = $"Missing: " + coreTaskObject.OutputFile;
                
            }
        }

        private void abort_butt_Click(object sender, RoutedEventArgs e)
        {
            coreTaskObject.aborteFfmpegProcess();
        }

        

        private void typePickerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (coreTaskObject != null)
            {

                
                coreTaskObject.Type = typePickerCombo.Value;
            }
        }

        private void userControl_Loaded(object sender, RoutedEventArgs e)
        {
            Image = IconAudio;
        }

        private async void miOpenLocation_Click(object sender, RoutedEventArgs e)
        {
            missingFileFlag.Visibility = Visibility.Hidden;

            bool success = await coreTaskObject.OpenOutputLocation(true);
            if (!success)
            {
                //show error feedback
                missingFileFlag.Visibility = Visibility.Visible;
                missingFileFlag.ToolTip = $"Missing: " + coreTaskObject.OutputFile;

            }
        }

        private async void miDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            bool success = await coreTaskObject.DeleteOutputFile();
            if (success)
            {
                MessageBox.Show("file deleted");
            }
        }

        private void resetTask_Click(object sender, RoutedEventArgs e)
        {
            this.coreTaskObject.Status = TaskStatus.pending;
        }
    }


}

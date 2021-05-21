using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Ookii.Dialogs.Wpf;
using System.Xml.Linq;
using System.Windows.Shell;
using System.Xml.Serialization;

namespace fbhd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


       

        public  MyClass myConc =  new MyClass() ;
        public MainWindow()
        {

            if (true)
            {
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            }
            InitializeComponent();

            webServer = new WebServer();
            // DataContext = mainSession;
            mainSession =  new Session();
            DataContext = mainSession;
           


            EventHandler kill_server = (s, e) => { if (webServer?.py_server == null) return;
               

                try
                {
                    webServer?.py_server?.Kill(); webServer?.py_server?.WaitForExit();

                }
                catch 
                {

                    
                }

            };

            AppDomain.CurrentDomain.DomainUnload += kill_server;
            AppDomain.CurrentDomain.ProcessExit += kill_server;
            AppDomain.CurrentDomain.UnhandledException += (s,e)=> { webServer?.py_server?.Kill(); webServer?.py_server?.WaitForExit(); };

         

        }




        public Session mainSession { get; set; }
       
        public WebServer webServer ;


        public  class MyClass : IValueConverter
        {
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
                System.Windows.Controls.AlternationConverter ic = new AlternationConverter();
                
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {

                return ((string) value)=="bleu"?(new SolidColorBrush(Colors.AliceBlue)) :(new SolidColorBrush(Colors.Wheat) );

            }
        }


        public class ResolutionPickerConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if(value == null)
                {
                    return "none";
                }
                if (value.GetType()==typeof (Resolution) )
                {
                    return ((Resolution) value)._String();
                }
                else
                {
                    return "none";
                }
                 
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }






        public bool hasTasks
        {
            get { return (bool)GetValue(hasTasksProperty); }
            set { SetValue(hasTasksProperty, value); }
        }
// commit try
        // Using a DependencyProperty as the backing store for hasTasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty hasTasksProperty =
            DependencyProperty.Register("hasTasks", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));



      


        private void button_Click(object sender, RoutedEventArgs e)
        {

           

           
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationInfo i = new ApplicationInfo();
            if (ApplicationInfo.IsDev)
            {
               
            }
         }


        public void updateMyBidings()
        {

            return;
            Run_ffmpeg.GetBindingExpression(ButtonMi.isDisabledProperty).UpdateTarget();
            tb_property_title.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            titlePopupPickerMi.GetBindingExpression(PopupPickerMi.PairItemsProperty).UpdateTarget();
            taskInfo.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();
            groupMeta.GetBindingExpression(GroupBox.VisibilityProperty).UpdateTarget();
           // grd_PropertyResolution.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();

        }
        private void dragable_DragOver(object sender, DragEventArgs e)
        {
            this.DragMove();
            
        }

        private void dragable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void butt_minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        public static System.Net.HttpListener hl = new System.Net.HttpListener();

        System.Diagnostics.Process process = new System.Diagnostics.Process();

        System.IO.StreamWriter inp;
        System.IO.StreamReader outp;

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {

         

         
          


        }

        private void Process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async  void read_Click(object sender, RoutedEventArgs e)
        {
           

            
           
           
        }

        async void  receive(object sender, DataReceivedEventArgs e)
        {
            if(e.Data!= null)

                await Task.Run(new Action(() => {

                    Dispatcher.BeginInvoke(new Action(() => {
                        // MessageBox.Show(e.Data + DateTime.Now.Second);
                       // verboseStatus = FFMPEG.FFMPEGProgress.FromStdoutLine( e.Data).ToString("size: $s    time: $t    frame:$f");

                    }));
                }));

           
            //FBHd.Verbose(e.Data);
        }

        private  async void write_Click(object sender, RoutedEventArgs e)
        {



            Queue<string> a = new Queue<string>();
            TaskFactory tf = new TaskFactory();
            


        }




        public string verboseStatus //displays what's really going on 
        {
            get { return (string)GetValue(verboseStatusProperty); }
            set { SetValue(verboseStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for verboseStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty verboseStatusProperty =
            DependencyProperty.Register("verboseStatus", typeof(string), typeof(MainWindow), new PropertyMetadata(null));




        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow newTaskWin = new NewTaskWindow();
            newTaskWin.Owner = this;
            newTaskWin.ShowDialog();
            return;
        }


        
        public void removeTask (FBHDTask task)
        {

            if (mainSession.SelectedTask == task)
            {
                //select the next or previous task behavior
              //  task.IsSelected = false; //lb
                int ix = mainSession.Tasks.IndexOf(task) +1;
               if (mainSession.Tasks.Count > ix)
                {
                    //select next task
                    FBHDTask nextTask=((FBHDTask)mainSession.Tasks[ ix ]);
                    TasksListBox.SelectedItem = nextTask;

                }
                else
                {
                   // select previous task
                      if(ix - 2 > -1)
                    {
                        FBHDTask nextTask = ((FBHDTask)mainSession.Tasks[ix - 2]);
                        TasksListBox.SelectedItem = nextTask;

                    }
                    

                }


            }
            mainSession.Tasks.Remove(task);
            mainSession.HasTasks = true; // this true value does not go anywhere it just triggers the setter so that the notif gets fired
            mainSession.TasksCount = 222; // this setter only notifies the change 



        }

        /*
        public void addNewTask(string url_, TaskType type)
        {
            TaskComponent nwtsk = new TaskComponent();

            nwtsk.taskType = type;

            nwtsk.url = url_;
            nwtsk.taskStatus = TaskStatus.pending;
           
            StackTasks.Children.Add(nwtsk);
            // nwtsk.isSelected = true;
            nwtsk.taskProperties = new TaskProperties();
             nwtsk.taskProperties.resolutionSettings.setAvailable( MI.standardResolutionSet);
            TitleSettings ts = nwtsk.taskProperties.titleSettings;
                ts.SerialTtitle = "fbhd-task-" + url_.GetHashCode().ToString();
            ts.Query = "{Auto}";
            ts.SourceFallbacks =
                StandardPostProperties.stdTitles;
            nwtsk.taskProperties.titleSettings = ts;
            hasTasks = StackTasks.Children.Count > 0;
            // nwtsk.taskProperties = ts;

            //nwtsk.startCycle();
        }
        */

        public void addNewFBHDTask(string url_, TaskType type, bool autoSelect = true)
        {
            FBHDTask nwtsk = new FBHDTask(mainSession.Tasks);

            nwtsk.Type = type;

            nwtsk.Url = url_;
            nwtsk.Status = TaskStatus.pending;

           // StackTasks.Children.Add(nwtsk);
            nwtsk.TaskProperties = new TaskProperties();
            nwtsk.TaskProperties.resolutionSettings.setAvailable(MI.standardResolutionSet);
            TitleSettings ts = nwtsk.TaskProperties.titleSettings;
            ts.SerialTtitle = "fbhd-task-" + url_.GetHashCode().ToString();
            ts.Query = "{Auto}";
            ts.SourceFallbacks =
                StandardPostProperties.stdTitles;
            nwtsk.Resolved += (s, e) =>
            {
                //todo restrict only current selected task
                if (mainSession.SelectedTask == null) return;
                if (mainSession.SelectedTask.IsResolved == false) return;
                rangepcker.Range = mainSession.SelectedTask.TaskProperties.trimmingSettings.NormalizedRange;
                crop_start_tb.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                crop_to_tb.GetBindingExpression(TextBox.TextProperty).UpdateTarget();

            }; 
            nwtsk.TaskProperties.titleSettings = ts;
            mainSession.Tasks.Add(nwtsk);
            mainSession.HasTasks = true; // this true value does not go anywhere it just triggers the setter so that the notif gets fired
            mainSession.TasksCount = 222; // this setter only notifies the change 
            if(autoSelect) TasksListBox.SelectedItem = nwtsk;
            TasksListBox.ScrollIntoView(nwtsk);
        }




        public uint exportTasks(string saveAs= null, string template="$url\r\n")
        {

            if (saveAs == null) saveAs = MI.APP_DATA + "\\Exported-tasks.txt";

            string stringified = "";
           var  tasks = mainSession.Tasks;
            foreach (var task in tasks)
            {
                stringified += template.Replace("$url", (task).Url);

            }
            

            System.IO.File.AppendAllText(saveAs, stringified);
            return (uint) tasks.Count;

        }


        







       
        



        public bool isSomethingSelected
        {
            get { return (bool)GetValue(isSomethingSelectedProperty); }
            set { SetValue(isSomethingSelectedProperty, value);

               // MessageBox.Show("ew somehin;" + value);
            }
        }

        public List<string> verboseStatusStack { get; internal set; } = new List<string>();

        // Using a DependencyProperty as the backing store for isSomethingSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isSomethingSelectedProperty =
            DependencyProperty.Register("isSomethingSelected", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        internal int cc;

        private void start_butt_Click(object sender, RoutedEventArgs e)
        {
           
        }





        private void start_butt_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("mi: start cycle methoode not implemented yet");
            
        }

        private async void ClearAllCommaneHandeler(object sender, RoutedEventArgs e)
        {

             }

        private async void ParseCommaneHandeler(object sender, RoutedEventArgs e)
        {
            if (mainSession.SelectedTask == null)
                return;

            mainSession.SelectedTask.Post = await mainSession.SelectedTask.StartResolve();
            // resolutionPicker.GetBindingExpression(ResolutionPicker.ResolutionsProperty).UpdateTarget();
        }
        private async void Parse_butt_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mainSession.SelectedTask == null)
                return;

            mainSession.SelectedTask.Post = await mainSession.SelectedTask.StartResolve();
           // resolutionPicker.GetBindingExpression(ResolutionPicker.ResolutionsProperty).UpdateTarget();
        }

        private void Run_ffmpeg_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void importListButton_Click(object sender, RoutedEventArgs e)
        {
            Typeface tf = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);

            

           
        }

        private void butt_propety_title_piker_Click(object sender, RoutedEventArgs e)
        {
            popup_titles_picker.IsOpen = true;
        }

        private void tb_property_title_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void resolutionPicker_ResolutionPicked(object sender, ResolutionPicker.ResolutionPickedArgs e)
        {
           // MessageBox.Show(e.Picked.serialized);
        }

        private void PopupPickerMi_Picked(object sender, KeyValuePair<string,string> e)
        {

            
            if(mainSession.SelectedTask != null)
            {
                //MessageBox.Show(e.Value);
                var ts = mainSession.SelectedTask.TaskProperties.titleSettings;
                ts.Query = e.Value ;
                mainSession.SelectedTask.TaskProperties.titleSettings = ts;

                popup_titles_picker.IsOpen = false;
                updateMyBidings();
            }
        }

        private void Run_ffmpeg_Click(object sender, RoutedEventArgs e)
        {
            if (mainSession.SelectedTask==null )
                return;


            if (!mainSession.SelectedTask.IsResolved)
            {
                MessageBox.Show("TaskComponent must have a non null postObj property! try Resolve first.");
                return;
            }
            else
            {

                mainSession.SelectedTask.StartDownload((Post)mainSession.SelectedTask.Post);

            }
        }

        private void preferencesButt_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.Owner = this;
            sw.ShowDialog();
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            WebServer ws = new WebServer();
            webServer = ws;

            webServer.onRequest += new EventHandler<string>((sender_, str) =>
            {
                Dispatcher.Invoke(() =>
                {
                    // MessageBox.Show("tesl");
                    Uri u;
                    if (Uri.TryCreate(str, UriKind.Absolute, out u))
                    {
                        addNewFBHDTask(str, TaskType.mp3Task);
                    }
                    else
                    {
                        MessageBox.Show("unvalid url:\n" + str);
                    }

                });

            });



            webServer.onServingStarted += new EventHandler<string>((sender_, str) =>
            {
                Dispatcher.Invoke(() =>
                {
                   // MessageBox.Show("runnng");
                    server_toggle.Content = "Server On";
                    mainSession.IsServerRunning = true;
                    ((SolidColorBrush)server_toggle.Foreground).Color = Colors.LightSeaGreen;//"#FF83CE7F"


                });

            });
            webServer.onError += new EventHandler<string>((sender_, str) =>
            {
                Dispatcher.Invoke(() =>
                {
                    mainSession.IsServerRunning = false;
                    MessageBox.Show(str);
                });

            });
            ws.onProcessExited += (s, er) => {
                Dispatcher.Invoke(() =>
                {
                    if (toggleButton.IsChecked.HasValue)
                    {
                        if (toggleButton.IsChecked.Value == true)
                        {
                            toggleButton.IsChecked = false;
                        }
                    }
                });
               
               
            };

          bool success=  ws.Start();
            if (!success)
            {
               
            }

        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            server_toggle.Content = "Server Off";
            mainSession.IsServerRunning = false;
            ((SolidColorBrush)server_toggle.Foreground).Color = Colors.Gray;//"#FF83CE7F"

            if (webServer.IsListening == false) return;
            webServer.Stop();
           


        }

        private void savelist_Click(object sender, RoutedEventArgs e)
        {
            uint appended = exportTasks();
            if (appended>0)
            {
                MessageBox.Show($"{appended} items appended succesfully.");
            }
        }

        private void removeSelected_Click(object sender, RoutedEventArgs e)
        {
            if (mainSession.SelectedTask == null) return;
            removeTask(mainSession.SelectedTask);
        }

        

        private void window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

           
        }

        private void deletebutt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilterUI_Deleted(object sender, EventArgs e)
        {
            filtersWrapPanel.Children.Remove( (UIElement) sender);
        }

        private void titleFilter_Loaded(object sender, RoutedEventArgs e)
        {
            titleFilter.mainValueMaker = (arg,arg1) => {
                try
                {
                    return arg == null ? null : (Regex)new Regex(arg);
                }
                catch (Exception)
                {

                    return null;
                }
               
            };
            durationFilterUI.mainValueMaker = (arg1, arg2) =>  {               
                return new SearchPresenter.DurationRange() {
                    min = Fucs.TimeSpanFromString(arg1),
                    max =Fucs. TimeSpanFromString(arg2) };
            };


        }

        private void DEv_update_Click(object sender, RoutedEventArgs e)
        {
            //dev_bind_filter.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.Type = TaskType.mkvTask; return;
          
        }

        private void set_mkv_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.Type = TaskType.mkvTask; return;

        }

        private void set_jpg_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.Type = TaskType.jpgTask; return;

        }

        private void set_mp4_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.Type = TaskType.mp4Task; return;

        }

        private void set_mp3_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.Type = TaskType.mp3Task; return;

        }

        private void set_show_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"Type: {mainSession.SelectedTask.Type.ToString()} ; MediaType: {mainSession.SelectedTask.MediaType.ToString()}");
            MessageBox.Show($"IsResolved: {mainSession.SelectedTask.IsResolved.ToString()} ; Status: {mainSession.SelectedTask.Status.ToString()}");

        }

        private void set_audio_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.MediaType = MediaType.Audio;
        }

        private void set_vid_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.MediaType = MediaType.Video;

        }

        private void set_image_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask.MediaType = MediaType.Image;

        }

        private void tb_property_title_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_property_title.SelectAll();
        }

        private void tb_property_title_QueryCursor(object sender, QueryCursorEventArgs e)
        {
            tb_property_title.SelectAll();

        }



        private void tb_property_title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void tb_property_title_Loaded(object sender, RoutedEventArgs e)
        {
            tb_property_title.AutoWordSelection = true;
            tb_property_title.IsManipulationEnabled = false;
           /// tb_property_title.
            
        }

        private void tb_property_title_LostFocus(object sender, RoutedEventArgs e)
        {
           // tb_property_title.Text = "lostfoc";
            
        }

        private void tb_property_title_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            tb_property_title.SelectAll();

        }

        private void titleFilter_FilterValueChanged(object sender, object e)
        {
            mainSession.MainSearch.Presenter.TitleFilter = (Regex)e;

        }

        private void durationFilterUI_FilterValueChanged(object sender, object e)
        {
            mainSession.MainSearch.Presenter.DurationFilter = (SearchPresenter.DurationRange)e;

        }

        private void datePostedFilterUI_FilterValueChanged(object sender, object e)
        {
            mainSession.MainSearch.Presenter.DatePostedFilter = (SearchPresenter.DateRange)e;

        }

        private void SearchQueryControl_onGo(object sender, string e)
        {
            mainSession.MainSearch.Query = e;
            if (string.IsNullOrWhiteSpace(e)) return;
            mainSession.MainSearch.StartSearch(true);

        }

        

        private async void button_Click_2(object sender, RoutedEventArgs e)
        {

          
         




        }

        private void resetSearchBffer_Click(object sender, RoutedEventArgs e)
        {

           
         
            mainSession.MainSearch.clearResults();

            mainSession.MainSearch.clearBuffer();
        }

        private void image1_Loaded(object sender, RoutedEventArgs e)
        {
           
        }



        private async void testCurl(string url)
        {
            string p = "DL% UL%  Dled  Uled  Xfers  Live   Qd Total     Current  Left    Speed";
               string p2 ="100 --  3906k     0     4     0     0  0:00:17  0:00:23 --:--:--  223k";
            string p3 = p + "\n" + p2;
          
            
        
        }
        // the 4 copy to clip buttons
        private void copy_to_clip_button(object sender, RoutedEventArgs e)
        {

          

            
            string from = (string)((Button)sender).Tag;
            string textToCopy = "";
            switch (from)
            {
                case "command":
                    textToCopy = "cp_command not implemented yet";
                    break;
                case "video":
                    string pickedReso = mainSession.SelectedTask.ResolvedResolution.serialized;// resolutionPicker.selectedResolution.serialized;
                    textToCopy = mainSession.SelectedTask.Post.Value.QualityLabels.Find((Q) =>
                (Q.qualityName ==(pickedReso)) ).videoUrl;
                    break;
                case "audio":
                    textToCopy = mainSession.SelectedTask.Post.Value.audioUrl ;
                    break;
                case "thumb":

                    textToCopy = mainSession.SelectedTask.Post.Value.Images.First().Value;
                    break;
                default:
                    break;
            }


            Clipboard.SetText(textToCopy);

            MI.Verbose(from + " copied", 2);
            
            
        }

        private void SearchQueryControl_onIsEmptyChanged(object sender, bool e)
        {
            mainSession.MainSearch.IsQueryUiEmpty = e;
        }



        private void OutpuFolderButt_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog picker = new VistaFolderBrowserDialog();
            picker.ShowNewFolderButton = true;
            picker.UseDescriptionForTitle = true;
            picker.Description = "FBHD Output Directoty";
            picker.ShowDialog(this);
            

            string pickedDir = picker.SelectedPath;
            mainSession.SetOutputDirectory(pickedDir);



        }

        private void importListButt_Click(object sender, RoutedEventArgs e)
        {
            string listFile = "oiu";
            var fd = new VistaOpenFileDialog();
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            fd.DefaultExt = "txt";
            fd.InitialDirectory = MI.MAIN_PATH;
            fd.Title = "Import Tasks";
            if (fd.ShowDialog().Value == true)
            {
                string list_str = File.ReadAllText(fd.FileName);
                List<string> urls = Fucs.extractUrls(list_str);
                foreach (string url_item in urls)
                {
                    addNewFBHDTask(url_item, TaskType.mp3Task);

                }
            }
            
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
             new AboutWindow() { Owner=this} .ShowDialog();
        }

        private void CmdLineHelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
           // await Task.Delay(5000);
            string cmdlineHelp = "usage:\n     fbhd [options] <url>\nOptions:\n     -mp3|-mp4|-mkv|-jpg: task type, defaults to mp4\n     -r <720p> : prefered resolution, defaults to the highest\n     -o <path>: output file path and name\n     -y : override existant files\n     -s : silent mode\n     -v : verbose logging";
            MessageBox.Show(cmdlineHelp, "cmdhelp", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
        }

        private void fsdmnewswatchButt_Click(object sender, RoutedEventArgs e)
        {
           

        }


        private void devregex_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            try
            {
                Match m = Regex.Match(devregex_iinput.Text,devregex.Text);
                if (m.Success)
                {
                    devresult.Text = m.Value;
                }
                else
                {
                    devresult.Text = "successfull = false";
                }
            }
            catch (Exception)
            {

                devresult.Text = "exception";
            }
        }

        private void fsdmnewswatchButt_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void fsdmnewswatchButt_Unchecked(object sender, RoutedEventArgs e)
        {
            

        }

      

         public void ShowNotificationNews(IEnumerable<INotifableItem> news, IWatch listWathcer)
        {
            NotificationWindowMi nm = new NotificationWindowMi();
            
            nm.Init(news , listWathcer);
            nm.Owner = this;
            nm.ShowInTaskbar = false;

            nm.Show();
        }
        

        public void PopupNews(IEnumerable<INotifableItem> news, IWatch listwatcher, string winTitle = "News" ,bool IsNotifyMode  =true)
        {
            GenericPopupWindow gpw = new GenericPopupWindow();
            SoundPlayerAction spa = new SoundPlayerAction();
           if(IsNotifyMode) mainSession.PlayNotification();
            gpw.setItemsSource(news,listwatcher, winTitle );
            gpw.ShowDialog();


        }

        private async void testwindowmuit_Click(object sender, RoutedEventArgs e)
        {

           
            
            await Task.Delay(5000);
            GenericPopupWindow gpw = new GenericPopupWindow();

            List<INotifableItem> li = new List<INotifableItem>()
            {
                new FsdmNew() {
                    Title ="TITLE 1",
                    Link = "https://abc/news/1",
                },
                new FsdmNew() {
                    Title ="TITLE 2",
                    Link = "https://abc/news/2",
                },
                  new FsdmNew() {
                    Title ="TITLE 3",
                    Link = "https://abc/news/3",
                },
               
            };


           
            gpw.setItemsSource(li, null, "dummy news");
            this.Activate();
            mainSession.PlayNotification();

            gpw.ShowDialog();
            

        }

        

       

        private void intervalIncTb_OnDecrease(object sender, RoutedEventArgs e)
        {
           
        }

     

        private void intervalIncTb_OnIncrease(object sender, RoutedEventArgs e)
        {
           

        }

        private void UnreadNewsButt_Click(object sender, RoutedEventArgs e)
        {
        }

       


        private void devFakeCheck_Click(object sender, RoutedEventArgs e)
        {

        }

        private void devShowPopup_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void devRemoveLatestNewsItem_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void devShowNotification_Click(object sender, RoutedEventArgs e)
        {
            var dummynews = new List<FsdmNew>()
            {
                new FsdmNew() {Title = "Dummy Notification Title" ,
                Link = "http://fsdm.ma/dummyhrtdfhdf",
                ID = "44444", date="zzrhzr"

                }
            };
            ShowNotificationNews(dummynews.Cast<INotifableItem>(),null);
        }

        private void devActivateXMLLW_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private async void loadListWatcherPresetButt_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaOpenFileDialog vofd = new VistaOpenFileDialog();
            vofd.DefaultExt = ".xml";
            vofd.InitialDirectory = MI.APP_DATA ;
             bool? success= vofd.ShowDialog(this);
            if (!success.HasValue) return;
            if (!success.Value) return;

           CustomLW loaded = await mainSession.LoadXMLLW(vofd.FileName);
            if(loaded!=null)
            MessageBox.Show("preset loaded successfilly");
        }

        private void prettifyXmlDoc_Click(object sender, RoutedEventArgs e)
        {
            


            var myConfig = new Config();
            myConfig.CLWPresetsDeclarations = new List<CLWPresetDeclaration>()
            {

                new CLWPresetDeclaration()
                {
                    Path=MI.CLW_PRESETS_DIR+"\\fsdmNewsX.xml", AutoStart = true
                },
                 new CLWPresetDeclaration()
                {
                    Path=MI.CLW_PRESETS_DIR+"\\fsdmUploads.xml", AutoStart = false
                }
            };
           
            return;
            Ookii.Dialogs.Wpf.VistaOpenFileDialog opener = new VistaOpenFileDialog();

            opener.InitialDirectory = MI.CLW_PRESETS_DIR;
            opener.ShowDialog();

            var parsed = XElement.Parse(File.ReadAllText(opener.FileName));
            parsed.Save(opener.FileName+"", SaveOptions.None);
            MessageBox.Show("saved");
        }

        private void factoryConfigButt_Click(object sender, RoutedEventArgs e)
        {
            var proceed = MessageBox.Show("this will override the config file including the prefered clw presets!", "sure?", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(proceed == MessageBoxResult.OK)
            Config.FactoryConfig().Save();
        }

        private void showPostDev_Click(object sender, RoutedEventArgs e)
        {
            var av = mainSession.SelectedTask.TaskProperties.resolutionSettings.Available;
            foreach (var item in av)
            {
                Debug.WriteLine(item.serialized);

            }
            try
            {
                string av2 = mainSession.SelectedTask.TaskProperties.resolutionSettings.UserPicked.serialized;
                Debug.WriteLine(av2);

            }
            catch (Exception)
            {

            }
            Debug.WriteLine(log);
        }

        private void LBResolutionPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
            mainSession.SelectedTask.TaskProperties.resolutionSettings.UserPicked = (Resolution)LBResolutionPicker.SelectedItem;
            Debug.WriteLine(mainSession.SelectedTask.TaskProperties.resolutionSettings.UserPicked.ToString());
        }

        private void uriTestsDev_Click(object sender, RoutedEventArgs e)
        {
            //                                     https://video.fcmn1-1.fna.fbcdn.net/v/t42.1790-2/118863551_370940204305719_7513385478080044646_n.mp4?_nc_cat=101&ccb=1-3&_nc_sid=5aebc0&efg=eyJ2ZW5jb2RlX3RhZyI6ImRhc2hfYXVkaW9fYWFjcF82NF9mcmFnXzJfYXVkaW8ifQ%3D%3D&_nc_ohc=bk12BoIHEFoAX-BUu6D&_nc_ht=video.fcmn1-1.fna&oh=5582579a423b6fe6f479bf8ff08f3e7d&oe=6088B07D
            string formed =  FFMPEG.UrlAdd443Port("https://video.fcmn1-1.fna.fbcdn.net/v/t42.1790-2/118863551_370940204305719_7513385478080044646_n.mp4?_nc_cat=101&ccb=1-3&_nc_sid=5aebc0&efg=eyJ2ZW5jb2RlX3RhZyI6ImRhc2hfYXVkaW9fYWFjcF82NF9mcmFnXzJfYXVkaW8ifQ%3D%3D&_nc_ohc=bk12BoIHEFoAX-BUu6D&_nc_ht=video.fcmn1-1.fna&oh=5582579a423b6fe6f479bf8ff08f3e7d&oe=6088B07D");
            Debug.WriteLine(formed);
        }

        private void StartAllCLW_Click(object sender, RoutedEventArgs e)
        {
            if (mainSession.CustomListWatchers == null) return;
            foreach (var item in mainSession.CustomListWatchers)
            {
                if (item.IsWatching) continue;
                item.StartWatching();
            }
        }

        private void StopAllCLW_Click(object sender, RoutedEventArgs e)
        {
            if (mainSession.CustomListWatchers == null) return;
            foreach (var item in mainSession.CustomListWatchers)
            {
                item.StopWatching();
            }
        }

       

        private void TasksListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (TaskWiewTabSwitch.IsChecked == false)
                {
                    TaskWiewTabSwitch.IsChecked = true;
                }
            }
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            devregex.Text = MI.regexTestPattern;
        }

        private void showMainath_Click(object sender, RoutedEventArgs e)
        {
            string s1 = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string s2 = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);

            MessageBox.Show(MI.MAIN_PATH);
            //MessageBox.Show(s2);


        }

        private void NewItemDefinitionToolButton1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OutputDirectoryMenuItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            int i;
            for( i = 0; i < mainSession.MainConfig.RecentGlobalDirectories.Count; i++)
            {
                ((MenuItem)OutputDirectoryMenuItem.FindName($"recentOutputDir{i + 1}")).Visibility = Visibility.Visible;
                ((MenuItem)OutputDirectoryMenuItem.FindName($"recentOutputDir{i + 1}")).Header = mainSession.MainConfig.RecentGlobalDirectories[i];

            }
            while (i<5)
            {
                ((MenuItem)OutputDirectoryMenuItem.FindName($"recentOutputDir{i + 1}")).Visibility = Visibility.Collapsed;

                i++;
            }

        }

        private void OutputDirectoryMenuItem_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            int i;
            for (i = 0; i < mainSession.MainConfig.RecentGlobalDirectories.Count; i++)
            {
                ((MenuItem)OutputDirectoryMenuItem.FindName($"recentOutputDir{i + 1}")).Visibility = Visibility.Visible;
                ((MenuItem)OutputDirectoryMenuItem.FindName($"recentOutputDir{i + 1}")).Header = mainSession.MainConfig.RecentGlobalDirectories[i];

            }
            while (i < 5)
            {
                ((MenuItem)OutputDirectoryMenuItem.FindName($"recentOutputDir{i + 1}")).Visibility = Visibility.Collapsed;

                i++;
            }

        }

        private void recentOutputDir_Click(object sender, RoutedEventArgs e)
        {
            string RecentdirPath = (string) ((MenuItem)sender).Header;// todo, use Tag instead
            mainSession.SetOutputDirectory(RecentdirPath);
            
        }

        private void setRangePickerValue_Click(object sender, RoutedEventArgs e)
        {
            rangepcker.Max = 0.8;

            rangepcker.Min = 0.2;
        }

        private void rangepcker_RangeChanged(object sender, RangeChangedEventArgs e)
        {

            if (!mainSession.SelectedTask.IsResolved) return;
            var ts = mainSession.SelectedTask.TaskProperties.trimmingSettings;

            ts.NormalizedRange = e.NewValue;

            return;
            TimeSpan totalDuration = mainSession.SelectedTask.Post.HasValue? mainSession.SelectedTask.Post.Value.Duration: new TimeSpan(0, 3, 14);
            var from = new TimeSpan((long)(totalDuration.Ticks * e.NewValue.Min));

            var to = new TimeSpan((long)(totalDuration.Ticks * e.NewValue.Max));

            string klk = Fucs.TimeSpanToString(to);

            crop_start_tb.Text = $"{(from.Hours > 0 ? from.Hours.ToString() + ":" : "")}{from.Minutes}:{from.Seconds}.{from.Milliseconds}";
            crop_to_tb.Text = $"{(to.Hours>0?to.Hours.ToString()+":":"")}{to.Minutes}:{to.Seconds}.{to.Milliseconds}";

        }

        private async void dev_show_range_Click(object sender, RoutedEventArgs e)
        {





            MessageBox.Show($"{(DateTime.Now.ToString("d/M/yyyy hh:mm:ss"))}");
            return;
            //var url = linklbl.Text;
            var url = "http://fsdmfes.ac.ma/uploads/Docs/Files/2021-05-20-01-54-05_183bddf1b0d6b398ccf9be4dfe32f87bb0364a09.pdf";

            Uri asUri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out asUri))
            {
                MessageBox.Show("bad url"); return;
            }
           

            var filename = asUri.LocalPath;
            filename = Path.GetFileName(filename);
            //MessageBox.Show(filename);

            var save = new Ookii.Dialogs.Wpf.VistaSaveFileDialog();
            save.FileName = filename;
            save.ShowDialog();

            filename = save.FileName;
            MessageBox.Show(filename);


            return;

            DownloadQueue aq = new DownloadQueue();
            int i = 0;
            foreach (var item in mainSession.Tasks)
            {

           
                int cc = i;
                
                

            aq.Add(item );
                   // MI.ConsoleLog("end");



               
            }


            return;
            MI.ConsoleLog("Started Raw Text");
            mainSession.SelectedTask.StartDownloadRawStreams();
           
        }

        private void rangepcker_Loaded(object sender, RoutedEventArgs e)
        {
            mainSession.PropertyChanged += (s, ee) =>
            {
                if (ee.PropertyName == nameof(Session.SelectedTask))
                {
                    try
                    {
                        if (mainSession.SelectedTask == null) return;
                        if (mainSession.SelectedTask.IsResolved == false) return;
                        rangepcker.Range = mainSession.SelectedTask.TaskProperties.trimmingSettings.NormalizedRange;
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            };
        }

        private void Dev_Apply_testing_function_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                devresult.Text = MI.TestingFunc(devregex_iinput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void Dev_RunMassTeser_Click(object sender, RoutedEventArgs e)
        {
            Dev_Tester dt = new Dev_Tester();


            var res= dt.RunMassTest("C:\\TOOLS\\fbhd-gui\\fbhd analysis\\testing data",dt.DashManifestTester);
            res.DumpToFile("file: {0},  resultString: {1}"+Environment.NewLine, "file: {0},  error: {1}"+Environment.NewLine, "C:\\TOOLS\\fbhd-gui\\fbhd analysis\\massTestResults.txt");
            MessageBox.Show("dumped ");
        }

        private void terminal_Click(object sender, RoutedEventArgs e)
        {
            
                Show_Console.IsChecked = !Show_Console.IsChecked;
            
        }

        private void Show_Console_Checked(object sender, RoutedEventArgs e)
        {
            consoleGrdWraper.Visibility = Visibility.Visible;
        }

        private void Show_Console_Unchecked(object sender, RoutedEventArgs e)
        {
            consoleGrdWraper.Visibility = Visibility.Collapsed;
        }

        private void taskInfo_ClickedUrl(object sender, EventArgs e)
        {
            string UrlToCopy = mainSession.SelectedTask?.Url;
            if (string.IsNullOrWhiteSpace(UrlToCopy)) return;
            Clipboard.SetText(UrlToCopy);
            MI.Verbose("Url Copied", 2);
        }

        private void taskInfo_ClickedOutputPath(object sender, EventArgs e)
        {
            string PathToCopy = mainSession.SelectedTask?.OutputFile;
            if (string.IsNullOrWhiteSpace(PathToCopy)) return;
            Clipboard.SetText(PathToCopy);
            MI.Verbose("Path Copied", 2);
        }

        private void taskInfo_ClickedInfo(object sender, EventArgs e)
        {
            if (mainSession.SelectedTask ==null) return;
            if (mainSession.SelectedTask.Post.HasValue == false) return;

            var infoWin = new PostInfoWindow()
            {Owner=this };
            infoWin.PostObject =  mainSession.SelectedTask.Post.Value;
            infoWin.Init(mainSession.SelectedTask.Post.Value);
            infoWin.Show();
        }

        private void Crop_expander_Expanded(object sender, RoutedEventArgs e)
        {
            PropertiesScrollView.ScrollToBottom();
        }

        private void Clear_Console_Click(object sender, RoutedEventArgs e)
        {
            ConsoleRTB.Document = new System.Windows.Documents.FlowDocument();
        }

        private void TasksListBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TasksListBox.UnselectAll();
        }

        private void controls_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TasksListBox.UnselectAll();

        }

        private void tb_property_title_ToolTipClosing(object sender, ToolTipEventArgs e)
        {
            tb_property_title.ToolTip = mainSession.SelectedTask?.TaskProperties.titleSettings.getResult();
        }

        private void tb_property_title_Copy_ToolTipOpening(object sender, ToolTipEventArgs e)
        {

            if (mainSession.SelectedTask == null) return;
            if (mainSession.SelectedTask.Post.HasValue == false) return;
            Post post = mainSession.SelectedTask.Post.Value;
            string ResultThumbUri = Fucs.getFirstNonNull(post.Images.ToList().ConvertAll<string>((item) => item.Value).ToArray());
            MI.ConsoleLog(ResultThumbUri);
            var imProp= post.Images.ToList().Find((i) => i.Value == ResultThumbUri);
            string propName = imProp.Key.name;
            var img = new System.Windows.Media.Imaging.BitmapImage(new Uri(
                    ResultThumbUri));
            double ratio = ((double)img.PixelWidth) / img.Height;
            
            ProgressBar pbar =  new ProgressBar()
            {
                
                Width = 120,
            Height = 8
            };
            tb_property_title_Copy.ToolTip = pbar;
            pbar.Maximum = 1;
            img.DownloadProgress += (s, ee) =>
            {
                pbar.Value = ((double)ee.Progress) / 100;
                
                MI.ConsoleLog(pbar.Value.ToString());
            };
            img.DownloadFailed+=
                (s, ee) =>
                {
                    

                    MI.ConsoleLog("failed");
                };
            img.DownloadCompleted += (s, ee) =>
            {
                StackPanel wraperGrd = new StackPanel() { Width = 120, Orientation= Orientation.Vertical };
                TextBlock caption = new TextBlock() { Width = 120,Text=propName,Foreground=new SolidColorBrush(Colors.DarkMagenta) };

                wraperGrd.Children.Add(caption);
                
                 Image image= new Image()
                {
                    Source = img,
                    Width = 120
                };
                wraperGrd.Children.Add(image);
                tb_property_title_Copy.ToolTip = wraperGrd;
            };
           
        }

        private void searchQueryControl2_onGo(object sender, string e)
        {
            searchViewTabSwitch.IsChecked = true;
            
            mainSession.MainSearch.Query = e;
            if (string.IsNullOrWhiteSpace(e)) return;
            mainSession.MainSearch.StartSearch(true);

        }

        private void ResolveAllButton_Click(object sender, RoutedEventArgs e)
        {
            ResolveQueue rq = new ResolveQueue();
            foreach (var task in mainSession.Tasks)
            {
                rq.Add(task);
            }
            //rq.Start();

        }

        private void DownloadAllButton_Click(object sender, RoutedEventArgs e)
        {
            DownloadQueue dq = new DownloadQueue();
            foreach (var task in mainSession.Tasks)
            {
                dq.Add(task);
            }
           // dq.Start();
        }

        private void DeleteAllButton_Click(object sender, RoutedEventArgs e)
        {
            mainSession.Tasks.Clear();
        }

        private async void StartToolButton_Click(object sender, RoutedEventArgs e)
        {
            mainSession.SelectedTask?.StartStart();
        }

        private async void DownloadRawStreamsButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainSession.SelectedTask == null) return;
            if (mainSession.SelectedTask.IsResolved == false) return;
            var res = await mainSession.SelectedTask?.StartDownloadRawStreams();
            MessageBox.Show($"{res.SuccessfullyDownloadedCC}/{res.totalResourcesCC} resources were successfully downloaded.", "download completed", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }






}

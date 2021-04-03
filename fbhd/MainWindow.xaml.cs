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
            mainSession = (Session) this.DataContext;
           


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
            Binding lb = new Binding();
            lb.Source = resolutionPicker;
            lb.Path = new PropertyPath(ResolutionPicker.selectedResolutionProperty);

            lb.Converter = new ResolutionPickerConverter();
            lb.StringFormat = "mlf";

            //LabelPickedResolution .SetBinding(TextBlock.TextProperty, lb);

            

            return;
            Binding groupMeta_binding = new Binding("selectedTasks");
            groupMeta_binding.Source = this;
            groupMeta_binding.Converter = new SelectedTasksToUIVisibilityConverter();
            groupMeta_binding.ConverterParameter = "properties";
            groupMeta.SetBinding(GroupBox.VisibilityProperty, groupMeta_binding);


            Binding noneSelectedLabel_bd = new Binding("selectedTasks");
            noneSelectedLabel_bd.Source = this;
            noneSelectedLabel_bd.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            noneSelectedLabel_bd.Converter = new SelectedTasksToUIVisibilityConverter();
            noneSelectedLabel_bd.ConverterParameter ="count";
            lblnoneSelected.SetBinding(TextBlock.VisibilityProperty, noneSelectedLabel_bd);
            grd_PropertyResolution.SetBinding(Grid.VisibilityProperty, groupMeta_binding);


           // label_islistening.SetBinding(TextBlock.TextProperty, noneSelectedLabel_bd);
        }


        public void updateMyBidings()
        {

            Run_ffmpeg.GetBindingExpression(ButtonMi.isDisabledProperty).UpdateTarget();
            tb_property_title.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            titlePopupPickerMi.GetBindingExpression(PopupPickerMi.PairItemsProperty).UpdateTarget();
            taskInfo.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();
           // label_islistening.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
            groupMeta.GetBindingExpression(GroupBox.VisibilityProperty).UpdateTarget();
            grd_PropertyResolution.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();
            lblnoneSelected.GetBindingExpression(TextBlock.VisibilityProperty).UpdateTarget();

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

            //string ui = char.ConvertFromUtf32(int.Parse("0647", NumberStyles.AllowHexSpecifier));
           string ui =  Fucs.decodeUtf("");
            MessageBox.Show(ui);
            return;
           
                //      here the action run its command on cmd 
              
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = "ffmpeg.exe";
                startInfo.Arguments = "-i \"cs-aot92.mp4\" \"cs-aot9.mkv\" -y";
            startInfo.WorkingDirectory = "C:\\TOOLS\\fbhd";

            startInfo.CreateNoWindow = false;
            
           startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;

            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;


            process.Exited += new EventHandler((object s, EventArgs er) =>
            {
                MessageBox.Show("process exited with code: ");
               
               
            });
            process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler((object s , System.Diagnostics.DataReceivedEventArgs ar)=> {


                MessageBox.Show(ar.Data);
            });
            

            process.Start();
           
           

            outp = process.StandardOutput;
            // process.BeginOutputReadLine();



           


           // MessageBox.Show("au");
            

            string[] args = Environment.GetCommandLineArgs();
            



        }

        private void Process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async  void read_Click(object sender, RoutedEventArgs e)
        {
           Process my=  Fucs.constructProcess("python.exe", "C:\\TOOLS\\fbhd-gui\\scripts\\stdout.py");

            
            my.Start();
            my.StandardInput.AutoFlush = true;
            await Task.Delay(2000);
           
            my.StandardInput.WriteLine("\x3");

            
           
           
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
                task.IsSelected = false;
                int ix = mainSession.Tasks.IndexOf(task) +1;
                if (mainSession.Tasks.Count > ix)
                ((FBHDTask)mainSession.Tasks[ ix ]).IsSelected = true;
                else
                {
                    if(ix - 2>-1)
                    (mainSession.Tasks[ix - 2]).IsSelected = true;
                    

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

        public void addNewFBHDTask(string url_, TaskType type)
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
            nwtsk.TaskProperties.titleSettings = ts;
            mainSession.Tasks.Add(nwtsk);
            mainSession.HasTasks = true; // this true value does not go anywhere it just triggers the setter so that the notif gets fired
            mainSession.TasksCount = 222; // this setter only notifies the change 

        }




        public uint exportTasks(string saveAs= MI.MAIN_PATH+ "\\tasks.txt", string template="$url\r\n")
        {



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

        // Using a DependencyProperty as the backing store for isSomethingSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isSomethingSelectedProperty =
            DependencyProperty.Register("isSomethingSelected", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        private void start_butt_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void start_butt_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("mi: start cycle methoode not implemented yet");
            
        }

        private async void Parse_butt_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mainSession.SelectedTask == null)
                return;

            mainSession.SelectedTask.Post = await mainSession.SelectedTask.StartResolve();
            resolutionPicker.GetBindingExpression(ResolutionPicker.ResolutionsProperty).UpdateTarget();
        }

        private void Run_ffmpeg_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void importListButton_Click(object sender, RoutedEventArgs e)
        {
            Typeface tf = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);

            

           // TextTrailingCharacterEllipsis uio = new TextTrailingCharacterEllipsis(70, tf);
            py_resolver_processes.TextTrimming = TextTrimming.CharacterEllipsis;
           
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

            ws.Start();

        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            webServer.Stop();
            server_toggle.Content = "Server Off";
            mainSession.IsServerRunning = false;

            ((SolidColorBrush)server_toggle.Foreground).Color = Colors.Gray;//"#FF83CE7F"

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
            mainSession.MainSearch.StartSearch(true);

        }

        private async void button_Click_2(object sender, RoutedEventArgs e)
        {

            testCurl("https://video.fcmn1-1.fna.fbcdn.net/v/t76.34397-2/10000000_452984002512954_6842131401692255162_n.mp4?_nc_cat=1&ccb=1-3&_nc_sid=5aebc0&efg=eyJ2ZW5jb2RlX3RhZyI6ImRhc2hfdjRfcGFzc3Rocm91Z2hfZnJhZ18yX3ZpZGVvIiwicG9saWN5SWQiOjQwOTd9&_nc_ohc=xBISr6nUnLsAX-wTD2u&_nc_ht=video.fcmn1-1.fna&hnt1=prn&hnt2=ftw&oh=1ae323b0038a420bbd29314e09ab471f&oe=6062C7EF");
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
            var cpp2 = new WebClient.cURL().parseProgress(p2);
            
            if (cpp2.HasValue)
                MessageBox.Show(cpp2.Value.ToString());
            else
            {
                MessageBox.Show("has no cale");
            }
            return;
            
        
        }
        // the 4 copy to clip buttons
        private void copy_to_clip_button(object sender, RoutedEventArgs e)
        {

            try
            {

            
            string from = (string)((ButtonMi)sender).Tag;
            string textToCopy = "";
            switch (from)
            {
                case "command":
                    textToCopy = "cp_command not implemented yet, look for me in mainWindow's code behind";
                    break;
                case "video":
                    string pickedReso = resolutionPicker.selectedResolution.serialized;
                    textToCopy = mainSession.SelectedTask.Post.Value.QualityLabels.Find((Q) =>
                (Q.qualityName ==
                (pickedReso))
                ).videoUrl;
                        testCurl(textToCopy);
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

            }
            catch (Exception)
            {
                MessageBox.Show("something went wrong");
            }
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
            picker.Description = "FBHD Global Output Directoty";
            picker.ShowDialog(this);

            mainSession.GlobalOutputFolder = picker.SelectedPath;

           
        }

        private void importListButt_Click(object sender, RoutedEventArgs e)
        {
            string listFile = "oiu";
            var fd = new VistaOpenFileDialog();
            fd.CheckFileExists = true;
            fd.CheckPathExists = true;
            fd.DefaultExt = "txt";
            fd.InitialDirectory = "C:\\TOOLS\\fbhd-gui";
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
    }






}

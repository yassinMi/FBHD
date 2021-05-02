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
           
         }


        public void updateMyBidings()
        {

            return;
            Run_ffmpeg.GetBindingExpression(ButtonMi.isDisabledProperty).UpdateTarget();
            tb_property_title.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            titlePopupPickerMi.GetBindingExpression(PopupPickerMi.PairItemsProperty).UpdateTarget();
            taskInfo.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();
            groupMeta.GetBindingExpression(GroupBox.VisibilityProperty).UpdateTarget();
            grd_PropertyResolution.GetBindingExpression(Grid.VisibilityProperty).UpdateTarget();

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
              //  task.IsSelected = false; //lb
                int ix = mainSession.Tasks.IndexOf(task) +1;
               // if (mainSession.Tasks.Count > ix)
               // ((FBHDTask)mainSession.Tasks[ ix ]).IsSelected = true;
              //  else
               // {
               //     if(ix - 2>-1)
                 //   (mainSession.Tasks[ix - 2]).IsSelected = true;
                    

               // }


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
            TasksListBox.SelectedItem = nwtsk;
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

            TaskbarItemInfo = new System.Windows.Shell.TaskbarItemInfo();

           // TaskbarItemInfo.ProgressState = System.Windows.Shell.TaskbarItemProgressState.Normal;
           // TaskbarItemInfo.ProgressValue = 0.9;
                var notim= new System.Windows.Media.Imaging.BitmapImage(new Uri("C:\\TOOLS\\fbhd-gui\\fbhd\\fbhd\\media\\bell-16-orange-filled.png"));
            TaskbarItemInfo.Overlay = notim;

            // TaskbarItemInfo.ProgressState = System.Windows.Shell.TaskbarItemProgressState.None;
            TaskbarItemInfo.Description = "fbhd - 5 news from DOCS";
            TaskbarItemInfo.ThumbButtonInfos = new System.Windows.Shell.ThumbButtonInfoCollection();
            ThumbButtonInfo ty;
            System.Windows.Shell.ThumbButtonInfo tb = new ThumbButtonInfo();
            tb.ImageSource = notim;
            tb.Description = "start list watcher";
            tb.Command = ApplicationCommands.NotACommand;
            tb.IsEnabled = true;
            tb.IsInteractive = true;
            tb.CommandTarget = this;
            tb.DismissWhenClicked = true;
            tb.Click += (s,ee) => { MessageBox.Show("ok"); };
            tb.DismissWhenClicked = true;
            System.Windows.Shell.ThumbButtonInfoCollection  tbc= new ThumbButtonInfoCollection();
            tbc.Add(tb);
            TaskbarItemInfo.ThumbButtonInfos = tbc;
                return;

            string xpreset = File.ReadAllText("C:\\TOOLS\\fbhd-gui\\xml\\testxml.xml");
            string htmldata = File.ReadAllText("C:\\TOOLS\\fbhd-gui\\xml\\textxmlcontent.html");
            var temp = XElement.Parse("<tr><td valign=\"top\"></td><td><a href=\"/uploads/Docs/\">Parent Directory</a>       </td><td></td><td align=\"right\">  - </td><td></td></tr>");

                                      //<tr><td valign="top"></td><td><a href="/uploads/Docs/">Parent Directory</a>       </td><td>&nbsp;</td><td align="right">  - </td><td>&nbsp;</td></tr>
            MessageBox.Show(temp.ToString());
            return;
            XParserTag xparser = new XParserTag(temp, new wraper(null, null) { Output = htmldata });


            string xn = "<par xmlns:x=\"my custom shit\"> <x:myDiv><x:regular normal=\"true\" /> bla bla bla </x:myDiv></par>";
            var parsed =  XElement.Parse(xn);
            var hasns = (XElement)parsed.FirstNode;
            var regular = (XElement)hasns.FirstNode;
           // string pre = regular.GetDefaultNamespace().ToString();
           // MessageBox.Show($"namespaceName: {pre}");
            MessageBox.Show(regular.Name.LocalName);
            MessageBox.Show(regular.Name.NamespaceName);


            return;

            
            string strr = File.ReadAllText("C:\\TOOLS\\fbhd-gui\\xml\\fsdmNews.xml");

         

            string str =""+
                $"PrimaryScreenHeight:{SystemParameters.PrimaryScreenHeight}\n" +
                $"FullPrimaryScreenHeight:{SystemParameters.FullPrimaryScreenHeight}\n" +
                $"MaximizedPrimaryScreenHeight:{SystemParameters.MaximizedPrimaryScreenHeight}\n" +
                $"MenuBarHeight:{SystemParameters.MenuBarHeight}\n" +
                $"CaptionHeight:{SystemParameters.CaptionHeight}\n" +
                $"MaximumWindowTrackHeight:{SystemParameters.MaximumWindowTrackHeight}\n" +
                $"VirtualScreenHeight:{SystemParameters.VirtualScreenHeight}\n" +
                $"FixedFrameHorizontalBorderHeight:{SystemParameters.FixedFrameHorizontalBorderHeight}\n" +


               "";

           
           // MessageBox.Show(str);
            
            NotificationWindowMi nm = new NotificationWindowMi();
            nm.Left = SystemParameters.PrimaryScreenWidth - nm.Width;
            nm.Top = SystemParameters.PrimaryScreenHeight 
            ;

            nm.Show();



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
           // mainSession.fsdmNewsWatcher.Interval = 10000;
           
            mainSession.FsdmNewsWatcher.StartWatching();
        }

        private void fsdmnewswatchButt_Unchecked(object sender, RoutedEventArgs e)
        {
            mainSession.FsdmNewsWatcher.StopWatching();

        }

        private void pinWindowButt_Click(object sender, RoutedEventArgs e)
        {
            string bluePinIcon= "file:///C:/TOOLS/fbhd-gui/fbhd/fbhd/media/pin-2-13BRIGHT-blue.png";
            string whitePinIcon = "file:///C:/TOOLS/fbhd-gui/fbhd/fbhd/media/pin-2-13BRIGHT.png";
            if (this.Topmost)
            {
                this.Topmost = false;
                pinWindowButt.iconSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(whitePinIcon));
                
            }
            else
            {
                this.Topmost = true;
                pinWindowButt.iconSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(bluePinIcon));

            }


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
            mainSession.FsdmNewsWatcher.Interval -= 30000;
        }

     

        private void intervalIncTb_OnIncrease(object sender, RoutedEventArgs e)
        {
            mainSession.FsdmNewsWatcher.Interval += 30000;

        }

        private void UnreadNewsButt_Click(object sender, RoutedEventArgs e)
        {
            PopupNews(mainSession.FsdmNewsWatcher.UnreadNews, mainSession.FsdmNewsWatcher, "News",false);
        }

       


        private void devFakeCheck_Click(object sender, RoutedEventArgs e)
        {

        }

        private void devShowPopup_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void devRemoveLatestNewsItem_Click(object sender, RoutedEventArgs e)
        {
            string c = File.ReadAllText(MI.FSDM_News_Ref_PATH);

            string pre_triming = Regex.Match(c, "<ul class=\"list contact-details\">(.*?)<div class=\"paginationx\">", RegexOptions.Singleline).Value;
            //MessageBox.Show(pre_triming.Length.ToString());

            string mc = Regex.Match(pre_triming, "<li>.\\s*<div>.?(.*?)</li>", RegexOptions.Singleline).Value;

            c=c.Replace(mc, "");
            File.WriteAllText(MI.FSDM_News_Ref_PATH, c);

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
    }






}

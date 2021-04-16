using System;
using System.Threading.Tasks;


using System.Windows;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace fbhd
{




    public enum TaskType
    {
        mp4Task = 1, mp3Task = 0, mkvTask = 2, jpgTask = 3

    }



    /// <summary>
    /// the core task object, use this as the main source of data, all other UI elements should use it as data context
    /// </summary>
    public class FBHDTask : DependencyObject, INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static MainWindow mw = (MainWindow)Application.Current.MainWindow;


        private void notif(string propName)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propName));

                //MessageBox.Show("a listener to "+ propName);

            }
        }














        private TaskType type;
        public TaskType Type
        {
            set { type = value;
                notif(nameof(Type));
                notif(nameof(HasVideo));
                notif(nameof(MediaType));

            }
            get { return type; }
        }


        private MediaType mediaType;
        public MediaType MediaType
        {
            set { mediaType = value; 
                type = Fucs.MediaTypeToType(value);
                notif(nameof(MediaType));
                notif(nameof(Type));
                notif(nameof(HasVideo));
            }
            get { return Fucs.TypeToMediaType(type); }

        }

        private string url;
        public string Url
        {
            set { url = value; notif(nameof(Url)); }
            get { return url; }
        }


        private Post? post;
        public Post? Post
        {
            set { post = value; notif(nameof(Post)); }
            get { return post; }
        }


        private TaskProperties taskProperties;
        public TaskProperties TaskProperties
        {
            set { taskProperties = value; notif(nameof(TaskProperties)); }
            get { return taskProperties; }
        }


        private TaskStatus status;
        public TaskStatus Status
        {
            set { status = value;
                notif(nameof(Status));
                notif(nameof(ShouldShowProperties));
            }
            get { return status; }
        }





        private Size outputFileSize;
        public Size OutputFileSize
        {
            set { outputFileSize = value;
                notif(nameof(OutputFileSize)); }
            get { return outputFileSize; }
        }



        public double downloadingPercent
        {
            
            get
            {
                if (ffmpegProgress.isNull == true)
                    return 0;

                if (ffmpegProgress.Percent == double.NaN)
                    return 0;
                if (double.IsNaN(ffmpegProgress.Percent))
                    return 0;
                return ffmpegProgress.Percent;
            }
        }


       


        private FFMPEG.FFMPEGProgress ffmpegProgress;
        public FFMPEG.FFMPEGProgress FfmpegProgress
        {
            set { ffmpegProgress = value;
              
                
                notif(nameof(FfmpegProgress));
                notif(nameof(downloadingPercent));

            }
            get { return ffmpegProgress; }
        }



        private bool isSelected;
        public bool IsSelected
        {
            set { 


                if (value)
                {
                    foreach (var taskObj in parentList)
                    {
                        if (taskObj.IsSelected)
                        {
                            taskObj.IsSelected = false;
                        }
                    }
                    mw.mainSession.SelectedTask = this;

                }

                else
                {
                    if(mw.mainSession.SelectedTask == this)
                    {
                        mw.mainSession.SelectedTask = null;
                    }
                }

                isSelected = value;
                notif(nameof(IsSelected)); }
            get { return isSelected; }
        }



        private bool isAborted;
        public bool IsAborted
        {
            set { isAborted = value; notif(nameof(IsAborted)); }
            get { return isAborted; }
        }


        private bool isDownloaading;
        public bool IsDownloading
        {
            set { isDownloaading = value; notif(nameof(IsDownloading)); }
            get { return isDownloaading; }
        }


        private bool isResolved;
        public bool IsResolved
        {
            set { isResolved = value;
                notif(nameof(IsResolved));
                notif(nameof(ShouldShowProperties));

                }
            get { return isResolved; }
        }



        private string failureReason;
        public string FailureReason
        {
            set { failureReason = value; notif(nameof(FailureReason)); }
            get { return failureReason; }
        }


        private string outputFile;
        public string OutputFile
        {
            set { outputFile = value; notif(nameof(OutputFile)); }
            get { return outputFile; }
        }


        private string outputDirectory = null;
        public string OutputDirectory
        {
            set {
                Trace.Assert(Directory.Exists(value), "Mi: Directory does not exist, Please contect the developer with error code: 25656");

                value = value.TrimEnd(new char[] {'\\' }) + "\\";


                outputDirectory = value; notif(nameof(OutputDirectory)); }
            get { 
                if(outputDirectory!= null)
                {
                    return outputDirectory;
                }
                else if(mw.mainSession.GlobalOutputFolder!=null)
                {
                    return mw.mainSession.GlobalOutputFolder;
                }
                else
                {
                    throw new Exception("mi: FBHDTask: output directory could not be resolved");
                }

            }
        }


        


        public bool ShouldShowProperties
        {
            get
            {
                return this.IsResolved && (Status != TaskStatus.done);
            }
        }





        /// <summary>
        /// just a shortcut to facilitate binding with smouth changes notifying
        /// </summary>
        public List<KeyValuePair<string,string>> AvailableTitles
        {
            get
            {
                return this.TaskProperties.titleSettings.AvailableTitles;
            }
        }



        /// <summary>
        /// indecates wheather the current type is a video type: i.e: mkv | mp4
        /// </summary>
        public bool HasVideo
        {
            get { return ((Type == TaskType.mp4Task) || (Type == TaskType.mkvTask)); }

        }





        public async void StartDownload(Post post)
        {
           // MessageBox.Show("mi FBHDTask. startDownload not implemented yet");

            //####  DOWNLOAD  ####
            Status = TaskStatus.downloading;


            Action<FFMPEG.FFMPEGProgress> onProgAction = (FFMPEG.FFMPEGProgress progress) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.FfmpegProgress = progress;
                    this.OutputFileSize = progress.Size;
                    this.IsDownloading = true;

                });
            };

            OutputFile = OutputDirectory + Fucs.filenamify(taskProperties.titleSettings.getResult()
                + $".{FFMPEG.getExtention(Type)}");
            string ffmpegArgs = FFMPEG.MakeArgs(this);
            
            // MessageBox.Show(ffmpegArgs);
            // return;
            // MessageBox.Show(ffmpegArgs);
            mw.comma.Text = ffmpegArgs;
            ffmpeg_process_ref = null;

            int downloaded = await Fucs.run_ffmpeg_task(ffmpegArgs, onProgAction, this);

            if ((downloaded != 0) && (downloaded != 255))
            {
                FailureReason = "ffmpg exited with code: " + downloaded.ToString();
                Status = TaskStatus.failed;
                return;
            }
            //TitleSettings ts = new TitleSettings(post, true, "miracles title", serialTtitle_: "robotic title");
            //ts.sourceFallbacks = new TitleSource[10];
            //ts.sourceFallbacks[0] = TitleSource.ogTitle;
            //ts.isTaskResolved = true;
            // FBHd.Verbose(new TitleSettings().getResult());
            if (downloaded == 255)
            {
                //todo distinguish between normal sucess, and an aborted task
                this.IsAborted = true;

            }
            this.IsDownloading = false;
            Status = TaskStatus.done;
        }


        public async Task<Post?> StartResolve()
        {

            // #### validate ####
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                FailureReason = "Invalid URL";
                Status = TaskStatus.failed;
                return null;
            }
            bool exixts = CheckExistentHTML();
            //MessageBox.Show(exixts.ToString());
            // ####  RESOLVE  ####
            Status = TaskStatus.resolving;
            Post post;
            try
            {
                if (exixts && !IsResolved)
                {

                    post =fbhd.Post.fromHTMLContent(File.ReadAllText(makeHTMLFileName()),
                    StandardPostProperties.stdTitles, StandardPostProperties.stdImages);


                }
                else
                    post = fbhd.Post.fromHTMLContent(await Fucs.run_py_fetcher(uri),
                        StandardPostProperties.stdTitles, StandardPostProperties.stdImages);
                //Post post = Post.fromHTMLContent(System.IO.File.ReadAllText("C:\\TOOLS\\fbhd-gui\\html\\dummy.html"));

            }
            catch (Exception hy)
            {
                FailureReason = hy.Message;
                Status = TaskStatus.failed;

                throw;
                return null;
            }

            if (post.isPrivate == true)
            {
                FailureReason = "Target content is private.";
                Status = TaskStatus.failed;
                return post;
            }

            //todo creat an onResolved event 
            var rs = TaskProperties.resolutionSettings;
            rs.Available = post.AvailableResolutions;
            TaskProperties.resolutionSettings = rs;
            var ts = TaskProperties.titleSettings;

            ts.PostObj = post;

            this.IsResolved = true;
            notif(nameof(AvailableTitles));
            //MessageBox.Show(post.audioUrl);

            Status = TaskStatus.pending;
            return post;

        }







        /// <summary>
        /// checkes wheather an HTML file named after this taskComponent's Url's hashcode exixsts in the HTML_CONTAINER_PATH 
        /// returns a boolean, and automatically updates the dproperty existsCachedHTML, 
        /// for other useses
        /// </summary>
        public bool CheckExistentHTML()
        {
            bool exists = File.Exists(makeHTMLFileName());
            // MessageBox.Show(makeHTMLFileName());
            this.existsCachedHTML = exists;
            return exists;
        }



        private bool existsCachedHTML;
        private readonly BindingList<FBHDTask> parentList;

        public FBHDTask(BindingList<FBHDTask> tasks)
        {
            this.parentList = tasks;
        }

        internal async Task<bool> OpenOutputFile()
        {
            Process p = Fucs.constructProcess("cmd", "/c \"" + OutputFile + "\"");
            await Task.Run(new Action(() => {
                p.Start();
                p.WaitForExit();
            }));
            return p.ExitCode == 0;
        }

        /// <summary>
        /// specifies wheather or not a pre-fetched HTML fle exists in the html countainer folder
        /// used for avoiding re fetching the same content, 
        /// NOTE: this does'nt performe the file chekint this is just a get/set property ,
        /// that said, use the CheckExistentHTML methode to update this
        /// </summary>
        public bool ExistsCachedHTML
        {
            
            get { return existsCachedHTML ; }
            set { existsCachedHTML= value; }
        }

       


        public async Task<bool> aborteFfmpegProcess()
        {
            if (ffmpeg_process_ref == null)
            {
                MessageBox.Show("prcess null");
                return false;
            }
            //ffmpeg_process_ref.StandardInput.WriteLine("\x3");
            //ffmpeg_process_ref.StandardInput.Flush();


            if (Fucs.AttachConsole((uint)ffmpeg_process_ref.Id))
            {
                Fucs.SetConsoleCtrlHandler(null, true);

                try
                {
                    if (!Fucs.GenerateConsoleCtrlEvent(Fucs.CTRL_C_EVENT, 0))
                        return false;
                    await Task.Run(() =>
                    {
                        ffmpeg_process_ref.WaitForExit();
                    });


                }
                finally
                {
                    Fucs.SetConsoleCtrlHandler(null, false);
                    Fucs.FreeConsole();

                }
                return true;
            }

            return true;


        }

        internal async Task<bool> OpenOutputLocation(bool shouldSelectFile)
        {
            Process p = Fucs.constructProcess("explorer", "/select,\"" + OutputFile + "\"");
            await Task.Run(new Action(() => {
                p.Start();
                p.WaitForExit();
            }));
            return true;
        }

    

        internal async Task<bool> DeleteOutputFile()
        {
            try
            {
                await Task.Run(new Action(() => {

                    File.Delete(OutputFile);

                }));

            }
            catch (Exception)
            {

                MessageBox.Show("could not delete file, make sure it's not opened by another program.");
                return false;
            }
            
            return true;
        }

        string makeHTMLFileName()
        {
            return MI.HTML_CONTAINER_PATH + "\\" + this.url.GetHashCode().ToString() + ".html";
        }



        

        public Process ffmpeg_process_ref
        {
            get;
            set;
        }


















































    }
}

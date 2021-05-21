using System;
using System.Threading.Tasks;


using System.Windows;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;
using System.Linq;

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



        private double rawDownloadProgress;
        public double RawDownloadProgress
        {
            set { rawDownloadProgress = value;
                notif(nameof(RawDownloadProgress));
                notif(nameof(downloadingPercent));

            }
            get { return rawDownloadProgress; }
        }



        public double downloadingPercent
        {
            
            get
            {
                if (RawDownloadMode)
                {
                    return RawDownloadProgress;
                }

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
        [Obsolete("",true)]
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




        /// <summary>
        /// calculates the resolution that should be used, using TaskProperties.resolutionSettings.getResult()
        /// </summary>
        public Resolution ResolvedResolution
        {
           
            get { return TaskProperties.resolutionSettings.getResult(); }
        }



        public async Task<int> StartDownload(Post post)
        {
            int downloadActionErrorCode=2; //1 makeArgs, 2: general , 3: pull error
           // MessageBox.Show("mi FBHDTask. startDownload not implemented yet");

            //####  DOWNLOAD  ####
            Status = TaskStatus.downloading;
            this.ProgressCaption = "Wait..";


            EventHandler<FFMPEG.FFMPEGProgress> onProgAction = (object s,FFMPEG.FFMPEGProgress progress) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.FfmpegProgress = progress;
                    this.OutputFileSize = progress.Size;
                    this.IsDownloading = true;

                });
            };

            if (!Directory.Exists(OutputDirectory))
            {
                Directory.CreateDirectory(OutputDirectory);
            }

            OutputFile = OutputDirectory + Fucs.filenamify(taskProperties.titleSettings.getResult()
                + $".{FFMPEG.getExtention(Type)}");
            string ffmpegArgs;
            try
            {
                ffmpegArgs =  FFMPEG.MakeArgs(this);
            }
            catch (Exception MakeArgsException)
            {
                FailureReason = "Error in FFMPEG.MakeArgs: " + Environment.NewLine +
                    MakeArgsException.Message;
                Status = TaskStatus.failed;
                return 1; //error 1 means make args exception

            }


            // MessageBox.Show(ffmpegArgs);
            // return;
            // MessageBox.Show(ffmpegArgs);
            //mw.devregex.Text = ffmpegArgs;
            mw.ConsoleRTB.Document.Blocks.Add(new Paragraph(new Run("ffmpeg "+ffmpegArgs)));
            mw.ConsoleRTB.ScrollToEnd();
            mw.consoleScrollView.ScrollToEnd();

            FfmpegTask = new FFMPEG();
            FfmpegTask.OnProgress += onProgAction;
            FfmpegTask.OnDownloadng+= (s, code) => {
                this.Dispatcher.Invoke(() =>
                {
                    ProgressCaption = "Downloading..";
                });
            };

            FfmpegTask.OnExitedWithError += (s, code) => {
                this.Dispatcher.Invoke(() =>
                {
                    // mw.devregex_iinput.Text = FfmpegTask.Builder.ToString();
                    // MessageBox.Show(FfmpegTask.Builder.ToString().Substring(Math.Max(0,  FfmpegTask.Builder.ToString().Length - 1200)));
                    // todo: fill commandline interface with the ffmpeg output
                    mw.ConsoleRTB.Document.Blocks.Add(new Paragraph(
                        new Run("----------------------" + Environment.NewLine +
                        FfmpegTask.Builder.ToString())
                        { Foreground = new SolidColorBrush(Colors.Yellow) }));
                    mw.ConsoleRTB.ScrollToEnd();
                    mw.consoleScrollView.ScrollToEnd();

                    FailureReason += $"ffmpg exited with code: {code} " ;
                    Status = TaskStatus.failed;

                    return ;
                });
            };

            FfmpegTask.OnExitedSuccessfully += (s, code) => {
                this.Dispatcher.Invoke(() =>
                {
                    this.IsDownloading = false;
                    Status = TaskStatus.done;
                });
            };
            FfmpegTask.OnError += (s, err) => {
                this.Dispatcher.Invoke(() =>
                {
                    FailureReason += $"{err.Message}.{Environment.NewLine}";
                    MI.DumpError(err, "Download Action");

                    if(FailureReason.Contains("pull"))
                    downloadActionErrorCode = 3 ;


                });
            };
            FfmpegTask.OnRunning += (s, rr) => {
                MI.Verbose("ffmpeg is running");
                FailureReason = "";
            };
            MI.Verbose("Starting ffmpeg..");


            int exitCode =await FfmpegTask.Run(ffmpegArgs);
            MI.Verbose(null);




            //TitleSettings ts = new TitleSettings(post, true, "miracles title", serialTtitle_: "robotic title");
            //ts.sourceFallbacks = new TitleSource[10];
            //ts.sourceFallbacks[0] = TitleSource.ogTitle;
            //ts.isTaskResolved = true;
            // FBHd.Verbose(new TitleSettings().getResult());
            if (exitCode == 255)
            {
                //todo distinguish between normal sucess, and an aborted task
                this.IsAborted = true;

            }

            //unsafe loop, keeps retrying on pull errors
            if (downloadActionErrorCode == 3)
            {
                return await StartDownload(Post.Value);
            }
            return downloadActionErrorCode;
           
        }
        public event EventHandler Resolved;

        public async Task<Post?> StartResolve()
        {

            // #### validate url ####
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                FailureReason = "Invalid URL";
                Status = TaskStatus.failed;
                return null;
            }
            ExistsCachedHTML = CheckExistentHTML();

            // ####  RESOLVE  ####
            Status = TaskStatus.resolving;
            Post post;
            string PagContent; // will hold either the cached page content or a new fetched one

            if (ExistsCachedHTML && !IsResolved) //use the cached page 
            {
                PagContent = File.ReadAllText(makeHTMLFileName());
            }
            else  //fetch new page 
            {
                string tempHtmlFileName = makeHTMLFileName();
                // fetch post and cach htmk file
                var PostResult = await new WebClient.cURL().GetTextAdvanced(Url, Headers.FB_Fake_Browser_For_HD_Videos, tempHtmlFileName, true);
                if (!PostResult.Success)
                {
                    FailureReason = $"curl exited with code: {PostResult.ClientExitCode}";
                    MI.DumpError(new Exception($"fetching failed, task url: {Url}"),"resolve action");
                    Status = TaskStatus.failed;
                    IsResolved = false;
                    return null;
                }
                PagContent = PostResult.Text;

            }

            try
            {
                IsResolved = false;

                post = fbhd.Post.fromHTMLContent(PagContent,
                        StandardPostProperties.stdTitles, StandardPostProperties.stdImages);

            }
            catch (Exception ParsingException)
            {

                FailureReason = ParsingException.Message;
                Status = TaskStatus.failed;
                MI.DumpError(ParsingException, "resolve action");

                //throw;
                //trace
                IsResolved = false;
                return null;
            }


            //validate post object
            if (post.isSomethingWentWrongPage == true)
            {
                FailureReason = "host returned Something Went Wrong page";
                MI.DumpError(new Exception("host returned Something Went Wrong page"), "resolve action");

                Status = TaskStatus.failed;
                return post;
            }
            if (post.isPrivate == true)
            {
                FailureReason = "Target content is private.";
                Status = TaskStatus.failed;
                return post;
            }
            // this validator is obsolete after the DashManifest update
            if (string.IsNullOrWhiteSpace(post.audioUrl) == true)
            {
                FailureReason = "Parsing failed: Audio Url is Missing.";
                Status = TaskStatus.failed;
                return post;
            }

            //todo creat an onResolved event 
            // # update properties 

            var rs = TaskProperties.resolutionSettings;
            rs.Available = post.AvailableResolutions;
            rs.isChoiceTargeted = true;
            TaskProperties.resolutionSettings = rs;
            var ts = TaskProperties.titleSettings;

            ts.PostObj = post;
            TaskProperties.trimmingSettings=new TrimmingSettings(post.Duration);

            this.IsResolved = true;
            Resolved?.Invoke(this, new EventArgs());

            notif(nameof(AvailableTitles));
           // notif(nameof(TrimmingTo));

            Status = TaskStatus.pending;
            return post;

        }



        public string getChosedVideoStream()
        {
            string resolutionstr = taskProperties.resolutionSettings.getResult().serialized;

            VideoRepresentation? pickedVr= this.Post.Value.DashManifest.VideoRepresentations.Find((vr) =>vr.FBQualityLabel== resolutionstr);
            if (pickedVr == null) throw new Exception("pickedVr NullRef");
            return pickedVr.Value.BaseUrl;

        }

        private bool rawDownloadMode;
        public bool RawDownloadMode
        {
            set { rawDownloadMode = value; notif(nameof(RawDownloadMode)); }
            get { return rawDownloadMode; }
        }


        private string progressCaption;
        public string ProgressCaption
        {
            set { progressCaption = value; notif(nameof(ProgressCaption)); }
            get { return progressCaption; }
        }




        public async void StartStart()
        {



            Post= await StartResolve();
            
            if(IsResolved&& Post.HasValue)
            StartDownload(Post.Value);
            return;
        }


        public struct DownloadRawResult
        {
           public int totalResourcesCC, SuccessfullyDownloadedCC;
        }

        public async Task<DownloadRawResult> StartDownloadRawStreams()
        {


            var result= new DownloadRawResult();
            RawDownloadMode = true;
            WebClient.cURL crl = new WebClient.cURL();
            crl.AfterArgs = " -k"; // insecure flag solves the connection was reset and the error 60 problems
            string name = Fucs.filenamify(taskProperties.titleSettings.getResult());

            // # setting up curl downloader
            crl.DateRecieved += (s, e) => {
               // MI.ConsoleLog("[curl]: " + e);
            };
            crl.onProgress += (s, e) => {

                this.RawDownloadProgress = e.Percent*100;
                
                MI.ConsoleLog(e.Percent.ToString());
            };
            crl.ProcessExited += (s,e) => {
                MI.ConsoleLog($"[curl exited with code {e}]");
            };

             Status = TaskStatus.downloading;


            result.totalResourcesCC = 3;
            // # video
            ProgressCaption = "[1/3]: video stream";
            string VidOutputFileName = $"{OutputDirectory}{name}-vid-rc";
            MI.ConsoleLog($"downloading raw video at {VidOutputFileName}");
            var chosedVidUrl = FFMPEG.UrlAdd443Port(getChosedVideoStream()); // this seems to solve the curl 34 error oppen ssl connection was reset after many tests
            WebClient.DownloadResult vidDLResult;
            do
            {
                vidDLResult = await crl.DownloadBinary(chosedVidUrl, VidOutputFileName);
                MI.ConsoleLog($"[curl returned code {vidDLResult.agentReturnCode}]");

            } while (vidDLResult.agentReturnCode==35);
            if (vidDLResult.Success)
            {
                result.SuccessfullyDownloadedCC++;
            }
            else
            {
                MI.ConsoleLog($"[curl failed with code {vidDLResult.agentReturnCode}]");
            }
            //# image
            ProgressCaption = "[2/3]: image stream";
            string ImgOutputFileName = $"{OutputDirectory}{name}-img-rc";
            MI.ConsoleLog($"downloading raw image at {ImgOutputFileName}");
            string choosedThumb = Fucs.getFirstNonNull(Post.Value.Images.ToList().ConvertAll<string>((item) => item.Value).ToArray());
            WebClient.DownloadResult ImgDLResult;
            do
            {
                ImgDLResult = await crl.DownloadBinary(choosedThumb, ImgOutputFileName);
                MI.ConsoleLog($"[curl returned code {ImgDLResult.agentReturnCode}]");

            } while (ImgDLResult.agentReturnCode == 35);
            if (ImgDLResult.Success)
            {
                result.SuccessfullyDownloadedCC++;
            }
            else
            {
                MI.ConsoleLog($"[curl failed with code {ImgDLResult.agentReturnCode}]");
            }


            //# audio
            ProgressCaption = "[3/3]: audio stream";
            string AudOutputFileName = $"{OutputDirectory}{name}-aud-rc";
            MI.ConsoleLog($"downloading raw audio at {AudOutputFileName}");
            string choosedAud = Post.Value.audioUrl;
            WebClient.DownloadResult AudDLResult;
            do
            {
                AudDLResult = await crl.DownloadBinary(choosedAud, AudOutputFileName);
                MI.ConsoleLog($"[curl returned code {AudDLResult.agentReturnCode}]");

            } while (AudDLResult.agentReturnCode == 35);
            if (AudDLResult.Success)
            {
                result.SuccessfullyDownloadedCC++;
            }
            else
            {
                MI.ConsoleLog($"[curl failed with code {AudDLResult.agentReturnCode}]");
            }



            Status = TaskStatus.pending;

            return result;

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
        /// indicates whether or not a pre-fetched HTML fle exists in the html countainer folder
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

            bool res = false;
            try
            {
                res = await FfmpegTask.Abort();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }


            return res;

        }

        public async Task<bool> KillFfmpegProcess()
        {
            
            bool res = false;
            try
            {
                
                FfmpegTask.Kill();
                res= true;
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }


            return res;
            await Task.Delay(1);

        }

        internal async Task<bool> OpenOutputLocation(bool shouldSelectFile)
        {
            string args = "/select,\"" + OutputFile + "\"";
            args = args+"";
           // MessageBox.Show(args);
            Process p = Fucs.constructProcess("explorer", args );
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
                if (File.Exists(OutputFile))
                {
                    await Task.Run(new Action(() => {

                        File.Delete(OutputFile);

                    }));
                    return true;
                }
                else
                {
                    MessageBox.Show("File does not exist");
                    return false;

                }

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
            return MI.TEMP_HTML_FILES + "\\" + Math.Abs( this.url.GetHashCode()).ToString() + ".html";
        }



        
        [Obsolete("Deprecated as the killing and aborting operations are now moved to the FFMPEG class, You can still access the process objec through The Process propetry of the FFMPEG instance",true)]
        public Process ffmpeg_process_ref
        {
            get;
            set;
        }

        public FFMPEG FfmpegTask
        {
            get;
            set;
        }


















































    }
}

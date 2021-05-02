using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows;

using System.Windows.Data;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.WebSockets;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml;

using System.Security.Policy;
using System.Dynamic;
using System.Xml.Serialization;

namespace fbhd
{





    public class BooleanToVisibilityInverted : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
           
            if ((bool)value == true)
            {
                return Visibility.Collapsed;
            }
            else 
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TaskObjToPropertiesVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }
            FBHDTask task = (FBHDTask)value;

            if (task.IsResolved == false)
            {
                return Visibility.Collapsed;
            }
            if (task.Status == TaskStatus.done)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class TypeToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)((TaskType)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (TaskType)((int)value);
        }
    }


    public class TypeToMediaTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Fucs.TypeToMediaType((TaskType)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Fucs.MediaTypeToType((MediaType)value);
        }
    }


    public class objectCast : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return (string)value;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }







    public class TaskStatusToTaskBarProgressState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskStatus input = (TaskStatus)value;

            switch (input)
            {
                case TaskStatus.pending:
                    return System.Windows.Shell.TaskbarItemProgressState.None;
                case TaskStatus.resolving:
                    return System.Windows.Shell.TaskbarItemProgressState.None;
                case TaskStatus.downloading:
                    return System.Windows.Shell.TaskbarItemProgressState.Normal;
                case TaskStatus.done:
                    return System.Windows.Shell.TaskbarItemProgressState.None;
                case TaskStatus.failed:
                    return System.Windows.Shell.TaskbarItemProgressState.Paused;
                default:
                    return System.Windows.Shell.TaskbarItemProgressState.None;
            }



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




    public class EmptyTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool reversed = false;
            
            if (parameter != null)
            {
                string parameterStr = parameter.ToString();
                bool.TryParse(parameterStr, out reversed);
                
               
     
            }
              

            bool evaluated;
            evaluated = ((string.IsNullOrEmpty((string)value)) ? true : false);
            if (reversed) evaluated = !evaluated;
            if (targetType == typeof(Visibility))
                return (evaluated ? Visibility.Visible : Visibility.Collapsed);
            else if (targetType == typeof(bool))
                return evaluated;
            else
                throw new NotImplementedException();



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class isPickedToForeground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return (((bool)value) ? ResolutionPicker.DefaultPickedForeground : ResolutionPicker.DefaultUnpickedForeground);


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class selectedToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)parameter == "border")
            {
                return new SolidColorBrush(((bool)value) ? TaskComponent.COLOR_SELECTEd_STATE_border : Colors.Transparent);

            }
            return new SolidColorBrush(((bool)value) ? TaskComponent.COLOR_SELECTEd_STATE : Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class TaskTypeToComboBoxItemIndex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskType tt = (TaskType)value;
            return (int)tt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int i = (int)value;
            return (TaskType)i;
        }
    }


    public class InvertBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }
    }


    /// <summary>
    /// converts the titles a resolevd post contains to a list of PairMiobjects (keys and values), so that the popupPickerMi can deal with them
    /// for abstraction purpos the PopupPickerMi was not designed to deal exclusively with picking titles, 
    /// it was meant to pick any Item, from a list of pairs, so the pairMi struct was implemented as a more generic solution
    /// </summary>
    [Obsolete("messed up and obsolete", true)]
    [ValueConversion(typeof(bool), typeof(bool))]
    public class taskTitlesToListOfPairsMi : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                //MessageBox.Show("its bull");
                return null;
            }
            TaskComponent tsk = (TaskComponent)value;
            if (tsk.isResolved)
            {
                return null;

            }
            else
            {
                //MessageBox.Show("returning the standard cuw untresolved");
                return null;
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }





    /// <summary>
    /// is the atsk is resolved this iwll returs the actual resolutions , if not its will resturn a standard set of resolutions
    /// </summary>
    public class taskToAvailableResolutions : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                //MessageBox.Show("its bull");
                return MI.standardResolutionSet;
            }
            FBHDTask tsk = (FBHDTask)value;
            if (tsk.IsResolved)
            {
                //MessageBox.Show("returned the av resos");
                //MessageBox.Show(tsk.postObj.Value.AvailableResolutions[0].toString());
                return tsk.Post.Value.AvailableResolutions;
            }
            else {
                //MessageBox.Show("returning the standard cuw untresolved");
                return MI.standardResolutionSet;
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// usage: passing the string "0:yassin; 1:miracles;" as param will return "yassin" on false and "miracles" on true
    /// can be sed to convert to double; 0:0; 1:1.5;
    ///  </summary>
    public class boolToStringsMI : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string param = (string)parameter;
            bool val = (bool)value;
            string true_str, false_str;

            true_str = (Regex.Match(param, "1:([^;]*);").Success) ?
                   Regex.Match(param, "1:([^;]*);").Groups[1].Value : "";
            false_str = (Regex.Match(param, "0:([^;]*);").Success) ?
                   Regex.Match(param, "0:([^;]*);").Groups[1].Value : "";

            if(targetType == typeof(string))
            {
                return val ? true_str : false_str;
            }
            else if (targetType == typeof(double))
            {
                return val ? double.Parse( true_str) : double.Parse( false_str);
            }
            else
            {
                return val ? true_str : false_str;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    /// <summary>
    /// used for shaping urls in different ways:
    /// exctracting id: no param,
    /// reducing string size with ellipses: param should specify the max number of characters, 
    /// </summary>
    public class URLtoVideoID : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            string param = (string)parameter;
            string url = (string)value;
            if (parameter == null)
            {
                url = new Uri(url).LocalPath;
                int i = url.IndexOf("videos/") + 7;
                if (i < 7)
                {
                    i = url.IndexOf("posts/") + 6;
                    if (i < 6)
                    {
                        return url;
                    }
                }
                if (i < url.Length)
                    return url.Substring(i);
                else
                    return "";
            }
            else if (int.Parse(param) > 0)
            {
                string reduced = "";
                int max = int.Parse(param);
                int length = url.Length;
                if (length > max)
                {

                    return url.Substring(0, ((int)(max / 2))) + "…" + url.Substring(length - ((int)(max / 2)));
                }
                else
                {
                    return url;
                }


                return reduced;
            }
            else
            {
                return "";
            }


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class SelectedTasksToUIVisibilityConverter : IValueConverter
    {
        public struct SelectedTasksToUIVisibilityConverterParameter
        {
            public SelectedTasksToUIVisibilityConverterParameter(string target_)
            {
                targetElem = target_;
            }
            public string targetElem;

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)parameter == "noneLabel")
            {
                // MessageBox.Show("noneLabel");
                if ((((List<TaskComponent>)value).Count) > 0)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }

            else if ((string)parameter == "properties")
            {
                if ((((List<TaskComponent>)value).Count) > 0)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }








            else
            {
                return ((List<TaskComponent>)value).Count.ToString();
            }



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class MI
    {
        public static string FFMPEG_PATH =  Environment.CurrentDirectory+"\\ffmpeg\\ffmpeg.exe";
        public static string CURL_PATH = Environment.CurrentDirectory + "\\curl\\curl.exe";
        public static string APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mi\\FBHD";
        public static MainWindow mw = (MainWindow)Application.Current.MainWindow;
        public static string MAIN_PATH = Environment.CurrentDirectory;
        internal const string FSDM_News_Ref_PATH = "C:\\TOOLS\\fbhd-gui\\fbhd-fsdm-news-watcher-reference.html";
        //public const string DEFAULT_GLOBAL_OUTPUT_DIR = "C:\\TOOLS\\fbhd-gui\\output\\";
        public static string DEFAULT_GLOBAL_OUTPUT_DIR = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\FBHD Output" ;

        public static string CLW_PRESETS_DIR= MAIN_PATH +  "\\CLW Presets";
        public static string APP_CONFIG_FILE =  APP_DATA + "\\config.mi.xml";
        internal static string TEMP_HTML_FILES = APP_DATA +  "\\Temp HTML";
        internal static string SCRIPTS_DIR = Environment.CurrentDirectory + "\\scripts";

        public static List<Resolution> standardResolutionSet {
            get
            {
                Resolution[] arrofresos =
                {

                new Resolution(720) ,
                Resolution.Source ,
                new Resolution(840) ,
               // new Resolution(690) ,
               // new Resolution(340) ,
             new Resolution(1080) ,
                new Resolution(144)

            };

                List<Resolution> li = new List<Resolution>();
                foreach (Resolution item in arrofresos)
                {
                    li.Add(item);
                }
                return li;

            }

        }

        public static async void Verbose(string VerboseStatus, int DurationInSeconds=-1)
        {

           await  mw.Dispatcher.Invoke(async () =>
            {
                if (VerboseStatus == null)
                {
                    mw.verboseStatusStack.Clear();
                    mw.verboseStatus = null;
                    return;
                }
                mw.verboseStatusStack.Add(VerboseStatus);
                
                mw.verboseStatus = mw.verboseStatusStack.Last();
               
               
                if (DurationInSeconds != -1)
                {
                    await Task.Delay(1000 * DurationInSeconds);
                    mw.verboseStatusStack.Remove(VerboseStatus);

                    if (mw.verboseStatusStack.Count > 0)
                    {
                        mw.verboseStatus = mw.verboseStatusStack.Last();
                    }
                    else
                    {
                        mw.verboseStatus = null;
                    }
                }
               


            });

        }

        public static void updateLogger(string VerboseStatus)
        {

            mw.Dispatcher.Invoke(() =>
            {
                mw.comma.Text = VerboseStatus;
            });

        }



    }





    public partial class Ybutt : System.Windows.Controls.Button
    {

        Ybutt()
        {
            System.Windows.Controls.Image io = new System.Windows.Controls.Image();


        }







    }


    public class dl_thick_anim : System.Windows.Media.Animation.IEasingFunction
    {
        public double Ease(double normalizedTime)
        {
            return Math.Floor(10 * normalizedTime) / 10; //
        }
    }







    public class TaskStatusToUIvisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskStatus ts = (TaskStatus)value;

            // converting status to the UIElement : url_border 's column propery (to ocupy he whole grid when status is pending

            if ((string)parameter == "url_column")
            {
                if (ts == TaskStatus.pending)
                {

                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            //MessageBox.Show( shouldMatch.ToString() );
            bool isVisible = (ts.ToString() == (string)parameter);
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class SelectedTasksToFirstItem : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            List<TaskComponent> tsks = (List<TaskComponent>)value;
            // converting status to the UIElement : url_border 's column propery (to ocupy he whole grid when status is pending


            if (tsks.Count > 0)
            {
                if (tsks[0] != null)
                {
                    return (TaskComponent)tsks[0];
                }
            }


            return (TaskComponent)null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public enum TaskStatus
    {
        pending, resolving, downloading, done, failed,
    }


    public struct QualityLabel
    {
        public QualityLabel(Resolution quality_resolution, string video_url)
        {
            qualityName = quality_resolution.toString(); videoUrl = video_url;
            resolution = quality_resolution;
            qualityThumbnail = "llje"; videoSize = "lze";
        }
        public string qualityName, videoUrl, qualityThumbnail, videoSize;
        public Resolution resolution;

    }





    public struct PostProperty<T>
    {



        public delegate T Extractor(string data);

        public Extractor MainExtractor { get; set; }
        public string name { get; set; }
        public Regex Regex { get; set; }
        public string PropertyGroup { get; set; }
        public int Precedence { get; set; }

        /// <summary>
        /// attemps to use the MainExtractor first, and fallsback into the Regex,
        /// if none was asigned it throws an exception 
        /// </summary>
        /// <param name="data">the data to perform the searching on, usually the post page content</param>
        public T Extract(string data)
        {
            if (MainExtractor != null)
                return MainExtractor(data);

            else if (Regex != null)
                throw new Exception("Mi:using Regex to execute the Exctraction is not supported yet");


            else
                throw new Exception("Mi: MainExtractor or Regex should be available in order to execute the Exctraction");
        }

    }

    public static class StandardPostProperties
    {


        public static PostProperty<string> ogtitle = new PostProperty<string>()
        {
            MainExtractor = new PostProperty<string>.Extractor((data) => {
                return Regex.Match(data,
             "<meta property=\"og:title\" content=\"([^\"]*)\" */>")
                    .Groups[1].Value.Replace("&amp;", "&");
            }),

            name = "og:title",
            PropertyGroup = "title",
            Precedence = 0


        };

        public static PostProperty<string> name_title = new PostProperty<string>()
        {
            MainExtractor = (data) => {
                return Regex.Match(data, "\"name\":\"([^\"]*)\"")
                .Groups[1].Value.Replace("&amp;", "&");
            },

            name = "name",
            PropertyGroup = "title",
            Precedence = 2,

        };

        public static PostProperty<string> description = new PostProperty<string>()
        {
            MainExtractor = (data) => {
                return Regex.Match(data,
                "<meta name=\"description\" content=\"([^\"]*)\" ?/>")
                 .Groups[1].Value.Replace("&amp;", "&");
            },

            name = "description",
            PropertyGroup = "title",
            Precedence = 1,


        };

        public static List<PostProperty<string>> stdTitles = new List<PostProperty<string>>()
        {

         ogtitle, description, name_title

        };

        public static PostProperty<bool> isPrivate = new PostProperty<bool>()
        {
            MainExtractor = (data) => {
                return Regex.Match(data,
                "You must log in to continue").Success;
            },

            name = "isPrivate",
            PropertyGroup = "general",
        };


        public static PostProperty<string> thumbnail = new PostProperty<string>()
        {
            MainExtractor = new PostProperty<string>.Extractor((data) =>
            {
                return Regex.Match(data, "\"thumbnailUrl\":\"([^\"]*)\"")
                .Groups[1].Value.Replace("\\", "");
            }),
            name = "thumbnailUrl",
            PropertyGroup = "image",
            Precedence = 1
        };

        public static PostProperty<string> ogImage = new PostProperty<string>()
        {
            MainExtractor = (data) => {
                return Regex.Match(data,
                "<meta property=\"og:image\" content=\"([^\"]*)\" */>")
                .Groups[1].Value.Replace("&amp;", "&");
            },
            name = "og:image",
            PropertyGroup = "image",
            Precedence = 0
        };

        public static List<PostProperty<string>> stdImages = new List<PostProperty<string>>()
        {
          thumbnail, ogImage
        };

        public static PostProperty<string> audioUrl = new PostProperty<string>()
        {
            MainExtractor = (data) => {
                return Regex.Match(data,
             "mimeType=\\\\\"audio/mp4\\\\\".*\\\\x3CBaseURL>([^\"]*)\\\\x3C/BaseURL>")
            .Groups[1].Value.Replace("&amp;", "&");

            },
            name = "audioUrl",
            PropertyGroup = "audio",
            Precedence = 0
        };


        public static PostProperty<List<QualityLabel>> qualityLabels = new PostProperty<List<QualityLabel>>()
        {
            name = "qualityLabelsList",
            PropertyGroup = "videos",
            MainExtractor = (data) =>
            {
                MatchCollection av = Regex.Matches(data, "FBQualityLabel=\\\\\"([0-9]{3,4}p|Source)\\\\\">");
                List<QualityLabel> labels = new List<QualityLabel>();
                foreach (Match item in av)
                {
                    string reso = item.Groups[1].Value; // "720";
                    Match m = Regex.Match(data, "FBQualityLabel=\\\\\"" + reso + "\\\\\">(?:\\\\x3C|\\\\u003c)BaseURL>([^\"]*)\\\\x3C/BaseURL>");
                    string vidUrl = m.Success ? m.Groups[1].Value.Replace("&amp;", "&") : null;
                    labels.Add(new QualityLabel(new Resolution(reso), vidUrl));
                }
                return labels;
            }
        };

    }


    public struct Post : INotifyPropertyChanged
    {
        public bool success { set; get; }
        public bool isPrivate { set; get; }
        public bool unknownFailur;
        public string url;
        public string audioUrl { set; get; }
        public string audioSize { set; get; }
        public List<QualityLabel> QualityLabels { set; get; }

        public Dictionary<PostProperty<string>, string> Titles { get; set; }
        public Dictionary<PostProperty<string>, string> Images { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"audioUrl: {audioUrl.Substring(0, 5)}, LabelsCount:{QualityLabels.Count.ToString()} ";
        }

        public List<Resolution> AvailableResolutions
        {

            get
            {
                List<Resolution> resolutions = new List<Resolution>(QualityLabels.Count);
                foreach (QualityLabel item in QualityLabels)
                {
                    resolutions.Add(item.resolution);
                }
                return resolutions;
            }
        }





        /// <summary>
        /// Main FB post parser, errors are returned within the Post object
        /// </summary>
        /// <param name="rawHTMLPage"></param>
        /// <returns></returns>
        public static Post fromHTMLContent(string rawHTMLContent, List<PostProperty<string>> TitleProperties,
            List<PostProperty<string>> ImagesProperties)
        {

            Post post = new Post();
            post.Titles = new Dictionary<PostProperty<string>, string>();
            post.Images = new Dictionary<PostProperty<string>, string>();
            post.QualityLabels = new List<QualityLabel>();
            // #### isPrivate ####     
            post.isPrivate = StandardPostProperties.isPrivate.Extract(rawHTMLContent);
            // #### titles ####
            foreach (PostProperty<string> item in TitleProperties)
                post.Titles.Add(item, Fucs.decodeUtf(item.Extract(rawHTMLContent)));
            // #### images ####
            foreach (PostProperty<string> item in ImagesProperties)
                post.Images.Add(item, item.Extract(rawHTMLContent));
            // #### audioUrl ####
            post.audioUrl = StandardPostProperties.audioUrl.Extract(rawHTMLContent);
            // #### available resolutions ####
            post.QualityLabels = StandardPostProperties.qualityLabels.Extract(rawHTMLContent);


            return post;

        }



    }


    public class FFMPEG
    {

        public FFMPEG()
        {
            this.OnProgress += (s, prog) =>
            {
                if (!this.IsDownloading)
                {
                    this.IsDownloading = true;
                    this.OnDownloadng?.Invoke(this, this.TotalDuration);
                }
            };
        }
        struct Args
        {
            public Args(int capacity)
            {
                argsList = new List<Arg>();
            }
            private List<Arg> argsList;

            public Args add(string param = "", string value = "", bool when = true)
            {
                if (when == false)
                    return this;
                Arg newArg = new Arg(param, value);
                argsList.Add(newArg);
                return this;
            }
            public string toString { get
                {
                    string result = "";
                    foreach (Arg arg_item in argsList)
                    {
                        result += " " + arg_item.toString;
                    }
                    return result;
                } }

            private struct Arg
            {
                string paramName, value;
                public Arg(string name, string value_)
                {
                    paramName = name.Trim(); value = value_.Trim();
                }
                public string toString { get { return paramName + " " + value; } }
            }


        }


        /// <summary>
        /// experimental: this is how the ssl connection problem was solved, basically adding the port component to the uri 
        /// </summary>
        public static string UrlAdd443Port(string url)
        {
            var asUri = new Uri(url);
            string SchemeAndServer = asUri.GetComponents(UriComponents.Scheme| UriComponents.HostAndPort|UriComponents.PathAndQuery, UriFormat.Unescaped);

            return SchemeAndServer;

        }

        public static bool hasVideo(TaskType type)
        {
            return (type == TaskType.mp4Task) || (type == TaskType.mkvTask);
        }


        /// <summary>
        /// returns eextention without the dot, e.g "mp3"
        /// </summary>
        public static string getExtention(TaskType type)
        {
            switch (type)
            {
                case TaskType.mp4Task: return "mp4";
                case TaskType.mp3Task: return "mp3";
                case TaskType.mkvTask: return "mkv";
                case TaskType.jpgTask: return "jpg";
                default: return "mp4";
            }
        }

        public static string MakeArgs(FBHDTask task)
        {

            Trace.Assert(task.IsResolved, "Mi: FFMPEG.MakeArgs(): task should be reselved, Please contact the developer with error code: 486327");
            Trace.Assert(task.Post.HasValue,"FFMPEG.MakeArgs(): FBHDTask object has no Post property, Please contact the developer with error code: 486328");
            
            Post post = task.Post.Value;
            TaskType type = task.Type;
            TaskProperties taskProperties = task.TaskProperties;


            string resolutionstr = taskProperties.resolutionSettings.getResult().serialized;

            string
                videoStream = post.QualityLabels.Find((Q) =>
                (Q.qualityName ==
                (resolutionstr))
                ).videoUrl,

                audioStram = post.audioUrl,
                metatitle = "",
                outputFile = task.OutputFile,
                thumb = post.Images.First().Value;
            // ## 27-04-2021 ssl connection problem: experimental fix
            videoStream = UrlAdd443Port(videoStream);
            audioStram = UrlAdd443Port(audioStram);
            thumb = UrlAdd443Port(thumb);
            // ##

            string args;
            if (hasVideo(type))
            {
                Args mp4args = new FFMPEG.Args(100);

                mp4args = mp4args.add("-v 32")
                    .add("-vn -i", Fucs.qoute(audioStram))
                    .add("-an -i", Fucs.qoute(thumb))
                    .add("-an -i", Fucs.qoute(videoStream))
                    .add("-map 0 -map 1 -map 2")
                    .add("-c:v:0 mjpeg")
                    .add("-c:v:1", "copy", type == TaskType.mkvTask)
                    .add("-c:a:0", "copy", type == TaskType.mkvTask)
                    .add("-disposition:v:0 attached_pic")
                    .add("-metadata", "title=" + Fucs.qoute(metatitle))
                    .add("-metadata:s:v:0", Fucs.qoute("comment='Cover (front)'"))
                    .add("-metadata:s:v:0", Fucs.qoute("title='Cover (front)'"))
                    .add(Fucs.qoute( outputFile ))
                    .add("-y")

                    ;
                args = mp4args.toString;
                // MessageBox.Show(args);

            }
            else
            {

                Args mp3args = new FFMPEG.Args(100);

                mp3args = mp3args.add("-v 32")
                    .add("-hide_banner")
                    .add("-vn -i", Fucs.qoute(audioStram))
                    .add("-an -i", Fucs.qoute(thumb))
                    .add("-map 0 -map 1")
                    .add("-c:v:0 mjpeg")
                    .add("-disposition:v:0", "attached_pic")

                    .add("-c:a:0", "copy", type == TaskType.mkvTask)

                    .add("-metadata", "title=" + Fucs.qoute(metatitle))
                    .add("-metadata:s:v", Fucs.qoute("comment='Cover (front)'"))
                    .add("-metadata:s:v", Fucs.qoute("title='Cover (front)'"))
                    .add(Fucs.qoute(outputFile))
                    .add("-y")

                    ;

                args = mp3args.toString;


            }

            return args;
        }

        /// <summary>
        /// attemptes to parse a raw Line from ffmpeg's stdout as if it contains the
        /// Duration information of some random stream : e.g "Duration: 00:00:13.63, start:..."
        /// returning the appropriate TimeSpan object on match, and null otherwise 
        /// </summary>
        public static TimeSpan? parseDuration(string rawLine)
        {
            TimeSpan ts;
            if (rawLine == null)
                return null;
            Match m = Regex.Match(rawLine, "Duration: (\\d{2}):(\\d{2}):(\\d{2}).(\\d{2,3}), start:");
            if (m.Success)
            {
                // MessageBox.Show(m.Value);
                int houres = int.Parse(m.Groups[1].Captures[0].Value);
                int minutes = int.Parse(m.Groups[2].Captures[0].Value);
                int secs = int.Parse(m.Groups[3].Captures[0].Value);
                int millis = int.Parse(m.Groups[4].Captures[0].Value);
                ts = new TimeSpan(0, houres, minutes, secs, millis);
                return ts;
            }
            else
            {
                return null;
            }

        }


        public struct FFMPEGProgress
        {
            // "frame=  218 fps= 42 q=28.0 size=     531kB time=00:00:09.21 bitrate= 472.5kbits/s";
            public int frame; public float q, fps;
            public string bitrate, time, size_str;
            public TimeSpan elapsedTime;
            public bool isNull;
            public TimeSpan totaleDuration;





            public double getPercent(TimeSpan totalDuration)
            {

                return this.elapsedTime.TotalMilliseconds / totalDuration.TotalMilliseconds;
            }

            public double Percent
            {
                get
                {
                    return getPercent(this.totaleDuration);
                }

            }


            private Size size;
            public Size Size
            {
                get { return size; }
                set { size = value;
                }
            }

            public double Frame { get { return this.frame; } }
            public float Fps { get { return this.fps; } }
            public string Time { get { return this.time; } }
            public string Bitrate { get { return this.bitrate; } }
            public string SizeStr { get { return this.size_str; } }


            static FFMPEGProgress NullProgress = new FFMPEGProgress() { isNull = true };
            public static FFMPEGProgress zeroProgress = new FFMPEGProgress() {
                totaleDuration = TimeSpan.Zero, elapsedTime = TimeSpan.Zero,
                fps = 0, frame = 0, isNull = false, bitrate = "", Size = new Size(0), time = ""

            };

            /// <summary>
            /// formats a string to display the object's pproperties
            /// use the folowing variables 
            /// fps: $fps , time: $t, size: $s, frame: $f bitrate: $b
            /// </summary>
            /// <param name="format"></param>
            /// <returns></returns>
            public string ToString(string format)
            {
                if (isNull)
                {
                    return null;
                }
                return format
                    .Replace("$f", frame.ToString())
                    .Replace("$fps", fps.ToString())
                    .Replace("$t", time.ToString())
                    .Replace("$s", size.ToString())
                    .Replace("$b", bitrate.ToString());


            }

            public static FFMPEGProgress FromStdoutLine(string rawLine, TimeSpan totalDuration_)
            {

                FFMPEGProgress prog = new FFMPEGProgress();
                prog.totaleDuration = totalDuration_;
                //version 2018:  frame=    1 fps=1.0 q=5.1 size=      75kB time=00:00:13.89 bitrate=  44.4kbits/s speed=13.9x
                try
                {
                    //frame
                    Regex frmReg = new Regex("frame= *(\\d*) *fps");
                    prog.frame = int.Parse(frmReg.Match(rawLine).Groups[1].Captures[0].Value);
                    //MessageBox.Show(prog.frame.ToString());
                    //fps
                    Regex fpsReg = new Regex("fps= *(\\d*\\.?\\d*) *q");
                    prog.fps = float.Parse(fpsReg.Match(rawLine).Groups[1].Captures[0].Value);
                    // MessageBox.Show(prog.fps.ToString());

                    //bitrate
                    Regex bitrateReg = new Regex("bitrate= *(\\S*) *");
                    prog.bitrate = (bitrateReg.Match(rawLine).Groups[1].Captures[0].Value);
                    // MessageBox.Show(prog.bitrate.ToString());

                    //time
                    Regex timeReg = new Regex("time= *((\\d{2}):(\\d{2}):(\\d{2})\\.(\\d{2,3})) *bitrate");

                    Match m = timeReg.Match(rawLine);
                    prog.time = m.Groups[1].Captures[0].Value;
                    int houres = int.Parse(m.Groups[2].Captures[0].Value);
                    int minutes = int.Parse(m.Groups[3].Captures[0].Value);
                    int secs = int.Parse(m.Groups[4].Captures[0].Value);
                    int millis = int.Parse(m.Groups[5].Captures[0].Value);
                    prog.elapsedTime = new TimeSpan(0, houres, minutes, secs, millis);

                    //size
                    Regex sizeReg = new Regex("size= *(\\S*) *time");
                    prog.size = new Size(sizeReg.Match(rawLine).Groups[1].Captures[0].Value);
                }
                catch (Exception)
                {
                    prog = FFMPEGProgress.NullProgress;
                }



                return prog;
            }

        }

       
        /// <summary>
        /// takes raw ffmpeg stdout content and rutuns an exception object if that content represents a known error 
        /// rreturns null otherwise
        /// </summary>
        internal static Exception ParseError(string data)
        {
            Exception outp = new Exception();
            if(data.Contains("HTTP error 403 Forbidden"))
            {
                return new Exception("Error 403 Forbidden, try resolving the link again");

            }


            return null;
        }




        public async Task<bool> Abort()
        {

            if (Process == null)
            {
                MessageBox.Show("prcess null");
                return false;
            }
            //ffmpeg_process_ref.StandardInput.WriteLine("\x3");
            //ffmpeg_process_ref.StandardInput.Flush();

          
            if (Fucs.AttachConsole((uint)Process.Id))
            {
                Fucs.SetConsoleCtrlHandler(null, true);

                try
                {
                    if (!Fucs.GenerateConsoleCtrlEvent(Fucs.CTRL_C_EVENT, 0))
                        return false;
                    await Task.Run(() =>
                    {
                        Process.WaitForExit();
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
        public void Kill()
        {
            Process.Kill();
        }

        public Process Process { get; set; }


        /// <summary>
        /// catches errors from the stdout currentely suported error: 403 forbidden
        /// </summary>
        public event EventHandler<Exception> OnError;

        /// <summary>
        /// fired repeatedly as the stdout prints progress information
        /// </summary>
        public event EventHandler<FFMPEGProgress> OnProgress;

        /// <summary>
        /// fired when the process object is instantiated, 
        /// </summary>
        public event EventHandler<Process> OnProcess;
        /// <summary>
        /// fired when stdout first prints the information that specifies a stream duration
        /// </summary>
        public event EventHandler<TimeSpan> OnTotalDuration;
        public event EventHandler<int> OnExitedSuccessfully;
        public event EventHandler<int> OnExitedWithError;
        public event EventHandler<int> OnExited;
        /// <summary>
        /// fired right after the first OnProgress event, passing the TotalDuration as the event arg
        /// </summary>
        public event EventHandler<TimeSpan> OnDownloadng;

        public event EventHandler OnRunning; 







        //public event EventHandler<Exception> OnError;


        public StringBuilder Builder { set; get; } = new StringBuilder();
        public TimeSpan TotalDuration { set; get; } = new TimeSpan(0, 0, 50);
        public bool IsDownloading { get; private set; }

        /// <summary>
        /// official ffmpeg running method// moved from fucs on 28-04-2021
        /// </summary>
        public async Task<int> Run(string ffmpegArgs)
        {
            Process =Fucs. constructProcess(MI.FFMPEG_PATH, ffmpegArgs);
            // parent_task_object.ffmpeg_process_ref = process;
            OnProcess?.Invoke(this, Process);

           

            DataReceivedEventHandler hndl = ((sender, args) =>
            {
                if (args.Data == null)
                    return;
                Builder.AppendLine(args.Data);

                TimeSpan? maybeTotalDuration = FFMPEG.parseDuration(args.Data);
                if (maybeTotalDuration != null)
                {
                    TotalDuration = (TimeSpan)maybeTotalDuration;
                    OnTotalDuration?.Invoke(this, TotalDuration);
                }
                FFMPEGProgress prog = FFMPEGProgress.FromStdoutLine(args.Data, TotalDuration);
                if (!prog.isNull)
                {
                    OnProgress?.Invoke(this,prog);
                }

                var maybeKnownError = ParseError(args.Data);
                if (maybeKnownError != null)
                {
                    OnError?.Invoke(this, maybeKnownError);
                }

            });
          //  Process.OutputDataReceived += hndl;
            Process.ErrorDataReceived += hndl;
            MI.Verbose("starting ffmpeg..");

            await Task.Run(new Action(() =>
            {
                Process.Start();
                Process.BeginErrorReadLine();
                Process.BeginOutputReadLine();
            }), new System.Threading.CancellationToken());
            //MI.Verbose("ffmpeg is runing");
            OnRunning?.Invoke(this, new EventArgs());
            await Task.Run(new Action(() =>
            {
                Process.WaitForExit();
            }));
            //MI.Verbose(null);
            OnExited?.Invoke(this, Process.ExitCode);
            if ((Process.ExitCode != 0) && (Process.ExitCode != 255))
            {
               
                OnExitedWithError?.Invoke(this, Process.ExitCode);
            }
            else
            {
                OnExitedSuccessfully?.Invoke(this, Process.ExitCode);
            }

            return Process.ExitCode;// process.ExitCode; //because dummy 
        }





    }



    public class ResolutionSettings : INotifyPropertyChanged
    {
        public enum FallBackBehaviour
        {
            GoHigher, GoLower, Closest
        }


        private void notif(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Resolution UserPicked
        {
            get { return userPickedResolution; }
            set { userPickedResolution = value; notif(nameof(UserPicked)); }
        }
        private Resolution userPickedResolution;
        private List<Resolution> available;
        public List<Resolution> Available
        {
            get { return available; }
            set { available = value;
                notif(nameof(Available));
                notif(nameof(UserPicked)); }
        }
        public bool isChoiceStandard;
        public bool isChoiceTargeted;
        public FallBackBehaviour fallBackBehaviour;

        public event PropertyChangedEventHandler PropertyChanged;

        internal Resolution getResult()
        {
            // MessageBox.Show("het");
            if (UserPicked == null)
            {
                //MessageBox.Show("het2");

                return Resolution.sort(available).First(); // the user didn't pick anything, the highest resolution will be picked untile implementing the fallback preferences 

            }
            // MessageBox.Show("het3");

            string userpicked = userPickedResolution.toString();
            if (isChoiceTargeted)
            {
                return userPickedResolution;
            }
            else // (isChoiceStandard)
            {
                // the fallBack behaviour currentely not actally sopported; all it does is getting the closest higher resolusuit 
                if (userPickedResolution.isSource)
                {
                    if (available.Exists((r) => r.isSource))
                    {
                        return userPickedResolution; // which is Source
                    }
                    else
                    {

                        return Resolution.sort(available).First(); // the user picked source but turned out the post has no source so we're going for the higher resolution available
                    }
                }

                int userValue = userPickedResolution.asInt;
                if (available == null)
                {
                    throw new Exception("mi: available resolutions list is null ");
                    return null;
                }

                List<int> availableValues = available.ConvertAll(new Converter<Resolution, int>((r) => r.isSource ? -1 : r.asInt));


                // now the Source reso is supposed to be the highest resolution , 
                //that said, if the user has picked something higher than
                //everything available, and if the source resolution is available,
                //it will be chosed, 

                if (availableValues.TrueForAll((v) => userValue > v))
                {
                    if (available.Exists((r) => r.isSource)) {
                        return Resolution.Source;
                    }
                    else
                    {
                        return Resolution.sort(available).First(); // the user picked a higher revolution than everything on the list and source reso is not available 


                    }
                }
                availableValues.Sort();

                List<int> higherValues = availableValues.FindAll((n) => n > userValue);
                higherValues.Sort();
                int bestVal = higherValues.Last();
                return available.Find((r) => r.asInt == bestVal);
            }

        }

        internal void setAvailable(List<Resolution> resolutionsSet)
        {
            this.Available = resolutionsSet;
        }
    }






    public class TitleSettings : INotifyPropertyChanged
    {
        private string literallTitle; // e.g "Miracles - Before I lost You"
        private string serialTtitle;    //e.g "fbhd-vid-2021-03-12-8-38-56"
        private List<PostProperty<string>> sourceFallbacks;
        private bool isTaskResolved;
        private Post postInfo;
        private string query;
        public string Query { get {
                return query;
            }
            set {
                updateQuery(value);
                query = value;
            } }

        public override string ToString()
        {
            return $"AvailableTits:{AvailableTitles?[0].Key}, query:{Query}, serial:{SerialTtitle}  ]";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Post PostObj {
            get { return postInfo; }

            set { postInfo = value; isTaskResolved = true;
                AvailableTitles = value.Titles.ToList().ConvertAll<KeyValuePair<string, string>>((p) => new KeyValuePair<string, string>(p.Key.name, p.Value));
                notif(nameof(AvailableTitles));
            }
        }
        public string LiteralTitle { get { return literallTitle; } set { literallTitle = value; } }
        public string SerialTtitle { get { return serialTtitle; } set { serialTtitle = value; } }
        public List<PostProperty<string>> SourceFallbacks { get { return sourceFallbacks; } set { sourceFallbacks = value; } }

        private void notif(string propName)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propName));

                //MessageBox.Show("a listener to "+ propName);

            }
        }

        public List<KeyValuePair<string, string>> AvailableTitles
        {
            get;

            set;

        }

        /// <summary>
        /// task MUST be resolved
        /// generates the following succession (empty and null items may be present: 
        /// literal-user-title , literal-source-titles(in order).. , literal-serialTitle 
        /// </summary>
        /// <returns></returns>
        private string[] generateLiterallFallbacks()
        {
            if (isTaskResolved == false)
            {
                throw (new System.Exception("mi: Trying to getResult() title without task being resolved "));
            }
            string[] outp = new string[10];
            outp[0] = literallTitle;
            for (int i = 0; i < sourceFallbacks.Count; i++)
            {
                outp[i + 1] = postInfo.Titles.ToList()[i].Value;
            }
            outp[sourceFallbacks.Count + 1] = serialTtitle;
            return outp;
        }


        /// <summary>
        /// Task MUST be resolved
        /// gets the best possible literal title as described with properties
        /// </summary>
        /// <returns></returns>
        public string getResult()
        {

            if (literallTitle != null)
            {
                return literallTitle;
            }
            else
            {
                // this will throw an excpetion if task is not resolved
                return Fucs.getFirstNonNull(this.generateLiterallFallbacks());
            }
        }



        /// <summary>
        /// this interprets the query and reflex the essecary changes on the other fields, 
        /// note this does not update the backing fiel query
        /// </summary>
        private void updateQuery(string query_)
        {


            if ((query_ == null) || (query_ == ""))
            {
                literallTitle = null;
                return;
            }
            if (Regex.Match(query_, "^{\\S*}$").Success)
            {
                literallTitle = null;
                // todo: parsing expression 
            }
            else
            {
                LiteralTitle = query_;
            }
        }
    }



    /// <summary>
    /// returns the first non null or empty string withing an array, 
    /// returns null if non was found
    /// </summary>
    public class Fucs
    {


        internal const int CTRL_C_EVENT = 0;

        [DllImport("kernel32.dll")]
        internal static extern bool GenerateConsoleCtrlEvent(uint dwCtrlEvent, uint dwProcessGroupId);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool AttachConsole(uint dwProcessGroupId);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        internal static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate HandelerRoutine, bool add);
        internal delegate Boolean ConsoleCtrlDelegate(uint CtrlType);


        public static List<TaskType> AUDIO_TYPES = new List<TaskType>() {
            TaskType.mp3Task
        };
        public static List<TaskType> VIDEO_TYPES = new List<TaskType>() {
           TaskType.mp4Task, TaskType.mkvTask,
        };
        public static List<TaskType> IMAGE_TYPES = new List<TaskType>() {
            TaskType.jpgTask
        };



        public static MediaType TypeToMediaType(TaskType type)
        {
            if (AUDIO_TYPES.IndexOf(type) != -1) return MediaType.Audio;
            else if (VIDEO_TYPES.IndexOf(type) != -1) return MediaType.Video;
            else if (IMAGE_TYPES.IndexOf(type) != -1) return MediaType.Image;
            else throw new Exception($"Mi: TaskType '{type}' doesnt seem to belong to any MediaType");
        }
        public static TaskType MediaTypeToType(MediaType mediaType)
        {
            switch (mediaType)
            {
                case MediaType.Audio:
                    return AUDIO_TYPES.First();
                case MediaType.Video:
                    return VIDEO_TYPES.First();
                case MediaType.Image:
                    return IMAGE_TYPES.First();
                default:
                    return AUDIO_TYPES.First();
            }
        }



        /// <summary>
        /// iterates over all directories listed in the PATH env var and their direct sub files searching for a file that matches the specified predicate
        /// NOTE: the predicate takes the whole filepath and not just the file name, use Path.getFileName to exctract the filname
        ///  </summary>
        public static bool ExecutableExistsInThePath(Predicate<string> match)
        {
            string path = Environment.GetEnvironmentVariable("path");
            // MessageBox.Show(path);
            foreach (var dir in path.Split(new char[] { ';' }))
            {
                if (!Directory.Exists(dir)) continue;
                string exists = Directory.GetFiles(dir).ToList().Find(match );
                if (exists != null) return true;
            }
            return false;
        }


        /// <summary>
        /// mi string to time span converter that uses a DateTime object and some regex adjustement under the hood
        /// NOTE: on missMatch, null value is returned,
        /// NOTE: only inputes like these examples are suported: "3:23" "1:45:12" "1:45:12.568" "20"
        /// avoide these input formats: "120" , "1:24.456" 
        /// NOTE: the input "3:32" is interpreted as "0:3:32" unlike how .Net does it (3:32:0)
        /// </summary>
        public static TimeSpan? TimeSpanFromString(string str)
        {
            if ((Regex.IsMatch(str, "^\\d*$"))) { // one number will be interpreted as minutes eg: "12" gives "0:12:0"
                str = "0:" + str + ":0";
            }
            else if (Regex.IsMatch(str, "^\\d*:\\d*$")) //if the suer typed something like 3:24 it gets automatically convetred to 0:3:24, so that the .Net TimeSpan parser recognize it
            {
                str = "0:" + str;
            }
            DateTime asDate;
            bool isValid = DateTime.TryParse(str, out asDate);

            return (isValid == false) ? (TimeSpan?)null : new TimeSpan(asDate.Hour, asDate.Minute, asDate.Second);

        }



        public static string decodeUtf(string raw)
        {
            string output = "";

            //raw = "u\\627u\\627&#x647;&#x643;&#x630;&#x627; &#x62a;&#x628;&#x62f;&#x648; &#x627;&#x644;&#x623;&#x631;&#x636; &#x645;&#x646; &#x645;&#x62d;&#x637;&#x629; &#x627;&#x644;&#x641;&#x636;&#x627;&#x621; &#x627;&#x644;&#x62f;&#x648;&#x644;&#x64a;&#x629;";
            output = Regex.Replace(raw, "&#x([\\dabcdef]{3,5});", (Match m) =>
                {
                    string decoded_char = "";
                    try
                    {
                        decoded_char = char.ConvertFromUtf32(int.Parse(m.Groups[1].Value, NumberStyles.AllowHexSpecifier));

                    }
                    catch (Exception)
                    {

                    }

                    return decoded_char;
                });

            output = Regex.Replace(output, "\\\\u([\\dabcdef]{3,5})", (Match m) =>
            {

                string decoded_char = "";

                try
                {
                    decoded_char = char.ConvertFromUtf32(int.Parse(m.Groups[1].Value, NumberStyles.AllowHexSpecifier));

                }
                catch (Exception)
                {

                }

                return decoded_char;
            });








            return output;
        }





        /// <summary>
        /// searchs whithin the input string for url-like substrings and retuns them as a List<string>
        /// </summary>
        /// <param name="rawUserInput">can be a simple url  or a bench of urls  </param>
        /// <returns></returns>
        public static List<string> extractUrls(string Inputstr)
        {
            List<string> outp = new List<string>();

            MatchCollection mc = Regex.Matches(Inputstr,
                "(https?://.*?)(?=(?:http|;|[ \\t\\n\\r\\f\\v]|\\Z))");

            foreach (Match m in mc)
            {
                outp.Add(m.Value);
                // MessageBox.Show(m.Value);
            }

            return outp;
        }

        public static string getFirstNonNull(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != null && arr[i] != "")
                    return arr[i];
            return null;
        }





        /// <summary>
        /// double quotes a string: "yass" => ""yass""
        /// </summary>
        public static string qoute(string input)
        {
            return "\"" + input + "\"";
        }



        /// <summary>
        /// removes special characters from a string: 
        /// < > : / \ ? * \n
        /// </summary>
        public static string filenamify(string name)
        {
            return Regex.Replace(name, "[/<>:\\*\\?\"\\|\\\\\\n]", ""); 
            //what fuck am I doing with my life
        }


        static MainWindow mw = (MainWindow)Application.Current.MainWindow;

        public static string bytesToString(byte[] b)
        {
            string res = "";
            foreach (byte item in b)
            {
                char c;
                c = (char)item;

                res = res + c.ToString();
            }
            return res;
        }


        public static Process constructProcess(string filename, string args)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = filename;
            startInfo.Arguments = args;
            startInfo.WorkingDirectory = "C:\\TOOLS\\fbhd-gui";
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;

            return process;
        }





      


        /// <summary>
        /// deprecated and ruined on 24-04-2021 due to changing the html temp to app data,
        /// curl WebClient should be used now
        /// 
        /// <summary>
        /// runs the python fetching and resolving script and gets back the raw serialize
        /// result from it's stdout and created the appropriate post object
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [Obsolete("use curl instead", true)]
        public static async Task<Post> run_py_resolver(Uri url)
        {
            StringBuilder py_raw_output = new System.Text.StringBuilder();
            py_raw_output.AppendLine("dummy serialized data from py_resolver");
            string python_args = ".\\scripts\\fetch-and-parse-python.py " + url.AbsoluteUri + " last-parsed.json";
            Process process = constructProcess("python.exe", python_args);
            DataReceivedEventHandler py_hndl = ((sender, args) =>
            {
                py_raw_output.AppendLine(args.Data);
            });
            process.OutputDataReceived += py_hndl;
            MI.Verbose("starting py_resolver..");
            await Task.Run(new Action(() =>
            {
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
            }));
            MI.Verbose("py_resolver is runing");
            await Task.Run(new Action(() =>
            {
                process.WaitForExit();
            }));
            return parse_py_resolver_output(py_raw_output.ToString());

        }




        [Obsolete("use curl instead",true)]
        /// <summary>
        /// deprecated and ruined on 24-04-2021 due to changing the html temp to app data,
        /// curl WebClient should be used now
        /// 
        /// runs the python fetching script and gets back the raw html content from its
        /// output file 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> run_py_fetcher(Uri url)
        {

            StringBuilder html_content = new StringBuilder();
            string outputFile = url.AbsoluteUri.GetHashCode() + ".html";
            string python_args = ".\\scripts\\fetch-python.py " + url.AbsoluteUri + " " +$"{MI.TEMP_HTML_FILES}\\{outputFile}";
            Process process = constructProcess("python.exe", python_args);
            process.StartInfo.WorkingDirectory = "C:\\TOOLS\\fbhd-gui";
            DataReceivedEventHandler py_hndl = ((sender, args) =>
            {
                html_content.AppendLine(args.Data);
            });
            process.OutputDataReceived += py_hndl;
            MI.Verbose("starting py_fetcher..");
            await Task.Run(new Action(() =>
            {
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
            }));
            MI.Verbose("py_fetcher is runing");
            await Task.Run(new Action(() =>
            {
                process.WaitForExit();
            }));
            MI.Verbose(null);
            string result = (html_content.ToString());
            if (result.Contains("success:"))
            {
                return File.ReadAllText(MI.TEMP_HTML_FILES+"\\" + outputFile);

            }

            return result;

        }












        public static Post parse_py_resolver_output(string serialized)
        {
            // FBHd.Verbose("parsing py_resolver_output");
            Post p = new Post();

            p.audioUrl = "";
            p.isPrivate = false;
            p.audioSize = "4.Mb";
            p.QualityLabels = new List<QualityLabel>();
            p.QualityLabels[0] = new QualityLabel();
            p.success = true;


            return p;

        }


         static DateTime d70 = new DateTime(1970, 1, 1, 0, 0, 0);



        /// <summary>
        /// timstamp should be in seconds, counting from 1/1/1970 00:00:00
        /// </summary>
        internal static DateTime dateFromTimestamp(int timestamp)
        {
            return(d70.AddSeconds(timestamp));
        }



        /// <summary>
        /// decodes stuff like "Mi &amp; You " to "Mi & You"
        /// it uses the xml parser, so it should handle all the escape notations
        /// </summary>
        internal static string decodeXml(string input)
        {
            XElement ElemWithTextNode = XElement.Parse($"<elem>{input}</elem>");

            return (((XText)ElemWithTextNode.FirstNode).Value);
            
        }
    }


    public struct ThumbnailSettings
    {

    }


    public enum OverrideBehaviour
    {
        Override, Enumerate, Prompt, Skip, CheckSizeAndSkip
    }


    public class TaskProperties : INotifyPropertyChanged
    {

        public TaskProperties()
        {
            titleSettings = new TitleSettings();
            resolutionSettings = new ResolutionSettings();
            extension = ".mi";
        }

        public override string ToString()
        {
            return $"titleSettings:{titleSettings.ToString()}, resoSetts:{resolutionSettings.ToString()}";
        }

        public TitleSettings titleSettings { get; set; }
        public ResolutionSettings resolutionSettings { get; set; }

        public OverrideBehaviour overridingBehaviour { get; set; }

        public ThumbnailSettings thumbnailSettings { get; set; }


        public string extension { get; set; }

        public string userOutputLocaton { get; set; }
        public bool isSkiped { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }









    public class Resolution
    {

        public class ResoComparer : IComparer<Resolution>
        {
            public int Compare(Resolution x, Resolution y)
            {
                return (y.isSource || (x.asInt > y.asInt)) ? -1 : 1;
            }
        }
        public static List<Resolution> sort(IEnumerable<Resolution> arr)
        {
            List<Resolution> list = new List<Resolution>();
            foreach (var item in arr)
            {
                list.Add(item);

            }
            list.Sort(new ResoComparer());
            return list;

        }
        private Resolution(bool isSource_)
        {
            asInt = -1;
            isSource = isSource_;
        }




        public Resolution()
        {

        }
        /// <summary>
        /// construct a Resolution obj from an integer specifying the resolution value e.g 720 , 
        /// Note that this cannot istantiate the Source resolution
        /// </summary>
        public Resolution(int value)
        {
            asInt = value;
            isSource = false;
        }


        /// <summary>
        /// construct the Resolution object directly from the resolution name e.g "720p" or "Source"
        /// if the passe string doesnt match a regular resolution name this will throw 
        /// an Exception
        /// </summary>
        public Resolution(string name)
        {
            if (name == "Source")
            {
                asInt = -1; isSource = true; return;
            }
            else
            {
                Match m = Regex.Match(name, "[0-9]{3,4}(?=p)");
                if (m.Success)
                {
                    asInt = int.Parse(m.Value);
                    isSource = false;
                }
                else
                {
                    throw new Exception("mi: couldn't instantiate a Resolution object with name: " + name);
                }
            }

        }
        public static Resolution Source = new Resolution(true);
        public int asInt;
        public bool isSource;

        public string serialized {
            get
            {
                return isSource ? "Source" : (asInt.ToString() + "p");
            }


        }

        public string _String()
        {
            return isSource ? "Source" : (asInt.ToString() + "p");
        }

        public override string ToString()
        {
            return isSource ? "Source" : (asInt.ToString() + "p");
        }
        public string toString()
        {
            return isSource ? "Source" : (asInt.ToString() + "p");
        }


    }








    public class WebServer
    {

        public Process py_server;
        public WebServer()
        {
            
           
            
            py_server = Fucs.constructProcess("python.exe", Fucs.qoute( MI.SCRIPTS_DIR+ "\\server-python.py"));
            onProcessExited += onExited;
            py_server.Exited += (s, e) => { onProcessExited?.Invoke(this, e); };
        }

        public bool IsListening { get; set; } = false;

        /// <summary>
        /// called when a user request is recieved, passin the string the user has entered as is without and validations
        /// </summary>
        public event EventHandler<string> onRequest;

        /// <summary>
        /// fired when python writes something unexceced to the stdout, 
        /// </summary>
        public event EventHandler<string> onError;

        public event EventHandler<string> onServingStarted;

        /// <summary>
        /// when the pythn process exits, fired in all cases
        /// </summary>
        public event EventHandler onProcessExited;

        public void onExited(object s , EventArgs e)
        {
            IsListening = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>the return value only indicates wether the process has started , and not whether the server is listening</returns>
        public bool Start()
        {

            bool existsPython = Fucs.ExecutableExistsInThePath((f) => (Path.GetFileName(f).ToLower() == "python.exe"));

            if (!existsPython)
            {
                MessageBox.Show("Python executable doesn't exist in the PATH ");
                return false;
            }

            DataReceivedEventHandler hndl = ((sender, args) =>
            {
                if (args.Data == null)
                    return;

                if (args.Data.Contains("serving at port"))
                {
                    onServingStarted?.Invoke(this, args.Data);
                    IsListening = true;
                    return;
                }

                if (args.Data.Contains("mi_error: couldn't start socketserver"))
                {
                    py_server.StandardInput.WriteLine("n");
                    return;
                }
                if (args.Data.Contains("should kill"))
                {
                    // thats just a prompt, ignoring it
                    return;
                }

                // NOTE/ script v2.0.0 update: requests are prefixed wuth "mi_request: " to help differentating between rqeuets and pythong errors

                if (args.Data.StartsWith("mi_request: ")){
                    // this should be a user request
                    onRequest?.Invoke(this, args.Data.Substring(12));
                    return;
                }
                // only errors or unexcpected loggings are left, 
                onError?.Invoke(this, args.Data);
                   
                
            });
            py_server.OutputDataReceived += hndl;
            py_server.ErrorDataReceived += hndl;
            Task.Run(() =>
            {
                py_server.Start();
                py_server.BeginErrorReadLine();
                py_server.BeginOutputReadLine();

            });
            return true;
        }
        public void Stop()
        {
            if (py_server != null)
            {
                if (py_server.HasExited)
                    return;
                py_server.Kill();

            }
            IsListening = false;

        }







    }




    /// <summary>
    /// webClient using a custome underlying process e.g curl/powershell/python
    /// abstracts away the hustel of spawning the process, configuring stdout...
    /// saving temporary HTML's, and reding data from them, provides simple, yet powerfull
    /// interface 
    /// </summary>
    public abstract class WebClient
    {
       
        public abstract  Headers DefaultHeaders { get; }
        public abstract  string ProcessFileName { get; }

        /// <summary>
        /// used for better loggings , instead of printing the wholre processName that may include full paths
        /// </summary>
        public abstract string Name { get; }

        public abstract string makeArgs(string url, Headers headers, string outputFile, bool followRedirects);
        public abstract bool success(int exitCode);



        /// <summary>
        /// get text using a temp html file
        /// returns null string on any failure, use the enhanced version GetTextAdvanced for more detailed failure reason
        /// </summary>
        /// <param name="saveAs">assigning this will cause the temp html to be saved under a custome name, and kept safe after the task completes</param>
        /// <returns>returns string on success, null on failure</returns>
        public async Task<string> GetText(string url, Headers headers =null, string saveAs=null)
        {
            bool shouldKeepFile = !(saveAs == null);
            string output = "";
            string tempHTMLFile = shouldKeepFile?saveAs: "temp,"+ DateTime.Now.GetHashCode().ToString();
            string args = makeArgs(url, headers, tempHTMLFile , true);
            Process webClientProcess = Fucs.constructProcess(ProcessFileName, args);
            StringBuilder cachedStdout = new StringBuilder();
            webClientProcess.OutputDataReceived += (s, e) => { cachedStdout.Append(e.Data); };
            webClientProcess.StartInfo.WorkingDirectory = MI.TEMP_HTML_FILES;
            /// ## RUNNING ##
            MI.Verbose($"starting {Name}..");
            await Task.Run(new Action(() =>
            {
                webClientProcess.Start();
                webClientProcess.BeginErrorReadLine();
                webClientProcess.BeginOutputReadLine();
            }));
            MI.Verbose($"{Name} is runing");
            await Task.Run(new Action(() =>
            {
                webClientProcess.WaitForExit();
            }));
            MI.Verbose(null);


            /// ## READING FROM FILE ##

            if (success(webClientProcess.ExitCode ))
            {
                output = File.ReadAllText(MI.TEMP_HTML_FILES+ "\\"+tempHTMLFile);
               if(!shouldKeepFile) File.Delete(MI.TEMP_HTML_FILES + "\\" +tempHTMLFile)  ;
                return output;
            }
            else
            {
                return null;
            }

        }


        /// <summary>
        /// get text using a temp html file, workes somilar to GetText but returns detailed information including the process exit code, the time spent
        /// </summary>
        /// <param name="saveAs">assigning this will cause the temp html to be saved under a custome name, and kept safe after the task completes</param>
        public async Task<GetTextResult> GetTextAdvanced(string url, Headers headers = null, string saveAs = null,bool followRedireects=false)
        {
            bool shouldKeepFile = !(saveAs == null);
            string output = "";

            string tempHTMLFile = saveAs;
            if (!shouldKeepFile)
            {
                tempHTMLFile = MI.TEMP_HTML_FILES+  "\\"+"temp," + DateTime.Now.GetHashCode().ToString();
            }
            string args = makeArgs(url, headers, tempHTMLFile, followRedireects);
            Process webClientProcess = Fucs.constructProcess(ProcessFileName, args);
            StringBuilder cachedStdout = new StringBuilder();
            webClientProcess.OutputDataReceived += (s, e) => { cachedStdout.Append(e.Data); };
            webClientProcess.StartInfo.WorkingDirectory = MI.TEMP_HTML_FILES;
            /// ## RUNNING ##
            MI.Verbose($"starting {Name}..");
            await Task.Run(new Action(() =>
            {
                webClientProcess.Start();
                webClientProcess.BeginErrorReadLine();
                webClientProcess.BeginOutputReadLine();
            }));
            MI.Verbose($"{Name} is runing");
            await Task.Run(new Action(() =>
            {
                webClientProcess.WaitForExit();
            }));
            MI.Verbose(null);


            /// ## READING FROM FILE ##

            if (success(webClientProcess.ExitCode))
            {
                output = File.ReadAllText( tempHTMLFile);
                if (!shouldKeepFile) File.Delete( tempHTMLFile);
                return new GetTextResult() {Text = output, Success = true, ClientExitCode = webClientProcess.ExitCode, RunningTime = webClientProcess.StartTime- webClientProcess.ExitTime };
            }
            else
            {
                return new GetTextResult() { Text = null, Success = false, ClientExitCode = webClientProcess.ExitCode, RunningTime = webClientProcess.StartTime - webClientProcess.ExitTime };
            }

        }



        internal event EventHandler<string> DateRecieved;

        public struct DownloadResult
        {
            public Exception Error;
            public bool Success;
            public int agentReturnCode;

            public override string ToString()
            {
                return $"success:{Success.ToString()} , error:{Error.ToString()} , returnCode:{this.agentReturnCode.ToString()} ";
            }
        }





        /// <summary>
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns>returns string on success, null on failure</returns>
        public async Task<DownloadResult> DownloadBinary(string url,  string saveAs, Headers headers = null )
        {
            string args = makeArgsBinary(url, saveAs, headers);
            MessageBox.Show(args);
            Process webClientProcess = Fucs.constructProcess(ProcessFileName, args);
            StringBuilder cachedStdout = new StringBuilder();
            webClientProcess.OutputDataReceived += (s, e) => {
                cachedStdout.Append(e.Data);
                if(!string.IsNullOrWhiteSpace(e.Data))
                {
                    if(DateRecieved != null)
                    {
                        DateRecieved(this, e.Data);
                    }
                }
                
                };
            webClientProcess.StartInfo.WorkingDirectory = "C:\\TOOLS\\fbhd-gui\\";
            /// ## RUNNING ##
            MI.Verbose($"starting {Name}..");
            await Task.Run(new Action(() =>
            {
                webClientProcess.Start();
                webClientProcess.BeginErrorReadLine();
                webClientProcess.BeginOutputReadLine();
            }));
            MI.Verbose($"{Name} is runing");
            await Task.Run(new Action(() =>
            {
                webClientProcess.WaitForExit();
            }));
            MI.Verbose(null);


            /// ## ##


            return new DownloadResult() {
                Error = success(webClientProcess.ExitCode) ? null : new Exception("agent failed with code " + webClientProcess.ExitCode.ToString()),
                Success = success(webClientProcess.ExitCode),
                agentReturnCode = webClientProcess.ExitCode

            };
            

        }

        internal abstract string makeArgsBinary(string url, string saveAs, Headers headers);

        public class cURL : WebClient
        {

            public event EventHandler<curlProgress> onProgress;

            public struct curlProgress
            {
                public double Percent; // DL ratio [0,1]
                public int Dled, Speed; // in  bytes
                public TimeSpan? Total, Left;
                public TimeSpan Current;

                public override string ToString()
                {
                    return $"percent:{Math.Round(Percent * 100, 1).ToString()}, left:{Left.ToString()}, elapsed:{Current.ToString()}, Total:{Total.ToString()}, Dled:{Dled.ToString()} ";
                }

            }


            public  curlProgress? parseProgress(string rawLine)
            {
                curlProgress outp = new curlProgress();
                //DL% UL%  Dled  Uled  Xfers  Live   Qd Total     Current  Left    Speed
                //100 --  3906k     0     4     0     0  0:00:17  0:00:23 --:--:--  223k
                try
                {
                    Regex re = new Regex("(\\d{1,3}) (\\S{1,3}) +(\\S{1,8}) +(\\S{1,8}) +(\\S{1,8}) +(\\S{1,8}) +(\\S{1,8}) +(\\S{1,8}) +(\\S{1,8}) +(\\S{1,8}) +(\\S{1,8})");
                    Match m = re.Match(rawLine);
                    if(!m.Success) return null;

                    string rawPercent = m.Groups[1].Value;
                    string rawDled = m.Groups[3].Value;
                    string rawTotal = m.Groups[8].Value;
                    string rawCurrent = m.Groups[9].Value;
                    string rawLeft = m.Groups[10].Value;
                    string rawSpeed = m.Groups[11].Value;


                   

                    outp.Percent = double.Parse(rawPercent) / 100;
                    outp.Dled = new Size(rawDled + "b").bytes;
                    outp.Total = Fucs.TimeSpanFromString(rawTotal);
                    outp.Current = Fucs.TimeSpanFromString(rawCurrent).Value;
                    outp.Left = Fucs.TimeSpanFromString(rawLeft);
                    outp.Speed = new Size(rawSpeed + "b").bytes;
                    //MessageBox.Show("787");

                    return outp;
                }
                catch (Exception)
                {

                    return null;
                }

            }


            public cURL()
            {
                base.DateRecieved += (s, e) =>
                {
                    curlProgress? cp = parseProgress(e);

                    if (cp.HasValue)
                    {
                        if (onProgress != null)
                        {
                            onProgress(this, cp.Value);
                        }
                    }
                };
            }
            public override Headers DefaultHeaders
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public override string ProcessFileName { get { return MI.CURL_PATH; } }

            public override string Name{ get {   return "cURL";}}


            /// <summary>
            /// instantites a new cURL object and uses its GetTextAdvanced method, 
            /// </summary>
            public static async Task<cURL.GetTextResult> GetTextStatic(string url, Headers headers, bool folowRedirects)
            {
                return await new cURL().GetTextAdvanced(url, headers , null, folowRedirects);
               
            }
            
            

            public override string makeArgs(string url, Headers headers, string outputFile, bool folowRedirects = false)
            {
                string args = "";
                args += (folowRedirects ? " -L " : "");
                args += $" --url {Fucs.qoute(url)}";
                args += $" -o {Fucs.qoute(outputFile)}";

                //
                foreach (var h in headers)
                {
                    args += $" -H \"{h.Key}:{h.Value}\" ";
                }

                return args;

            }

            public override bool success(int exitCode){  return exitCode == 0; }

            internal override string makeArgsBinary(string url, string saveAs, Headers headers)
            {
                string args = "";

                args += $" --url {Fucs.qoute(url)}";
                args += $" -o {Fucs.qoute(saveAs)}";

                //
                if(headers != null)
                {
                    foreach (var h in headers)
                    {
                        args += $" -H \"{h.Key}:{h.Value}\" ";
                    }

                }

                Clipboard.SetText(args);
                return args;
            }
        }

        public class PyFetcher
        {

        }
        public class Powershell
        {

        }

        public struct GetTextResult
        {
            public string Text { get; set; }
            public int ClientExitCode { get; set; }
            public bool Success { get; set; }
            public TimeSpan RunningTime { get; set; }
        }
    }

    public class Headers : Dictionary<string, string>
    {
        public const string USER_AGENT = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.11 Safari/537.36";
        public static  Headers DefaultFbWatchHeaders { get
            {
                var v = new Headers();
                v.Add("accept-language", "en-US;");
                return v;
            } }

        public static Headers FakeUserAgentHeaders
        {
            get
            {
                var v = new Headers();
                v.Add("user-agent", Headers.USER_AGENT);
                return v;
            }
        }

        /// <summary>
        /// these cookies are critical for fbhd post parsing to work, not using them will result in fb 
        /// sending a minimal response that suits lite browsers and doesn't include all the information were looking for e.g quality labels, audio stream..   
        /// </summary>
        public static Headers FB_Fake_Browser_For_HD_Videos 
        {
            get
            {
                var v = new Headers();
                v.Add("user-agent", Headers.USER_AGENT);
                //  v.Add("sec-ch-ua", "\"Google Chrome\";v=\"87\", \"\\\"Not;A\\\\Brand\";v=\"99\", \"Chromium\";v=\"87\"");
                // commented out because there seem to be some quote escaping issues, fortunatly this one
                //is not critical 
                v.Add("accept", "text/html");
                v.Add("sec-ch-ua-mobile", "?0");
                v.Add("accept-encoding", "");
                v.Add("sec-fetch-mode", "navigate");
                v.Add("accept-language", "en-US,en;q=0.9");
                v.Add("sec-fetch-dest", "document");

                return v;
                /* some cokies as taken from chrome dev tools
                "sec-ch-ua": "\"Google Chrome\";v=\"87\", \"\\\"Not;A\\\\Brand\";v=\"99\", \"Chromium\";v=\"87\"",
                "accept":"text/html",
                "sec-ch-ua-mobile": "?0",
                "accept-encoding":"",
                "sec-fetch-mode": "navigate" ,
                "accept-language": "en-US,en;q=0.9" ,
                "sec-fetch-dest": "document"
                */
            }
        }

        public void evz()
        {
            
        }
    }

   
    public class ExperimentalSearchResultsParser
    {



        
        /// <summary>
        /// attempts to parse a raw html string which suposedely contains all the needed properties
        /// into a searchElement instance
        /// if a mandatory property failed or is missing, this will return null
        /// mandatory props are:title, owner, duration, dateposted, views
        /// 
        /// </summary>
        /// <param name="rawItemSection"></param>
        /// <returns></returns>
        public static SearchElement ParseOne(string rawItem)
        {
            //duration    //class="_3qn7 _61-0 _2fyi _3qng _2pq8">3:18</div>
            //description //<span class="_50f4 _2iex">description here, it may contain line breaks </span>
            //title       //<span class="_50f6 _2iev"> title goes here </span>
            //datePosted  //data-utime="1617109806"  // thats the very datePosted timestamp, exactely what youre looking for
            //views       //· </span>1 178 vues</div>
            //thumbnail   //style="background-image: url(&#039;https://dummy-url-that-should-be-)
            //owner + url // <span class="fwb"><a href="https://web.facebook.com/thejuanAnime/">The JUAN</a></span>
            Regex duration_reg = new Regex("class=\"_3qn7 _61-0 _2fyi _3qng _2pq8\">([\\d\\:]*)</div>");
            Regex description_reg = new Regex("<span class=\"_50f4 _2iex\">(.*?)</span>", RegexOptions.Singleline);
            Regex title_reg = new Regex("<span class=\"_50f6 _2iev\">(.*?)</span>");
            Regex timeStampPosted_reg = new Regex("data-utime=\"(\\d*)\"");
            Regex views_reg = new Regex("· </span>([\\d,]*) views</div>");
            Regex thumbnail_reg = new Regex("background-image: url\\(&#039;(.*?)&#039;\\)");
            Regex owner_reg = new Regex("<span class=\"fwb\">(.*?)<");
            Regex timeStampContent = new Regex("class=\"timestampContent\">(.*?)</span>");
            Regex href_reg = new Regex("data-channel-caller=\"search\" href=\"(.*?)\"");
            
            SearchElement outp = new SearchElement();
            try
            {
                string thumbUrl = thumbnail_reg.Match(rawItem).Groups[1].Value.Replace("&amp;", "&");
                outp.ThumbUrl = thumbUrl;
                string willBeUref  = href_reg.Match(rawItem).Groups[1].Value;
                willBeUref = "https://web.facebook.com" + willBeUref;
                willBeUref = "https://web.facebook.com"+ new Uri(willBeUref).AbsolutePath;
                //MessageBox.Show(willBeUref);
                outp.Url = willBeUref;
                outp.Duration_str = duration_reg.Match(rawItem).Groups[1].Value;
                outp.Description = description_reg.Match(rawItem).Groups[1].Value;
                outp.Title = title_reg.Match(rawItem).Groups[1].Value;
                int timestamp = int.Parse(timeStampPosted_reg.Match(rawItem).Groups[1].Value);
                outp.DatePosted = Fucs.dateFromTimestamp(timestamp);
               // MessageBox.Show(views_reg.Match(rawItem).Groups[1].Value);
                outp.Views = int.Parse(views_reg.Match(rawItem).Groups[1].Value, NumberStyles.AllowThousands);
                // outp.Duration_str = thumbnail_reg.Match(rawItem).Groups[1].Value;
                //140 250
                //style="background-image: url(&#039;https://scontent.fcmn1-1.fna.fbcdn.net/v/t15.5256-10/s261x260/159144905_390467082028882_392967372454611679_n.jpg?_nc_cat=101&amp;ccb=1-3&amp;_nc_sid=08861d&amp;_nc_ohc=isrS0pNcQhYAX-OV27c&amp;_nc_ht=scontent.fcmn1-1.fna&amp;tp=7&amp;oh=fc53964dc4d7b19b3c66c434ee3389b7&amp;oe=608A84CE&#039;)

                outp.OwnerName = owner_reg.Match(rawItem).Groups[1].Value;

               
                outp.DateAndViewsInfo = timeStampContent.Match(rawItem).Groups[1].Value + " · " + views_reg.Match(rawItem).Groups[1].Value + " Views" + " · by: " + outp.OwnerName;
            }
            catch (Exception)
            {
                //File.WriteAllText(MI.MAIN_PATH+"\\log.failedtoparse.txt", rawItem);
               // MessageBox.Show("failed to parse an element,\nraw content dumped at log.failedtoparse.txt");
                return null;
            }
            




            return outp;

        }

        public static List<SearchElement> Parse(string rawHtml)
        {
            //items separator  //<div class="_keywordSearchVideoHomeVideoListItem__wrapper">
            const string ITEMS_SEPARATOR = "<div class=\"_keywordSearchVideoHomeVideoListItem__wrapper\">";
            string[] rawItems = rawHtml.Split(new string[] { ITEMS_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

            List<SearchElement> outp = new List<SearchElement>();

            int i;
            for (i = 1 ; i< rawItems.Length; i++)
            {
                string item = rawItems[i];
                SearchElement maybeNewSearchElem = ParseOne(item);
                if(maybeNewSearchElem != null) 
                outp.Add(maybeNewSearchElem);
            }

            return outp;

        }
    }


    // a raw object containing the raw gatherd properties of a video from a search result
    // constructor requires 4 raw string arguments:
    // title:      owner:       duration:"4:65"      info:"Feb 14 dot 77K Views"
    // with two optional args:  description and thumbnail_url
    public class SearchElement : INotifyPropertyChanged
    {
        private string url;
        private string id;
        private string title;
        private string ownerName;
        private string dateAndViewsInfo;
        private string thumbUrl;
        private string duration_str;
        private TimeSpan duration;
        private DateTime datePosted;
        private int views;

        public string Url { set { url = value; } get { return url; } }
        public string Id { set { id = value; } get { return id; } }
        public string OwnerName { set { ownerName = value; } get { return ownerName; } }
        public string DateAndViewsInfo { set {
                dateAndViewsInfo = value;
                DatePosted = parseDate(value);
                Views = parseViews(value);
            } get { return dateAndViewsInfo; } }

       
        public string Title { set { title = value; } get { return title; } }
        public string ThumbUrl { set { thumbUrl = value;
                notif(nameof(ThumbImageSource));
            } get { return thumbUrl; } }

        /// <summary>
        /// assigning this will automatically assign the Duration property with the parsed timespne
        /// </summary>
        public string Duration_str { set {
                duration_str = value;
                Duration = parseDuration(value);
            } get { return duration_str; } }

       

        public TimeSpan Duration { set { duration = value; } get { return duration; } }
        public DateTime DatePosted { set { datePosted = value; } get { return datePosted; } }

        public string Description { get; internal set; }

        public int Views;

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource ThumbImageSource
        {
            set {
            }
            get
            {
                if(ThumbUrl != null)
                {
                    return new System.Windows.Media.Imaging.BitmapImage(new Uri(ThumbUrl));

                }
                else
                    return new System.Windows.Media.Imaging.BitmapImage(new Uri("file:///C:/TOOLS/fbhd-gui/fbhd/fbhd/media/video-48-white.png"));//
            }

        }


        private void notif(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //vale is soething like : Feb 3 · 223K Views
        private int parseViews(string value)
        {
            Match match = Regex.Match(value, "(\\d*)([KMB])? *views", RegexOptions.IgnoreCase);
            if (!match.Success) throw new Exception($"mi: the values {value} could not be parsed into Views as int ");
            string number = match.Groups[1].Value;
            string unit = match.Groups[2].Value.ToLower();
            return int.Parse(number) * (unit == "k" ? 1000 : unit == "m" ? 1000000 : unit == "b" ? 1000000000 : 1);
        }

        //vale is soething like : Feb 3 · 223K Views
        private DateTime parseDate(string value)
        {
            return new DateTime(2021, 03, 20);
        }

        //vale is soething like : 4:35
        private TimeSpan parseDuration(string value)
        {

            return Fucs.TimeSpanFromString(value).Value;
        }

    }

    // server side 
    public class SearchParams
    {
        //todo
    }



    

   


    //
    public abstract class Filter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isActive = false;

        /// <summary>
        /// defines how SearchElement Lists are filtered
        /// returnig false means the Item gets filtered out
        /// </summary>
        public abstract bool Test(SearchElement Item);


        internal void notif(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool IsActive
        {
            set
            {
                isActive = value;
                notif(nameof(IsActive));

            }
            get { return isActive; }
        }


        public IEnumerable<SearchElement> Apply(IEnumerable<SearchElement> list)
        {
            return list.Where((elem) => Test(elem));
        }
        



    }


    //only supports 3 types: int ,TimeSpan and DateTime
    //which are related to the properties: Views, Duration and DatePosted
    public class RangeFilter<T> : Filter where T : IComparable
    {
        private T min;
        public T Min
        {
            set { min = value; notif(nameof(Min)); }
            get { return min; }
        }


        private T max;
        public T Max
        {
            set { max = value; notif(nameof(Max)); }
            get { return max; }
        }




       
        public enum FilterType
        {
            regex, range, 
        }


        public  object TargetProperty(SearchElement se)
        {
            if(typeof(T) == typeof(DateTime))
            {
                return se.DatePosted;
            }
            else if (typeof(T) == typeof(TimeSpan))
            {
                return se.Duration;
            }
            else if (typeof(T) == typeof(int))
            {
                return se.Views;
            }
            else
            {
                throw new Exception($"mi: type {typeof(T)} is notsupported in the generic class RangeFilter (only int, timespan, dateTime are supported ");
            }
        }
        
        public override bool Test(SearchElement Elem)
        {
            T value = (T) TargetProperty(Elem);

            return (
                 ((Min == null) || (Min.CompareTo(value) != 1)) &&
                 ((Max == null) || (Max.CompareTo(value) != -1))
                 );
                   
        }

       
    }
    


    // client side params for filtering and sorting search results 
    public class SearchPresenter:INotifyPropertyChanged //Search Results Presenter
    {
        private SortBy sortBy = SortBy.Relevance; //descending order based on viewes
        private Regex titleFilter; // applies both on the title and description
        private Regex ownerFilter; // 
        private DurationRange durationFilter;
        private DateRange datePostedFilter;

        public event PropertyChangedEventHandler PropertyChanged;

        // qualityFilter // not supported since it requires pre-resolving the elements
        // which takes alot of time in most cases

            private void notif(string propName)
        {
            if (PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public Regex TitleFilter { get { return titleFilter; } set { titleFilter = value;  notif(nameof(TitleFilter)); /*MessageBox.Show(value? .ToString()); */} }
        public Regex OwnerFilter { get { return ownerFilter; } set { ownerFilter = value; notif(nameof(OwnerFilter)); } }
        public DurationRange DurationFilter { get { return durationFilter; } set { durationFilter = value; notif(nameof(DurationFilter)); } }
        public DateRange DatePostedFilter { get { return datePostedFilter; } set { datePostedFilter = value; notif(nameof(DatePostedFilter)); } }
        public SortBy SortBy_ { get { return sortBy; } set { sortBy = value; notif(nameof(SortBy_)); } }


        public struct DurationRange
        {
            public TimeSpan? min;
            public TimeSpan? max;


            /// <summary>
            /// user friendly string representation of DurationRange 
            /// based on different snarios it returns something like: "NoFilter" | "min:0:32:24" | "min:0:32:24, max:0:35:12" | "max:0:35:12"
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return (min == null && max == null) ? "NoFilter":( (min==null?"": $"min:{min.ToString()}")+
                   ( max==null?"": ((min == null ? "" :", ") + $"max:{max.ToString()}")));
            }
        }
        public struct DateRange
        {
            public DateTime? min;
            public DateTime? max;
        }



        public enum SortBy
        {
            MostRecent, Relevance, Duration
        }

    }


    /// <summary>
    /// searching tools for Facebook Watch, add levels of abstraction to cover FB, IGTV 
    /// </summary>
    public class Search :INotifyPropertyChanged  {

        public Search()
        {
            this.BufferedResuls = new BindingList<SearchElement>();
            Presenter = new SearchPresenter()
            {
                TitleFilter = null,
                OwnerFilter = null,
                DatePostedFilter = new SearchPresenter.DateRange(),
                DurationFilter = new SearchPresenter.DurationRange(),
                SortBy_ = SearchPresenter.SortBy.MostRecent,

            };


        }
        
        private SearchParams params_;
        private SearchPresenter presenter;
        private BindingList<SearchElement> results;

        public event PropertyChangedEventHandler PropertyChanged;


        private bool applyFilter;
        

        private string query;
        public string Query
        {
            set { query = value;
                notif(nameof(Query));

            }
            get { return query; }
        }

        public SearchParams Params
        {
            set { params_ = value; notif(nameof(Params)); }
            get { return params_; }
        }

        public SearchPresenter Presenter
        {
            set { presenter = value;

                notif(nameof(Presenter));
                presenter.PropertyChanged += (p,r) =>
                {
                    //MessageBox.Show("ch");
                    notif(nameof(Results));
                    notif(nameof(BufferedResuls));

                };
            }
            get { return presenter; }
        }

        public BindingList<SearchElement> Results
        {
            set { results = value; notif(nameof(Results)); }
            get { return Manipulate( results,Presenter); }
        }


        // beffuring results feature : performing multiple search operations
        //with different queries and coleect the results into one single list ready
        // for client side filtering and sorting operations, 
        // 
        private BindingList<SearchElement> bufferedResults;
        public BindingList<SearchElement> BufferedResuls
        {
            set { bufferedResults = value;
                notif(nameof(BufferedResuls));
                notif(nameof(ShouldShowFiltersSection));
            }
            get { return Manipulate( bufferedResults,Presenter);

                
            }
        }


        private bool isSearching = false;
        public bool IsSearching
        {
            set { isSearching = value; notif(nameof(IsSearching)); }
            get { return isSearching; }
        }

        public bool HasBufferedElements
        {
            set { notif(nameof(HasBufferedElements)); }
            get { return BufferedResuls.Count>0; }
        }


        public bool ShouldShowFiltersSection
        {
            set { notif(nameof(ShouldShowFiltersSection)); }
            get { return ((bufferedResults.Count>0) || (!IsQueryUiEmpty)); }
        }


        //this doesn tell wheather that the Query propertie is null , but it's bound through an event to the very text on the query UI element
        // usefull for the ShouldShowFiltersSection updatng
        // cus it should apear as soon  s the user starts typing the query
        private bool isQueryUiEmpty = true;
        public bool IsQueryUiEmpty
        {
            get
            {
                return isQueryUiEmpty;
            }
            set
            {
                isQueryUiEmpty = value;
                notif(nameof(ShouldShowFiltersSection));
            }
        }



        private bool shouldShowError;
        public bool ShouldShowError
        {
            set { shouldShowError = value; notif(nameof(ShouldShowError)); }
            get { return shouldShowError; }
        }


        private string failureReason;
        public string FailureReason
        {
            set { failureReason = value; notif(nameof(FailureReason)); }
            get { return failureReason; }
        }


        void notif(string prop)
        {

            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            if(prop == nameof(BufferedResuls))
            {
                notif(nameof(HasBufferedElements));
                notif(nameof(ShouldShowFiltersSection));

            }
            if (prop == nameof(Query))
            {
                notif(nameof(ShouldShowFiltersSection));

            }
        }



        /// <summary>
        // applies filters and sortning operations if any , 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private BindingList<SearchElement> Manipulate(BindingList<SearchElement> input,SearchPresenter searchPresenter)
        {

            return new BindingList<SearchElement>( input.Where((searchElem) =>
            {
                bool pass = true;

                // # Title & Owner filtering #
                pass = pass && ((searchPresenter.TitleFilter==null) || (searchPresenter.TitleFilter.IsMatch(searchElem.Title)));
               // pass = pass && ((searchPresenter.TitleFilter==null) || (searchPresenter.OwnerFilter.IsMatch(searchElem.OwnerName)));
                // # Duration Filtering #
                pass = pass && ((!searchPresenter.DurationFilter.max.HasValue) || (searchPresenter.DurationFilter.max.Value >= searchElem.Duration));
                pass = pass && ((!searchPresenter.DurationFilter.min.HasValue) || (searchPresenter.DurationFilter.min.Value <= searchElem.Duration));
                // # DatePosted Filtering #
                pass = pass && ((!searchPresenter.DatePostedFilter.max.HasValue) || (searchPresenter.DatePostedFilter.max.Value >= searchElem.DatePosted));
                pass = pass && ((!searchPresenter.DatePostedFilter.min.HasValue) || (searchPresenter.DatePostedFilter.min.Value <= searchElem.DatePosted));



                return pass;
            }). ToList() );

        }

        private BindingList<SearchElement> generateDummyList()
        {
            return new BindingList<SearchElement>() {
                new SearchElement() { Title="SearchEllement object 1",
                    Duration_str ="2:56",
                    OwnerName ="A Page Name",
                    DateAndViewsInfo ="Jun 24 · 333.4K Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },
                new SearchElement() { Title="untitled",
                    Duration_str ="3:14" ,
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    OwnerName ="Creep",
                    DateAndViewsInfo ="2019 Oct 26 · 13M Views" },

                new SearchElement() { Title ="SearchEllement object 2",
                    Duration_str ="13:53",
                    OwnerName ="Dummy profile" ,
                    DateAndViewsInfo ="Feb 2 · 222 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },

                new SearchElement() { Title="SearchEllement object 3",
                    Duration_str ="13:53",
                    OwnerName ="Dummy profile3" ,
                    DateAndViewsInfo ="Feb 3 · 223 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },

                new SearchElement() { Title="SearchEllement object too ",
                    Duration_str ="13:53",
                    OwnerName ="Dummy profile long title" ,
                    DateAndViewsInfo ="Nov 12 · 0 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },

                new SearchElement() { Title="test the elipsis behavior",
                    Duration_str ="13:53",
                    OwnerName ="testing profile" ,
                    DateAndViewsInfo ="Oct 24 · 3145 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },

                new SearchElement() { Title="SearchEllement object 4",
                    Duration_str ="14:53",
                    OwnerName ="Dummy profile4" ,
                    DateAndViewsInfo ="Feb 4 · 224 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },

                new SearchElement() { Title="SearchEllement object 5",
                    Duration_str ="15:53",
                    OwnerName ="Dummy profile5" ,
                    DateAndViewsInfo ="Feb 5 · 225 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },

                new SearchElement() { Title="SearchEllement object 6",
                    Duration_str ="16:53",
                    OwnerName ="Dummy profile6" ,
                    DateAndViewsInfo ="Feb 6 · 226 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },

                new SearchElement() { Title="SearchEllement object 7",
                    Duration_str ="17:53",
                    OwnerName ="Dummy profile7" ,
                    DateAndViewsInfo ="Feb 7 · 227 Views",
                    Url ="https://www.facebook.com/Othmanemd/videos/533766623864047/?sfnsn=mo",
                    },



             };
        }

        const int ERR_CONNECTION = 1;
        const int ERR_UNKNOWN = 2;
        const int SUCCESS = 0;





        //dummy
        // performs the search and updates the results property on successfull
        //operation or rises the OnSearchFaild even otherwise
        public async Task<int> StartSearch (bool addToBuffer)
        {
            bool dev_dummy_mode = query.Contains("dummy");
            Trace.Assert(!string.IsNullOrWhiteSpace(Query), "cannot call SatrtSearch with NullOrWhiteSpace Query, please contact th developer with error code : 0156532 ");

            ShouldShowError = false;

            IsSearching = true;

            if (dev_dummy_mode)
            {
                Results = generateDummyList();
                await Task.Delay(1000);
                isSearching = false;

                notif(nameof(Results));
                if (addToBuffer)
                {
                    foreach (var item in results)
                    {
                        bufferedResults.Add(item);

                    }
                    notif(nameof(BufferedResuls));
                }



               // MainWindow mw = (MainWindow)App.Current.MainWindow;
               // mw.searchResultsList.Items.Filter = (o) => false;
               // var ss = mw.searchResultsList.Items.CanFilter.ToString();
               // Debug.WriteLine(ss);
                return SUCCESS; // int 0
            }
           

            // await Task.Delay(1500);
            Uri queryUrl = new Uri( "https://web.facebook.com/watch/search/?query="+Query);



            
            var r =   await WebClient.cURL.GetTextStatic(queryUrl.AbsoluteUri, Headers.DefaultFbWatchHeaders, true);


            if (!r.Success)
            {
                IsSearching = false;
                ShouldShowError = true;

                if (r.ClientExitCode == 6)
                {
                    this.FailureReason = "Connection Error";

                    return ERR_CONNECTION;

                }
                else
                {

                    this.FailureReason = "Unknown Error";
   
                    return ERR_UNKNOWN;

                }


            }

            Trace.Assert(r.Text.Length >10, "the WebClient.cURL fetching operation failed with exit code:" + r.ClientExitCode.ToString(),"Please Contact the devoloper with error code :'569847'");
            string rawHTML = r.Text;
            IsSearching = false;

           
            
                Results = new BindingList<SearchElement>(ExperimentalSearchResultsParser.Parse(rawHTML));




            notif(nameof(Results));
            if (addToBuffer)
            {
                foreach (var item in results)
                {
                    bufferedResults.Add(item);

                }
                notif(nameof(BufferedResuls));
            }


            return SUCCESS; // int 0

        }

        internal void clearBuffer()
        {
            int c = BufferedResuls.Count;
            bufferedResults.Clear();
            notif(nameof(BufferedResuls));
        }
        internal void clearResults()
        {
            results.Clear();
            //Results = new
            notif(nameof(Results));
        }
    }

    public enum DownloadClients { curl,powershell,ffmpeg}

    [Serializable]
    public class CLWPresetDeclaration
    {
        public string Path { get; set; }
        public bool AutoStart { get; set; }
        public bool AutoLoad { get; set; }
    }
    [Serializable]
    public class Config
    {
       

        public List<CLWPresetDeclaration> CLWPresetsDeclarations { get; set; } = new List<CLWPresetDeclaration>();


        public string GlobalOutputDirectory { get; set; } = MI.DEFAULT_GLOBAL_OUTPUT_DIR;

        public List<string> RecentGlobalDirectories { get; set; } = new List<string>();
        public OverrideBehaviour DefaultOverrideBehaviour { get; set; } = OverrideBehaviour.Override;
        public bool DownloadRawStreams { get; set; } = false;
        public bool AutoStartServer { get; set;  } = false;
        public bool UseChunckedDownloading { get; set; } = false;
        public DownloadClients DefaultDownloadClient { get; set; } = DownloadClients.curl;

        static XmlSerializer sr = new XmlSerializer(typeof(Config));

        public void Save(string saveAS =null)
        {
            if (saveAS == null) saveAS = MI.APP_CONFIG_FILE;
            using (var stream = File.Open(saveAS, FileMode.Create))
            {
                sr.Serialize(stream, this);
            }
        }

        public static Config Load(string ConfigFile =null)
        {
            if(ConfigFile==null) ConfigFile = MI.APP_CONFIG_FILE;
            if (!File.Exists(ConfigFile)) {
                Config.FactoryConfig().Save();
                return FactoryConfig();
            }
            using (var stream = File.OpenRead(ConfigFile))
            {
                return  sr.Deserialize(stream) as Config;
            }
        }

        public static Config FactoryConfig()
        {
            return new Config() ;
                
        }


    }



    public class Session : INotifyPropertyChanged 
    {

        private string printSpectioalFolder (Environment.SpecialFolder sf)
        {
            return sf.ToString() + ": " + Environment.GetFolderPath(sf); 
        }

        public Session()
        {

            if (!Directory.Exists(MI.TEMP_HTML_FILES)) Directory.CreateDirectory(MI.TEMP_HTML_FILES);
            bool curlExists = File.Exists(  Environment.CurrentDirectory+ "\\curl\\curl.exe");
            bool ffmpegExists = File.Exists(Environment.CurrentDirectory + "\\ffmpeg\\ffmpeg.exe");

          Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\mi\\fbhd");
            
            Trace.Assert(curlExists, "couldnt find the curl executable at .\\curl\\curl.exe the wpp will not work correctely unless another location is specidied in the settings or it is included in the path.");
            Trace.Assert(ffmpegExists, "couldnt find the ffmpeg executable at .\\ffmpeg\\ffmpeg.exe the wpp will not work correctely unless another location is specified or it is included in the path.");

            MainConfig = Config.Load();
            if (string.IsNullOrWhiteSpace( MainConfig.GlobalOutputDirectory)==false)
                GlobalOutputFolder = MainConfig.GlobalOutputDirectory;
            
            if (MainConfig == null) MainConfig = Config.FactoryConfig();

            MainSearch = new Search();
           // mp.Open(new Uri("C:\\TOOLS\\fbhd-gui\\notif-5th.wav"));
            mp.Open(new Uri("C:\\TOOLS\\fbhd-gui\\mi-notif-5th.wav"));

            FsdmNewsWatcher.OnError += (s, err) => {

                MI.Verbose ( "Couldn't connect");

            };
            FsdmNewsWatcher.NewItems += (s, news) =>
            {
                string appended = "";
                foreach (FsdmNew item in news)
                {
                    appended += item.PopupMessageString + "\n\n";
                }
                appended = appended.Substring(0, appended.Length - 2);
                // Application.Current.MainWindow.Activate();

                // mw. PopupNews(news);
                PlayNotification();
                IEnumerable<INotifableItem> AsINotifable = news.Cast<INotifableItem>();
                mw.ShowNotificationNews(AsINotifable, FsdmNewsWatcher);
                //MessageBox.Show($"{appended}","fsdm news", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            };

            CustomListWatchers = new BindingList<CustomLW>();
            foreach (var presetDeclaration in MainConfig.CLWPresetsDeclarations)
            {
                string presetPath = presetDeclaration.Path;
                if (presetDeclaration.AutoLoad)
                {
                    CustomLW clwObject=null;
                    Task.Run(async() =>
                    {

                        clwObject = await LoadXMLLW(presetPath);
                        
                           
                    }).GetAwaiter().GetResult();
                    if(clwObject != null)
                    {
                      //  MessageBox.Show(clwObject.Name);
                    }
                   if (presetDeclaration.AutoStart)
                       clwObject.StartWatching();

                }

            }
            OnPropertyChanged(nameof(ExistLoadedCLWatchers));
           // Tasks = new BindingList<FBHDTask>();
            //SelectedTask = null;
        }



        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        private FBHDTask selectedTask;
        private BindingList<FBHDTask> tasks = new BindingList<FBHDTask>();
        private string globalOutputFolder = MI.DEFAULT_GLOBAL_OUTPUT_DIR;
        private int runningFfmpegCount = 0;
        private bool isServerRunning = false;
        private int failedCount = 0;
        private int runningPy_fetcherCount = 0;


        


        private BindingList<CustomLW> customListWatchers;
        public BindingList<CustomLW> CustomListWatchers
        {
            set { customListWatchers = value;
                OnPropertyChanged(nameof(CustomListWatchers));

            }
            get { return customListWatchers; }
        }


        public bool ExistLoadedCLWatchers
        {
            get { return CustomListWatchers.Count>0; }
        }




        private FSDMNewsWatcher fsdmNewsWatcher= new FSDMNewsWatcher(File.ReadAllText(MI.FSDM_News_Ref_PATH)) { Interval = 3 * 60 * 1000 };
        public FSDMNewsWatcher FsdmNewsWatcher 
        {
            get { return fsdmNewsWatcher; }
        }




        public bool HasSelection
        {
            get { return (SelectedTask!=null); }
        }




        public int TasksCount
        {
            set {  OnPropertyChanged(nameof(TasksCount)); }
            get { return Tasks.Count; }
        }




        public bool HasTasks
        {
            
            get { return Tasks.Count>0; }
            set
            {
                OnPropertyChanged(nameof(HasTasks));
            }
        }



        public FBHDTask SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
                OnPropertyChanged(nameof(HasSelection));
            }
        }

        public BindingList<FBHDTask> Tasks 
        {
            set { tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }

            get { return tasks; }
        }

        private Search mainSearch;
        public Search MainSearch
        {
            set { mainSearch = value; OnPropertyChanged(nameof(MainSearch)); }
            get { return mainSearch; }
        }



        public string GlobalOutputFolder {
            get {
                return globalOutputFolder;
            } set
            {
                value = value.TrimEnd(new char[] { '\\' }) + "\\";
                globalOutputFolder = value;
                OnPropertyChanged(nameof(GlobalOutputFolder));
            }
        }
        public int RunningFfmpegCount {
            get
            {
                return runningFfmpegCount;
            }
            set
            {
                runningFfmpegCount = value;
                OnPropertyChanged(nameof(RunningFfmpegCount));
            }
        }
        public bool IsServerRunning {
            get
            {
                return isServerRunning;
            }
            set
            {
                isServerRunning = value;
                OnPropertyChanged(nameof(IsServerRunning));
            }
        }
        public int FailedCount {
            get
            {
                return failedCount;
            }
            set
            {
                failedCount = value;
                OnPropertyChanged(nameof(FailedCount));
            }
        } 
        public int RunningPy_fetcherCount {
            get
            {
                return runningPy_fetcherCount;
            }
            set
            {
                runningPy_fetcherCount = value;
                OnPropertyChanged(nameof(RunningPy_fetcherCount));
            }
        }

        public Config MainConfig { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if(propertyName == nameof(CustomListWatchers))
            {
                OnPropertyChanged(nameof(ExistLoadedCLWatchers));
            }
        }


        private MediaPlayer mp = new MediaPlayer();
        internal void PlayNotification()
        {


            // mp.Volume = 1;
            mp.Position = TimeSpan.FromMilliseconds(0);
            mp.Play() ;
        }



        /// <summary>
        /// loads the file content, parses it, adds a listwatcher objct to the CustomListWatchers 
        /// returnng the new CustomLW instance on succes and null on failure
        ///  </summary>
        internal async Task<CustomLW> LoadXMLLW(string fileName)
        {
            CustomLW newCustomLW  =  XMLLW.LoadXMLPreset(File.ReadAllText(fileName));


            if (File.Exists(newCustomLW.ReferenceFilePath))
            {
                newCustomLW.InitialReferenceContent = File.ReadAllText(newCustomLW.ReferenceFilePath);

                if (string.IsNullOrEmpty(newCustomLW.InitialReferenceContent))
                {
                    MessageBox.Show($"Empty initial data! XMLLW-Loader will attemp to fetch data from {newCustomLW.Href} and override the file:\n {newCustomLW.ReferenceFilePath}  ");
                    var data = await WebClient.cURL.GetTextStatic(newCustomLW.Href, Headers.FakeUserAgentHeaders, true);
                    if (data.Success)
                    {
                        File.WriteAllText(newCustomLW.ReferenceFilePath, data.Text);
                        newCustomLW.InitialReferenceContent = data.Text;
                    }
                    else
                    {
                        MessageBox.Show($"couldnt fetch the data, try later\n errorcoe:{data.ClientExitCode}");
                        return newCustomLW;// //done//todo: shold inform the caller that things went wrong
                    }
                }
            }

            else
            {
                MessageBox.Show($"Reference file does not exist at {newCustomLW.Href}!\n XMLLW-Loader will attemp to create one with initial data from {newCustomLW.Href} ");
                var data = await WebClient.cURL.GetTextStatic(newCustomLW.Href, Headers.FakeUserAgentHeaders, true);
                if (data.Success)
                {
                    File.WriteAllText(newCustomLW.ReferenceFilePath, data.Text);
                    newCustomLW.InitialReferenceContent = data.Text;

                }
                else
                {
                    MessageBox.Show($"couldnt fetch the data, try later\n errorcoe:{data.ClientExitCode}");
                    return null;
                }

            }

           
            newCustomLW.NewItems += (s, news) =>
            {
                PlayNotification();
                mw.ShowNotificationNews(news, newCustomLW);
            };
            CustomListWatchers.Add(newCustomLW);
            OnPropertyChanged(nameof(ExistLoadedCLWatchers));
            return newCustomLW;

        }
    }



    
    /// <summary>
    /// besides the extension based TaskType, this serves as a more general type that can be used to enhance the UX and watnot 
    /// this will always accept three values   
    /// </summary>
    public enum MediaType
    {
         Audio = 0, Video = 1, Image =2

    }



    public struct Size
    {
        public Size(int bytes_)
        {
            bytes = bytes_;
        }

        /// <summary>
        /// uses raw string, e.g:  2056kB | 3.62GB | 500Mb
        /// </summary>
        /// <param name="str"></param>
        public Size(string str)
        {

            int sizeInBytes=0;
            Match match = Regex.Match(str, "(b|kb|mb|gb)", RegexOptions.IgnoreCase);
            if (match.Value == null) throw new Exception("mi: Size parsing failed; unsuported format");
            string asNumber = str.Replace(match.Value, "").Trim();
            
            switch (match.Value.ToLower())
            {
                case "b" :
                    sizeInBytes = int.Parse(asNumber);
                        break;
                case "kb":
                    sizeInBytes = (int) (Double.Parse(asNumber)*1024);
                    break;
                case "mb":
                    sizeInBytes = (int)(Double.Parse(asNumber) * 1048576);
                    break;
                case "gb":
                    sizeInBytes = (int)(Double.Parse(asNumber) * 1073741824);
                    break;
                default:

                    break;
            }
           // MessageBox.Show(sizeInBytes.ToString());
            bytes = sizeInBytes;
        }
        public int bytes;
        public override string ToString()
        {

              if (bytes >= 1073741824)
            {
                return $"{ Math.Round((double)(bytes / 1073741824), 2).ToString()}GB";
            }
            else if (bytes >= 1048576)
            {
                return $"{ Math.Round((double)(bytes / 1048576), 2).ToString()}MB";
            }

            else if (bytes >= 1024)
            {
                return $"{ Math.Round((double)(bytes / 1024)).ToString()}KB";
            }

            else if (bytes < 1024)
            {
                return $"{bytes.ToString()}B";
            }
              else
            {
                throw new Exception("mi: invalid number");
            }
            
           
            



        }
    }





    public interface IHasID
    {
        string ID { get; }

    }



    public interface ListWatcherItem : IHasID
    {
         string PopupMessageString { get; }


    }


    //created to solve some casting problems and abstract away methods between the fsdmlistwatcher and CustomListWatcher
    public interface IWatch
    {

         void MarkAllAsRead();


         void MarkAsRead(IEnumerable<INotifableItem> what);
        
    }


    /// <summary>
    /// base class for watching a static web page that has a list-like patern, by Checking it's content regularely with the pre configured Interval
    /// notifies changes through firing the events NewItems, RevokedItems ;
    /// the OnError event is fired in when the client fails to connect or when the list parser method fails 
    /// NOTE/ it's important for the ID property of an item to be unique and stay unchanged over time in order for this to work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ListWatcher<T>  : INotifyPropertyChanged, IWatch where T : ListWatcherItem
    {

        
       
        public event EventHandler<List<T>> NewItems;
        public event EventHandler<List<T>> RevokedItems;

        public event EventHandler<string> OnError;
        public event PropertyChangedEventHandler PropertyChanged;





        private int interval = 60000;
        public int Interval
        {
            set {
                if (value < 30000) value = 30000;
                interval = value;
                notif(nameof(Interval));
                notif(nameof(IntervalAsString));

            }
            get { return interval; }
        }




        public int ChecksCount { get; set; } = 0; // countes both successfull and unsuccessful checkings
        public TimeSpan WatchingFor { get; set; }



        internal void notif(string propertyName)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private bool isWatching = false;
        public bool IsWatching { get {return isWatching; } private set {
                isWatching = value;
                notif(nameof(IsWatching));
                notif(nameof(StatusMessage));


            }
        }


        public bool IsFailing
        {
           
            get { return FailingCount > 0; }
        }

        public bool IsRunningSuccessfully
        {
            get { return !IsFailing; }
        }



        /// <summary>
        /// seccessful checking counter, starts when first initalized
        /// </summary>
        private int successfulCheckCount;
        public int SuccessfulCheckCount
        {
            set { successfulCheckCount = value;
                notif(nameof(SuccessfulCheckCount)); notif(nameof(StatusMessage));
            }
            get { return successfulCheckCount; }
        }



        

        public void MarkAllAsRead()
        {
            UnreadNews.Clear();
            UnreadNews = new BindingList<INotifableItem>();
            notif(nameof(HasUnreadNews));
            notif(nameof(UnreadCount));
            UpdateReferenceFile();

        }

        public void MarkAsRead(IEnumerable<INotifableItem> what)
        {
            foreach (var item in what)
            {
                UnreadNews.Remove(item);
            }
            notif(nameof(HasUnreadNews));
            notif(nameof(UnreadCount));
        }


        private BindingList<INotifableItem> unreadNews;
        public BindingList<INotifableItem> UnreadNews
        {
            set { unreadNews = value;
                notif(nameof(UnreadNews));
                notif(nameof(HasUnreadNews));
                notif(nameof(UnreadCount));
            }
            get { return unreadNews; }
        }


        public bool HasUnreadNews
        {
            set { notif(nameof(HasUnreadNews)); }
            get { return UnreadNews.Count > 0; }
        }


        public int UnreadCount
        {
            set {  notif(nameof(UnreadCount)); }
            get { return UnreadNews.Count; }
        }






        public string StatusMessage
        {
            set {  notif(nameof(StatusMessage)); }
            get { return !IsWatching? "Disabled" : IsFailing? $"Failed [{FailingCount}]" : $"Running [{SuccessfulCheckCount}]"; }
        }



        /// <summary>
        /// unsuccessful checkings cc, gets reset to 0 when a successfull check occurs
        /// </summary>
        private int failingCount;
        public int FailingCount
        {
            set { failingCount = value;
                notif(nameof(FailingCount));
                notif(nameof(IsFailing));
                notif(nameof(IsRunningSuccessfully));
                notif(nameof(StatusMessage));


            }
            get { return failingCount; }
        }




        /// <summary>
        /// short description: only assign something that Fucs.TimeSpanFromString can 
        /// parse, and expect the getter to return "03:30"-like strings
        /// this property works as a parser/converter for the actual int Interval property 
        /// simplifing the two way binding for the UI IncreaseTextBox control
        /// NOTE: when passing a string tha cannot be resolved the value 00:30 is supplied 
        /// </summary>
        public string IntervalAsString
        {
            set {
                var ts = Fucs.TimeSpanFromString(value);
                if (!ts.HasValue)
                {
                    Interval = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
                }
                else
                {
                    Interval = (int) ts.Value.TotalMilliseconds;
                }

            }
            get { return TimeSpan.FromMilliseconds(Interval).ToString().Substring(3); }
        }





        public abstract string Href { get;  }
        public string InitialReferenceContent { get; set; }
        public List<T> CurrentReferenceList { get; set; }
        public  string ReferenceFilePath { get; set; }

        //internal abstract string GetPageContent(string href);

        /// <summary>
        /// returns false on any parsing failure, 
        /// on successful parsing it assigns a new list oject to the out parsedList argument
        /// </summary>
        /// <returns></returns>
        internal abstract bool ParseList(string pageContent, out List<T> parsedList );


        /// <summary>
        /// iterates through the newList items and searchs for new ones that does not exist in the oldList, 
        /// returns false if not new items were found, true otherwise
        /// the passed newItems object should be pre-assigned cuw the new items will be added ther using its .add() method
        /// </summary>
        private bool findNewItems(List<T> oldList, List<T> newList, List<T> newItemsOutput)
        {
            bool newsExist = false;
            foreach (var item in newList)
            {
                int ix = oldList.FindIndex((One)=>One.ID==item.ID);
                if ( ix== -1)
                {
                    newItemsOutput.Add(item);
                    newsExist = true;
                }
            }

            return newsExist;
        }

        public string  currentContent;


        /// <summary>
        /// iterates through the oldList items and searchs for ones that are missing in the newList, 
        /// returning true when revoked items exist, false otherwise
        /// the passed revokedItems object should be pre-assigned cuz the revoked items will be added there using its .add() method
        /// Note: the results relies only on the items's ID
        ///  </summary>
        private bool findRevokedItems(List<T> oldList, List<T> newList, List<T> revokedItemsOutput)
        {
            bool Exist = false;
            foreach (var item in oldList)
            {
                int ix = newList.FindIndex((One) => One.ID == item.ID);
                if (ix == -1)
                {
                    revokedItemsOutput.Add(item);
                    Exist = true;
                }
            }

            return Exist;
        }


        struct CheckingResult
        {
            public bool ExistChanges;
            public bool Success;
            public Exception Error;
        }

        private async Task <CheckingResult> Check()
        {
            
            

                var r = await WebClient.cURL.GetTextStatic(Href, Headers.FakeUserAgentHeaders, true);

            if (!r.Success)
            {
                return new CheckingResult() { Success = false, Error = new Exception("Couldnt fetch: curl exited wih code: "+ r.ClientExitCode.ToString()), ExistChanges = false };

            }
            currentContent = r.Text;

            
            if (currentContent == null)
            {
                return new CheckingResult() { Success = false, Error = new Exception("couldent fetch"), ExistChanges = false };
               
            }

            // File.WriteAllText(MI.MAIN_PATH + "\\aaaareeeef.html", currentContent);

            // MessageBox.Show("saved html");

            List<T> currentList;
            bool successfulParsing = ParseList(currentContent , out currentList);
            if(!successfulParsing)
            {
                return new CheckingResult() { Success = false, Error = new Exception("mi: parsing method failed") };
            }
            List<T> maybeNewItems = new List<T>();
            List<T> maybeRevokedItems = new List<T>();
            bool existNews = findNewItems(CurrentReferenceList, currentList, maybeNewItems);
            bool existRevoked = findRevokedItems(CurrentReferenceList, currentList, maybeRevokedItems);
            bool existChanges = existNews || existRevoked;
            if (existChanges)
            {
                CurrentReferenceList = currentList;
                if (existNews)
                {
                    if (NewItems != null) NewItems(this, maybeNewItems);
                }
                if (existRevoked)
                {
                    if (RevokedItems != null) RevokedItems(this, maybeRevokedItems);
                }
            }

            return new CheckingResult() { Success = true, ExistChanges = existChanges };



        }

        public async void StartWatching()
        {
            Debug.WriteLine($"StartWatching() was called", "ListWatcher<>");

            if (CurrentReferenceList == null) 
            {
                Debug.WriteLine($"CurrentReferenceList is null", "ListWatcher<>");

                if (string.IsNullOrWhiteSpace(InitialReferenceContent))
                {
                    throw new Exception("mi: ListWatcher: cannot start watching before assigning the initialContentReference");
                }
                List<T> initialList;
               bool succesfullInitialization =  ParseList(InitialReferenceContent, out initialList);
                if (succesfullInitialization)
                {
                    CurrentReferenceList = initialList;
                    Debug.WriteLine($"initialized CurrentReferenceList ({CurrentReferenceList.Count} Items)", "ListWatcher<>");

                }
                else
                {
                    throw new Exception("mi: canot init the watcher because parsing the initialContentReference failed");
                }

            }
            IsWatching = true;
            while (IsWatching)
            {
                CheckingResult res = await Check();
                if(res.Success == false)
                {
                    FailingCount++;
                    Debug.WriteLine($"Check() method returned unsuccessfull CheckingResult with Error: {res.Error} ", "ListWatcher<>");
                    Debug.WriteLine($"Firing the OnError event", "ListWatcher<>");

                    if (OnError!=null)  OnError(this,"could'nt fetch");


                }
                else
                {
                    if (FailingCount > 0) FailingCount = 0;
                    SuccessfulCheckCount++;
                    Debug.WriteLine($"Check() method succeed, CurrentReferenceList has {CurrentReferenceList.Count} items ", "ListWatcher<>");
                    
                }
                await Task.Delay(Interval);
            }
            
        }

        

        public void StopWatching()
        {
            IsWatching = false;
        }


        internal void UpdateReferenceFile()
        {
            File.WriteAllText(this.ReferenceFilePath, currentContent);
        }

       
    }




    


    public struct FsdmNew: ListWatcherItem, INotifableItem
    {
        public string ID { get; set; }
        public string PopupMessageString { get {
                return $"{Title} \n       {Link}";
            } }

        public string SubTitle { get { return date; } }

        public string Link { get; set; }
        public string Title { get; set; }
        public string date { get; set; }
        public string category { get; set; }


    }

    public class FSDMNewsWatcher : ListWatcher<FsdmNew>, IWatch
    {
        public FSDMNewsWatcher(string initialReferenceContent)
        {
           
            InitialReferenceContent = initialReferenceContent;
            ReferenceFilePath = MI.FSDM_News_Ref_PATH;
            Debug.WriteLine($"initialized with InitialReferenceContent of {initialReferenceContent.Length.ToString()} lenght", "FSDMNewsWatcher");

            UnreadNews = new BindingList<INotifableItem>();

            base.NewItems += (s, news) => {
                foreach (var item in news)
                {
                    UnreadNews.Add(item);
                }
                notif(nameof(UnreadNews));
                notif(nameof(HasUnreadNews));
                notif(nameof(UnreadCount));


            };

        }

        


       


        
       




        // taken from python version 
        // attemps to parse item, no need to handle exceptions cuz this is called inside a catch
        private FsdmNew parseItem(string rawItemString)
        {
            FsdmNew outp = new FsdmNew();


            Match parse_href_and_title = Regex.Match(rawItemString,"<a  href=\"(http://fsdmfes.ac.ma/News/(\\d{3,5})/show)\">(.*?)</a></span></p>");
            Match date_and_category = Regex.Match(rawItemString, "<p style=\"font-size:10px; \">(.*?)\\|(.*?)</p>");

    if (parse_href_and_title.Success ==false)
            {
                throw new Exception("parsing item filed: parse_href_and_title");
            }
           if (parse_href_and_title.Success == false)
            {
                throw new Exception("parsing item filed: date_and_category");
            }
            outp.Link = parse_href_and_title.Groups[1].Value;
            outp.ID = int.Parse(parse_href_and_title.Groups[2].Value).ToString();
            outp.Title = parse_href_and_title.Groups[3].Value.Replace("&amp;", "&").Replace("&#039;", "'") ;
            outp.date = date_and_category.Groups[1].Value;
            outp.category = date_and_category.Groups[2].Value;
            return outp;
        }
        private List<string> getRawItems(string rawPage)
        {


            List<string> outplist = new List<string>();

            string pre_triming = Regex.Match(rawPage,"<ul class=\"list contact-details\">(.*?)<div class=\"paginationx\">",  RegexOptions.Singleline).Value;
            //MessageBox.Show(pre_triming.Length.ToString());

            MatchCollection mc = Regex.Matches(pre_triming, "<li>.\\s*<div>.?(.*?)</li>", RegexOptions.Singleline);

            foreach (Match item  in mc)
            {
                outplist.Add(item.Value);
            }

            Debug.WriteLine($"getRawItems returned {outplist.Count} raw items", "FSDMNewsWatcher");

            return outplist;

        }

    public override string Href  {get {return "http://fsdmfes.ac.ma/News"; } }

        internal override bool ParseList(string pageContent, out List<FsdmNew> parsedList)
        {
            Debug.WriteLine($"ParseList was called", "FSDMNewsWatcher");

            List<string> rawItems = getRawItems(pageContent);
            if (rawItems.Count < 2)
            {
                parsedList = null;
                return false;
            }
            List<FsdmNew> outp = new List<FsdmNew>();
            foreach (var rawItem in rawItems)
            {
                FsdmNew maybeItem;
                if(parseItem(rawItem, out maybeItem))
                {
                    outp.Add(maybeItem);

                }
            }
            if (outp.Count < 2)
            {
                parsedList = null;
                return false;
            }
            parsedList = outp;
            return true;
        }

        private bool parseItem(string rawItem, out FsdmNew maybeItem)
        {
            try
            {
                maybeItem = parseItem(rawItem);
                return true;
            }
            catch (Exception)
            {
                maybeItem = new FsdmNew();
                return false;
                
            }
        }

        
    }







    public class ExpandoLWItemObject : DynamicObject, ListWatcherItem, INotifableItem
    {
        public string ID
        {
            get { return ExpandoObj.ID; }
        }

        public string PopupMessageString
        {
            get {   return ExpandoObj.PopupMessageString;  }
        }


        public dynamic  ExpandoObj { get; set; }

        public string Title
        {
            get { return HasProperty("Title") ? ExpandoObj.Title : "unknown"; }

        }

        bool HasProperty(string propname)
        {
            IDictionary<String, object> asDict = (IDictionary<string, object>)this.ExpandoObj;
            return asDict.Keys.Contains(propname);
        }

        public string SubTitle
        {
            get {
                return HasProperty("SubTitle") ? ExpandoObj.SubTitle : null;
               
            }

        }

        public string Link
        {
            get { return HasProperty("Link") ? ExpandoObj.Link : "unknown"; }

        }
    }



    public class XMLLW
    {

        public static class MESSAGES
        {

            public static string missingProp(string elementName, string propName)
            {
                return $"Mi: {elementName} element missing the '{propName}' property";
            }
            public static string missingElem(string elementName)
            {
                return $"Mi: {elementName} element missing";
            }

            public const string listWatcher_missing_name_prop = "Mi: ListWatcher is missing the name property";
            public const string zez = "Mi: ListWatcher";
            public const string zezr = "Mi: ListWatcher";
            public const string zerz = "Mi: ListWatcher";
            public const string err = "Mi: ListWatcher";
            public const string erre = "Mi: ListWatcher";
            public const string rte = "Mi: ListWatcher";

        }



        public static CustomLW LoadXMLPreset(string PrestXmldata)
        {

            XDocument d = XDocument.Parse(PrestXmldata);
            
           // File.WriteAllText("C:\\TOOLS\\fbhd-gui\\xml\\fsdmNews.xml", d.ToString());
            XElement listWatcher = null;
            foreach (var item in d.Nodes())
            {
                if (item.NodeType == System.Xml.XmlNodeType.Element)
                {
                    //MessageBox.Show(((XElement)item).Name.LocalName);
                    if (((XElement)item).Name == "ListWatcher")
                    {
                        listWatcher = (XElement)item;
                    }
                }
            }
            Trace.Assert(listWatcher != null, XMLLW.MESSAGES.missingElem("ListWatcher"));

            XElement ItemClass = listWatcher.Element("ItemClass");
            Debug.Assert(ItemClass != null, XMLLW.MESSAGES.missingElem("ItemClass"));
            XElement ListParser = null;

            foreach (var item in listWatcher.Descendants())
            {
                if (fbhd.Tag.Type(item) == fbhd.Tag.TagType.ListParser)
                    ListParser = (XElement)item;
            }
            Debug.Assert(ListParser != null, XMLLW.MESSAGES.missingElem("ListParser"));

            XAttribute nam = listWatcher.Attribute("name");
            string presetName = nam == null ? null : nam.Value;
            XAttribute RefFileAttr = listWatcher.Attribute("referenceFile");
            string referenceFile = RefFileAttr == null ? null : RefFileAttr.Value;
            Debug.Assert(!string.IsNullOrWhiteSpace(presetName), XMLLW.MESSAGES.missingProp("ListWatcher", "name"));
            Debug.Assert(!string.IsNullOrWhiteSpace(referenceFile), XMLLW.MESSAGES.missingProp("ListWatcher", "referenceFile"));

            Debug.WriteLine("loading preset with name: " + presetName);

            XElement ItemParser = ListParser.Element("Item");
            Debug.Assert(ItemParser != null, XMLLW.MESSAGES.missingElem("ItemParser"));

            //string input = File.ReadAllText(MI.FSDM_News_Ref_PATH);

            ListWatcherTag main = new ListWatcherTag(listWatcher, "dummy data");

            Debug.WriteLine("main ListWatcher Tag constructed, the preset model is constructed succesfully");

            ListParser listParserTag = (ListParser)main.GetAllDescendants().Find((elem) => elem.GetType() == typeof(ListParser));

            Debug.Assert(listParserTag != null, "mi: listParserTag did not get cosntructed, please contact the developer iwth error key: 43323");

            //var collection = listParserTag.GetParsedList();

            
           // Debug.WriteLine($"{collection.Count} items were parsed");
            return new CustomLW(main, referenceFile);

        }


    }



    public class CustomLW : ListWatcher<ExpandoLWItemObject> , IWatch
    {
        private string PresetHref;
        public string Name { get { return ListWatcherTag.presetName; } }

        private ListWatcherTag ListWatcherTag { get; set; }
        private ListParser ListParserTag { get; set; }

        public CustomLW(ListWatcherTag main, string referenceFile)
        {
            ReferenceFilePath = referenceFile;
            ListWatcherTag = main;
            PresetHref = main.uri;
            Interval = (int) main.DefaultInterval.TotalMilliseconds;

            ListParserTag = main.ListParserRef;
            UnreadNews = new BindingList<INotifableItem>();

            base.NewItems += (s, news) => {
                foreach (var item in news)
                {
                    UnreadNews.Add(item);
                }
                notif(nameof(UnreadNews));
                notif(nameof(HasUnreadNews));
                notif(nameof(UnreadCount));


            };

        }
        public override string Href
        {
            get
            {
                return PresetHref;
            }
        }


        

        internal override bool ParseList(string pageContent, out List<ExpandoLWItemObject> parsedList)
        {

            List<ExpandoLWItemObject> outputList = new List<ExpandoLWItemObject>();
            ListWatcherTag.Input = pageContent;
            ListWatcherTag.Refresh(pageContent);
            outputList = ListParserTag.GetParsedList().ConvertAll<ExpandoLWItemObject>(new Converter<ExpandoObject, ExpandoLWItemObject>((e) => new ExpandoLWItemObject() { ExpandoObj = e }));
            parsedList = outputList;

            if (outputList.Count <1 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       
       
    }




    /// <summary>
    /// a moodle session, provides facilities for loging in, monitoring and downloading
    /// all types of resources,
    /// </summary>
    public class Moodle
    {
        public Moodle()
        {     
        }

        public List<Module> Modules;

        public partial class Module
        {
            public List<Section> l;
        }
        public partial class Section
        {
        }
        public partial class Folder
        {
        }
        public partial class Resource
        {

        }
        public  enum ResourceType { Doc,Vid,Zip}

    }


    

    
    
    public abstract class Tag
    {

        public List<Tag> GetAllDescendants()
        {
            List<Tag> outp = new List<Tag>();
            if (Children == null)
            {
                return outp;
            }
            foreach (var item in Children)
            {
                outp.AddRange(item.GetAllDescendants());
                outp.Add(item);
            }
            return outp;
        }


        public void spawnChildren()
        {
            foreach (var item in XElement.Nodes())
            {
                //doesnt include Item tag cz the ListParser class does child spawning by it's owwn, instead of calling this base ethode
                TagType type = Type(item);
                if (type == TagType.Wraper)
                {
                    Children.Add(new wraper((XElement)item, this));
                }
                else if (type == TagType.Replacer)
                {
                    Children.Add(new Replacer((XElement)item, this));
                }
                else if (type == TagType.Match)
                {
                    Children.Add(new Matcher((XElement)item, this));
                }
                else if (type == TagType.TargetProperty)
                {
                    Children.Add(new TargetProperty((XElement)item, this));
                }
                
                else if (type == TagType.ListParser)
                {
                    Children.Add(new ListParser((XElement)item, this));
                }
                else if (type == TagType.Value)
                {
                    Children.Add(new ValueTag((XElement)item, this));
                }
                else if (type == TagType.Group)
                {
                    Children.Add(new GroupTag((XElement)item, this));
                }
                else if (type == TagType.tracer)
                {
                    Children.Add(new TracerTag((XElement)item, this));
                }
                else if (type == TagType.XParser)
                {
                    Children.Add(new XParserTag((XElement)item, this));
                }
                else if (type == TagType.InnerXML)
                {
                    Children.Add(new InnerXML((XElement)item, this));
                }
                else if (type == TagType.AttributeValue)
                {
                    Children.Add(new AttributeValue((XElement)item, this));
                }

            }
        }



        /// <summary>
        /// returns null if attribute doesnt exist
        /// </summary>
        public string getAttrib(string attribName)
        {
            return XElement.Attribute(attribName)?.Value;
        }

        /// <summary>
        /// returns bool indicating wether the attribute was found and outputed
        /// </summary>
        public bool getAttrib(string attribName, out string maybeValue)
        {
            var xattr =  XElement.Attribute(attribName);
            if (xattr != null) {  maybeValue = xattr.Value; return true; }
            else { maybeValue = null; return false; }
        }



        /// <summary>
        /// causes all descendants to re apply(), resulting in a new data distrubution over the preset model, 
        /// this allows to re use the preset model to parse another string data, and usually only invoked by the root ListWatcher object 
        /// </summary>
        public virtual void Refresh(string injectInput="")
        {
            Input = injectInput;
            if (string.IsNullOrEmpty(injectInput))
            {
                Input = Parent.Output;
            }
            
            apply();
            foreach (var item in Children)
            {
                item.Refresh();
            }
        }

        public enum TagType { Wraper, Replacer, Match, ListParser, Item, Value, Group, Success, TargetProperty , none,
            tracer,
            XParser,
            InnerXML,
            AttributeValue
        }

        public static TagType Type(XElement xelem)
        {
            if (xelem.Name.Namespace == "xml-parser") return TagType.XParser;
            switch (xelem.Name.LocalName.ToLower())
            {
                case "wraper":
                    return TagType.Wraper;
                case "replacer":
                    return TagType.Replacer;
                case "match":
                    return TagType.Match;
                case "listparser":
                    return TagType.ListParser;
                case "item":
                    return TagType.Item;
                case "value":
                    return TagType.Value;
                case "group":
                    return TagType.Group;
                case "targetproperty":
                    return TagType.TargetProperty;
                case "tracer": return TagType.tracer;
                case "attributevalue": return TagType.AttributeValue;
                case "innerxml": return TagType.InnerXML;
                default:
                   return TagType.none ;
            }

        }
        public static TagType Type(XNode xnode)
        {
            if(xnode.NodeType == XmlNodeType.Element)
            {
                return Type((XElement)xnode);
            }
            else
            {
                return TagType.none;
            }
           
              
        }

        public List<Tag> Children { get; set; }
        public XElement XElement { get; set; }

        public string Input { set; get; }
        public string Output { set; get; }
        public Tag Parent { set; get; }

        public virtual void apply()
        {
            Output = (Input);
        }

       
    }





    public class ListWatcherTag : Tag
    {
        public string uri { get; set; }
        public string presetName { get; set; }

        public TimeSpan DefaultInterval { set; get; } = TimeSpan.FromMinutes(3);
        public string DefaultAction { set; get; }
        public string PopupWindowTitleFormatter { get; set; } = "$name : $c New Items";
        public string UnreadButtonCaptionFormatter { get; set; } = "$c News";

        private ListParser listParserRef = null;
        public ListParser ListParserRef { get {

                if(listParserRef != null)
                {
                    return listParserRef;
                }
                foreach (var item in this.GetAllDescendants())
                {
                    if (item.GetType() ==  typeof(ListParser)) {
                        listParserRef = (ListParser)item;
                        return listParserRef;
                    }
                }

                Debug.Assert(listParserRef != null, "Mi: ListWarcherTag object couldnt find the ListParser descendant ");
                return null;
            } }

        public ListWatcherTag(XElement XELEM, string input)
        {
            
            Debug.WriteLine("spawning ListWatcherTag");
            Children = new List<Tag>();
            XElement = XELEM;
            // ## validating and parsing attributes ## //
            string maybeDefaultAction = getAttrib("defaultAction");
            if (maybeDefaultAction != null) DefaultAction = maybeDefaultAction;
            string maybeDefaultInterval;
            if (getAttrib("defaultInterval", out maybeDefaultInterval) )
            {
                var maybeDefaultInterval_ = Fucs.TimeSpanFromString(maybeDefaultInterval);
                Trace.Assert(maybeDefaultInterval_!= null, $"Mi defaultInterval attribute value '{maybeDefaultInterval}' is not a valid timeSpan value");
                if (maybeDefaultInterval_.HasValue)
                    DefaultInterval = maybeDefaultInterval_.Value;
            }
            string maybePPWT;
            if (getAttrib("popupWindowTitle", out maybePPWT))
                PopupWindowTitleFormatter = maybePPWT;

            string maybeUBC;
            if (getAttrib("unreadButtonCaption", out maybeUBC))
                UnreadButtonCaptionFormatter = maybeUBC;

            uri = XElement.Attribute("uri")?.Value;
            Trace.Assert(uri !=null, XMLLW.MESSAGES.missingProp("ListWatcher", "uri"));
            presetName = XElement.Attribute("name")?.Value;
            Trace.Assert(uri != null, XMLLW.MESSAGES.missingProp("ListWatcher", "name"));

            Input = input;
            apply();
            base.spawnChildren();

        }

       


    }











    public class wraper: Tag
    {
        string From { get; set; }
        string To { get; set; }
        int Ignore { get; set; }
       
         public wraper(XElement XELEM, Tag parent)
        {
            if(XELEM == null && parent == null)
            {
                return;
            }
            Debug.WriteLine("spawning wraper");
            Children = new List<Tag>();
            XElement = XELEM;
            string from= (string) XElement.Attribute("from").Value;
            string to = (string)XElement.Attribute("to").Value;
            int ignor = int.Parse( XElement.Attribute("ignore").Value);

            From = from;
            To = to;
            Ignore = ignor;

            Parent = parent;
            Input = Parent.Output;
            apply();
           
        }

        

        public override void apply()
        {
            Output = wraper.Wrap(Input, From, To, Ignore);
        }

        public static string Wrap(string input, string from, string to, int ignore)
        {
            Match m = Regex.Match(input, from + ".*?" + to);
            if (m.Success) return m.Value;
            else return "";
        }

    }






    public class Replacer : Tag
    {
        string Pattern { get; set; }
        string Replacement { get; set; }
        string UseConverter { get; set; }

        public Replacer(XElement XELEM, Tag parent)
        {

            Children = new List<Tag>();
            XElement = XELEM;



            var ReplacementAtt = XElement.Attribute("replacement");
            var PatternAtt = XElement.Attribute("pattern");
            var UseConverterAtt = XElement.Attribute("converter");
            Trace.Assert(ReplacementAtt != null, XMLLW.MESSAGES.missingProp("replacer", "pattern"));
            Trace.Assert(ReplacementAtt != null, XMLLW.MESSAGES.missingProp("replacer", "replacement"));
            Replacement = ReplacementAtt.Value;
            Pattern = PatternAtt.Value;
            UseConverter = UseConverterAtt==null? "none" : UseConverterAtt.Value;

            Parent = parent;
            Input = Parent.Output;
            apply();
            base.spawnChildren();


        }

        public override void apply()
        {
            if (UseConverter.ToLower() == "xmldecoder")
            {
                Output = Fucs.decodeXml(Input);
                    
            }
            else
            {
                Output = Regex.Replace(Input, Pattern, Replacement);

            }
        }

       

    }








    public class Matcher : Tag, IMatcher
    {
        string Pattern { get; set; } string Options { get; set; }
        public Match MatcherOutput { set; get; }

        public bool Success{  get{return MatcherOutput.Success;}}

        public GroupCollection Groups {get{return MatcherOutput.Groups;}}

        public string Value{get{return MatcherOutput.Value;}}

        public Matcher(XElement XELEM, Tag parent)
        {
            Debug.WriteLine("spawning matcher");

            Children = new List<Tag>();
            XElement = XELEM;

            Pattern = XElement.Attribute("pattern")?.Value;
            Options = XElement.Attribute("options")?.Value;
            Trace.Assert(Pattern != null, XMLLW.MESSAGES.missingProp("matcher", "pattern"));

            Parent = parent;
            Input = Parent.Output;
            apply();
            base.spawnChildren();
        }

        public static RegexOptions parseOptions(string asStr)
        {
            switch (asStr)
            {
                case "Singleline": return RegexOptions.Singleline;
                default:
                    return RegexOptions.None;
            }
        }
        public override void apply()
        {
            MatcherOutput = Regex.Match(Input, Pattern,parseOptions(Options)  );
            Output = MatcherOutput.Success? MatcherOutput. Value : "";
        }
    }




    public class ListParser : Tag
    {


        private string ItemPattern { get; set; }
        private RegexOptions ItemPatternOptions { get; set; }
        private XElement ItemNode { get; set; }

        public List<ExpandoObject> GetParsedList()
        {
            List<ExpandoObject> outp = new List<ExpandoObject>();
            foreach (var item in Children)
            {
                outp.Add( ((ItemParser)item).makeItemObject());

            }

            return outp;
        }


        public ListParser(XElement XELEM, Tag parent)
        {
            Debug.WriteLine("spawning ListParser");

            Children = new List<Tag>();
            XElement = XELEM;



            Parent = parent;
            Input = Parent.Output;
            apply();

            ItemNode = (XElement) XElement.FirstNode;
            Debug.Assert( (ItemNode!=null) &&(Type(ItemNode) == TagType.Item),"ListParser must have an Item element as fist child");

            ItemPatternOptions = Matcher.parseOptions(ItemNode.Attribute("options")?.Value);
            ItemPattern = ItemNode.Attribute("pattern")?.Value;
            Debug.Assert(ItemPattern != null, "mi: Item must have a pattern attribute");



            spawnItems();
        }

        public override void Refresh(string injectedInput="")
        {
            Input = injectedInput;
            if (string.IsNullOrEmpty(injectedInput))
            {
                Input = Parent.Output;
            }
            apply();
            spawnItems();
            //new code is uneccessary , the new spawned objects will have an up to date data no refreshing needed
            return;
            foreach (var item in Children)
            {
                item.Refresh();
            }
        }

        /// <summary>
        /// should be recalled when data changes
        /// </summary>
        private void spawnItems()
        {
            MatchCollection mc = Regex.Matches(Input, ItemPattern, ItemPatternOptions);
            Children.Clear();
            foreach (Match oneMatch in mc)
            {
                Children.Add(new ItemParser(ItemNode, oneMatch, this));


            }
        }

       
    }




    // for matcher and ItemParser (anthing that accepts the success , group, vale sub tags
    public interface IMatcher
    {
        bool Success { get; }
        GroupCollection Groups { get; }
        string Value { get; }

    }

    public class ItemParser : Tag , IMatcher
    {
        Match RawMatch { get; set; }
        
        public bool Success { get { return RawMatch.Success; } }
        public GroupCollection Groups { get { return RawMatch.Groups; } }
        public  string Value { get { return RawMatch.Value; } }

        public Match MatcherOutput { set; get; }

        
       
        public ExpandoObject makeItemObject()
        {
            dynamic obj = new ExpandoObject();
            IDictionary<String, object> asDict = (IDictionary<string, object>)obj;

            foreach (var item in GetAllDescendants())
            {
                if(item.GetType() ==typeof(TargetProperty))
                {
                    TargetProperty tp = (TargetProperty)  item;
                    asDict.Add(tp.PropertyName, tp.Output);
                    if(tp.UseAs != SpecialProps.none)
                    {
                        asDict.Add(tp.UseAs.ToString(), tp.Output);
                    }
                }
            }
            obj.ldjslk = "lklm";

           


            return obj;
        }
        public ItemParser(XElement XELEM, Match rawMatch, ListParser parent)
        {
            Debug.WriteLine("spawning ItemParser");

            RawMatch = rawMatch;
            Children = new List<Tag>();
            XElement = XELEM;


            Parent = parent;
            Input = RawMatch.Value;
            apply();
            base.spawnChildren();
        }
        public override void apply()
        {
            Output = Value;
        }
    }


    // most messy shit i've ever written
    public class XParserTag : Tag
    {
        /// <summary>
        /// target, usually html, element name, e.g div, span
        /// </summary>
        public string ElementName { set; get; }

        /// <summary>
        /// contains the raw inner string of the node
        /// </summary>
        public string InnerXmlString { get; set; }


        /// <summary>
        /// gets the first element that passes a set of attribute conditions and/or an index condition
        /// the indedx condition usage is as follow x:index="4", meaning the element must ba the 4th among it's siblings 
        /// </summary>
        static XElement GetElement(XElement InputElem, string targetElemName, IEnumerable<XAttribute> requiredAttributes)
        {
            var attribsAslist = requiredAttributes.ToList();
            var attribsASKeyPairs = attribsAslist.ConvertAll<KeyValuePair<string, string>>(new Converter<XAttribute, KeyValuePair<string, string>>((at)=>new KeyValuePair<string, string>( (at.Name.NamespaceName=="xml-parser"?"x:":"" )+ at.Name.LocalName,at.Value)));
            return GetElement(InputElem, targetElemName, attribsASKeyPairs);
        }


        /// <summary>
        /// returns the first child element that have all the required attribs with the requiredd values, 
        /// passing a null string as a required attib value will pass any value
        /// returns null if no match was found
        /// </summary>
        static XElement GetElement(XElement InputElem, string targetElemName, IEnumerable<KeyValuePair<string,string>> requiredAttributes)
        {
             List< XElement> lst =new List<XElement>( InputElem.Elements(targetElemName));
            foreach (var item in lst)
            {
                bool passesAllConditions = true;
                foreach (var requiredAttrib in requiredAttributes)
                {
                    //### case of a special x:index=4 condition
                    if (requiredAttrib.Key == "x:index")
                    {
                        int requiredIndexValue = int.Parse(requiredAttrib.Value);
                        if ( GetIndexOf(InputElem,item) != requiredIndexValue)
                        {
                            passesAllConditions = false;
                            break;
                        }

                        continue;
                    }

                    
                    //## case of a regular attribute=value condition
                    XAttribute att = (item.Attribute(requiredAttrib.Key));
                    if (att == null)
                    {
                        passesAllConditions = false;
                        break; // no need to keep cheking other requested attribs
                    } 
                    if(requiredAttrib.Value != null)
                    {
                        if ((requiredAttrib.Value!="mi:any")&& (att.Value != requiredAttrib.Value))
                        {
                            // break if element does not have the requird attrib at all
                            // break ig it have the required attib but with a different vale that the one required, 
                            // if the required value is null then this will not do the value checking
                            passesAllConditions = false;
                            break; // no need to keep cheking other requested attribs
                        }
                       
                    }
                    
                }
                if (passesAllConditions){ return item;}
                // steps here when the item didsnt pass the tests, 
            }
            // steps here when none of the items if any passed the tests, 
            // returning null
            return null;

        }


        /// <summary>
        /// returns the index of an item whithin a parrent's child elements, or -1 if it doesnt exist among them 
        /// </summary>
        private static int GetIndexOf(XElement parentElem, XElement elem, bool sameLocalName = false)
        {
            if (sameLocalName)
                return parentElem.Elements(elem.Name.LocalName).ToList().IndexOf(elem);
            return parentElem.Elements().ToList().IndexOf(elem);
        }

        public XElement ParsedElement { get; set; }
        public bool Success { set; get; }
        public bool isParentAnXParser
        {
            get
            {
                return Parent.GetType() == typeof(XParserTag);
            }
        }
        public XParserTag(XElement XELEM, Tag parent)
        {

            Parent = parent;
            Input = Parent.Output;

            Debug.Assert(XELEM.Name.NamespaceName == "xml-parser","Mi: the passed xelement does not belong to the 'xml-parser' namespace");
            XElement = XELEM;

            ElementName = XElement.Name.LocalName;
            
            
            Debug.WriteLine("spawning XParserTag");
            
            Children = new List<Tag>();
            XElement = XELEM;



            apply();
            spawnChildren();

        }

        public override void apply()
        {
            if (isParentAnXParser)
            {
                var parentAsXparser = (XParserTag)Parent;
                if (!parentAsXparser.Success)
                {
                    Debug.WriteLine($"XParserTag with elementName name:'{ElementName}' failed because it's XParserTag '{parentAsXparser.ElementName}' parent has failed");
                    Success = false;
                   
                }
                else
                {
                    var parentsParsedElement = ((XParserTag)Parent).ParsedElement;

                    ParsedElement = GetElement(parentsParsedElement, this.ElementName, this.XElement.Attributes());
                    Success = ParsedElement != null;
                    if (Success == false)
                    {
                        Debug.WriteLine($"XParserTag with elementName name:'{ElementName}' failed because GetElement() didnt find any matching element, parent XParserTag is: '{parentAsXparser.ElementName}' ");
                    }
                }
                
            }
            else
            {
                try
                {
                    ParsedElement = XElement.Parse(Input);
                    Success = true;
                    if (ParsedElement == null)
                    {
                        Success = false;
                        Debug.WriteLine($"Mi: XParserTag with name:'{ElementName}' failed because parsing it's input text returnd a null XElement object");
                    }
                    else if (ParsedElement.Name.LocalName != ElementName)
                    {
                        Success = false;
                        Debug.WriteLine($"Mi: XParserTag with name:'{ElementName}' failed because parsing it's input text returnd an XElement with name '{ParsedElement.Name.LocalName}' when the name '{ElementName}' was excpected");
                    }
                   
                }
                catch (Exception)
                {
                    Success = false;
                    Debug.WriteLine($"Mi: XParserTag with name:'{ElementName}' failed to parse it's Input text");
                }
            }
            
            Output = Success ? ParsedElement.ToString() : "";
            InnerXmlString = Success ? ParsedElement.Value : "";
        }

    }


    // can only appear as a XParserTag child
    // supplies children with the parent's InnertXMLSring 
    // if a 'Trim' attribut is present this performes a string.trim() before outputing text
    public class InnerXML : Tag
    {
        public bool EnableTrimming { get; set; }

        public InnerXML(XElement XELEM, Tag parent)
        {
            Trace.Assert(parent.GetType() == typeof(XParserTag), "Mi: InnerXML tag can only appear as a XParser child ");
            Children = new List<Tag>();
            XElement = XELEM;
            Parent = parent;
            EnableTrimming = XElement.Attribute("Trim") != null;

            var parentAsXParser = (XParserTag)parent;
            Input = parentAsXParser.InnerXmlString; // tofo: make this tag do the inner text exctracting operations instead of the XParser, for better debuging

            Debug.WriteLine($"spawning InnerXML, child of a '{parentAsXParser.ElementName}' XParser");


            
            apply();
            base.spawnChildren();

        }

        public override void apply()
        {
            if (EnableTrimming)
                Output = Input.Trim();
            else
                Output = Input;
        }

    }



    // can only appear as a XParserTag child
    // supplies children with the parent's attribute value  
    // if a 'Trim' attribut is present this performes a string.trim() before outputing text
    public class AttributeValue : Tag
    {
        public bool EnableTrimming { get; set; }
        public string AttributeName { get; internal set; }

        public AttributeValue(XElement XELEM, Tag parent)
        {
            Children = new List<Tag>();
            XElement = XELEM;
            Parent = parent;
            Trace.Assert(parent.GetType() == typeof(XParserTag), "Mi: AttributeValue tag can only appear as a XParser child ");

            var parentAsXParser = (XParserTag)parent;
            Input = parent.Output;
            Debug.WriteLine($"spawning AttributeValue, child of a '{parentAsXParser.ElementName}' XParser, target attribute is ");

            Trace.Assert((AttributeName =getAttrib("AttributeName")) != null, XMLLW.MESSAGES.missingProp("AttributeValue", "AttributeName"));
            EnableTrimming = XElement.Attribute("Trim") != null;




            apply();
            base.spawnChildren();

        }

        public override void apply()
        {
            var parentAsXParser = (XParserTag)Parent;
            string outString ;

            if (parentAsXParser.Success)
            {
                XAttribute targetAtt = parentAsXParser.ParsedElement.Attribute(AttributeName);
                if (targetAtt == null)
                {
                    outString = "";
                    Debug.WriteLine($"Mi: AttributeValue tag couldnt find the requested attribute '{AttributeName}'");

                }
                else
                {
                    outString = targetAtt.Value ;

                }
            }
            else /// (!parentAsXParser.Success)
            {
                outString = "";
                Debug.WriteLine($"Mi: AttributeValue tag returned empty string because its XParser '{parentAsXParser.ElementName}' parent has failed ");

            }
            if (EnableTrimming)
                Output = outString.Trim();
            else
                Output = outString;
        }

    }



    public enum SpecialProps
    {
        Title, SubTitle, Link,
        none
    }

    public class TargetProperty : Tag
    {
        public string PropertyName { get; internal set; }
        public string AppendAfter { get; set; }
        public string AppendBefore { get; set; }
        public SpecialProps UseAs { get; set; } = SpecialProps.none;



        public TargetProperty(XElement XELEM, Tag parent)
        {

            Debug.WriteLine("spawning targetProperty");
            Children =null;
            XElement = XELEM;

            PropertyName = XELEM.Attribute("property")?.Value;
            Trace.Assert(PropertyName != null, XMLLW.MESSAGES.missingProp("TargetProperty", "property"));

            AppendBefore = getAttrib("appendBefore");
            AppendAfter = getAttrib("appendAfter" );
            string UseAsStr_ = getAttrib("UseAs");
            if (UseAsStr_ != null)
            {
                UseAsStr_ = UseAsStr_.ToLower();
                switch (UseAsStr_)
                {
                    case "title": UseAs = SpecialProps.Title; break;
                    case "link": UseAs = SpecialProps.Link; break;
                    case "subtitle": UseAs = SpecialProps.SubTitle; break;
                    default: UseAs = SpecialProps.none; break;
                }
            }
           
            

            Parent = parent;
            
            Input = Parent.Output;
            apply();
        }


        public override void apply()
        {
           
            Output = AppendBefore + Input + AppendAfter;
        }

    }



    public class TracerTag : Tag
    {
        public string Message { get; internal set; }

        public override void Refresh(string injectInput = "")
        {
            Input = Parent.Output;
            Debug.WriteLine("tarcer refreshed: " + Message);
            Debug.WriteLine(Input);

        }

        public TracerTag(XElement XELEM, Tag parent)
        {
          
            Children = null;

            XElement = XELEM;
            Message = XELEM.Attribute("message").Value;
            Debug.WriteLine("tarcer: " + Message);
            Parent = parent;
            Input = Parent.Output;
            Debug.WriteLine(Input);

            apply();
        }

    }



    public class ValueTag : Tag
    {
        public string PropertyName { get; internal set; }

        public ValueTag(XElement XELEM, Tag parent)
        {
            Children = new List<Tag>();

            Debug.WriteLine("spawning valueTag");
            Debug.WriteLine(parent.GetType());

            Debug.Assert((parent.GetType() == typeof(Matcher)) || (parent.GetType() == typeof(ItemParser)),"Mi: a Value tag's parent must be either a Matcher or an Item");

            XElement = XELEM;
            Parent = parent;
            Input = ((IMatcher) Parent).Value;
            apply();
            base.spawnChildren();

        }

    }








    public class GroupTag : Tag
    {

        public int Index { get; internal set; }

        public GroupTag(XElement XELEM, Tag parent)
        {
            Debug.WriteLine("spawning GroupTag");
            Children = new List<Tag>();

            Debug.Assert((parent.GetType() == typeof(ItemParser)) || (parent.GetType() == typeof(Matcher)), "Mi: a Group tag's parent must be either a Matcher or an Item");

            XElement = XELEM;
            Index = int.Parse(XElement.Attribute("index").Value);
            Debug.WriteLine("GroupTag's index is:" + Index.ToString());
            //<td><a href=\"2019-03-26-08-33-33_58f37f00f409b98b8eda58634d6dbeadeec0340f\">2019-03-26-08-33-33_..&gt;</a></td><td align=\"right\">2019-03-26 09:33  </td><td align=\"right\">713K</td><td>&nbsp;</td></tr>\r
            //<a href=\"((.*)(\\..{3,5}))\">
            Parent = parent;
            Debug.Assert(((IMatcher)Parent).Groups.Count > Index, "mi: a Group tag is pointing to an out of range index");
            Input = ((IMatcher)Parent).Groups[Index].Value;
            apply();
            base.spawnChildren();

        }

    }




}









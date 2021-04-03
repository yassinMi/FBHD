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
using System.Security.Policy;

namespace fbhd
{





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



    public class EmptyTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool reversed = false;
            if (parameter != null)
                reversed = (bool)parameter;

            bool evaluated;
            evaluated = ((string.IsNullOrEmpty((string)value)) ? true : false);
            if (reversed) evaluated = !evaluated;
            if (targetType == typeof(Visibility))
                return (evaluated ? Visibility.Visible : Visibility.Hidden);
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
    /// usage: passing the string "0:yassin 1:miracles" as param will return "yassin" on false and "miracles" on true
    /// </summary>
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

            return val ? true_str : false_str;



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
        public static string FFMPEG_PATH = "C:\\TOOLS\\fbhd-gui\\ffmpeg\\ffmpeg.exe";
        public static MainWindow mw = (MainWindow)Application.Current.MainWindow;
        internal static string HTML_CONTAINER_PATH = "C:\\TOOLS\\fbhd-gui\\html";
        internal const string MAIN_PATH = "C:\\TOOLS\\fbhd-gui";



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

        public static void Verbose(string VerboseStatus)
        {

            mw.Dispatcher.Invoke(() =>
            {
                mw.verboseStatus = VerboseStatus;
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

        public static string MakeArgs(Post post, TaskType type, TaskProperties taskProperties)
        {

            // taskProperties.resolutionSettings.UserPicked = new Resolution(855);


            //  MessageBox.Show(taskProperties.resolutionSettings.getResult().serialized);
            //MessageBox.Show(taskProperties.titleSettings.getResult());


            string resolutionstr = taskProperties.resolutionSettings.getResult().serialized;
            // MessageBox.Show("ljl");

            string
                videoStream = post.QualityLabels.Find((Q) =>
                (Q.qualityName ==
                (resolutionstr))
                ).videoUrl,


                audioStram = post.audioUrl,

                title = Fucs.filenamify(taskProperties.titleSettings.getResult()),

                metatitle = "",
                output = title,
                thumb = post.Images.First().Value,
                extension;

            string args;
            if (hasVideo(type))
            {
                extension = $".{getExtention(type)}";
                FFMPEG.Args mp4args = new FFMPEG.Args(100);

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
                    .add(Fucs.qoute(title + extension))
                    .add("-y")

                    ;
                args = mp4args.toString;
                // MessageBox.Show(args);

            }
            else
            {
                extension = ".mp3";
                args = "  -v 32 -hide_banner -vn -i " + Fucs.qoute(audioStram) +
                    " -an -i " + Fucs.qoute(thumb) + " -map 0 -map 1 -c:v:0 mjpeg -disposition:v:0 attached_pic -metadata title=\"" +
                   metatitle + "\"  -metadata:s:v \"comment='Cover (front)'\" -metadata:s:v \"title='Cover (front)'\"  \"" +
                   title + extension + "\" -y";


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
    }



    public struct ResolutionSettings
    {
        public enum FallBackBehaviour
        {
            GoHigher, GoLower, Closest
        }

        public Resolution UserPicked
        {
            get { return userPickedResolution; }
            set { userPickedResolution = value; }
        }
        private Resolution userPickedResolution;
        private List<Resolution> available;
        public List<Resolution> Available
        {
            get { return available; }
            set { available = value; }
        }
        public bool isChoiceStandard;
        public bool isChoiceTargeted;
        public FallBackBehaviour fallBackBehaviour;

        internal Resolution getResult()
        {
            // MessageBox.Show("het");
            if (userPickedResolution == null)
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





        public static async Task<int> run_ffmpeg_task(string ffmpegArgs, Action<FFMPEG.FFMPEGProgress> onProgress, FBHDTask parent_task_object)
        {
            StringBuilder builder = new StringBuilder();
            Process process = constructProcess(MI.FFMPEG_PATH, ffmpegArgs);
            parent_task_object.ffmpeg_process_ref = process;

            TimeSpan totalDuration = new TimeSpan(0, 0, 50);

            DataReceivedEventHandler hndl = ((sender, args) =>
            {
                if (args.Data == null)
                    return;
                builder.AppendLine(args.Data);

                TimeSpan? maybeTotalDuration = FFMPEG.parseDuration(args.Data);
                if (maybeTotalDuration != null)
                {
                    totalDuration = (TimeSpan)maybeTotalDuration;
                }
                FFMPEG.FFMPEGProgress prog = FFMPEG.FFMPEGProgress.FromStdoutLine(args.Data, totalDuration);
                if (!prog.isNull)
                {
                    onProgress(prog);
                }
            });
            process.OutputDataReceived += hndl;
            process.ErrorDataReceived += hndl;
            MI.Verbose("starting ffmpeg..");

            await Task.Run(new Action(() =>
           {
               process.Start();
               process.BeginErrorReadLine();
               process.BeginOutputReadLine();
           }), new System.Threading.CancellationToken());
            // System.Threading.CancellationToken v = new System.Threading.CancellationToken();
            // v.
            MI.Verbose("ffmpeg.exe is runing");
            await Task.Run(new Action(() =>
            {
                process.WaitForExit();
            }));
            //await Task.Delay(30000);
            MI.Verbose(null);
            if ((process.ExitCode != 0) && (process.ExitCode != 255))
            {
                string error = builder.ToString();
                MessageBox.Show(error.Substring(Math.Max(0, error.Length - 700)));
            }
            return process.ExitCode;// process.ExitCode; //because dummy 
        }





        /// <summary>
        /// runs the python fetching and resolving script and gets back the raw serialize
        /// result from it's stdout and created the appropriate post object
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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






        /// <summary>
        /// runs the python fetching script and gets back the raw html content from its
        /// output file 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> run_py_fetcher(Uri url)
        {

            StringBuilder html_content = new StringBuilder();
            string outputFile = url.AbsoluteUri.GetHashCode() + ".html";
            string python_args = ".\\scripts\\fetch-python.py " + url.AbsoluteUri + " .\\html\\" + outputFile;
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
                return File.ReadAllText("C:\\TOOLS\\fbhd-gui\\html\\" + outputFile);

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
            py_server = Fucs.constructProcess("python.exe", ".\\scripts\\server-python.py");
        }

        public bool IsListening { get; set; } = false;

        public event EventHandler<string> onRequest;

        public event EventHandler<string> onServingStarted;


        public void Start()
        {

            DataReceivedEventHandler hndl = ((sender, args) =>
            {
                if (args.Data == null)
                    return;

                if (args.Data.Contains("serving at port"))
                {
                    if (onServingStarted != null)
                    {
                        // MessageBox.Show("fireing startted");
                        onServingStarted(this, args.Data);
                        IsListening = true;
                    }
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

                if (onRequest != null)
                {
                    onRequest(this, args.Data);
                }
            });
            py_server.OutputDataReceived += hndl;
            py_server.ErrorDataReceived += hndl;
            Task.Run(() =>
            {
                py_server.Start();
                py_server.BeginErrorReadLine();
                py_server.BeginOutputReadLine();

            });
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
        public abstract string makeArgs(string url, Headers headers, string outputFile);
        public abstract bool success(int exitCode);



        /// <summary>
        /// get text using a temp html file
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="saveAs">assigning this will cause the temp html to be saved under a custome name, and kept safe after the task completes</param>
        /// <returns>returns string on success, null on failure</returns>
        public async Task<string> GetText(string url, Headers headers =null, string saveAs=null)
        {
            bool shouldKeepFile = !(saveAs == null);
            string output = "";
            string tempHTMLFile = shouldKeepFile?saveAs: "temp,"+ DateTime.Now.GetHashCode().ToString();
            string args = makeArgs(url, headers, tempHTMLFile );
            Process webClientProcess = Fucs.constructProcess(ProcessFileName, args);
            StringBuilder cachedStdout = new StringBuilder();
            webClientProcess.OutputDataReceived += (s, e) => { cachedStdout.Append(e.Data); };
            webClientProcess.StartInfo.WorkingDirectory = "C:\\TOOLS\\fbhd-gui\\html\\";
            /// ## RUNNING ##
            MI.Verbose($"starting {ProcessFileName}..");
            await Task.Run(new Action(() =>
            {
                webClientProcess.Start();
                webClientProcess.BeginErrorReadLine();
                webClientProcess.BeginOutputReadLine();
            }));
            MI.Verbose($"{ProcessFileName} is runing");
            await Task.Run(new Action(() =>
            {
                webClientProcess.WaitForExit();
            }));
            MI.Verbose(null);


            /// ## READING FROM FILE ##

            if (success(webClientProcess.ExitCode ))
            {
                output = File.ReadAllText("C:\\TOOLS\\fbhd-gui\\html\\"+tempHTMLFile);
               if(!shouldKeepFile) File.Delete("C:\\TOOLS\\fbhd-gui\\html\\"+tempHTMLFile)  ;
                return output;
            }
            else
            {
                return null;
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
            MI.Verbose($"starting {ProcessFileName}..");
            await Task.Run(new Action(() =>
            {
                webClientProcess.Start();
                webClientProcess.BeginErrorReadLine();
                webClientProcess.BeginOutputReadLine();
            }));
            MI.Verbose($"{ProcessFileName} is runing");
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

            public override string ProcessFileName { get { return "curl.exe"; } }
            public static async Task<string> GetTextStatic(string url, Headers headers)
            {
                return await new cURL().GetText(url, headers);
            }
            
            

            public override string makeArgs(string url, Headers headers, string outputFile)
            {
                string args = "";

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
                MessageBox.Show("failed to parse an element,\nraw content dumped at log.failedtoparse.txt");
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
                    return new System.Windows.Media.Imaging.BitmapImage(new Uri("file:///C:/TOOLS/fbhd-gui/fbhd/fbhd/video-48-white.png"));//
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
            get { return Manipulate( bufferedResults,Presenter); }
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

                new SearchElement() { Title="SearchEllement object too but with super long title to test the elipsis behavior",
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


        //dummy
        // performs the search and updates the results property on successfull
        //operation or rises the OnSearchFaild even otherwise
        public async void StartSearch (bool addToBuffer)
        {
            IsSearching = true;
            // await Task.Delay(1500);
            Uri queryUrl = new Uri( "https://web.facebook.com/watch/search/?query="+Query);

            string rawHTML = await WebClient.cURL.GetTextStatic(queryUrl.AbsoluteUri, Headers.DefaultFbWatchHeaders);
            IsSearching = false;
            if(query.Contains("dummy"))
            {
                 Results = generateDummyList();

            }
            else
            {
                Results = new BindingList<SearchElement>(ExperimentalSearchResultsParser.Parse(rawHTML));

            }
            notif(nameof(Results));
            if (addToBuffer)
            {
                foreach (var item in results)
                {
                    bufferedResults.Add(item);

                }
                notif(nameof(BufferedResuls));
            }
            

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


    public class Session : INotifyPropertyChanged 
    {


        public Session()
        {
            MainSearch = new Search();
        }


        private FBHDTask selectedTask;
        private BindingList<FBHDTask> tasks = new BindingList<FBHDTask>();
        private string globalOutputFolder = "c`:\\tools\\fbhd-gui\\";
        private int runningFfmpegCount = 0;
        private bool isServerRunning = false;
        private int failedCount = 0;
        private int runningPy_fetcherCount = 0;





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


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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


}









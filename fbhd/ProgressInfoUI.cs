using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading.Tasks;


using System.Windows;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace fbhd
{


    /// <summary>
    /// usage: bind the Progress property to a notifying source and that's it, this will render a textBlock with the currentely selected property 
    /// templating need one PART_TEXTBLOCK , and it doesnt need any bindings as this object will update it's Text every time the Progress or CurrentShowedProp changes
    /// all state is internal i didnt see any need to make the CurrentShowedProperty property accessible externaly,
    /// </summary>
    class ProgressInfoUI : Control, INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void notif(string propName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            mainTextBlock = (TextBlock) GetTemplateChild("PART_TEXTBLOCK");
            if(mainTextBlock != null)
            {
                mainTextBlock.MouseLeftButtonDown += onClick;
                mainTextBlock.MouseRightButtonDown += onClickRight;
                
            }
        }

        private void onClick(object sender, MouseButtonEventArgs e)
        {
            shiftShowedProperty();
        }
        private void onClickRight(object sender, MouseButtonEventArgs e)
        {
            shiftShowedProperty(true);
        }

        private void shiftShowedProperty(bool toRight = false)
        {
            if (toRight)
            {
                if (CurrentShowedProperty == ProgressProperties.time) CurrentShowedProperty = ProgressProperties.fps;
                else
                {
                    CurrentShowedProperty--;

                }
            }
            else
            {
                CurrentShowedProperty =(ProgressProperties)( ( ((int)CurrentShowedProperty) + 1) %6 );


            }

        }


        private enum ProgressProperties
        {
            time = 0,
            percent = 1,
            size = 2,
            bitrate = 3,
            frame = 4,
            fps = 5,
        }

        private ProgressProperties currentShowedProperty = ProgressProperties.time;
        private ProgressProperties CurrentShowedProperty
        {
            get { return currentShowedProperty; }
            set { currentShowedProperty = value;
                updateText(RenderedText);
            }
        }


        private void updateText (string text)
        {
            if (mainTextBlock != null)
            {
                mainTextBlock.Text =   text ;
            }
        }

        public string RenderedText
        {

           
            
            get {
                switch (CurrentShowedProperty)
                {
                    case ProgressProperties.time:
                        return  Progress.Time;
                    case ProgressProperties.percent:
                        return Math.Round( Progress.Percent*100,2).ToString()+"%";
                    case ProgressProperties.size:
                        return  "Size: "+ Progress.Size.ToString();
                    case ProgressProperties.bitrate:
                        return "Bitrate: " + Progress.Bitrate;
                    case ProgressProperties.frame:
                        return "Frame: " + Progress.Frame.ToString();
                    case ProgressProperties.fps:
                        return "FPS: " + Progress.Fps.ToString();
                    default:
                        return Progress.Time;
                }

            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.Property == ProgressProperty)
            {
                //MessageBox.Show("ipdated");
                updateText(RenderedText);
            }
            
        }


        public FFMPEG.FFMPEGProgress Progress
        {
            get { return (FFMPEG.FFMPEGProgress)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Progress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(FFMPEG.FFMPEGProgress), typeof(ProgressInfoUI), new PropertyMetadata(null));



        public TextBlock mainTextBlock { get; set; }
        

    }
}

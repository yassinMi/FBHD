using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace fbhd
{


    public class ButtonWithIcon : Button, INotifyPropertyChanged
    {

        public override void BeginInit()
        {
            base.BeginInit();

        }
        public event PropertyChangedEventHandler PropertyChanged;





        public ImageSource IconHover
        {
            get { return
                    (ImageSource)GetValue(IconHoverProperty) == null ? (ImageSource)GetValue(IconProperty) : (ImageSource)GetValue(IconHoverProperty);
            }
            set { SetValue(IconHoverProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconHover.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconHoverProperty =
            DependencyProperty.Register("IconHover", typeof(ImageSource), typeof(ButtonWithIcon), new PropertyMetadata(null));





        public ImageSource IconPressed
        {
            get { return
                    
                    (ImageSource)GetValue(IconPressedProperty) == null? (ImageSource)GetValue(IconProperty): (ImageSource)GetValue(IconPressedProperty); }
            set { SetValue(IconPressedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconPressed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPressedProperty =
            DependencyProperty.Register("IconPressed", typeof(ImageSource), typeof(ButtonWithIcon), new PropertyMetadata(null));






        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(ButtonWithIcon), new PropertyMetadata(null));


    }


    class MediaTypeSwitchControl : Control, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.Property == ValueProperty)
            {
                
                if ((  MediaType) e.NewValue== MediaType.Audio)
                {
                    MainButton.Icon = IconAudio;
                }
                if ((MediaType)e.NewValue == MediaType.Video)
                {
                    MainButton.Icon = IconVideo;
                }
                if ((MediaType)e.NewValue == MediaType.Image)
                {
                    MainButton.Icon = IconImage;
                }
                
            }
        }


        /// <summary>
        /// Fired when the user clicks the Switch, this doesnt cause the Value to change, 
        /// you should emutate that using this event, and the shift methide that this class provides
        /// the arg specifies the shift direction: 1 if its a right shift, and 2 if left
        /// </summary>
        public event EventHandler<int> Shifted;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


             MainButton = (ButtonWithIcon) GetTemplateChild("PART_BUTTON");
            if (MainButton != null)
            {
                MainButton.Click += onButtonClicked;
                MainButton.MouseRightButtonDown += onButtonRightClicked;
            }
        }




        public ButtonWithIcon MainButton
        {
            get { return (ButtonWithIcon)GetValue(MainButtonProperty); }
            set { SetValue(MainButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MainButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainButtonProperty =
            DependencyProperty.Register("MainButton", typeof(ButtonWithIcon), typeof(MediaTypeSwitchControl), new PropertyMetadata(null));




        public void onButtonClicked(object sender, RoutedEventArgs args)
        {
            if (Shifted != null)
            {
                Shifted(this, 1);
            }
           
        }
        public void onButtonRightClicked(object sender, MouseButtonEventArgs e)
        {
            if (Shifted != null)
            {
                Shifted(this, 2);
            }
        }



        public MediaType shiftValue(  bool right = false)
        {
            if (right)
            {
                
                if (Value == 0) return  (MediaType) 2;
                else
                {
                    return (MediaType) Value - 1;
                }
                

            }

            return  (MediaType) (((int)Value + 1 )% 3);

           

        }

        public ImageSource IconVideo
        {
            get { return (ImageSource)GetValue(IconVideoProperty); }
            set { SetValue(IconVideoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconVideo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconVideoProperty =
            DependencyProperty.Register("IconVideo", typeof(ImageSource), typeof(MediaTypeSwitchControl), new PropertyMetadata(null));


        public ImageSource IconAudio
        {
            get { return (ImageSource)GetValue(IconAudioProperty); }
            set { SetValue(IconAudioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconAudio.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconAudioProperty =
            DependencyProperty.Register("IconAudio", typeof(ImageSource), typeof(MediaTypeSwitchControl), new PropertyMetadata(null));


        public ImageSource IconImage
        {
            get { return (ImageSource)GetValue(IconImageProperty); }
            set { SetValue(IconImageProperty, value
                
               

                ); }
        }

        // Using a DependencyProperty as the backing store for IconImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconImageProperty =
            DependencyProperty.Register("IconImage", typeof(ImageSource), typeof(MediaTypeSwitchControl), new PropertyMetadata(null));




        public MediaType Value
        {
            get { return (MediaType)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value);

               /* if ((MediaType)value == MediaType.Audio)
                {
                    MainButton.Icon = IconAudio;
                }
                else if ((MediaType)value == MediaType.Video)
                {
                    MainButton.Icon = IconVideo;
                }
                else if ((MediaType)value == MediaType.Image)
                {
                    MainButton.Icon = IconImage;
                }
                // MessageBox.Show("calye " + value);
                */


            }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(MediaType), typeof(MediaTypeSwitchControl), new PropertyMetadata(MediaType.Audio));



    }
}

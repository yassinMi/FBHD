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

    public class RadioWithIcon : RadioButton
    {





        public Brush CheckedBackground
        {
            get { return (Brush)GetValue(CheckedBackgroundProperty); }
            set { SetValue(CheckedBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckedBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(RadioWithIcon), new PropertyMetadata(new SolidColorBrush(Colors.AliceBlue)));




        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(RadioWithIcon), new PropertyMetadata(null));




    }



    [TemplatePart(Name = "PART_ARG1", Type = typeof(TextBox))]
    public class FilterControl : Control, System.ComponentModel.INotifyPropertyChanged
    {


        public override void BeginInit()
        {
            base.BeginInit();

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Arg1 = GetTemplateChild("PART_ARG1") as TextBox;
            if (Arg1 != null)
            {
                Arg1.TextChanged += new TextChangedEventHandler(onArgChanged);
            }
            Arg2 = GetTemplateChild("PART_ARG2") as TextBox;
            if (Arg2 != null)
            {
                Arg2.TextChanged += new TextChangedEventHandler(onArgChanged);
            }

            Image img = GetTemplateChild("PART_IMAGE_DROP") as Image;
            if (img != null)
            {

            }

            Popup popup = GetTemplateChild("PART_POPUP") as Popup;
            if (popup != null)
            {
                mainPopup = popup;
                mainPopup.Closed += (s, a) => { mainPopup.Tag = "closed"; };
                mainPopup.Opened += (s, a) => { mainPopup.Tag = "opened"; };
            }

            maingGrid = GetTemplateChild("PART_MAIN_GRID") as Grid;
            if (maingGrid != null)
            {

                maingGrid.MouseLeftButtonDown += new MouseButtonEventHandler(onClicked);
            }
            DropButton = GetTemplateChild("PART_DROP_BUTTON") as Button;
            if (DropButton != null)
            {

                DropButton.Click += new RoutedEventHandler(onButtonClicked);
            }

            ButtonMi deleteButton = GetTemplateChild("PART_DELETE") as ButtonMi;
            if (deleteButton != null)
            {
                deleteButton.textcaption = "Delete";
                deleteButton.iconSource = DeleteIcon;
                deleteButton.Click += (s, a) =>
                {
                    if (this.Deleted != null)
                    {
                        this.Deleted(this, new EventArgs());
                    }
                };

            }

        }

        public Popup mainPopup { get; set; }
        public TextBox Arg1 { get; set; }
        public TextBox Arg2 { get; set; }
        public Grid maingGrid { get; set; }
        public Button DropButton { get; set; }


        public event EventHandler Deleted;
        public event EventHandler Clicked;
        public event EventHandler<object> FilterValueChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        void onClicked(object sender, MouseButtonEventArgs e)
        {
            this.IsActivated = !IsActivated;
        }



        void onArgChanged(object sender, TextChangedEventArgs e)
        {
            object oldValue = FilterValue;
            FilterValue = mainValueMaker(Arg1?.Text, Arg2?.Text);
            if (FilterValueChanged != null)
            {
                if (FilterValue!=oldValue)
                FilterValueChanged(this, FilterValue);
            }

        }

        void onButtonClicked(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (mainPopup != null)
            {

                if ((string)mainPopup.Tag == "opened")
                {
                    mainPopup.IsOpen = false;
                }
                else
                {
                    mainPopup.IsOpen = true;
                    Arg1.Focus();
                }


            }
        }




        public bool IsActivated
        {
            get
            {
                return (bool)GetValue(IsActivatedProperty);
            }
            set { SetValue(IsActivatedProperty, value); }
        }




        // Using a DependencyProperty as the backing store for IsActivated.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsActivatedProperty =
            DependencyProperty.Register("IsActivated", typeof(bool), typeof(FilterControl), new PropertyMetadata(true));





        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(FilterControl), new PropertyMetadata(null));



        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(FilterControl), new PropertyMetadata(null));




        public ImageSource DeleteIcon
        {
            get { return (ImageSource)GetValue(DeleteIconProperty); }
            set { SetValue(DeleteIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteIconProperty =
            DependencyProperty.Register("DeleteIcon", typeof(ImageSource), typeof(FilterControl), new PropertyMetadata(null));





        public delegate object ValueMaker(string arg1, string arg2);


        public ValueMaker mainValueMaker { get; set; } = (o, z2) => null;



        private void notif(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public object FilterValue
        {
            get { return (object)GetValue(FilterValueProperty); }
            set
            {
                SetValue(FilterValueProperty, value);
                notif(nameof(FilterValue));

            }
        }



        // Using a DependencyProperty as the backing store for FilterValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterValueProperty =
            DependencyProperty.Register("FilterValue", typeof(object), typeof(FilterControl), new PropertyMetadata("none"));











    }







}

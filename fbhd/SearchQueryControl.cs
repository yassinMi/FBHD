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

namespace fbhd
{
    class SearchQueryControl : Control, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<string> onGo;

        public event EventHandler<bool> onIsEmptyChanged;


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            textBox =(TextBox) GetTemplateChild("PART_TEXTBOX");
            if (textBox != null)
            {
                textBox.AcceptsReturn = false;
                textBox.KeyUp += (s, e) => {
                   if( e.Key == System.Windows.Input.Key.Enter)
                    {
                        if(onGo!=null)
                        onGo(this, textBox.Text);
                    }
                };
                textBox.TextChanged += (s, e) => {

                    notif(nameof(ShouldShowPlaceHolder));
                    notif(nameof(ShouldShowResetButton));
                    IsEmpty = string.IsNullOrEmpty(textBox.Text);

                };
            }
            GoButton = (ButtonMi) GetTemplateChild("PART_GO_BUTTON");
            if (GoButton != null)
            {
                GoButton.Click += (e, s) =>
                {
                    if (onGo != null)
                        onGo(this, textBox.Text);
                };
            }
            ResetButton = (ButtonMi)GetTemplateChild("PART_RESET_BUTTON");
            if (ResetButton != null)
            {
                ResetButton.Click += (e, s) =>
                {
                    Reset();
                };
            }
        }





        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyProperty, value);
                if (onIsEmptyChanged != null)
                {
                    onIsEmptyChanged(this, value);
                }
            }
        }

        // Using a DependencyProperty as the backing store for IsEmpty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEmptyProperty =
            DependencyProperty.Register("IsEmpty", typeof(bool), typeof(SearchQueryControl), new PropertyMetadata(true));




        private ButtonMi GoButton {get; set;}
        private TextBox textBox { get; set; }


        private bool shouldShowPlaceHolder;
        public bool ShouldShowPlaceHolder
        {
            set { shouldShowPlaceHolder = value;
                notif(nameof(ShouldShowPlaceHolder)); }
            get { return  string.IsNullOrWhiteSpace( textBox.Text); }
        }

        public bool ShouldShowResetButton
        {
            set
            {
                notif(nameof(ShouldShowPlaceHolder));
            }
            get { return !string.IsNullOrWhiteSpace(textBox.Text); }
        }

        public ButtonMi ResetButton { get; private set; }

        private void Reset()
        {
            textBox.Text = "";
        }

        private void notif(string propName)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propName));

                //MessageBox.Show("a listener to "+ propName);

            }
        }

    }
}

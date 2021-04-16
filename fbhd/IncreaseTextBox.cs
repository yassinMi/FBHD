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
    public class IncreaseTextBox : TextBox, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public delegate string IncreaseModifier(string value, bool increase);


        public event RoutedEventHandler OnIncrease;
        public event RoutedEventHandler OnDecrease;


        public IncreaseModifier IncreaseFunction
        {
            get { return (IncreaseModifier)GetValue(IncreaseFunctionProperty); }
            set { SetValue(IncreaseFunctionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IncreaseFunction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IncreaseFunctionProperty =
            DependencyProperty.Register("IncreaseFunction", typeof(IncreaseModifier), typeof(IncreaseTextBox), new PropertyMetadata(new IncreaseModifier((s,inc) =>  (int.Parse(s) + (inc ? 1 : -1)).ToString() )));


        public string DefaultInt(string s, bool inc )
        {
            try
            {
                return (int.Parse(s) + (inc ? 1 : -1)).ToString();

            }
            catch (Exception)
            {

                return s;
            }
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            IncreaseButton = GetTemplateChild("PART_INCREASE") as RepeatButton;
            if (IncreaseButton!= null)
            {
                IncreaseButton.Click += onIncreaseClick;
            }
            IncreaseButton = GetTemplateChild("PART_DECREASE") as RepeatButton;
            if (IncreaseButton != null)
            {
                IncreaseButton.Click += onDecreaseClick;
            }
        }


        public RepeatButton IncreaseButton { get; set; }
        public RepeatButton DecreaseButton { get; set; }



        private void onIncreaseClick(object sender, RoutedEventArgs e)
        {
            OnIncrease?.Invoke(this, new RoutedEventArgs());
            if (IncreaseFunction == null) return;
            Text = IncreaseFunction(Text, true);
        }


        private void onDecreaseClick(object sender, RoutedEventArgs e)
        {
            OnDecrease?.Invoke(this, new RoutedEventArgs());

            if (IncreaseFunction == null) return;
            Text = IncreaseFunction(Text, false);
        }









        public bool CanIncrease
        {
            get { return (bool)GetValue(CanIncreaseProperty); }
            set { SetValue(CanIncreaseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanIncrease.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanIncreaseProperty =
            DependencyProperty.Register("CanIncrease", typeof(bool), typeof(IncreaseTextBox), new PropertyMetadata(true));



        public bool CanDecrease
        {
            get { return (bool)GetValue(CanDecreaseProperty); }
            set { SetValue(CanDecreaseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanDecrease.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanDecreaseProperty =
            DependencyProperty.Register("CanDecrease", typeof(bool), typeof(IncreaseTextBox), new PropertyMetadata(true));






        private void notif(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      

       
    }
}

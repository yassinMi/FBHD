   M S B A M L   `   `   `  ����?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  5          fbhd.ButtonMi   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:fbhd     5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   5      -   5          >�Name$  userControl��5   N    � UseLayoutRounding . $
��Left=�5	   ;   $	��Top=�6V   $��42.525��6n    � 	Resources 5
         121 �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value ��Name J� Opacity �� RelativeSource �� AncestorType   fbhd.ButtonMi  buttmicorebutt��%�  &	        &	 �    �� 5   
   " ��6&   .R�5      � $
 grid��6   $��16��6!   $��16��6,   ���	#00040405 5        5      CommonStates��. 5        
Normal��6&     5      	MouseOver��. 5      �� .��5   "   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6?   $
	 grid��6�   .g�5   &     $
 0��6:   $ 	#00333333��6F   5   #   U� 5   "   $ (UIElement.Opacity)�6@   $	 image��6p   .\�5   &     $ 0��6;   $ 1Q�6G   5   #   5      5        5      Pressed��6&     5      Disabled��6&   5      .+�5      �� $ image��6   $��Hidden=�6�   $
��None=�6�   }�. $
 0.75Q�6�   ��6'   �� *
iconSource+ �� *FindAncestor+"  6�   5       5!      �� 5"   
   " ��61   .R�5#      � $
 grid��6   $��16��6!   $��16��6,   ���	#00040405 5$        5%      CommonStates��. 5&        
Normal��. 5'      �� .��5(   "   U� $ (UIElement.Opacity)�6@   $	 image��6p   .\�5)   &     $ 0��6;   $ 1Q�6G   5*   #   5+      5,        5-      	MouseOver��. 5.      �� .��5/   "   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6?   $
	 grid��6�   .g�50   &     $
 0��6:   $ 	#00333333��6F   51   #   U� 52   "   $ (UIElement.Opacity)�6@   $	 image��6p   .\�53   &     $ 0��6;   $ 1Q�6G   54   #   55      56        57      Pressed��6&     58      Disabled��6&   59      .+�5;      �� $ image��6   $��Hidden=�6�   $
��None=�6�   }�. $
 0.75Q�6�   ��6'   �� *
iconSource+ �� *FindAncestor+"  6�   5<      5=      5>      .��5?      � $
��Left=�6   $	��Top=�6&   ���	#00000000 J� Effect 5@   
   4  .Microsoft.Expression.Media.Effects.BloomEffect  5A      -   5        bloo��   BloomIntensity$ 1Q�5A   .      BaseSaturation$ 1Q�6A      BaseIntensity$ 0Q�6T      BloomSaturation$ 1Q�6f      	Threshold$ 0Q�6z    5C   
     5D      -   5        VisualStateGroup��. 5E        -   5        	Hover��. 5F      �� .��5G      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�67   $	 caption��6�   .g�5H        $
 0��62   $ White��6>   5I      U� 5J      $ (UIElement.Opacity)�68   $	 caption��6h   .\�5K        $ 0��63   $ 1Q�6?   5L      U� 5M      $ (UIElement.Opacity)�68   $	 
coreButton��6h   .\�5N        $ 0��63   $ 1Q�6?   5O      5P      5Q        5R      -   5        
Normal��. 5S      �� .��5T      U� $ (UIElement.Opacity)�68   $	 caption��6h   .\�5U        $ 0��63   $ 1Q�6?   5V      5W      5X        5Y      -   5        Pressed��. 5Z      �� .��5[      U� $ (UIElement.Opacity)�68   $	 caption��6h   .\�5\        $ 0��63   $ 1Q�6?   5]      5^      5_        5`      -   5        disabled��. 5b      �� .��5d      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�67   $	 caption��6�   .g�5e        $
 0��62   $ 	#FF656565��6>   5f      U� 5g      $ BloomSaturation�68   $
	 bloo��6d   .\�5h        $ 0��63   $ 0Q�6?   5i      U� 5j      $ Opacity�68   $	 
coreButton��6\   .\�5k        $ 0��63   $	 0.4Q�6?   5l      5m      5n      5o      .+�5q   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6I   $	��Top=�6d   .+�5r      �� -   5         ��Name$ 
coreButton��5r      $��Button��6)   #���  6:   ���	#FF040405���	#FF7DCD79$��0q�6�    J� SnapsToDevicePixels . 
 � Tag$	 mp3��6�   $
��Left=�6�   $��Center=�6�   $
 0.75Q�6  �� 5s      -	   5         ��Name$ caption��5s      $
��Wrap=�6)   ���	#FFD5D5D5&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�66  ��6=   �� *textcaption+ �� ElementName$ userControl����6�   �� *captionMargin+$ userControl��y�6�   �� *captionVisibility+$ userControl��66  5u      5w      5x      
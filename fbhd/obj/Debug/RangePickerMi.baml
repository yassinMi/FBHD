   M S B A M L   `   `   `  ����?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  5          fbhd.RangePickerMi   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:fbhd     5      -   5          >�Name$  userControl��5       � UseLayoutRounding . $��32��5   L    J� SnapsToDevicePixels .  � 	Resources 5      '   !fbhd.RangePickerPercentToPosition    RangePickerPercentToPosition  ThumbMiHandleStyle �� 
TargetType �� Property �� Value �� 
TargetType F�Name	 �� Stretch
 J� 	AllowDrop �� Triggers P� Property P� Value  minHandleFocus �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value  minHandleUnfocus  maxHandleFocus  maxHandleUnfocus  innerBorderFocus  innerBorderUnfocus  Storyboard1��%�  &	        &	      &	     &	 �    &	 z    &	 0    &	 �    &	 �    &	 X      5	   
   6-   �� 5
   
   " n�6B   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       � �� 5      �� 5      " n�6&   .R�5      � .+�5      F� $ Handle��6$   -   5        H�������V�Q,�&^k�SUUU@Q,�&^k�SUOX@Q�^k�SUOX@Q�^k�SUUU@	$
	 Fill=�5   �   #��z��6�    .  $��12��6�   $��16��6�   #��z��6�   
 . 6&  5       5      P� 5       �@J�IsMouseOver . 5      P� 5       � {� .  5      5      5      5      �� 5   
   .��5      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ ThumbMin��6t   .g�5         $ 0:0:0.1��6&   $ 	#FF26B08A��68   5!      5"      �� 5#   
   .��5$      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ ThumbMin��6t   .g�5%        $ 0:0:0.2��6&   $ 	#FF4C4F4F��68   5&      5'      �� 5(   
   .��5)      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ ThumbMax��6t   .g�5*        $ 0:0:0.1��6&   $ 	#FF26B08A��68   5+      5,      �� 5-   
   .��5.      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ ThumbMax��6t   .g�5/        $ 0:0:0.2��6&   $ 	#FF4C4F4F��68   50      51      �� 53   
   .��54      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ InnerBorder��6t   .g�55        $ 0:0:0.1��6&   $ 	#FFB8BBBA��68   56      57      �� 58   
   .��59      �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6+   $ InnerBorder��6t   .g�5:        $ 0:0:0.2��6&   $ 	#FF4C4F4F��68   5;      5<      �� 5=   
   6   5>       � Triggers 5?      :� 5A   
    :� 
SourceName$ ThumbMax��6    :� RoutedEvent$! FrameworkElement.MouseEnter��6-   .[�5B      �� #��[ 6   �� 5C      -   5         ��Name$&  innerBorderFocus_BeginStoryboard��5C      #��[ 6H   5D      :� 5E   
   $ ThumbMax��6   $! FrameworkElement.MouseLeave��6-   .[�5F      �� #��[ 6   �� 5G      -   5        $) #innerBorderUnfocus_BeginStoryboard1��5G      #��[ 6K   5H      :� 5K   
   $ UIElement.MouseEnter��6   $ ThumbMin��6:   .[�5L      �� #��[ 6   �� 5M      -   5        $' !innerBorderFocus_BeginStoryboard1��5M      #��[ 6I   5N      :� 5O   
   $ UIElement.MouseLeave��6   $ ThumbMin��6:   .[�5P      �� -   5        $&  minHandleUnfocus_BeginStoryboard��5P      #��[ 6H   �� 5Q      -   5        $( "innerBorderUnfocus_BeginStoryboard��5Q      #��[ 6J   5R      .��5U      �  � RowDefinitions 5V   
   �� 5W      �� 5X      .+�5Z   
   �� -   5         ��Name$ OutterBorder��5Z      $��0q�6'   $��1q�62   ���	#FF2F2F37._�5[      �� -	   5        $ InnerBorder��5[      $��0q�6*   $��1q�65    	 MiBrush#��� 	 6I   ���	#FFACACAC6p   5\      �� 5]   
   $��0q�6   $��1��6   .+�5^      F� -
   5        $ 	MinHandle��5^      H�������V�Q,�&^k�SUUU@Q,�&^k�SUOX@Q�^k�SUOX@Q�^k�SUUU@	$
	 Fill=�6|   ���	#FFE8E8E8 .  $��12��6�   $��16��6�   $��0q�6�    �� StrokeDashArray$	 1 0R�6�   ���	#00000000$y�	Collapsed=�6  n� 5_      -   5         n�Name$ ThumbMin��5_       �� Left$ 30��6&   #���  67   
 �� Top$ 0��6d   #��� 	 6�   ���	#FF4C4F4F6  n� 5`      -   5        $ ThumbMax��5`      $	 195��6&   #���  68   $ 0��6e   ���	#FF4C4F4F#��� 	 6�   6  5b      5d      5e      
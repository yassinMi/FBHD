   M S B A M L   `   `   `  ����?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 5   N       fbhd.TaskComponent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:fbhd     5      c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      WThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  6N   -   5          >�Name$  userControl��5   �    � UseLayoutRounding .  J� SnapsToDevicePixels . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�5	   j   $��0q�6�   ���	#00000000 � 	Resources 5
          BooleanToVisibilityConverter-   'fbhd.selectedToBackgroundColorConverter  selectedToBackColor   fbhd.URLtoVideoID  URLtoVideoID#   fbhd.TaskStatusToUIvisibility  TaskStatusToUIvisibility  121 �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard
 �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value9	  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value ��Name � ToolTip J� Opacity  buttonoptionsdrop  MenuBackground �� EndPoint �� 
StartPoint � Color � Offset  
MenuStyle1 �� 
TargetType �� Property �� Value �� Padding  
MenuStyle2 	 MenuItemControlTemplate1 ��Name �� RadiusY �� RadiusX � ColumnDefinitions z� SharedSizeGroup  �� HeaderStringFormat! �� ContentStringFormat" m� InputGestureText# �� Triggers$ P� Value% P� Property& �� 
TargetName 
 starmenuitem  MenuItemControlTemplat_skip  ButtonFocusVisual' �� StrokeDashArray  ButtonNormalBackground  ButtonNormalBorder( �� Color  
ouoiuoiuio+
  %Microsoft.Windows.Themes.ButtonChrome) 
 Name* 
  BorderBrush+ 
  
Background, J� IsMouseOver- 
  RenderMouseOver. 
  RenderPressed/ �� IsDefaulted0 
  RenderDefaulted<  6System.Windows.Media.Animation.EasingThicknessKeyFrame1 p� KeyTime2 p� Value3 ��Name  ProgressBarStyle14 ��Name5 �� CornerRadius  smallProgBarFlat " MenuItemControlTemplatecopycmd��%�(  &	        &	      &	 &     &	 9     &	 L     &	 1    &	     &	     7  &	 �    7  &		 W
    &	
 F    &	 5    &	     &	 �    &	 �    &	 �    7  7  7  &	 �     &	 �!    &	 ##    �� 5   
   6'     5   
   63     5   
   6     5   
   6)   �� 5   
   " ��6&   .R�5      � $
 grid��6   $��16��6!   $��16��6,   ���	#00040405 5        5      CommonStates��. 5        
Normal��6&     5      	MouseOver��.	 5      �� .��5   "   �� $0
 *(Panel.Background).(SolidColorBrush.Color)�6?   $
 grid��6�   .g�5   &     $ 0��6:   $ 	#00333333��6F   5   #   U� 5   "   $
 (UIElement.Opacity)�6@   $ image��6p   .\�5   &   	  $ 0��6;   $ 1Q�6G   5   #   5       5!        5"      Pressed��6&     5#      Disabled��6&   5$      .+�5&      �� $ image��6   $��media/mp3-cool-yellow.png��6'   $��Hidden=�6J   $
��None=�6|   }�. $ mp3 task��6�   $
 0.75Q�6�   5'      5(      �� 5)   
   " ��64   .R�5*      � $
 grid��6   ���	#00040405 5+        5,      CommonStates��. 5-        
Normal��6&     5.      	MouseOver��.	 5/      �� .��50   "   �� $0
 *(Panel.Background).(SolidColorBrush.Color)�6?   $
 grid��6�   .g�51   &     $ 0��6:   $ 	#00333333��6F   52   #   U� 53   "   $
 (UIElement.Opacity)�6@   $ image��6p   .\�54   &   	  $ 0��6;   $ 1Q�6G   55   #   56      57        58      Pressed��6&     59      Disabled��6&   5:      .+�5<      �� $ image��6   $��Center=�6'   $&�� media/arow-down-white-mi-7x7.png��6D   $��Center=�6n   $��7��6�   $��0q�6�   $��7��6�   $
 0.75Q�6�   5=      5>      �� 5?   
   $	 0,1&�65   $	 0,0&�6D   .��5@      � $ #F6F6F6��6   $
 0.25Q�6+   � 5A      $ #EAE8E8��6   $
 0.25Q�6+   � 5B      $ #DCD9D9��6   $	 0.8Q�6+   � 5C      $ White��6   $ 1Q�6)   5D      �� 5E   
   " o�6#   .�5F      ��  � ��8   6+   �� 5G       � ��# � ��6+   �� 5H       � ��# � ��6)   �� 5I       � ��# � ��6*   �� 5J       � ��# � ��6+   �� 5K       � ��# � ��6+   �� 5L       � �� 5M      �� 5N      " o�6&   .R�5O      �� #��z��6!   #��z��6M   #��z��6�   # z��6�    . ._�5P      �� # z 6-   5Q      5R      5T      5U      �� 5V   
   " o�6#   .�5W      ��  � ��8   6+   �� 5X       � ��# � ��6+   �� 5Y       � ��# � ��6)   �� 5Z       � ��# � ��6*   �� 5[       � ��# � ��6+   �� 5\       � ��# � ��6+   �� 5]       � �� 5^      �� 5_      " o�6&   .R�5`      �� #��z��6!   #��z��6M   #��z��6�   # z��6�    . ._�5a      �� # z 6-   5b      5c      5e      5f      �� 5g   
   " m�6;   .R�5h      �  . .+�5i      �� $ Bg��6   #��z��6(   $ 0��6L   $ 0��6X   #��z��6d   $	��0.5��6�   � 5j       5k      �� 5l      $��24��6+   $ MenuItemIconColumnGroup��69   $
��Auto �6c   �� 5m      $��4 �6+   �� 5n      $��* �6+   �� 5o      $��37 �6+   �� 5p      $ MenuItemIGTColumnGroup��6+   $
��Auto �6T   �� 5q      $��17 �6+   .+�5s      �� $
 icon��6   $��Stretch=�6*   $��0,0,0,1q�6H   $��14��6Y   $��14��6d   $&�� media/elet-14-grey-filled-mi.png��6p   �� 5t      #��z��6'   #��z��6Z   $��2��6}   #! z  6�   $��Header��6�   #��z��6�   ��. # z 6  �� 5u      $��4��6    #��z��60   #��z" 6S   5v      5w      # 5x      P� 5y      $ 6*   Z� % �@m�IconP� 5z      % �@m�	IsChecked$ . 6/   P� 5{      % �@m�IsHighlighted$ . . �5|      �� $& Bg��6-    � �� 5}      �� 5~      $	 0,1&�62   $	 0,0&�6A   .��5   "   � $ 	#34C5EBFF��6/   $ 0Q�6A   � 5�   "   $ 	#3481D8FF��6/   $ 1Q�6A   5�      5�      �� 5�      $& Bg��6/    � �� �	#8071CBF16?   5�      P� 5�      % � {�$ .  . �5�      ��  � �� �	#FF9A9A9A63   5�      5�      �� 5�   
   " m�6/   .R�5�      �  . .+�5�      �� $ Bg��6   #��z��6(   $ 0��6L   $ 0��6X   #��z��6d   $	��0.5��6�   � 5�       5�      �� 5�      $��24��6+   $ MenuItemIconColumnGroup��69   $
��Auto �6c   �� 5�      $��4 �6+   �� 5�      $��* �6+   �� 5�      $��37 �6+   �� 5�      $ MenuItemIGTColumnGroup��6+   $
��Auto �6T   �� 5�      $��17 �6+   .+�5�      �� $
 icon��6   $��Stretch=�6*   $��5,3,5,4q�6H   $��14��6Y   $��14��6d   $&�� media/star-14-grey-filled-mi.png��6p   �� 5�      #��z��6'   #��z��6Z   $��2��6}   #! z  6�   $��Header��6�   #��z��6�   ��. # z 6  �� 5�      $��4��6    #��z��60   #��z" 6S   5�      5�      # 5�      P� 5�      $ 6*   Z� % �@m�IconP� 5�      % �@m�	IsChecked$ . 6/   P� 5�      % �@m�IsHighlighted$ . . �5�      �� $& Bg��6-    � �� 5�      �� 5�      $	 0,1&�62   $	 0,0&�6A   .��5�   "   � $ 	#34C5EBFF��6/   $ 0Q�6A   � 5�   "   $ 	#3481D8FF��6/   $ 1Q�6A   5�      5�      �� 5�      $& Bg��6/    � �� �	#8071CBF16?   5�      P� 5�      % � {�$ .  . �5�      ��  � �� �	#FF9A9A9A63   5�      5�      �� 5�   
   " m�6>   .R�5�      �  . .+�5�      �� $ Bg��6   #��z��6(   $ 0��6L   $ 0��6X   #��z��6d   $	��0.5��6�   � 5�       5�      �� 5�      $��24��6+   $ MenuItemIconColumnGroup��69   $
��Auto �6c   �� 5�      $��4 �6+   �� 5�      $��* �6+   �� 5�      $��37 �6+   �� 5�      $ MenuItemIGTColumnGroup��6+   $
��Auto �6T   �� 5�      $��17 �6+   .+�5�      �� $
 icon��6   $��Stretch=�6*   $��0,0,0,1q�6H   $��14��6Y   $��14��6d   $��media/enter-grey14-14.png��6p   �� 5�      #��z��6'   #��z��6Z   $��2��6}   #! z  6�   $��Header��6�   #��z��6�   ��. # z 6  �� 5�      $��4��6    #��z��60   #��z" 6S   5�      5�      # 5�      P� 5�      $ 6*   Z� % �@m�IconP� 5�      % �@m�	IsChecked$ . 6/   P� 5�      % �@m�IsHighlighted$ . . �5�      �� $& Bg��6-    � �� 5�      �� 5�      $	 0,1&�62   $	 0,0&�6A   .��5�   "   � $ 	#34C5EBFF��6/   $ 0Q�6A   � 5�   "   $ 	#3481D8FF��6/   $ 1Q�6A   5�      5�      �� 5�      $& Bg��6/    � �� �	#8071CBF16?   5�      P� 5�      % � {�$ .  . �5�      ��  � �� �	#FF9A9A9A63   5�      5�      �� 5�   
   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� $	' 1 2R�6$   $��1��6:   #��� ��6N    . $��2q�6�   5�      5�      5�      �� 5�   
   $	 0,1&�6=   $	 0,0&�6L   .��5�      � $ #F3F3F3��6   $ 0Q�6+   � 5�      $ #EBEBEB��6   $	 0.5Q�6+   � 5�      $ #DDDDDD��6   $	 0.5Q�6+   � 5�      $ #CDCDCD��6   $ 1Q�6+   5�      �� 5�   
   $( 	#FF707070��65   �� 5�   
   " ��6#   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��$ 1q�60   �� 5�       � ��# � ��6+   �� 5�       � ��$ Center=�6;   �� 5�       � ��$ Center=�69   �� 5�       � ��$ 1q�6(   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      
  $) Chrome��6.   #* z��6>   #+ z��6j   #- z, 6�   #. z��6�   #0 z/ 6�    .  5�        5�   "   CommonStates��. 5�   &     
Normal��62     5�   &   	MouseOver��.	 5�   *   �� .��5�   .   r� $
 (FrameworkElement.Margin)�6O   $ contentPresenter��6�   .	�5�   2     $1 0��6J   $2 	564,1,1,1q�6V   5�   /   5�   +   5�   '     5�   &   Pressed��.	 5�   *   �� .��5�   .   r� $
 (FrameworkElement.Margin)�6O   $ contentPresenter��6�   .	�5�   2     $1 0��6J   $2 	506,1,1,1q�6V   5�   /   5�   +   5   '     5  &   Disabled��62   5  #   ._�5     �� $3 contentPresenter��6/   #��z��6I   $��1q�6�   ��. # z 6�   #��z��6�   5     # 5     P� 5     % �@J�IsKeyboardFocused$ . . �5  "   �� $& Chrome��6D    �@
 RenderDefaulted . 6X   5	     P� 5
     % �@d�	IsChecked$
$ trueY�6H   . �5  "   �� $& Chrome��6B    �@
 RenderPressed . 6V   5     P� 5     % � {�$ .  . �5  "   ��  � �� �#ADADAD6?   5     5     5     5     �� 5  
   " �6*   .�5     ��  � �� 5     �� 5     " �6&   .R�5     � .+�5     �� $4 
PART_Track��6%   #��z��69   $��1q�6c   $5 2��6w   �� 5     $4 PART_Indicator��6@   $
��Left=�6%   #��z��6X   $��1q�6�   $5 2��6�   5!     5"     5$     5%     �� 5&  
   " �6)   .�5'     ��  � �� 5(     �� 5)     " �6&   .R�5*     � .+�5-     �� $4 
PART_Track��6%   #��z��69   $��1q�6c   $5 0��6w   �� 50     $4 PART_Indicator��6@   $
��Left=�6%   #��z��6X   $��1q�6�   $5 0��6�   52     53     55     56     �� 57  
   " m�6A   .R�58     �  . .+�59     �� $ Bg��6   #��z��6(   $ 0��6L   $ 0��6X   #��z��6d   $	��0.5��6�   � 5:      5;     �� 5<     $��24��6+   $ MenuItemIconColumnGroup��69   $
��Auto �6c   �� 5=     $��4 �6+   �� 5>     $��* �6+   �� 5?     $��37 �6+   �� 5@     $ MenuItemIGTColumnGroup��6+   $
��Auto �6T   �� 5A     $��17 �6+   .+�5C     �� $
 icon��6   $��Stretch=�6*   $��0,0,0,1q�6H   $��14��6Y   $��14��6d   $)��#media/copy-16-white-commandline.png��6p   �� 5D     #��z��6'   #��z��6Z   $��2��6}   #! z  6�   $��Header��6�   #��z��6�   ��. # z 6  �� 5E     $��4��6    #��z��60   #��z" 6S   5F     5G     # 5H     P� 5I     $ 6*   Z� % �@m�IconP� 5J     % �@m�	IsChecked$ . 6/   P� 5K     % �@m�IsHighlighted$ . . �5L     �� $& Bg��6-    � �� 5M     �� 5N     $	 0,1&�62   $	 0,0&�6A   .��5O  "   � $ 	#34C5EBFF��6/   $ 0Q�6A   � 5P  "   $ 	#3481D8FF��6/   $ 1Q�6A   5Q     5S     �� 5T     $& Bg��6/    � �� �	#8071CBF16?   5U     P� 5V     % � {�$ .  . �5W     ��  � �� �	#FF9A9A9A63   5X     5Z     5[     .��5\     �� -   5        $4 grd_main��5\     $	 0,1q�6   $��1q�6-   
������  5]  
     5^     -   5        
Status��. 5_       -   5        Resolved��.	 5`     �� .��5a     �� $6
 0(TextElement.Foreground).(SolidColorBrush.Color)�67   $ lblUrl��6�   .g�5b       $ 0��62   $ 	#FFF3F3F3��6>   5c     5d     5e       5f     -   5        NotResolved��.	 5g     �� .��5h     �� $6
 0(TextElement.Foreground).(SolidColorBrush.Color)�67   $ lblUrl��6�   .g�5i       $ 0��62   $ 	#FF656565��6>   5j     5k     5l     5m       5n     -   5        HoverStatus��. 5o       -   5        	Hover��5o       5p     -   5        
normal��5p     5q     ._�5s  
   � ���	#00000000.+�5u     � $��0q�6   }�. ���	#00000000 5v     �� 5w     �� 5x     $��20 �6'   �� 5y     $��14 �6'   .+�5{     � $��0,0,5,0q�6   ���	#00000000 5|     �� 5}     $��5* �6+   �� 5~     $	��38* �6+   .+�5�     � -	   5        $ grd_statusIcon��5�     $��0q�63   $��Center=�6>   $��Center=�6[   }�. .+�5�     �� -
   5        $ done_i��5�      $��0q�60   $��media/chec3.png��6;   $��10��6T   $��Center=�6`   y�6�   �� *
taskStatus+6 �� ConverterParameter$
6 done��7 �� 	Converter#7 [ 8 �� RelativeSource8 �� *FindAncestor+9 �� AncestorType   fbhd.TaskComponent"9  �� 5�     -   5        $ 	error_ico��5�      $��0q�63   $��media/error1.png��6>   $��10��6X   $��Center=�6d   y�6�   �� *
taskStatus+$6 failed��#7 [ : �� ElementName$: userControl���� 5�     -   5        $ resolving_ico��5�      $��0q�67   $$��media/resloving-gray-10-10.png��6B   $��10��6j   $��Center=�6v   ; J� RenderTransformOrigin$; 0.5,0.5&�6�   y�6�   �� *
taskStatus+$6 	resolving��#7 [ $: userControl��� 5�     -   5        $ grd_downloading_anim��5�     $��0q�6=   $��10��6H   $��10��6S   $��Center=�6_   $��Center=�6|   }�. y�6�   �� *
taskStatus+$6 downloading��#7 [ $: userControl��.+�5�     �� -   5        $ downloading_ico��5�  $   $��	0,0,-60,0q�6=   $)��#media/down-small-11-turns-white.png��6P   $��Center=�6}   $; 0.5,0.5&�6�   $y�Visible=�6�   $��10��6�   $	��110��6�   $
��Left=�6�   $
��None=�6   5�     5�     �� 5�     -   5        $4 
url_border��5�     $��0q�61   $��1q�6<   $5 2��6P   ���	#FF2F2F37$��2��6{   ��6�   �� *
taskStatus+$6 
url_column��#7 [ $: userControl��._�5�     �� -   5        < ��Name$< lblUrl��5�  $   $��WrapWithOverflow=�6�   $	��1,0q�6a  ���	#FFA4A4A4}�. ��6�   �� *url+#7 [ $: userControl��= �� FallbackValue$M= Ghttps://www.facebook.com/DUMMYking.net/videos/575243946572618/?sfnsn=mo��> �� Mode$> OneWay=�6�  5�     5�     � 5�     -   5        $ 
typeSwitch��5�     $��1��6+   $��0,4,3.965,3q�6;   $y�	Collapsed=�6P   .+�5�        fbhd.ButtonMi  -   5        ?  Name$? mp3Butt��5�  %   @   
iconSource$@ media/mp3-cool-yellow.png��6Q   
A � Tag$	A mp3��6x     5�     -   5        $? mp4Butt��5�  %   $'@ !media/mp4-cool-magenta-ofiice.png��66   $	A mp4��6�   $y�	Collapsed=�6�     5�     -   5        $? mkvButt��5�  %   $$@ media/mkvcool-white-office.png��66   $	A mkv��6b   $y�	Collapsed=�6m   $��0,0,-26.525,0q�6�     5�     -   5        $? jpgButt��5�  %   $@ media/jpg-cool-office.png��66   $	A jpg��6]   $y�	Collapsed=�6h   $��0,0,-26.525,0q�6   5�     � 5�     -   5        $ menu1��5�     $��2��6&   $��0q�66   $��13��6A   $��Center=�6L   $��Center=�6i   $��12��6�   .+�5�     �� -   5        B ��Name$B buttonoptionsdrop��5�     $��Button��68   #���  6I   ���	#FF040405���	#FF7DCD79 . $��Center=�6�   $��16��6�   $ Options��6  � 5�     -   5        C �Name$C popup��5�     $��0q�6+   $��Bottom=�66   $��Right=�6Q   D � 	StaysOpenD .  .��5�     �� 
���   �$
��Left=�68   $��0q�6S   $	��Top=�6^   .+�5�     m� -   5        $��Remove��5�  '   ���	#FFAAAAAA$ Display=�6N   $��0,0,2,0q�6�   #��� 	 6�   6  m� 5�     $��
Properties��6'   ���	#FFAAAAAA$ Display=�6R   $��0,0,2,0q�6{   #��� 
 6�   $" R��6  m� 5�     -   5        $
��Skip��5�  '   ���	#FFAAAAAA$ Display=�6L   $��0,0,2,0q�6u   #���  6�   6  m� 5�     -   5        $
��Copy��5�  '   ���	#FFAAAAAA$ Display=�6L   $��0,0,2,0q�6u   #���  6�   $" C��6&   E m� UsesItemContainerTemplateE . .@�5�  "   m� -   5        $��ffmpeg args��5�  +   ���	#FFAAAAAA$ Display=�6W   $��0,0,2,0q�6�   #���  6�   6�   m� 5�  "   -   5        $��post url��5�  +   ���	#FFAAAAAA$ Display=�6T   $��0,0,2,0q�6}   #���  6�   6�   m� 5�  "   -   5        $��	thumb url��5�  +   ���	#FFAAAAAA$ Display=�6U   $��0,0,2,0q�6~   #���  6�   6�   m� 5�  "   -   5        $��	video url��5�  +   ���	#FFAAAAAA$ Display=�6U   $��0,0,2,0q�6~   #���  6�   6�   m� 5�  "   -    5        $��	audio url��5�  +   ���	#FFAAAAAA$ Display=�6U   $��0,0,2,0q�6~   #���  6�   6�   m� 5�  "   $��MenuItem��6+   $	��100��6=   $	��100��6J   F m� StaysOpenOnClickF . 6V   5�     5�     5�     5�     � 5�     -!   5        $ MediaTypeSwitchGrd��5�     $��1��63   $��0,4,3.965,3q�6C   $y�	Collapsed=�6X   .+�5�       -"   5        $? mp3Butt1��5�  %   $@ media/mp3-cool-yellow.png��6R   $	A mp3��6y     5�     -#   5        $? mp4Butt1��5�  %   $'@ !media/mp4-cool-magenta-ofiice.png��67   $	A mp4��6�   $y�	Collapsed=�6�     5�     -$   5        $? mkvButt1��5�  %   $$@ media/mkvcool-white-office.png��67   $	A mkv��6c   $y�	Collapsed=�6n   $��0,0,-26.525,0q�6�     5�     -%   5        $? jpgButt1��5�  %   $@ media/jpg-cool-office.png��67   $	A jpg��6^   $y�	Collapsed=�6i   $��0,0,-26.525,0q�6�   5�     !  fbhd.MediaTypeSwitchControl  5�     -&   5        G  Name$G MediaTypeSwitch��5�  /   !  fbhd.MediaTypeSwitchControlH   Shifted$H MediaTypeSwitch_Shifted��6H   $��1��6j   $	��2,0q�6z   I   	IconAudio$I media/wav-16-white.png��6�   J   	IconVideo$J media/video-16-medium.png��6�   K   	IconImage$K media/image-16-small.png��6�   L   ValueL 6�   �� *	MediaType+$= 0����5�     �� 5�     .R�5�     � .+�5�  "      fbhd.ButtonWithIcon  M  Name$M PART_BUTTON��67   N   Icon$N media/wav-16-white.png��6L   ��5�  &   �� 5�  *   "  6:   .R�5�  .   � $	 grd��63   ���	#00000000$
 0.85Q�6W   .+�5�  2   �� #��zN 68   $��16��6X   $��16��6d   $��Center=�6o   $��Center=�6�   6�   5�  /   # 5�  .   P� 5�  2   % �@J�IsMouseOver$ . . �5�  6   �� $	& grd��6Z    �@J�Opacity$ 1Q�6P   6Z   5�  3   5�  +   5�  #   5�     5�     5�     5�     � 5�     -'   5        O �Name$O progressBar_download��5�     $��4��68   $��0q�6C   #���  6N   $��Bottom=�6y   ���	#003E3D3D���	#0004B081���	#FF9C9C9CP � Maximum$P 1Q�6�   $��0q�6�   y�6�   �� *IsDownloading+#7 [  Q � ValueQ 6X  �� *downloadingPercent+$= 0��$> OneWay=�5�     5�     5�     
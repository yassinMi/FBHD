   M S B A M L   `   `   `  ����?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  5          fbhd.TaskInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:fbhd     5      c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6N   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6�   -   5          >�Name$  userControl��5   �    � UseLayoutRounding . $	��368��5   8    � 	Resources 5
         fbhd.TypeToIntConverter   TypeToIntConverter&    fbhd.TaskTypeToComboBoxItemIndex  ttype_to_inex   fbhd.boolToStringsMI  boolToStringsMI   fbhd.URLtoVideoID  URLtoVideoID1  URLtoVideoID#   fbhd.TaskStatusToUIvisibility  TaskStatusToUIvisibility  ProgressBarStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius # ComboBoxDisabledForegroundBrush	 �� Color # ComboBoxDisabledBackgroundBrush 	 ComboBoxDisabledBorderBrush %
 !ToggleButtonControlTemplateflattt
 � ColumnDefinitions F�Name �� Triggers P� Property P� Value �� 
TargetName  ComboBoxFlatStyle_miVersion d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �Name � AllowsTransparency �� IsDropDownOpen �Name  J� SnapsToDevicePixels! � ActualWidth" �� MaxDropDownHeight-  'System.Windows.Input.KeyboardNavigation#   DirectionalNavigation  MiTB_Highlightable$ �� 	Resources  Key% �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame& �� KeyTime' �� Value( �� Triggers) :� RoutedEvent* N� EnterActions+ ��Name  	Highlight, N� ExitActions  uNHighlight��%f  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �    &	 �    &		 �    &	
     7  7  7 	 7  &	 �    7  &	 �    7  7    5   
   6#     5   
   6,     5   
   6      5   
   6     5   
   6     5   
   6)   �� 5   
   " �6*   .�5      ��  � �� 5      �� 5      " �6&   .R�5      � .+�5      �� $ 
PART_Track��6%   #��z��69   $��1q�6c   $ 2��6w   �� 5      $ PART_Indicator��6@   $
��Left=�6%   #��z��6X   $��1q�6�   $ 2��6�   5      5      5!      5"      �� 5#   
   $
	 #888��6B   �� 5$   
   $
	 #eee��6B   �� 5%   
   $
	 #888��6>   �� 5&   
   " d�6D   .R�5'      � 
 5(      �� 5)      �� 5*      $��20 �6'   .+�5,      �� $ Border��6-   $��2��6   ���	#FF2F2F37$ 0��5.      $��
1, 1, 1, 1q�6   
���   �5/      �� 50      $ ButtonBorder��6U   $��1��6   $��
1, 1, 1, 1q�6)   ���	#FF2F2F37$ 
0, 0, 0, 0��51      $��
0, 0, 0, 0q�6&   ���	#FF04040452      F� 54      $ Arrow��6   $��1��6&   =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=�56      ���	#FF929292$��Center=�57      58       59      P� 5:       �@J�IsMouseOver . . �5;      �� $ Border��64    � �� �	#FF43434F6H   �� 5<      $ ButtonBorder��69    � �� �	#FF3A3A3A6S   5=      P� 5>       �@d�	IsChecked$
 TrueY�6/   . �5?      �� $ ButtonBorder��69    � �� �	#FF3A3A3A6S   �� 5@      $ Arrow��6-    � �� �	#FFB5C1C96@   5A      P� 5B       � {� .  . �5C      �� $ Border��69   8    � ��6M   �� 5D      $ ButtonBorder��69   8   � ��6S   �� 5E      $ ButtonBorder��64   8   � ��6N   �� 5F      8   � ��6?   �� 5G      $ Arrow��6-    � �� �#9996@   5H      5J      �� 5K   
   " ��65   .�5L      ��  �@J�SnapsToDevicePixels . 64   �� 5M       �@�OverridesDefaultStyle . 66   �� 5N       � ��$
 Auto=�6K   �� 5O       � ��$
 Auto=�6I   �� 5P       � �� . 6>   �� 5Q       � �� �	#FFB6B6B667   �� 5R       �@�FocusVisualStyle 61   Z� �� 5S       � �� 5T      �� 5U      " ��6&   .R�5V      � .+�5W      d� $ ToggleButton��6+   $��2��6A   $ Press=�5X      |�.  #��� 
 5Z      
���   � 5Y      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+5Z   N   �� 5\      $ ContentSite��6/   $��5, 3, 23, 3q�6D    .  $
��Left=�5]      $��Center=�6*   #��z 5^      #��z 5_      #��z��5`      �� 5a      $ PART_EditableTextBox��6&   $��3, 3, 23, 3q�6D   # z 5b      $y�Visible=�5c      
������ $
��Left=�5d      $��Center=�6*   |�. .��5e   !   ��5f   "   �� 5g   &   " ��66   .R�5h   *   �� $ PART_ContentHost��61   |�.  6K   5i   '   .��5j   4   5k      � 5m      $ Popup��6$   $��Bottom=�63   |�.   . #��z 5o      $��Slide=�5p      .��5q   "   � $ DropDown��6'     . #��z! 5r      #��z" 5s      .+�5t   &   �� $ DropDownBorder��6-   ���	#FF212121$��
0, 1, 0, 0q�6\   $ 0��5u      $��1,1,1,1q�6"   ���	#FF4F4F4F5v      �� 5w   &   $��4q�63     . .��5x   *   �� $# 	Contained=�69   5y   '   5z   #   5{      5|       5}      P� 5~       �@��HasItems .  . �5   "   �� $ DropDownBorder��6>    � ��$ 95��6Z   5�      P� 5�       � {� .  . �5�   "   �� 8    � ��6K   5�      P� 5�       �@��
IsGrouping . . �5�   "   ��  � �� .  6R   5�      P� 5�       �@��
IsEditable . . �5�   "   ��  �@ 	IsTabStop .  6Q   �� 5�   "   $ PART_EditableTextBox��6?    � y�$ Visible=�6a   �� 5�   "   $ ContentSite��6?    � y�$ Hidden=�6X   5�      5�      5�      5�      �� 5�   
   " ��6+   $ 5�      ���� 5�      zaga 6   �� 5�      	Highlight .��5�      �� $6% 0(TextElement.Foreground).(SolidColorBrush.Color)�63   .g�5�        $& 0:0:0.1��6.   $' #FFFFFF��6@   5�      5�      �� 5�      uNHighlight .��5�      �� $6% 0(TextElement.Foreground).(SolidColorBrush.Color)�63   .g�5�        $& 0:0:0.2��6.   $' 	#FFC1C1C1��6@   5�      5�      5�      ( 5�      :� 5�      $) FrameworkElement.Loaded��6   P� 5�       �@J�IsMouseOver . * 5�      �� 5�      $+ Highlight_BeginStoryboard��6*   8��  6M   , 5�      �� 5�      8�� 6+   5�      .�5�      ��  � ��$ NoWrap=�6-   �� 5�       � ��$
 None=�6-   5�      5�      .��5�      �� .+�5�   
   �� -   5        $ ID��5�      $��54��6   ���	#FF2D2D30$��1q�6t   ._�5�      � -   5        $ 
TaskiIdgRD��5�      - � RowDefinitions- 5�      �� 5�      $	��14* �6$   �� 5�      $	��13* �6$   
 5�      �� 5�      $��48 �6'   �� 5�      .+�5�      � -   5        $ grd_type��5�      $��2��6)   $��0,0,0,6q�6=   $��1��6i   $��1��6v   
 5�      �� 5�      $��40 �6+   �� 5�      $
��100* �6+   �� 5�      $	��39* �6+   .+�5�      �� -   5        . ��Name$. lbl_type��5�       $	��0,2q�62   $
��Wrap=�6?   $��Type:��6S   $��Center=�6`   ���	#FFD5D5D5&   System.Windows.Media.TextOptions/   TextFormattingMode$/ Display=�6�   $
��Left=�6�   	  fbhd.TypeComboBox	  5�      -   5        0 	 Name$0 typePickerCombo��5�   )   
���   ����	#FF2F2F37#���  6m   1 � ToolTip$1 	Task Type��6�   $��Center=�6�   $��1��6�   $
��Left=�6�   $��58��6�   $/ Display=�6	  ���	#FFDAD7D72 �� SelectedIndex2 6I  �� *SelectedTask.Type+3 �� 	Converter#3 [  4 �� FallbackValue$4 0��$ TwoWay=�.@�5�      �� $	��MP3��6'   $/ Display=�65   �� 5�      $	��MP4��6'   ���	#FFC5C5C5$/ Display=�6]   ��6L   Z� 6]   �� 5�      $	��MKV��6'   $/ Display=�65   �� 5�      $	��JPG��6'   $/ Display=�65   5�      �� 5�      -   5        5 ��Name$5 ShowInfoWindowButton��5�      $��2��6;   $��Right=�6K   $��0,0,10,0q�6g     SimplerStyleMi#���  6y   ���	#00000000$��16��6�   $��16��6�   $��Center=�6�   $1 Show Post Info��6  ��6�   Z� {�6>  �� *coreTaskObject.IsResolved+6 �� ElementName$6 userControl��.��5�      �� -   5        7 ��Name$
7 info��5�       $%��information-b-on-w-13-large.png��6.   $��13��6W   $��13��6b   5�      �� 5�      -	   5        $5 CopyLinkButt��5�      $��2��63   $��	31,2,31,1q�6C   #���  6V   ���	#00000000$��16��6�   $y�	Collapsed=�6�   ��6   Z� .��5�      �� -
   5        $7 info1��5�       $%��information-b-on-w-13-large.png��6/   $��13��6X   $��13��6c   5�      5�      � 5�      -   5        $ grd_urle��5�      $��0q�6)   $��1��6O   $��Center=�6_   
 5�      �� 5�      $��40 �6+   �� 5�      .+�5�      �� -   5        $
. URL_��5�       $��0,3.5q�6.   $
��Wrap=�6=   $
��URL:��6Q   $��Center=�6]   ���	#FFD5D5D5$/ Display=�6�   $
��Left=�6�   #���  6�   �� 5�      -   5        $. lblTaskName��5�       $��WrapWithOverflow=�65   ���	#FFC1C1C1$/ Display=�6l   $��Center=�6�   $��2��6>  $��1��6R  $��CharacterEllipsis=�6b  $	��270��6�  #���  6�  ��6�   �� *coreTaskObject.Url+8 �� ConverterParameter$8 50��#3 [ $6 userControl��$4 -��1 6�  �� *coreTaskObject.Url+$6 userControl��6�  5�      � 5�      -   5        $ typeIcon��5�      $��0q�6)   $��2��64   $��Center=�6E   $��Center=�6b   $��48��6}   $��48��6�   .+�5�      �� -   5        $7 image��5�      $��0q�6+   $��32��6�   $��32��6�   $��Center=�6�   $��Center=�6�   $
��None=�6�   ��66   �� *Image+$6 userControl��9 �� UpdateSourceTrigger$9 PropertyChanged=�6�   5�      5�      5�      � 5�   
   -   5        $ taskStatusBigGraphics��5�      $��0,3,0,2q�6.   
 5�      �� 5�      $	��13* �6#   �� 5�      $	��25* �6#   .+�5�      � -   5        $ 
grd_status��5�      }�. $��2��6g   .+�5�      � -   5        $ graphics_resolving��5�      $��0q�63   $��40��6�   $	��Top=�6�   y�6>   �� *coreTaskObject.Status+$8 	resolving��#3 [ $6 userControl��$4 	collapsed��
 5�      �� 5�      $��48 �6+   �� 5�      .+�5�      � -   5        $ resolvingGridc��5�      : J� RenderTransformOrigin$: 0.5,0.5&�63   $��32��6S   $��1,0,0,0q�6_   $	��Top=�6p   $��Center=�6�   .+�5�      %
  Microsoft.Expression.Shapes.Arc
  ; 
  ArcThickness$; 3Q�6!   < 
  ArcThicknessUnit$< Pixel=�62   = 
  EndAngle$	= 360Q�6K   $��0q�6Z   > �� Stretch$
> None=�6e   ? 
  
StartAngle$? 0Q�6t   ���	#FF5CAE9B$��31��6�   $��31��6�   $��Right=�6�   $��Bottom=�6�   @ J� Opacity$	@ 0.8Q�6�   � 5�      -   5        $ rotatingRect��5�      $��5��65   $��0q�6@   $��Center=�6K   A J� OpacityMaskA �	#FFBFBFBF$��31��6~   $��Center=�6�   
���   �$: 0.5,0.5&�6�   5�      �� 5�      -   5        $. lbl_Status1��5�       $��	4,11,0,11q�65   $
��Wrap=�6H   $��Resolving post��6\   ���	#FFBDBDBD$��10.667(�6�   $
��Left=�6�   $��Center=�6�   $/ Display=�6�   $��18��6�   $��1��6     fbhd.ButtonMi  5�      $��Right=�6%   $��18��6A   $��
0,11,10,11q�6M   $��59��6a   B   textcaption$B Cancel��6l   C   
iconSource$C media/x-16-white.png��6�   $��Center=�6�   $��1��6�   D   captionVisibility$D Visible=�6�   5�      � 5�      -   5        $ graphics_down��5�      $��0,0,0,2q�6.   $��60��6�   $	��Top=�6�   y�6?   �� *coreTaskObject.Status+$8 downloading��#3 [ $6 userControl��$4 	collapsed��- 5�      �� 5�      �� 5�      $
��9.25 �6(   �� 5�      $��12.75 �6(   
 5�      �� 5�      $��48 �6+   �� 5�      .+�5�      � -   5        $ 	down_anim��5�      $: 0.5,0.5&�6.   $��32��6N   $��31��6Y   $y�Visible=�6e   $	��Top=�6z   $��8,4,8,0q�6�   $��Center=�6�   .+�5�      � $
��Left=�6   $��5,5,0,6q�6:   $��6��6K   .+�5�      �� -   5        $7 dowloadAnim_line��5�   $   $"��media/32-down-white-line.png��6>   $
��Left=�6   $	��Top=�6�   $��2��6�   $��2,0,0,0q�6�   5�      �� 5�      -   5        $7 dowloadAnim_drive��5�       $��0q�6;   $��media/32-down-white.png��6F   $	@ 0.7Q�6g   $
��Left=�6u   $	��Top=�6�   5�      �� 5�      -   5        $. 
lbl_Status��5�       $��0q�64   $
��Wrap=�6?   ���	#FFBDBDBD$��10.667(�6�   $
��Left=�6�   $��Center=�6�   $/ Display=�6�   $��1��6%  ��6S   �� * coreTaskObject.ProgressCaption+$6 userControl��6%  � 5�      -   5        E �Name$E progressBar_download��5�   "   $	��2,0q�6@   #���  6M   ���	#FF3E3D3D���	#0004B081���	#FF9C9C9CF � Maximum$F 1Q�6  $��2��6%  $��1��69  $��6��6F  G � ValueG 6�   �� *#!coreTaskObject.downloadingPercent+$6 userControl��$ OneWay=�6F    fbhd.ProgressInfoUI  5      $��1��6w   $��Right=�6�   $��Center=�6�   $��0,0,10,0q�6�   H   ProgressH 6+   �� *coreTaskObject.FfmpegProgress+$6 userControl����5     �� 5     "  6.   .R�5  "   �� $. PART_TEXTBLOCK��6,   -   5        $��0q�5  D   $
��Wrap=�6O   ���	#FFBDBDBD$��10.667(�6z   $��Stretch=�6�   $��Stretch=�6�   $/ Display=�6�   
I � Tag$I 0��65  $��1��6=  ���	#FF020202$��50��6d  $��10��6r  $��-��6�  J �� TextAlignment$J Right=�6�  5     5       5     -   5        K  Name$K 	kill_butt��5  %      fbhd.ButtonMiL   Click$L kill_butt_Click��6�   $1 Kill Process��68   $��0,1,15,0q�6O   $
��Auto��6a   $��Right=�6n   $
B Kill��6�   $C media/x-16-white.png��6�   M   captionMargin$M 3,0,0,0q�6�   $��1��6�   $��2��6   $D Visible=�6    5     -   5        $K 	pauseButt��5  %   $L abort_butt_Click��6�   $
1 Stop��68   $��0,1,70,0q�6G   $
��Auto��6Y   $��Right=�6f   $
B Stop��6�   $$C media/pause16white-perfect.png��6�   $��1��6�   $��2��6�   $D Visible=�6�   �� 5	     -   5        $. elapsed_time��5	      $��81,1,0,0q�66   $
��Wrap=�6H   ���	#FFBDBDBD$��10.667(�6s   $	��Top=�6�   $/ Display=�6�   $I 0��6  $��(Elapsed time: 0:56)��6  $
��Left=�60  $��1��6K  $��2��6[  $y�Hidden=�6h  5
     � 5     -    5        $ graphics_done��5     $��0q�6.   $	��Top=�6�   y�69   �� *coreTaskObject.Status+$
8 done��#3 [ $6 userControl��$4 visible��- 5     �� 5     �� 5     $��32 �6(   
 5     �� 5     $��48 �6+   �� 5     .+�5     �� -!   5        $7 done_i��5     $��0q�6,   $"��media/check-32-aqagreen3.png��67   $y�Visible=�6]   $��Center=�6r   $��Center=�6�   $��32��6�   $��32��6�   � 5     -"   5        $ Wraper��5     $��1��6+   $��0q�6;   $��40��6F   - 5     �� 5     �� 5     .+�5     �� -#   5        $. lbl_outputPath��5  $   $��0q�6<   $
��Wrap=�6G   ���	#FFD5D5D5$��10.667(�6r   $
��Left=�6�   $��Center=�6�   $/ Display=�6�   #���  6�  ��6�   �� *coreTaskObject.OutputFile+$8 40��#3 [ $6 userControl��$4 FILENAME��1 6�  �� *coreTaskObject.OutputFile+$6 userControl��6�  �� 5     -$   5        $. lbl_size��5  $   $
��Wrap=�66   ���	#FFBDBDBD$��10.667(�6�   $
��Left=�6�   $/ Display=�6  $��0q�60  $��1��6;  $��Center=�6c  ��6J   �� *coreTaskObject.OutputFileSize+$6 userControl��$4 Size: -��N �� StringFormat$N 	Size: {0}��6c    5     -%   5        $K 	resetTask��5  )   $L resetTask_Click��6�   $��	117,0,5,0q�6<   $ C new-task-lite-16-white.png��6O   $B 
Reset Task��6w   $��Center=�6�   $
��Auto��6�   $M 4,0,0,0q�6�   $��Right=�6�   $��18��6�   $D Visible=�6  $��1��6F  5     �� 5     -&   5        $ Actions��5     $��2��6.   $��0q�6B   $��1��6M   $��Bottom=�6Z   ���	#FF2D2D30$��1q�6�   O �� Padding$	O 4,2q�6�   ._�5     � 
 5      �� 5!  "   $	��29* �63   �� 5"  "   $��16 �63   �� 5#  "   $	��85* �63   .+�5%       -'   5        $K 
miOpenFile��5%  -   P   PreviewMouseLeftButtonUp$)P #miOpenFile_PreviewMouseLeftButtonUp��6�   $.C (media/play-in-circle-white-16-larger.png��6A   $B 	Open file��6w   $��Stretch=�6�   $
��Auto��6�   $M 4,0,0,0q�6�   $��18��6�   $D Visible=�6  $1 Open Output File��67    5&     -(   5        $K miOpenLocation��5&  -   $L miOpenLocation_Click��65  $��
14,0,104,0q�6E   $2C ,media/folder-open-property-16-white-cyan.png��6Y   $B Show in Folder��6�   $��Stretch=�6�   $
��Auto��6�   $M 4,0,0,0q�6�   $��Stretch=�6�   $��18��6  $��2��6R  $D Visible=�6b  $1 Open output location��6~    5'     -)   5        $K miDeleteFile��5'  -   $L miDeleteFile_Click��6�   $C media/delete-16-white.png��6C   $B Delete File��6j   $��Stretch=�6�   $
��Auto��6�   $M 4,0,0,0q�6�   $��Right=�6�   $��18��6�   $��2��6  $D Visible=�6  $1 Delete Output file��64  � 5(     -*   5        $ missingFileFlag��5(  #   $��1��6<   $��0q�6L   $��10��6W   $��10��6b   $��Center=�6n   $1 missing file��6�   $y�Hidden=�6�   .+�5)  "   �� -+   5        $7 image1��5)  (   $��0q�68   $��media/error1.png��6C   $��10��6]   $��10��6h   $��Center=�6t   $��Center=�6�   5*     5+     5,     5-     � 5.     -,   5        $ graphics_failed��5.     $��0q�60   $	��Top=�6�   y�6;   �� *coreTaskObject.Status+$8 failed��#3 [ $6 userControl��$4 visible��
 5/     �� 50     $��48 �6+   �� 51     .+�53     �� --   5        $7 	error_ico��53     $	��0,2q�6/   $��media/alert-32 (1).png��6<   $��32��6\   $��Center=�6h   $��Center=�6�   �� 54     -.   5        $. lbl_Status_Copy1��54      $��2,0,0,0q�6:   $
��Wrap=�6K   ���	#FFE04006$��10.667(�6�   $
��Left=�6�   $��Center=�6  $/ Display=�6*  $��1��6S  ��6_   �� *coreTaskObject.FailureReason+$6 userControl��$4 Unknown Failur Reason��6S  55     56     57     59     5:     
   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.TaskInfo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:fbhd     c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  -     >�Name$  userControl�� � UseLayoutRounding . $	��368�� � 	Resources    fbhd.TypeToIntConverter   TypeToIntConverter&    fbhd.TaskTypeToComboBoxItemIndex  ttype_to_inex   fbhd.boolToStringsMI  boolToStringsMI   fbhd.URLtoVideoID  URLtoVideoID1  URLtoVideoID#   fbhd.TaskStatusToUIvisibility  TaskStatusToUIvisibility  ProgressBarStyle1 �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius # ComboBoxDisabledForegroundBrush	 �� Color # ComboBoxDisabledBackgroundBrush 	 ComboBoxDisabledBorderBrush %
 !ToggleButtonControlTemplateflattt
 � ColumnDefinitions F�Name �� Triggers P� Property P� Value �� 
TargetName  ComboBoxFlatStyle_miVersion d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �Name � AllowsTransparency �� IsDropDownOpen �Name  J� SnapsToDevicePixels! � ActualWidth" �� MaxDropDownHeight-  'System.Windows.Input.KeyboardNavigation#   DirectionalNavigation  MiTB_Highlightable$ �� 	Resources  Key% �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame& �� KeyTime' �� Value( �� Triggers) :� RoutedEvent* N� EnterActions+ ��Name  	Highlight, N� ExitActions  uNHighlight��%k  &	        &	      &	 
     &	      &	      &	      &	      &	 �     &	 �     &		 �     &	
 �     7  7  7 	 7  &	     7  &	 	    7  7              �� " �.���  � �� �� " �.R�� .+��� $ 
PART_Track��#��z��$��1q�$ 2���� $ PART_Indicator��$
��Left=�#��z��$��1q�$ 2���� $
	 #888���� $
	 #eee���� $
	 #888���� " d�.R�� 
 �� �� $��20 �.+��� $ Border��$��2�����	#FF2F2F37$ 0��$��
1, 1, 1, 1q�
���   ��� $ ButtonBorder��$��1��$��
1, 1, 1, 1q����	#FF2F2F37$ 
0, 0, 0, 0��$��
0, 0, 0, 0q����	#FF040404F� $ Arrow��$��1��=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=����	#FF929292$��Center=� P�  �@J�IsMouseOver . . ��� $ Border�� � �� �	#FF43434F�� $ ButtonBorder�� � �� �	#FF3A3A3AP�  �@d�	IsChecked$
 TrueY�. ��� $ ButtonBorder�� � �� �	#FF3A3A3A�� $ Arrow�� � �� �	#FFB5C1C9P�  � {� .  . ��� $ Border��8    � ���� $ ButtonBorder��8   � ���� $ ButtonBorder��8   � ���� 8   � ���� $ Arrow�� � �� �#999�� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � �� �	#FFB6B6B6��  �@�FocusVisualStyle Z� ��  � �� �� " ��.R�� .+�d� $ ToggleButton��$��2��$ Press=�|�.  #��� 
 
���   � �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $ ContentSite��$��5, 3, 23, 3q� .  $
��Left=�$��Center=�#��z #��z #��z���� $ PART_EditableTextBox��$��3, 3, 23, 3q�# z $y�Visible=�
������ $
��Left=�$��Center=�|�. .������ " ��.R��� $ PART_ContentHost��|�.  .��� $ Popup��$��Bottom=�|�.   . #��z $��Slide=�.��� $ DropDown��  . #��z! #��z" .+��� $ DropDownBorder�����	#FF212121$��
0, 1, 0, 0q�$ 0��$��1,1,1,1q����	#FF4F4F4F�� $��4q�  . .���� $# 	Contained=� P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 95��P�  � {� .  . ��� 8    � ��P�  �@��
IsGrouping . . ���  � �� .  P�  �@��
IsEditable . . ���  �@ 	IsTabStop .  �� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=��� " ��$ ���� zaga �� 	Highlight .���� $6% 0(TextElement.Foreground).(SolidColorBrush.Color)�.g�  $& 0:0:0.1��$' #FFFFFF���� uNHighlight .���� $6% 0(TextElement.Foreground).(SolidColorBrush.Color)�.g�  $& 0:0:0.2��$' 	#FFC1C1C1��( :� $) FrameworkElement.Loaded��P�  �@J�IsMouseOver . * �� $+ Highlight_BeginStoryboard��8��  , �� 8�� .���  � ��$ NoWrap=���  � ��$
 None=�.���� .+��� -   $ ID��$��54�����	#FF2D2D30$��1q�._�� -   $ 
TaskiIdgRD��- � RowDefinitions- �� $	��14* ��� $	��13* �
 �� $��48 ��� .+�� -   $ grd_type��$��2��$��0,0,0,6q�$��1��$��1��
 �� $��40 ��� $
��100* ��� $	��39* �.+��� -   . ��Name$. lbl_type��$	��0,2q�$
��Wrap=�$��Type:��$��Center=����	#FFD5D5D5&   System.Windows.Media.TextOptions/   TextFormattingMode$/ Display=�$
��Left=�	  fbhd.TypeComboBox	  -   0 	 Name$0 typePickerCombo��
���   ����	#FF2F2F37#���  1 � ToolTip$1 	Task Type��$��Center=�$��1��$
��Left=�$��58��$/ Display=����	#FFDAD7D72 �� SelectedIndex2 �� *SelectedTask.Type+3 �� 	Converter#3 [  4 �� FallbackValue$4 0��$ TwoWay=�.@��� $	��MP3��$/ Display=��� $	��MP4�����	#FFC5C5C5$/ Display=���Z� �� $	��MKV��$/ Display=��� $	��JPG��$/ Display=��� -   5 ��Name$5 ShowInfoWindowButton��$��2��$��Right=�$��0,0,10,0q�  SimplerStyleMi#���  ���	#00000000$��16��$��16��$��Center=�$1 Show Post Info����Z� {��� *coreTaskObject.IsResolved+6 �� ElementName$6 userControl��.���� -   7 ��Name$
7 info��$%��information-b-on-w-13-large.png��$��13��$��13���� -	   $5 CopyLinkButt��$��2��$��	31,2,31,1q�#���  ���	#00000000$��16��$y�	Collapsed=���Z� .���� -
   $7 info1��$%��information-b-on-w-13-large.png��$��13��$��13��� -   $ grd_urle��$��0q�$��1��$��Center=�
 �� $��40 ��� .+��� -   $
. URL_��$��0,3.5q�$
��Wrap=�$
��URL:��$��Center=����	#FFD5D5D5$/ Display=�$
��Left=�#���  �� -   $. lblTaskName��$��WrapWithOverflow=����	#FFC1C1C1$/ Display=�$��Center=�$��2��$��1��$��CharacterEllipsis=�$	��270��#���  ���� *coreTaskObject.Url+8 �� ConverterParameter$8 50��#3 [ $6 userControl��$4 -��1 �� *coreTaskObject.Url+$6 userControl��� -   $ typeIcon��$��0q�$��2��$��Center=�$��Center=�$��48��$��48��.+��� -   $7 image��$��0q�$��32��$��32��$��Center=�$��Center=�$
��None=����� *Image+$6 userControl��9 �� UpdateSourceTrigger$9 PropertyChanged=�� -   $ taskStatusBigGraphics��$��0,3,0,2q�
 �� $	��13* ��� $	��25* �.+�� -   $ 
grd_status��}�. $��2��.+�� -   $ graphics_resolving��$��0q�$��40��$	��Top=�y��� *coreTaskObject.Status+$8 	resolving��#3 [ $6 userControl��$4 	collapsed��
 �� $��48 ��� .+�� -   $ resolvingGridc��: J� RenderTransformOrigin$: 0.5,0.5&�$��32��$��1,0,0,0q�$	��Top=�$��Center=�.+�%
  Microsoft.Expression.Shapes.Arc
  ; 
  ArcThickness$; 3Q�< 
  ArcThicknessUnit$< Pixel=�= 
  EndAngle$	= 360Q�$��0q�> �� Stretch$
> None=�? 
  
StartAngle$? 0Q����	#FF5CAE9B$��31��$��31��$��Right=�$��Bottom=�@ J� Opacity$	@ 0.8Q�� -   $ rotatingRect��$��5��$��0q�$��Center=�A J� OpacityMaskA �	#FFBFBFBF$��31��$��Center=�
���   �$: 0.5,0.5&��� -   $. lbl_Status1��$��	4,11,0,11q�$
��Wrap=�$��Resolving post�����	#FFBDBDBD$��10.667(�$
��Left=�$��Center=�$/ Display=�$��18��$��1��   fbhd.ButtonMi  $��Right=�$��18��$��
0,11,10,11q�$��59��B   textcaption$B Cancel��C   
iconSource$C media/x-16-white.png��$��Center=�$��1��D   captionVisibility$D Visible=�� -   $ graphics_down��$��0,0,0,2q�$��60��$	��Top=�y��� *coreTaskObject.Status+$8 downloading��#3 [ $6 userControl��$4 	collapsed��- �� �� $
��9.25 ��� $��12.75 �
 �� $��48 ��� .+�� -   $ 	down_anim��$: 0.5,0.5&�$��32��$��31��$y�Visible=�$	��Top=�$��8,4,8,0q�$��Center=�.+�� $
��Left=�$��5,5,0,6q�$��6��.+��� -   $7 dowloadAnim_line��$"��media/32-down-white-line.png��$
��Left=�$	��Top=�$��2��$��2,0,0,0q��� -   $7 dowloadAnim_drive��$��0q�$��media/32-down-white.png��$	@ 0.7Q�$
��Left=�$	��Top=��� -   $. 
lbl_Status��$��0q�$
��Wrap=����	#FFBDBDBD$��10.667(�$
��Left=�$��Center=�$/ Display=�$��1������ * coreTaskObject.ProgressCaption+$6 userControl��� -   E �Name$E progressBar_download��$	��2,0q�#���  ���	#FF3E3D3D���	#0004B081���	#FF9C9C9CF � Maximum$F 1Q�$��2��$��1��$��6��G � ValueG �� *#!coreTaskObject.downloadingPercent+$6 userControl��$ OneWay=�  fbhd.ProgressInfoUI  $��1��$��Right=�$��Center=�$��0,0,10,0q�H   ProgressH �� *coreTaskObject.FfmpegProgress+$6 userControl������ "  .R��� $. PART_TEXTBLOCK��-   $��0q�$
��Wrap=����	#FFBDBDBD$��10.667(�$��Stretch=�$��Stretch=�$/ Display=�
I � Tag$I 0��$��1�����	#FF020202$��50��$��10��$��-��J �� TextAlignment$J Right=�  -   K  Name$K 	kill_butt��   fbhd.ButtonMiL   Click$L kill_butt_Click��$1 Kill Process��$��0,1,15,0q�$
��Auto��$��Right=�$
B Kill��$C media/x-16-white.png��M   captionMargin$M 3,0,0,0q�$��1��$��2��$D Visible=�  -   $K 	pauseButt��$L abort_butt_Click��$
1 Stop��$��0,1,70,0q�$
��Auto��$��Right=�$
B Stop��$$C media/pause16white-perfect.png��$��1��$��2��$D Visible=��� -   $. elapsed_time��$��81,1,0,0q�$
��Wrap=����	#FFBDBDBD$��10.667(�$	��Top=�$/ Display=�$I 0��$��(Elapsed time: 0:56)��$
��Left=�$��1��$��2��$y�Hidden=�� -    $ graphics_done��$��0q�$	��Top=�y��� *coreTaskObject.Status+$
8 done��#3 [ $6 userControl��$4 visible��- �� �� $��32 �
 �� $��48 ��� .+��� -!   $7 done_i��$��0q�$"��media/check-32-aqagreen3.png��$y�Visible=�$��Center=�$��Center=�$��32��$��32��� -"   $ Wraper��$��1��$��0q�$��40��- �� �� .+��� -#   $. lbl_outputPath��$��0q�$
��Wrap=����	#FFD5D5D5$��10.667(�$
��Left=�$��Center=�$/ Display=�#���  ���� *coreTaskObject.OutputFile+$8 40��#3 [ $6 userControl��$4 FILENAME��1 �� *coreTaskObject.OutputFile+$6 userControl���� -$   $. lbl_size��$
��Wrap=����	#FFBDBDBD$��10.667(�$
��Left=�$/ Display=�$��0q�$��1��$��Center=����� *coreTaskObject.OutputFileSize+$6 userControl��$4 Size: -��N �� StringFormat$N 	Size: {0}��  -%   $K 	resetTask��$L resetTask_Click��$��	117,0,5,0q�$ C new-task-lite-16-white.png��$B 
Reset Task��$��Center=�$
��Auto��$M 4,0,0,0q�$��Right=�$��18��$D Visible=�$��1���� -&   $ Actions��$��2��$��0q�$��1��$��Bottom=����	#FF2D2D30$��1q�O �� Padding$	O 4,2q�._�� 
 �� $	��29* ��� $��16 ��� $	��85* �.+�  -'   $K 
miOpenFile��P   PreviewMouseLeftButtonUp$)P #miOpenFile_PreviewMouseLeftButtonUp��$.C (media/play-in-circle-white-16-larger.png��$B 	Open file��$��Stretch=�$
��Auto��$M 4,0,0,0q�$��18��$D Visible=�$1 Open Output File��  -(   $K miOpenLocation��$L miOpenLocation_Click��$��
14,0,104,0q�$2C ,media/folder-open-property-16-white-cyan.png��$B Show in Folder��$��Stretch=�$
��Auto��$M 4,0,0,0q�$��Stretch=�$��18��$��2��$D Visible=�$1 Open output location��  -)   $K miDeleteFile��$L miDeleteFile_Click��$C media/delete-16-white.png��$B Delete File��$��Stretch=�$
��Auto��$M 4,0,0,0q�$��Right=�$��18��$��2��$D Visible=�$1 Delete Output file��� -*   $ missingFileFlag��$��1��$��0q�$��10��$��10��$��Center=�$1 missing file��$y�Hidden=�.+��� -+   $7 image1��$��0q�$��media/error1.png��$��10��$��10��$��Center=�$��Center=�� -,   $ graphics_failed��$��0q�$	��Top=�y��� *coreTaskObject.Status+$8 failed��#3 [ $6 userControl��$4 visible��
 �� $��48 ��� .+��� --   $7 	error_ico��$	��0,2q�$��media/alert-32 (1).png��$��32��$��Center=�$��Center=��� -.   $. lbl_Status_Copy1��$��2,0,0,0q�$
��Wrap=����	#FFE04006$��10.667(�$
��Left=�$��Center=�$/ Display=�$��1������ *coreTaskObject.FailureReason+$6 userControl��$4 Unknown Failur Reason��
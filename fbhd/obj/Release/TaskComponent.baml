   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes     fbhd.TaskComponent   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:fbhd     c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  WThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  -     >�Name$  userControl�� � UseLayoutRounding .  J� SnapsToDevicePixels . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�$��0q����	#00000000 � 	Resources     BooleanToVisibilityConverter-   'fbhd.selectedToBackgroundColorConverter  selectedToBackColor   fbhd.URLtoVideoID  URLtoVideoID#   fbhd.TaskStatusToUIvisibility  TaskStatusToUIvisibility  121 �� 
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
  RenderDefaulted<  6System.Windows.Media.Animation.EasingThicknessKeyFrame1 p� KeyTime2 p� Value3 ��Name  ProgressBarStyle14 ��Name5 �� CornerRadius  smallProgBarFlat " MenuItemControlTemplatecopycmd��%�  &	        &	      &	 
     &	      &	      &	 �    &	 �    &	     7  &	 �    7  &		 �    &	
 �    &	 �    &	 �    &	 �    &	 Z    &	 o    7  7  7  &	 �    &	 �    &	      ��       �� " ��.R�� $
 grid��$��16��$��16�����	#00040405   CommonStates��.   
Normal��  	MouseOver��.	 �� .���� $0
 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ 	#00333333��U� $
 (UIElement.Opacity)�$ image��.\�	  $ 0��$ 1Q�  Pressed��  Disabled��.+��� $ image��$��media/mp3-cool-yellow.png��$��Hidden=�$
��None=�}�. $ mp3 task��$
 0.75Q��� " ��.R�� $
 grid�����	#00040405   CommonStates��.   
Normal��  	MouseOver��.	 �� .���� $0
 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ 	#00333333��U� $
 (UIElement.Opacity)�$ image��.\�	  $ 0��$ 1Q�  Pressed��  Disabled��.+��� $ image��$��Center=�$&�� media/arow-down-white-mi-7x7.png��$��Center=�$��7��$��0q�$��7��$
 0.75Q��� $	 0,1&�$	 0,0&�.��� $ #F6F6F6��$
 0.25Q�� $ #EAE8E8��$
 0.25Q�� $ #DCD9D9��$	 0.8Q�� $ White��$ 1Q��� " o�.���  � ��8   ��  � ��# � ����  � ��# � ����  � ��# � ����  � ��# � ����  � ��# � ����  � �� �� " o�.R��� #��z��#��z��#��z��# z�� . ._��� # z �� " o�.���  � ��8   ��  � ��# � ����  � ��# � ����  � ��# � ����  � ��# � ����  � ��# � ����  � �� �� " o�.R��� #��z��#��z��#��z��# z�� . ._��� # z �� " m�.R��  . .+��� $ Bg��#��z��$ 0��$ 0��#��z��$	��0.5���  �� $��24��$ MenuItemIconColumnGroup��$
��Auto ��� $��4 ��� $��* ��� $��37 ��� $ MenuItemIGTColumnGroup��$
��Auto ��� $��17 �.+��� $
 icon��$��Stretch=�$��0,0,0,1q�$��14��$��14��$&�� media/elet-14-grey-filled-mi.png���� #��z��#��z��$��2��#! z  $��Header��#��z����. # z �� $��4��#��z��#��z" # P� $ Z� % �@m�IconP� % �@m�	IsChecked$ . P� % �@m�IsHighlighted$ . . ��� $& Bg�� � �� �� $	 0,1&�$	 0,0&�.��� $ 	#34C5EBFF��$ 0Q�� $ 	#3481D8FF��$ 1Q��� $& Bg�� � �� �	#8071CBF1P� % � {�$ .  . ���  � �� �	#FF9A9A9A�� " m�.R��  . .+��� $ Bg��#��z��$ 0��$ 0��#��z��$	��0.5���  �� $��24��$ MenuItemIconColumnGroup��$
��Auto ��� $��4 ��� $��* ��� $��37 ��� $ MenuItemIGTColumnGroup��$
��Auto ��� $��17 �.+��� $
 icon��$��Stretch=�$��5,3,5,4q�$��14��$��14��$&�� media/star-14-grey-filled-mi.png���� #��z��#��z��$��2��#! z  $��Header��#��z����. # z �� $��4��#��z��#��z" # P� $ Z� % �@m�IconP� % �@m�	IsChecked$ . P� % �@m�IsHighlighted$ . . ��� $& Bg�� � �� �� $	 0,1&�$	 0,0&�.��� $ 	#34C5EBFF��$ 0Q�� $ 	#3481D8FF��$ 1Q��� $& Bg�� � �� �	#8071CBF1P� % � {�$ .  . ���  � �� �	#FF9A9A9A�� " m�.R��  . .+��� $ Bg��#��z��$ 0��$ 0��#��z��$	��0.5���  �� $��24��$ MenuItemIconColumnGroup��$
��Auto ��� $��4 ��� $��* ��� $��37 ��� $ MenuItemIGTColumnGroup��$
��Auto ��� $��17 �.+��� $
 icon��$��Stretch=�$��0,0,0,1q�$��14��$��14��$��media/enter-grey14-14.png���� #��z��#��z��$��2��#! z  $��Header��#��z����. # z �� $��4��#��z��#��z" # P� $ Z� % �@m�IconP� % �@m�	IsChecked$ . P� % �@m�IsHighlighted$ . . ��� $& Bg�� � �� �� $	 0,1&�$	 0,0&�.��� $ 	#34C5EBFF��$ 0Q�� $ 	#3481D8FF��$ 1Q��� $& Bg�� � �� �	#8071CBF1P� % � {�$ .  . ���  � �� �	#FF9A9A9A�� .���  � �� �� .R��� $	' 1 2R�$��1��#��� �� . $��2q��� $	 0,1&�$	 0,0&�.��� $ #F3F3F3��$ 0Q�� $ #EBEBEB��$	 0.5Q�� $ #DDDDDD��$	 0.5Q�� $ #CDCDCD��$ 1Q��� $( 	#FF707070���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�
  $) Chrome��#* z��#+ z��#- z, #. z��#0 z/  .    CommonStates��.   
Normal��  	MouseOver��.	 �� .��r� $
 (FrameworkElement.Margin)�$ contentPresenter��.	�  $1 0��$2 	564,1,1,1q�  Pressed��.	 �� .��r� $
 (FrameworkElement.Margin)�$ contentPresenter��.	�  $1 0��$2 	506,1,1,1q�  Disabled��._��� $3 contentPresenter��#��z��$��1q���. # z #��z��# P� % �@J�IsKeyboardFocused$ . . ��� $& Chrome�� �@
 RenderDefaulted . P� % �@d�	IsChecked$
$ trueY�. ��� $& Chrome�� �@
 RenderPressed . P� % � {�$ .  . ���  � �� �#ADADAD�� " �.���  � �� �� " �.R�� .+��� $4 
PART_Track��#��z��$��1q�$5 2���� $4 PART_Indicator��$
��Left=�#��z��$��1q�$5 2���� " �.���  � �� �� " �.R�� .+��� $4 
PART_Track��#��z��$��1q�$5 0���� $4 PART_Indicator��$
��Left=�#��z��$��1q�$5 0���� " m�.R��  . .+��� $ Bg��#��z��$ 0��$ 0��#��z��$	��0.5���  �� $��24��$ MenuItemIconColumnGroup��$
��Auto ��� $��4 ��� $��* ��� $��37 ��� $ MenuItemIGTColumnGroup��$
��Auto ��� $��17 �.+��� $
 icon��$��Stretch=�$��0,0,0,1q�$��14��$��14��$)��#media/copy-16-white-commandline.png���� #��z��#��z��$��2��#! z  $��Header��#��z����. # z �� $��4��#��z��#��z" # P� $ Z� % �@m�IconP� % �@m�	IsChecked$ . P� % �@m�IsHighlighted$ . . ��� $& Bg�� � �� �� $	 0,1&�$	 0,0&�.��� $ 	#34C5EBFF��$ 0Q�� $ 	#3481D8FF��$ 1Q��� $& Bg�� � �� �	#8071CBF1P� % � {�$ .  . ���  � �� �	#FF9A9A9A.���� -   $4 grd_main��$	 0,1q�$��1q�
������    -   
Status��.   -   Resolved��.	 �� .���� $6
 0(TextElement.Foreground).(SolidColorBrush.Color)�$ lblUrl��.g�  $ 0��$ 	#FFF3F3F3��  -   NotResolved��.	 �� .���� $6
 0(TextElement.Foreground).(SolidColorBrush.Color)�$ lblUrl��.g�  $ 0��$ 	#FF656565��  -   HoverStatus��.   -   	Hover��  -   
normal��._�� ���	#00000000.+�� $��0q�}�. ���	#00000000 �� �� $��20 ��� $��14 �.+�� $��0,0,5,0q����	#00000000 �� $��5* ��� $	��38* �.+�� -	   $ grd_statusIcon��$��0q�$��Center=�$��Center=�}�. .+��� -
   $ done_i��$��0q�$��media/chec3.png��$��10��$��Center=�y��� *
taskStatus+6 �� ConverterParameter$
6 done��7 �� 	Converter#7 [ 8 �� RelativeSource8 �� *FindAncestor+9 �� AncestorType   fbhd.TaskComponent"9  �� -   $ 	error_ico��$��0q�$��media/error1.png��$��10��$��Center=�y��� *
taskStatus+$6 failed��#7 [ : �� ElementName$: userControl���� -   $ resolving_ico��$��0q�$$��media/resloving-gray-10-10.png��$��10��$��Center=�; J� RenderTransformOrigin$; 0.5,0.5&�y��� *
taskStatus+$6 	resolving��#7 [ $: userControl��� -   $ grd_downloading_anim��$��0q�$��10��$��10��$��Center=�$��Center=�}�. y��� *
taskStatus+$6 downloading��#7 [ $: userControl��.+��� -   $ downloading_ico��$��	0,0,-60,0q�$)��#media/down-small-11-turns-white.png��$��Center=�$; 0.5,0.5&�$y�Visible=�$��10��$	��110��$
��Left=�$
��None=��� -   $4 
url_border��$��0q�$��1q�$5 2�����	#FF2F2F37$��2������ *
taskStatus+$6 
url_column��#7 [ $: userControl��._��� -   < ��Name$< lblUrl��$��WrapWithOverflow=�$	��1,0q����	#FFA4A4A4}�. ���� *url+#7 [ $: userControl��= �� FallbackValue$M= Ghttps://www.facebook.com/DUMMYking.net/videos/575243946572618/?sfnsn=mo��> �� Mode$> OneWay=�� -   $ 
typeSwitch��$��1��$��0,4,3.965,3q�$y�	Collapsed=�.+�   fbhd.ButtonMi  -   ?  Name$? mp3Butt��@   
iconSource$@ media/mp3-cool-yellow.png��
A � Tag$	A mp3��  -   $? mp4Butt��$'@ !media/mp4-cool-magenta-ofiice.png��$	A mp4��$y�	Collapsed=�  -   $? mkvButt��$$@ media/mkvcool-white-office.png��$	A mkv��$y�	Collapsed=�$��0,0,-26.525,0q�  -   $? jpgButt��$@ media/jpg-cool-office.png��$	A jpg��$y�	Collapsed=�$��0,0,-26.525,0q�� -   $ menu1��$��2��$��0q�$��13��$��Center=�$��Center=�$��12��.+��� -   B ��Name$B buttonoptionsdrop��$��Button��#���  ���	#FF040405���	#FF7DCD79 . $��Center=�$��16��$ Options��� -   C �Name$C popup��$��0q�$��Bottom=�$��Right=�D � 	StaysOpenD .  .���� 
���   �$
��Left=�$��0q�$	��Top=�.+�m� -   $��Remove�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#��� 	 m� $��
Properties�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#��� 
 $" R��m� -   $
��Skip�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#���  m� -   $
��Copy�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#���  $" C�� E m� UsesItemContainerTemplateE . .@�m� -   $��ffmpeg args�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#���  m� -   $��post url�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#���  m� -   $��	thumb url�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#���  m� -   $��	video url�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#���  m� -    $��	audio url�����	#FFAAAAAA$ Display=�$��0,0,2,0q�#���  m� $��MenuItem��$	��100��$	��100��F m� StaysOpenOnClickF . � -!   $ MediaTypeSwitchGrd��$��1��$��0,4,3.965,3q�$y�	Collapsed=�.+�  -"   $? mp3Butt1��$@ media/mp3-cool-yellow.png��$	A mp3��  -#   $? mp4Butt1��$'@ !media/mp4-cool-magenta-ofiice.png��$	A mp4��$y�	Collapsed=�  -$   $? mkvButt1��$$@ media/mkvcool-white-office.png��$	A mkv��$y�	Collapsed=�$��0,0,-26.525,0q�  -%   $? jpgButt1��$@ media/jpg-cool-office.png��$	A jpg��$y�	Collapsed=�$��0,0,-26.525,0q�!  fbhd.MediaTypeSwitchControl  -&   G  Name$G MediaTypeSwitch��!  fbhd.MediaTypeSwitchControlH   Shifted$H MediaTypeSwitch_Shifted��$��1��$	��2,0q�I   	IconAudio$I media/wav-16-white.png��J   	IconVideo$J media/video-16-medium.png��K   	IconImage$K media/image-16-small.png��L   ValueL �� *	MediaType+$= 0������ .R�� .+�   fbhd.ButtonWithIcon  M  Name$M PART_BUTTON��N   Icon$N media/wav-16-white.png������ "  .R�� $	 grd�����	#00000000$
 0.85Q�.+��� #��zN $��16��$��16��$��Center=�$��Center=�# P� % �@J�IsMouseOver$ . . ��� $	& grd�� �@J�Opacity$ 1Q�� -'   O �Name$O progressBar_download��$��4��$��0q�#���  $��Bottom=����	#003E3D3D���	#0004B081���	#FF9C9C9CP � Maximum$P 1Q�$��0q�y��� *IsDownloading+#7 [  Q � ValueQ �� *downloadingPercent+$= 0��$> OneWay=�
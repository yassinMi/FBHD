   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes     fbhd.PostInfoWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:fbhd     ]ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero       � Title$  	Post Info��$	��300��$	��458��
�������
���   � J� SnapsToDevicePixels .  � UseLayoutRounding . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�   WindowFlat4#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=� � 	Resources /   )fbhd.VideoRepresentationToDimentionsStrng ( $VideoRepresentationToDimentionsStrng%   fbhd.taskToAvailableResolutions  taskToAvailableResolutions  butt_open_title_piker �� 
TargetType	 �Name'  !System.Windows.VisualStateManager
   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value J� RenderTransformOrigin �� Angle  Button_image ��Name � ToolTip # LBResolutionPickerPanelTemplate K� IsItemsHost �� DataType " LBResolutionPickerItemTemplate ��Name + 'LBResolutionPickerItemContainerTemplate �� 
TargetType �� Property �� Value �� RelativeSource �� AncestorType � 	Resources  Key9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  ��Name! �� Padding" J� Opacity# �� Triggers$ P� Property% P� Value& N� ExitActions' ��Name 	 UnHighlight( N� EnterActions 
 	Highlight  
ListBorder) �� Color  ListBoxResolutionPicker* �� 
TargetName+ ]� 
Conditions, �� Property- �� Value   BooleanToVisibilityConverter  MiExpanderFlat_ToggleButton. F�Name/ �� Stretch  Storyboard1  DisabledForegroundBrush  MiExpanderFlat  
LightBrush  NormalBorderBrush0 � RowDefinitions1 ��Name2 �� CornerRadius3 � ColumnDefinitions  NormalBrush4 � OverridesDefaultStyle5 d� 	IsChecked6 �� Mode  DisabledBackgroundBrush  DisabledBorderBrush	   fbhd.TimeSpanToStringMi  TimeSpanToStringMi  ScrollBarStyle3  VerticalScrollBarBackground7 �� LineUpCommand8 J� IsMouseOver  ScrollBarButton+
  %Microsoft.Windows.Themes.ScrollChrome9 
  ScrollGlyph: ]�Name; ]� DecreaseRepeatButton< �� PageUpCommand  VerticalScrollBarPageButton= ]� IncreaseRepeatButton> �� PageDownCommand? ]� Thumb  SimpleThumbStyle  ThumbControlTemplate1@ �� LineDownCommandA �� ScaleYB �� ScaleXC �� AngleYD �� AngleX  ScrollBarDisabledBackgroundE �� Triggers ! HorizontalScrollBarBackgroundF �� LineLeftCommandG �� PageLeftCommand !  HorizontalScrollBarPageButtonH �� PageRightCommand ! ScrollBarThumbI �� LineRightCommand " ScrollBarStyle2 # 	scrolfaltJ ��NameK ��NameL �� CanContentScrollM �� CanHorizontallyScrollN �� CanVerticallyScrollO ��Name4  .System.Windows.Automation.AutomationPropertiesP   AutomationIdQ � CursorR �� ScrollableHeightS � MaximumT � Minimum*U �� #ComputedVerticalScrollBarVisibilityV �� ViewportHeightW �� ViewportSizeX � ValueY �� ScrollableWidthZ �� Orientation,[ �� %ComputedHorizontalScrollBarVisibility\ �� ViewportWidth $ BorderGapMaskConverter % GroupBoxStyle1] J� OpacityMask^ `� ConverterParameter_ `� 	Converter` �� ElementNamea �� Path & MiTB_Highlightableb �� 	Resourcesc :� RoutedEvent ' uNHighlight   fbhd.URLtoVideoID ( URLtoVideoID1 ) VideoStreamInfoItemTemplate   fbhd.VideoRepresentationd �� FallbackValuee �� 	Converter * AudioStreamsItemsTemplate   fbhd.AudioRepresentation��%�.  &	       &	      &	 
     &	 �    &	 �    (�� �    *local:Resolution+)&	 '    7 	 7 
 &	 �    &	 �    7  &	 �	    &	 �	    7  &	 Z    &	     &	     7  7  7  7  7  7  7  7  7   7   7 ! 7  7  &	" �    7  7  7  7  7 ! 7  7  7  7  7   7   7 ! 7  7  &	# �    &	$ e    &	% j    7 $ &	& �    7 
 7 ' &	( �    &	) �    7  &	* m&        �� " ��.R�� $
	 grid��$��16��$��16�����	#00040405
   CommonStates��.   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ 	#FF333333��  Pressed��  Disabled��.+�� $��0q�$��5��$��Center=�$��Center=�$��5��#��z��$ 0.5,0.5&�z�V� .~��� �� �� $ 0Q�T� �� " ��.R�� $
	 grid��$��16��$��16�����	#00040405
   CommonStates��.   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ 	#00333333���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ grid1��.g�  $ 0��$ 	#00000000��  Pressed��  Disabled��.+��� $ image��$��media/image-16-16.png��$��Hidden=�$
��None=�}�. $ mp3 task��� $	 grid1��$��0q����	#4C000000�� .R��  . $	��289���� $ local:Resolution��.R�� $	��4,2q����	#00000000.+��� $ 	textBlock��$
��Wrap=�$
��Auto��$	��4,2q����� �� " ��.���  � ��
 ���� ��  � �� �� *HorizontalContentAlignment+ �� " ����  � �� �� *VerticalContentAlignment+ �� " ����  � ��$ 2,0,0,0q���  � �� �� " �� ���� 	Highlight .���� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�$ Bd��.g�  $ 0:0:0.1��$ 	#FF05E4B1��U� $ (UIElement.Opacity)�$ Bd��.\�  $ 0:0:0.1��$ 1Q��� UnHighlight .���� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�$ Bd��.g�  $ 0:0:0.1��$ 	#7F959595��U� $ (UIElement.Opacity)�$ Bd��.\�  $ 0:0:0.1��$
 0.85Q�.R��� $  Bd��$��1q����	#0005E4B1#! z�� . ���	#7F959595$	��6,4q�$
" 0.85Q�._��� # z $	��4,2q�# P� $ �@��
IsSelected% . & �� $!' UnHighlight_BeginStoryboard��8��  ( �� $' Highlight_BeginStoryboard��8�� �� $) #828790���� " ��.���  � ��# � ����  � ��8   ��  � ��$ 1q���  � ��# � ����  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��$ Center=���  � �� �� " ��.R��� $  Bd��#��z��#��z��#��z��$! 1q� . ._��� # z # P� $ � {�% .  . ��� $* Bd��# � �� � ��]� + �� , �@��
IsGrouping- . �� ", �@%�IsVirtualizingWhenGrouping- .  ./���  � �� .  �� �� " d� ���� Storyboard1 .R�� ���	#00000000.+�F� $. 
Down_Arrow��$��Center=�$��Center=�
�������������1i��@r�u�'�ΐ�@��n.dd�� @^2h�U?�V�!@�wa��U?�V�!@^2h�U?�V�!@��n�U?�V�!@r�u�.dd�� @r�u'�ΐ�@r�u�1i��@r�u	
������� .  . $��7��$��7��$��0q�$
/ Fill=�$y�	Collapsed=�F� $. Up_Arrow��$y�Visible=�$��Center=�$��Center=����	#00444444,����]k�SU�P@"X	�_��28
�]k�SU�P@�C	$��5��$��9��
�������$��0q�$
/ Fill=�# P� $ �@J�IsMouseOver% . . ��� $* Up_Arrow�� � �� �	#FF06FFA4�� $* 
Down_Arrow�� � �� �	#FF06FFA4�� $* 
Down_Arrow�� � �� �	#FF06FFA4P� $ � ��% . P� $ �@d�	IsChecked$
% trueY�( �� 8��  . ��� $* Up_Arrow�� � y�$ 	Collapsed=��� $* 
Down_Arrow�� � y�$ Visible=�P� $ � {�% .  . ��� # �   � ���� # �  $* 
Down_Arrow�� � ���� " 9�.���  � ��# �  ��  � ��# �  ��  � �� �� " 9�.R�� 0 �� $
��Auto ��� $1 
ContentRow��$��* �.+��� $  Border��$��0��#��z��#��z��#��z��$2 2,2,0,0��._�� 3 �� $��20 ��� $��* �.+�d� #���  #���  4 . 5 �� *
IsExpanded+$6 TwoWay=� �� *TemplatedParent+�� $��1��$��4q���. $��Header���� $  
ExpandSite��$y�	Collapsed=�$��1�����	#00000000$��1,0,1,1q�$2 0,0,2,2��._��� #��z��#��z��#��z��|�.  # P� $ �@9�
IsExpanded% . . ��� $* 
ExpandSite�� � y�$ Visible=�P� $ � {�% .  . ��� # �  $* Border�� � ���� # �  $* Border�� � ���� # �   � ��	  �� " ��.���  � ��8   ��  �@��IsPressAndHoldEnabled .  ��  �@��IsFlicksEnabled .  ��  � ��# � ����  � ��# � r���  � ��# � r���  � �� �� " ��.R�� $	 Bg�� . 0 �� #��� q��� $��0.00001* ��� #��� q�.+��� #��Z7 #{�z8 8�� $9 UpArrow=�]� $: 
PART_Track����. #{�z8 $��1��; �� #��Z< 8�� = �� #��Z> 8�� ? n� #���  $9 VerticalGripper=�#���  ���	#00F0F0F0�� #��Z@ #{�z8 $��2��8�� $9 	DownArrow=�$ 0.5,0.5&�z�V� .~��� $A -1Q�$B 1Q��� $C 0Q�$D 0Q��� $ 0Q�T� # P� $ � {�% .  . ��� $* Bg��8   � ��E P� $ �@��Orientation$% 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��# � ����  � ��# � ����  � ��8  ��  � �� �� " ��.R�� $	 Bg��#��z�� . 3 �� #��� ���� $��0.00001* ��� #��� ��.+��� #��ZF #{�z8 8�� $9 	LeftArrow=�]� $: 
PART_Track��$��1��#{�z8 ; �� #��ZG 8�� = �� #��ZH 8��	 ? n� 8��
 $9 HorizontalGripper=��� $��2��#��ZI #{�z8 8�� $9 
RightArrow=�# P� $ � {�% .  . ��� $* Bg��8   � ���� " ��.���  � ��8   ��  �@��IsPressAndHoldEnabled .  ��  �@��IsFlicksEnabled .  ��  � ��# � ����  � ��# � r���  � ��# � r���  � �� �� " ��.R�� $	 Bg��#��z�� . 0 �� #��� q��� $��0.00001* ��� #��� q�.+��� #��Z7 #{�z8 8�� $9 UpArrow=�]� $: 
PART_Track����. #{�z8 $��1��; �� #��Z< 8�� = �� #��Z> 8�� ? n� 8�� $9 VerticalGripper=��� #��Z@ #{�z8 $��2��8�� $9 	DownArrow=�# P� $ � {�% .  . ��� $* Bg��8   � ��E P� $ �@��Orientation$% 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 0����  � ��# � ����  � ��# � ����  � ��8  ��  � �� �� " ��.R�� $	 Bg��#��z�� . 3 �� #��� ���� $��0.00001* ��� #��� ��.+��� #��ZF #{�z8 8�� $9 	LeftArrow=�]� $: 
PART_Track��$��1��#{�z8 ; �� #��ZG 8��	 = �� #��ZH 8��
 ? n� 8�� $9 HorizontalGripper=��� $��2��#��ZI #{�z8 8�� $9 
RightArrow=�# P� $ � {�% .  . ��� $* Bg��8   � ���� " ��.R�� $
	 Grid��#��z��3 �� $��* ��� $
��Auto �0 �� $��* ��� $
��Auto �.+��� $J Corner��$��1��#��� ��$��1���� $!K PART_ScrollContentPresenter��#L z��M .  N .  #��z��#��z��$��0��#��z��$��0���� $O PART_VerticalScrollBar��$P VerticalScrollBar��$Q Arrow��$��1��#S zR $T 0Q�$��0��#y�zU #W zV ���	#FF040405#���  X �� *VerticalOffset+$6 OneWay=� �� *TemplatedParent+�� $O PART_HorizontalScrollBar��$P HorizontalScrollBar��$Q Arrow��$��0��#S zY $T 0Q�$Z 
Horizontal=�$��1��#y�z[ #W z\ #��� " X �� *HorizontalOffset+$6 OneWay=� �� *TemplatedParent+�� �� " ��.���  � �� �#D5DFE5��  � ��$ 1q���  � �� �� " ��.R��  . 3 �� $��6 ��� $
��Auto ��� $��* ��� $��6 �0 �� $
��Auto ��� $
��Auto ��� $��* ��� $��6 �.+��� #��z��$��4��$2 4��$��1��$��3����Z� ] `� $^ 7��8_   .1��� $` Header��$a ActualWidth��� $a ActualWidth� �� *Self+�� $a ActualHeight� �� *Self+._��� #��z��#��z��$2 3���� $  Header��$��1��$! 3,1,3,0q�$��0��$��2��._��� $��Header����. # z �� $��2��$��1��#��z��$��2��# z �� " ��b ���� zaga �� 	Highlight .���� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�.g�  $ 0:0:0.1��$ #FFFFFF���� uNHighlight .���� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�.g�  $ 0:0:0.2��$ 	#FFC1C1C1��.���  � ��$ NoWrap=���  � ��$
 None=�E :� $c FrameworkElement.Loaded��P� $ �@J�IsMouseOver% . ( �� $' Highlight_BeginStoryboard��8��  & �� 8��   �� "  .R�� $	 stream_Entry��$��2q�$��80��3 �� $��52 ��� .+�� $	 Header��$��20��$	��Top=�$��44��.+��� $ 	textBlock��$
��Wrap=�$
��Left=�$��Center=�$��38��$��8,0,0,0q����� *FBQualityLabel+$d 3140p��F� +����@B @B р� @B р� �� �@B �� 	���	#FFF4F4F5$
��Left=�$��0q�$
/ Fill=�
���   � .  $��6��$��6��$��Center=��� $��1��$��0,0,9,0q�.+�� $	 keyVal��$��20��$��10,0,0,0q�3 �� $��59 ��� .+��� $ label_Propery2��$��Center=�$��codecs��$
��Wrap=�$��4,0,0,0q�$
��Left=����	#FFCFCFCF�� $ codecsValue��$��0q�$
��Wrap=����	#FFD5D5D5$��10.667(�$��Center=�$ Display=�#��� & $��1��$
��Left=����� *codecs+$d -��� $	 keyVal_Copy��$��20��$��10,0,0,0q�3 �� $��59 ��� .+��� $ label_Propery3��$	��dim��$
��Wrap=�$��4,2,0,2q����	#FFCFCFCF�� $ DimensionsVale��$��0q�$
��Wrap=����	#FFD5D5D5$��10.667(�$ Display=�#��� & $��1��$
��Left=�$��Center=����� 8e   $d -��$6 OneWay=�� $	 keyVal_Copy1��$��10,0,0,0q�3 �� $��59 ��� .+��� $ label_Propery4��$	��Top=�$��BaseURL��$
��Wrap=�$��4,0,0,0q�$
��Left=����	#FFCFCFCF�� $ BaseUrlVlue��$��0q�$
��Wrap=����	#FFD5D5D5$��10.667(�$��Center=�$ Display=�#��� & $��1��$��40��$��CharacterEllipsis=�$
��Left=����� *	BaseUrl+$�d �https://video.fcmn1-1.fna.fbcdn.net/v/t42.1790-2/10000000_113476854118559_8530497262393228175_n.mp4?_nc_cat=1&amp;ccb=1-3&amp;_nc_sid=5aebc0&amp;efg=eyJ2ZW5jb2RlX3RhZyI6ImRhc2hfYXVkaW9fYWFjcF82NF9mcmFnXzJfYXVkaW8ifQ%3D%3D&amp;_nc_ohc=M3F0d4jg3SMAX9cf1zR&amp;_nc_ht=video.fcmn1-1.fna&amp;oh=5ff2a7e47bcef0c0e6d1b07a542e55ac&amp;oe=6093476C��$6 OneWay=��� "  .R�� $	 stream_Entry��$��2q�$��80��3 �� $��52 ��� .+�� $	 Header��$
��Auto��$	��Top=�$��44��.+��� $ 	textBlock��$
��Wrap=�$
��Left=�$	��Top=�$��38��$��8,0,0,0q�
����������� *
mimeType+$d Audio��F� +����@B @B р� @B р� �� �@B �� 	���	#FFF4F4F5$
��Left=�$��0q�$
/ Fill=�
���   � .  $��6��$��6��$��Center=��� $��1��$��0,0,9,0q�.+�� $	 keyVal��$��20��$��10,0,0,0q�3 �� $��59 ��� .+��� $ label_Propery2��$��Center=�$��codecs��$
��Wrap=�$��4,0,0,0q�$
��Left=����	#FFCFCFCF�� $ codecsValue��$��0q�$
��Wrap=����	#FFD5D5D5$��10.667(�$��Center=�$ Display=�#��� & $��1��$
��Left=����� *codecs+$d -��� $	 keyVal_Copy��$��20��$��10,0,0,0q�3 �� $��59 ��� .+��� $ label_Propery3��$��SampRate��$
��Wrap=�$��4,2,0,2q����	#FFCFCFCF�� $ SampRate��$��0q�$
��Wrap=����	#FFD5D5D5$��10.667(�$ Display=�#��� & $��1��$
��Left=�$��Center=����� *samplingRate+$d -��$6 OneWay=�� $	 keyVal_Copy1��$��10,0,0,0q�3 �� $��59 ��� .+��� $ label_Propery4��$	��Top=�$��BaseURL��$
��Wrap=�$��4,0,0,0q�$
��Left=����	#FFCFCFCF�� $ BaseUrlVlue��$��0q�$
��Wrap=����	#FFD5D5D5$��10.667(�$��Center=�$ Display=�#��� & $��1��$��40��$��CharacterEllipsis=�$
��Left=����� *	BaseUrl+$�d �https://video.fcmn1-1.fna.fbcdn.net/v/t42.1790-2/10000000_113476854118559_8530497262393228175_n.mp4?_nc_cat=1&amp;ccb=1-3&amp;_nc_sid=5aebc0&amp;efg=eyJ2ZW5jb2RlX3RhZyI6ImRhc2hfYXVkaW9fYWFjcF82NF9mcmFnXzJfYXVkaW8ifQ%3D%3D&amp;_nc_ohc=M3F0d4jg3SMAX9cf1zR&amp;_nc_ht=video.fcmn1-1.fna&amp;oh=5ff2a7e47bcef0c0e6d1b07a542e55ac&amp;oe=6093476C��$6 OneWay=�.��� $��	0,24,0,10q�.+��� $
��Auto=�#��� # .���� -   f ��Name$f stack_properties��g �� Orientation$g Vertical=�.+�� -   $	 UrlGrd��$
��10,2q�$��34��3 �� $��63 ��� .+��� -   $ label_Propery��$	��URL��$
��Wrap=�$��	4,10,0,10q�$
��Left=����	#FFCFCFCF$��21���� -   $ UrlLbl��$	��0,4q�$
��Wrap=����	#FFD5D5D5$��10.667(�$ Display=�#��� & $��1��$G��Ahttps://web.facebook.com/slanderofficial/videos/2192468374337641/��$
��Left=�$��Center=�� -   $	 MoreInfo��$
��10,0q�3 �� �� �� .+�� -   $	 DurationGrd��$��34��$	��Top=�$��0q�$
��Left=�3 �� $��63 ��� .+��� -   $ label_Propery1��$��Duration��$
��Wrap=�$��	4,10,0,10q����	#FFCFCFCF�� -   $ DurationValue��$
��Wrap=�$��0q����	#FFCFCFCF$��1��$
��Left=�$��Center=����� *
Duration+#e [ $d 3:14:00��� -	   $	 	OwnerInfo��$��34��$	��Top=�$��0q�$��1��$
��Left=�3 �� $��63 ��� .+��� -
   $ label_Propery2��$��Owner��$
��Wrap=�$��	4,10,0,10q����	#FFCFCFCF�� -   $ DurationValue1��$
��Wrap=�$��0q����	#FFCFCFCF$��1��$
��Left=�$��Center=�$��-��� -   $	 DatePostedGrd��$��34��$	��Top=�$��0q�$��2��$
��Left=�3 �� $��63 ��� .+��� -   $ label_Propery3��$��
DatePosted��$
��Wrap=�$��	4,10,0,10q����	#FFCFCFCF�� -   $ DurationValue2��$
��Wrap=�$��0q����	#FFCFCFCF$��1��$
��Left=�$��Center=�$��-��9� -   h 9�Name$h TitlesSection��#���  $��0q�i 9� 
IsExpandedi . $��Titles�����	#FFDCD9D9
���   ���Z� .��� -   $	 grd_resolution_settings1��$��Bottom=�$��0q�$
��Auto��y��� *SelectedTask.HasVideo+#e [ $d Visible��9� -   $h VideoStreamsSection��#���  $��0q�i . $��Video Sources�����	#FFDCD9D9
���   ���Z� .��� -   $	 VideosStreams��$��0q�$��Bottom=�.+��� #��� ) $��20��$��	20,0,10,0q����� *#!DashManifest.VideoRepresentations+9� -   $h AudioStreamsSection��#���  $��0q�$��Audio Sources�����	#FFDCD9D9
���   ���Z� .��� -   $	 AudioStreams��$��Bottom=�$��0q�3 �� .+��� -   j ��Name$j AudStreamsControl��#��� * $��20��$��	20,0,10,0q�$��2������ *#!DashManifest.AudioRepresentations+9� -   $h ImagesSection��#���  $��0q�i . $��Image Sources�����	#FFDCD9D9
���   ���Z� .��� -   $	 grd_resolution_settings2��$��Bottom=�$��0q�$
��Auto��y��� *SelectedTask.HasVideo+#e [ $d Visible��
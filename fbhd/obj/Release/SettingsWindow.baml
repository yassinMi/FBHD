   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes     fbhd.SettingsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:fbhd     c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  WThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 Bei9http://schemas.microsoft.com/expression/2010/interactions  -     � Title$  Settings��$��293.637��$��344.465��
���   � J� SnapsToDevicePixels . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=� � WindowStartupLocation$ CenterOwner=�   WindowFlat4#���    � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � 	Resources    BooleanToVisibilityConverter  TabControlNormalBorderBrush �� Color  	flat_tabs	 �� 
TargetType
 �� Property �� Value �� 
TargetType-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions ��Name � RowDefinitions ��Name ��Name K� IsItemsHost   TabIndex K� ZIndex ��Name   DirectionalNavigation �� Triggers P� Property P� Value �� 
TargetName  TabPanelStyle1  WindowTemplateKey ��Name ]� 
Conditions �� Property �� Value  WindowStyleflat  �Name! ��Name  butto-dialog-x
" � Tag# � ToolTip$ J� RenderTransformOrigin% ��Name& �� Triggers'  !System.Windows.VisualStateManager'   VisualStateGroups%  System.Windows.VisualStateGroup(   States   System.Windows.VisualState)   
Storyboard* �� TargetProperty+ �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame, �� KeyTime- �� Value. ��Name  RadioTabSwitchMi   fbhd.RadioWithIcon0  *Microsoft.Expression.Shapes.RegularPolygon/  Name0   InnerRadius1   
PointCount2 �� Stretch3 �� ScaleY4 �� ScaleX5 �� AngleY6 �� AngleX7 �� Angle8   Icon9 �� ContentStringFormat: �� ContentStringFormat; �� StrokeDashArray 	 
buttonPlus 
 ScrollBarStyle3  VerticalScrollBarBackground< �� LineUpCommand= J� IsMouseOver  ScrollBarButton+	  %Microsoft.Windows.Themes.ScrollChrome> 	  ScrollGlyph? ]�Name@ ]� DecreaseRepeatButtonA �� PageUpCommand  VerticalScrollBarPageButtonB ]� IncreaseRepeatButtonC �� PageDownCommandD ]� Thumb  SimpleThumbStyle  ThumbControlTemplate1E �� LineDownCommand  ScrollBarDisabledBackground ! HorizontalScrollBarBackgroundF �� LineLeftCommandG �� PageLeftCommand ! HorizontalScrollBarPageButtonH �� PageRightCommand  ScrollBarThumbI �� LineRightCommand  ScrollBarStyle2  	scrolfaltJ ��NameK ��NameL �� CanContentScrollM �� CanHorizontallyScrollN �� CanVerticallyScrollO ��Name4
  .System.Windows.Automation.AutomationPropertiesP 
  AutomationIdQ � CursorR �� ScrollableHeightS � MaximumT � Minimum*U �� #ComputedVerticalScrollBarVisibilityV �� ViewportHeightW �� ViewportSizeX � ValueY �� ModeZ �� RelativeSource[ �� ScrollableWidth\ �� Orientation,] �� %ComputedHorizontalScrollBarVisibility^ �� ViewportWidth  BorderGapMaskConverter  GroupBoxStyle1_ �� CornerRadius` J� OpacityMaska `� ConverterParameterb `� 	Converterc �� ElementNamed �� Pathe �� Padding  autoloadClwPresetTemplatef �� DataType   fbhd.CLWPresetDeclarationg ��Nameh �� TextWrapping  SimpleTextBoxi ��Namej d� 	IsChecked  FlatButt��%Y"  &	       &	      &	      7  &	 s    &	 }    &	 �    7  &	 �
    &	 �    &		 �    &	
 N    7  7  7  7  7  7  7  7  7  7  7  7  7  &	 �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	     &	 �    &	 �    7  &	 �    �� �� $ #8C8E94���� "	 ��.��� 
 � ��# � ���� 
 � ��$ 4,4,4,4q��� 
 � ��$ 1q��� 
 � ��8   �� 
 � �� �#F9F9F9�� 
 � ��$ Center=��� 
 � ��$ Center=��� 
 � �� �� " ��.R�� }�.  . $ Local=� �� $ ColumnDefinition0���� $ ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+��� $ HeaderPanel��$��0�� . $��
-6,10,10,0q�$��1��$ 1��$ 1��$��19.96��$	��Top=��� $ ContentPanel��#��z��#��z��#��z��$��0��$ 	Contained=�$��1��$ 2��$ Local=�._��� $ tabPanel��$��-74,48.04,0,37q�$
��Left=�$	��147��b� $��Stretch=�$��19��$��-32,-35,88,0q�$��1��$	��Top=�$
��Auto�� P�  �@��TabStripPlacement$ Bottom=�. ��� $ HeaderPanel��
 � ��$ 1���� $ ContentPanel��
 � ��$ 0���� $ RowDefinition0��
 � ��$ * ��� $ RowDefinition1��
 � ��$
 Auto ��� $ HeaderPanel��
 � ��$ 2,0,2,2q�P�  �@��TabStripPlacement$
 Left=�. ��� $ HeaderPanel��
 � ��$ 0���� $ ContentPanel��
 � ��$ 0���� $ HeaderPanel��
 � ��$ 0���� $ ContentPanel��
 � ��$ 1���� $ ColumnDefinition0��
 � ��$
 Auto ��� $ ColumnDefinition1��
 � ��$ * ��� $ RowDefinition0��
 � ��$ * ��� $ RowDefinition1��
 � ��$ 0 ��� $ HeaderPanel��
 � ��$ 2,2,0,2q�P�  �@��TabStripPlacement$ Right=�. ��� $ HeaderPanel��
 � ��$ 0���� $ ContentPanel��
 � ��$ 0���� $ HeaderPanel��
 � ��$ 1���� $ ContentPanel��
 � ��$ 0���� $ ColumnDefinition0��
 � ��$ * ��� $ ColumnDefinition1��
 � ��$
 Auto ��� $ RowDefinition0��
 � ��$ * ��� $ RowDefinition1��
 � ��$ 0 ��� $ HeaderPanel��
 � ��$ 0,2,2,2q�P�  � {� .  . ��� # � ��
 � ���� "	 ���� " �.R��� #��z��#��z��#��z��._�� .+��� .u��� �� $ WindowResizeGrip��$��Right=���.  $y�	Collapsed=�$��Bottom=� ]�  ��  �@�
ResizeMode$ CanResizeWithGrip=���  �@�WindowState$ Normal=�./��� $ WindowResizeGrip��
 � y�$ Visible=��� "	 �.��� 
 � ��# � ���� 
 � ��# � ���� 
 � �� �� " �.R��� ���	#FF9C9C9C$��1q�._�� #��z��.+��� .u��� � $  grd_window_head��$��20��$	��Top=�$��0,0,-0.535,0q�.+��� $! x��$��Button��#���  ���	#FF040405���	#FF7DCD79$��0,0,2,0q� . $	" mp3��$# 	Task type��$��Center=�$��Right=�$$ 0.828,0.469&��� $% textBlock_Copy��$
��Left=�$��5,2,0,0q�$
��Wrap=�$��Center=����	#FFB2AFAF$ Display=�#��z  & P�  �@�
ResizeMode$ CanResizeWithGrip=�. ��� 
 � ��8   �� " ��.R�� $
  grid��$��16��$��16�����	#00040405'   CommonStates��.(   
Normal��  	MouseOver��.) �� .���� $0* *(Panel.Background).(SolidColorBrush.Color)�$
+ grid��.g�  $, 0��$- 	#00333333���� $0* *(Panel.Background).(SolidColorBrush.Color)�$+ grid1��.g�  $, 0��$- 	#00000000��  Pressed��  Disabled��.+��� $. image��$��media/x-white.png��$��Hidden=�$
��None=�}�. $# mp3 task��� $  grid1��$��0q����	#4C000000�� "  .R�� $  mainGrid��#��z��.+�  $/ triangle��#��z��$��Right=�$
��Auto��$0 1Q�$��	0,0,-14,0q�$1 3Q�$
2 Fill=�$$ 0.5,0.5&�$��28����Z� z�V� .~��� $3 -1Q�$4 1Q��� $5 0Q�$6 0Q��� $7 0Q�T� � $��16��$��4,0,0,0q� �� $��16 ��� .+��� $. IconPart��#��z8 $��0q�$��Center=�$��Center=�$��16��$��16���� #��z��#��z��#: z9 #��z��#��z����. #��z��$��1�� P�  � �� . . ��� 
 �@�FocusVisualStyle �� .��� 
 � �� �� .R��� $��14,0,0,0q� . #��� ��$��1��$	; 1 2R��� 
 � ��$ 4,0,0,0q�P�  � {� .  . ��� # � ��
 � ��P�  �@d�	IsChecked$ falseY�. ��� $ triangle��
 � ��
 ���� �� $ mainGrid��
 � ��
 ���� �� " ��.R�� $
  grid��$��16��$��16�����	#00040405'   CommonStates��.(   
Normal��  	MouseOver��.) �� .���� $0* *(Panel.Background).(SolidColorBrush.Color)�$
+ grid��.g�  $, 0��$- 	#FF333333��  Pressed��  Disabled��.+�� $��0q�$��Center=�$��Center=�$��2��$��8��#��z��� $��0q�$��8��$��Center=�$��Center=�$��2��#��z���� "	 ��.��� 
 � ��8   �� 
 �@��IsPressAndHoldEnabled .  �� 
 �@��IsFlicksEnabled .  �� 
 � ��# � ���� 
 � ��# � r��� 
 � ��# � r��� 
 � �� �� " ��.R�� $  Bg�� .  �� #��� q��� $��0.00001* ��� #��� q�.+��� #��Z< #{�z= 8�� $> UpArrow=�]� $? 
PART_Track����. #{�z= $��1��@ �� #��ZA 8�� B �� #��ZC 8�� D n� #���  $> VerticalGripper=�#���  ���	#00F0F0F0�� #��ZE #{�z= $��2��8�� $> 	DownArrow=�$$ 0.5,0.5&�z�V� .~��� $3 -1Q�$4 1Q��� $5 0Q�$6 0Q��� $7 0Q�T�  P�  � {� .  . ��� $ Bg��8  
 � ��& P�  �@��Orientation$ 
Horizontal=�. ��� 
 � ��$
 Auto���� 
 � ��$ 0���� 
 � ��# � ���� 
 � ��# � ���� 
 � ��8  �� 
 � �� �� " ��.R�� $  Bg��#��z�� .  �� #��� ���� $��0.00001* ��� #��� ��.+��� #��ZF #{�z= 8�� $> 	LeftArrow=�]� $? 
PART_Track��$��1��#{�z= @ �� #��ZG 8�� B �� #��ZH 8��	 D n� 8��
 $> HorizontalGripper=��� $��2��#��ZI #{�z= 8�� $> 
RightArrow=� P�  � {� .  . ��� $ Bg��8  
 � ���� "	 ��.��� 
 � ��8   �� 
 �@��IsPressAndHoldEnabled .  �� 
 �@��IsFlicksEnabled .  �� 
 � ��# � ���� 
 � ��# � r��� 
 � ��# � r��� 
 � �� �� " ��.R�� $  Bg��#��z�� .  �� #��� q��� $��0.00001* ��� #��� q�.+��� #��Z< #{�z= 8�� $> UpArrow=�]� $? 
PART_Track����. #{�z= $��1��@ �� #��ZA 8�� B �� #��ZC 8�� D n� 8�� $> VerticalGripper=��� #��ZE #{�z= $��2��8�� $> 	DownArrow=� P�  � {� .  . ��� $ Bg��8  
 � ��& P�  �@��Orientation$ 
Horizontal=�. ��� 
 � ��$
 Auto���� 
 � ��$ 0���� 
 � ��# � ���� 
 � ��# � ���� 
 � ��8  �� 
 � �� �� " ��.R�� $  Bg��#��z�� .  �� #��� ���� $��0.00001* ��� #��� ��.+��� #��ZF #{�z= 8�� $> 	LeftArrow=�]� $? 
PART_Track��$��1��#{�z= @ �� #��ZG 8��	 B �� #��ZH 8��
 D n� 8�� $> HorizontalGripper=��� $��2��#��ZI #{�z= 8�� $> 
RightArrow=� P�  � {� .  . ��� $ Bg��8  
 � ���� " ��.R�� $
  Grid��#��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $J Corner��$��1��#��� ��$��1���� $!K PART_ScrollContentPresenter��#L z��M .  N .  #��z��#��z��$��0��#��z��$��0���� $O PART_VerticalScrollBar��$P VerticalScrollBar��$Q Arrow��$��1��#S zR $T 0Q�$��0��#y�zU #W zV ���	#FF040405#��� 
 X �� *VerticalOffset+$Y OneWay=�Z �� *TemplatedParent+�� $O PART_HorizontalScrollBar��$P HorizontalScrollBar��$Q Arrow��$��0��#S z[ $T 0Q�$\ 
Horizontal=�$��1��#y�z] #W z^ #���  X �� *HorizontalOffset+$Y OneWay=�Z �� *TemplatedParent+�� �� "	 ��.��� 
 � �� �#D5DFE5�� 
 � ��$ 1q��� 
 � �� �� " ��.R��  .  �� $��6 ��� $
��Auto ��� $��* ��� $��6 � �� $
��Auto ��� $
��Auto ��� $��* ��� $��6 �.+��� #��z��$��4��$_ 4��$��1��$��3����Z� ` `� $a 7��8b   .1��� $c Header��$d ActualWidth��� $d ActualWidth�Z �� *Self+�� $d ActualHeight�Z �� *Self+._��� #��z��#��z��$_ 3���� $ Header��$��1��$e 3,1,3,0q�$��0��$��2��._��� $��Header����. # z �� $��2��$��1��#��z��$��2��# z �� "f  .R��  �� $��26 ��� $��26 ��� �� $��31 �.+��� $g PresetPathTB��$��2��$
��10,0q�$
h Wrap=�#���  
���   ����	#FFBDBDBD���	#FF2F2F37$��Center=����� *Path+�� $i 
autoLoadCB��$�� ��$��Center=�$��0q�$
��Auto�����	#FFDEDEDE$��Center=�$# 	Auto load��$��1��j �� *
AutoLoad+$Y TwoWay=��� $i AutoStartCb��$�� ��$��Center=�$��0q�$
��Auto��$��Center=����	#FFEAEAEA$# 
Auto start��j �� *	AutoStart+$Y TwoWay=��� $! BrowseButton_Copy��$��···��$��3��$��0q�#���  $��Center=�$��Center=�$��28��.��� k � UseLayoutRoundingk .  �� �� $��39 ��� $��27 �. 	 (System.Windows.Interactivity.Interactionl   	Behaviorsl A  ;Microsoft.Expression.Interactivity.Layout.FluidMoveBehavior  .+�� -   $  General_Settings��$��
20,30,20,4q�y��� *	IsChecked+m �� 	Converter#m [ $c 
GeneralTab��.+��� $��0,0,0,4q�n �� Orientation$n Vertical=�.+�� $��Center=�$��31��$��0,4,10,4q� �� $��83 ��� �� $��31 �.+��� -   $g OutputDirectoryTB��$��1��$��0,4,10,4q�$
h Wrap=�#���  
���   ����	#FFBDBDBD���	#FF2F2F37���� *GlobalOutputDirectory+$Y TwoWay=��� -   $!! outputDirectoryBrowseButton��$��···��$��2��$��0q�#���  $��Center=�$��Center=�$��28���� -   $% 
textBlock7��$��0q�$
��Wrap=�$��Global Output�����	#FFDEDEDE$��Center=�� $��31��$��	0,4,122,4q�$	��Top=�o J� Effecto 9  3Microsoft.Expression.Media.Effects.MonochromeEffect  p   Color$p 	#FF818181��.+��� -   q ��Name$q comboBox��  mi_flat_combo#���  $��Right=�$��73��r �� SelectedIndex$r 0��$	��0,4q�s �� 
IsReadOnlys . .@��� $��curl.exe���� $��ffmpeg���� $��
powershell���� -   $% 	textBlock��$
��Left=�$��0q�$
��Wrap=�$��Download with��$��85�����	#FFF7F7F7$��Center=�$D# >in raw download mode, what tool to use for downloading streams��d� -   t d�Name$t toggleButton��$��Show ffmpeg window��$��	0,4,122,4q�  MiServerStyleToggle#���  ���	#FFE8E6E6$��31��d� -	   $t toggleButton_Copy��$��Raw Download��$��	0,4,122,4q�#���  ���	#FFF3F3F3$3# -Download streams as is before processing them��$��31��� -
   $  CLW_Settings��$��
20,30,10,2q�y��� *	IsChecked+#m [ $c CLWTab��.+��� $��0,0,0,2q�#���  $
��Auto=�.���� $n Vertical=�.+��� -   u ��Name$u gb_AutoLoadList��$��Auto-Load List��$��0,0,10,0q�$ Display=�$��Stretch=�$
��Auto��#���  ���	#FFD5D5D5���	#FF2F2F37k . .��� -   $  
grd_wraper��$��5,5,-2,5q�k .  �� $��33 ��� .+�� -   $  controls��$��0,10,0,5q�k .  �� $	��33* ��� $	��33* ��� $	��34* ��� $	��33* ��� $��20 ��� $��20 ��� $��20 ��� $��20 �.+��� -   $! addItemButt��$��Button��#��� 	 ���	#FF040405���	#FF7DCD79$��Center=�$	��0,1q�$��7��$��16��$��16��$��Right=�$# Add new��   fbhd.ButtonMi  -   v  Name$v RemoveItemButt��$��6��$��Center=�$��0q�$��Center=�w   
iconSource$w minus-16-white.png��$
��Auto��$# Import list���� -   x ��Name$x listBox��$��0q�$��1��
���   ����	#FFD6D6D6#���  $��30����Z� ���� *CLWPresetsDeclarations+� $	��229��$
��Left=�$��Center=�$	��0,4q�$��31��.+��� -   $% 
textBlock3��$
��Left=�$��0q�$
��Wrap=�$��Default Interval��$	��108�����	#FFF7F7F7$��Center=�$D# >in raw download mode, what tool to use for downloading streams��� $	��229��$
��Left=�$��Center=�$	��0,4q�$��31��.+��� -   $q 	comboBox2��#���  $��Right=�$��97��$r 0��$	��0,4q�.@��� $��Notification���� $��Popup���� $
��None���� -   $% 
textBlock2��$
��Left=�$��0q�$
��Wrap=�$��Default Action��$	��108�����	#FFF7F7F7$��Center=�$D# >in raw download mode, what tool to use for downloading streams��� $	��229��$
��Left=�$��Center=�$	��0,4q�$��31��.+��� -   $q 	comboBox4��#���  $��Right=�$��89��$r 0��$	��0,4q�.@��� $��Default���� $��Custom..���� -   $% 
textBlock4��$
��Left=�$��0q�$
��Wrap=�$��Notification Sound��$	��108�����	#FFF7F7F7$��Center=�$D# >in raw download mode, what tool to use for downloading streams���� -   y ��Name$y TabsSwitchGrd��$��0,7,0,0q�$n 
Horizontal=�$��2��.+�  -   z  Name$z 
GeneralTab��#���  $
��Left=����	#FF303030���	#FFF0EFF1$-8 'media/code-in-square-16-white-small.png��$��General��$	��4,0q�$
j TrueY���Z�   -   $z 	SearshTab��#���  $
��Left=����	#FF303030���	#FFF0EFF1$*8 $media/search-in-square-16-white2.png��$��Search��$	��4,0q���Z�   -   $z CLWTab��#���  $
��Left=����	#FF303030���	#FFF0EFF1$*8 $media/search-in-square-16-white2.png��$	��CLW��$	��4,0q�$
j TrueY���Z�   -   $z searchViewTabSwitch_Copy1��#���  $
��Left=����	#FF303030���	#FFF0EFF1$*8 $media/search-in-square-16-white2.png��$��Server��$	��4,0q���Z� �� -   $! 
SaveConfig��$
��Save��$��Right=�$��0,0,10,0q�$��1��$��Center=�#���  $��42��$��22��
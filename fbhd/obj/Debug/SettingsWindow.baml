   M S B A M L   `   `   `  ����?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  5   	   a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 5   I       fbhd.SettingsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:fbhd     5   	   c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5   	   WThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  6I   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   6�   c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 6�   Bei9http://schemas.microsoft.com/expression/2010/interactions  6(  -   5          � Title$  Settings��5	   	   $��293.637��6   $��344.465��6+   
���   � J� SnapsToDevicePixels . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6i    � WindowStartupLocation$ CenterOwner=�6�      WindowFlat4#���   6�    � WindowStyle$
 None=�6�    � 
ResizeMode$ NoResize=�6�    � ShowInTaskbar .   � 	Resources 5
         BooleanToVisibilityConverter  TabControlNormalBorderBrush �� Color  	flat_tabs	 �� 
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
  AutomationIdQ � CursorR �� ScrollableHeightS � MaximumT � Minimum*U �� #ComputedVerticalScrollBarVisibilityV �� ViewportHeightW �� ViewportSizeX � ValueY �� ModeZ �� RelativeSource[ �� ScrollableWidth\ �� Orientation,] �� %ComputedHorizontalScrollBarVisibility^ �� ViewportWidth  BorderGapMaskConverter  GroupBoxStyle1_ �� CornerRadius` J� OpacityMaska `� ConverterParameterb `� 	Converterc �� ElementNamed �� Pathe �� Padding  autoloadClwPresetTemplatef �� DataType   fbhd.CLWPresetDeclarationg ��Nameh �� TextWrapping  SimpleTextBoxi ��Namej d� 	IsChecked  FlatButt��%W9  &	       &	      &	 4     7  &	 �    &	 �    &	 �    7  &	      &	 N    &		 �    &	
 _    7  7  7  7  7  7  7  7  7  7  7  7  7  &	 �$    7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 u,    &	 e0    &	 x0    7  &	 �4    �� 5   
   6'   �� 5   
   $ #8C8E94��6>   �� 5   
   "	 ��6"   .�5      �� 
 � ��# � ��6+   �� 5      
 � ��$ 4,4,4,4q�6(   �� 5      
 � ��$ 1q�60   �� 5      
 � ��8   6,   �� 5      
 � �� �#F9F9F96+   �� 5      
 � ��$ Center=�6;   �� 5      
 � ��$ Center=�69   �� 5      
 � �� 5      �� 5      " ��6&   .R�5      � }�.  . $ Local=�6N    5      �� 5   "   $ ColumnDefinition0��63   �� 5   "   $ ColumnDefinition1��63   $��0 �6N    5      �� 5   "   $ RowDefinition0��60   $
��Auto �6H   �� 5   "   $ RowDefinition1��60   $��* �6H   .+�5!      �� $ HeaderPanel��6'   $��0��6<    . $��
-6,10,10,0q�6_   $��1��6s   $ 1��6�   $ 1��6�   $��19.96��6�   $	��Top=�6�   �� 5"      $ ContentPanel��6%   #��z��6;   #��z��6g   #��z��6�   $��0��6�   $ 	Contained=�6�   $��1��6
  $ 2��6  $ Local=�67  ._�5#   "   �� $ tabPanel��6+   $��-74,48.04,0,37q�6=   $
��Left=�6U   $	��147��6p   5$      b� 5%      $��Stretch=�63   $��19��6Q   $��-32,-35,88,0q�6]   $��1��6s   $	��Top=�6�   $
��Auto��6�   5&       5'      P� 5(       �@��TabStripPlacement$ Bottom=�6C   . �5)   "   �� $ HeaderPanel��6=   
 � ��$ 1��6V   �� 5*   "   $ ContentPanel��6=   
 � ��$ 0��6W   �� 5+   "   $ RowDefinition0��6;   
 � ��$ * �6W   �� 5,   "   $ RowDefinition1��6;   
 � ��$
 Auto �6W   �� 5-   "   $ HeaderPanel��6;   
 � ��$ 2,0,2,2q�6T   5.      P� 5/       �@��TabStripPlacement$
 Left=�6C   . �50   "   �� $ HeaderPanel��6=   
 � ��$ 0��6V   �� 51   "   $ ContentPanel��6=   
 � ��$ 0��6W   �� 52   "   $ HeaderPanel��6@   
 � ��$ 0��6Y   �� 53   "   $ ContentPanel��6@   
 � ��$ 1��6Z   �� 54   "   $ ColumnDefinition0��6:   
 � ��$
 Auto �6Y   �� 55   "   $ ColumnDefinition1��6:   
 � ��$ * �6Y   �� 56   "   $ RowDefinition0��6;   
 � ��$ * �6W   �� 57   "   $ RowDefinition1��6;   
 � ��$ 0 �6W   �� 58   "   $ HeaderPanel��6;   
 � ��$ 2,2,0,2q�6T   59      P� 5:       �@��TabStripPlacement$ Right=�6C   . �5;   "   �� $ HeaderPanel��6=   
 � ��$ 0��6V   �� 5<   "   $ ContentPanel��6=   
 � ��$ 0��6W   �� 5=   "   $ HeaderPanel��6@   
 � ��$ 1��6Y   �� 5>   "   $ ContentPanel��6@   
 � ��$ 0��6Z   �� 5?   "   $ ColumnDefinition0��6:   
 � ��$ * �6Y   �� 5@   "   $ ColumnDefinition1��6:   
 � ��$
 Auto �6Y   �� 5A   "   $ RowDefinition0��6;   
 � ��$ * �6W   �� 5B   "   $ RowDefinition1��6;   
 � ��$ 0 �6W   �� 5C   "   $ HeaderPanel��6;   
 � ��$ 0,2,2,2q�6T   5D      P� 5E       � {� .  . �5F   "   �� # � ��6?   
 � ��5G      5I      5K      5L      �� 5M   
   "	 ��6'   �� 5N   
   " �64   .R�5O      �� #��z��6   #��z��6A   #��z��6u   ._�5P      � .+�5Q      �� .u�5R      �� 5S      �� 5T      $ WindowResizeGrip��6!   $��Right=�6;   ��.  $y�	Collapsed=�6i   $��Bottom=�6�   5U      5V       5W      ]� 5X       5Y      �� 5Z       �@�
ResizeMode$ CanResizeWithGrip=�6:   �� 5[       �@�WindowState$ Normal=�6;   ./�5]      �� $ WindowResizeGrip��63   
 � y�$ Visible=�6Q   5^      5`      �� 5a   
   "	 �6(   .�5b      �� 
 � ��# � ��6+   �� 5c      
 � ��# � ��6+   �� 5d      
 � �� 5e      �� 5f      " �6&   .R�5g      �� ���	#FF9C9C9C$��1q�69   ._�5h      � #��z��6#   .+�5i   "   �� .u�5j   &   �� 5k   #   � 5l   "   $  grd_window_head��6'   $��20��6@   $	��Top=�6L   $��0,0,-0.535,0q�6d   .+�5m   &   �� $! x��6-   $��Button��68   #���  6I   ���	#FF040405���	#FF7DCD79$��0,0,2,0q�6�    . $	" mp3��6�   $# 	Task type��6�   $��Center=�6�   $��Right=�6  $$ 0.828,0.469&�6$  �� 5n   &   $% textBlock_Copy��60   $
��Left=�6H   $��5,2,0,0q�6c   $
��Wrap=�6t   $��Center=�6�   ���	#FFB2AFAF$ Display=�6�   #��z  6�   5o   #   5p      5q      5r      5t      & 5u      P� 5v       �@�
ResizeMode$ CanResizeWithGrip=�60   . �5w      �� 
 � ��8   61   5x      5z      �� 5{   
   " ��61   .R�5|      � $
  grid��6   $��16��6!   $��16��6,   ���	#00040405' 5}        5~      CommonStates��.( 5        
Normal��6&     5�      	MouseOver��.) 5�      �� .��5�   "   �� $0* *(Panel.Background).(SolidColorBrush.Color)�6?   $
+ grid��6�   .g�5�   &     $, 0��6:   $- 	#00333333��6F   5�   #   �� 5�   "   $0* *(Panel.Background).(SolidColorBrush.Color)�6?   $+ grid1��6�   .g�5�   &     $, 0��6:   $- 	#00000000��6F   5�   #   5�      5�        5�      Pressed��6&     5�      Disabled��6&   5�      .+�5�      �� $. image��6   $��media/x-white.png��6'   $��Hidden=�6B   $
��None=�6t   }�. $# mp3 task��6�   � 5�      $  grid1��6   $��0q�6&   ���	#4C00000061   5�      5�      �� 5�   
   "  63   .R�5�      � $  mainGrid��6   #��z��6%   .+�5�        $/ triangle��6$   #��z��67   $��Right=�6[   $
��Auto��6w   $0 1Q�6�   $��	0,0,-14,0q�6�   $1 3Q�6�   $
2 Fill=�6�   $$ 0.5,0.5&�6�   $��28��6�   ��6�   Z� z�5�      V� 5�      .~�5�      �� $3 -1Q�6-   $4 1Q�69   �� 5�      $5 0Q�6,   $6 0Q�67   �� 5�      $7 0Q�6.   T� 5�      5�      5�      � 5�      $��16��6   $��4,0,0,0q�6#    5�      �� 5�      $��16 �6+   �� 5�      .+�5�      �� $. IconPart��6   #��z8 6.   $��0q�6O   $��Center=�6Z   $��Center=�6v   $��16��6�   $��16��6�   �� 5�      #��z��6'   #��z��6[   #: z9 6   #��z��6�   #��z��6�   ��. #��z��6<  $��1��6{  5�      5�       5�      P� 5�       � �� . . �5�      �� 
 �@�FocusVisualStyle 5�      �� 5�      .�5�   "   �� 
 � �� 5�   &   �� 5�   *   .R�5�   .   �� $��14,0,0,0q�68    . #��� ��6e   $��1��6�   $	; 1 2R�6�   5�   +   5�   #   5�      5�      �� 5�      
 � ��$ 4,0,0,0q�60   5�      P� 5�       � {� .  . �5�      �� # � ��63   
 � ��5�      P� 5�       �@d�	IsChecked$ falseY�6/   . �5�      �� $ triangle��6-   
 � ��
 ���� 6C   �� 5�      $ mainGrid��63   
 � ��
 ���� 6I   5�      5�      �� 5�   
   " ��6-   .R�5�      � $
  grid��6   $��16��6!   $��16��6,   ���	#00040405' 5�        5�      CommonStates��.( 5�        
Normal��6&     5�      	MouseOver��.) 5�      �� .��5�   "   �� $0* *(Panel.Background).(SolidColorBrush.Color)�6?   $
+ grid��6�   .g�5�   &     $, 0��6:   $- 	#FF333333��6F   5�   #   5�      5�        5�      Pressed��6&     5�      Disabled��6&   5�      .+�5�      � $��0q�6   $��Center=�6"   $��Center=�6?   $��2��6Z   $��8��6d   #��z��6o   � 5�      $��0q�6   $��8��6"   $��Center=�6,   $��Center=�6I   $��2��6d   #��z��6o   5�      5�      �� 5�   
   "	 ��6(   .�5�      �� 
 � ��8   6+   �� 5�      
 �@��IsPressAndHoldEnabled .  6=   �� 5�      
 �@��IsFlicksEnabled .  67   �� 5�      
 � ��# � ��6+   �� 5�      
 � ��# � r�6&   �� 5�      
 � ��# � r�6)   �� 5�      
 � �� 5�      �� 5�      " ��6&   .R�5�      � $  Bg��6    .  5�      �� 5�   "   #��� q�60   �� 5�   "   $��0.00001* �60   �� 5�   "   #��� q�60   .+�5�      �� #��Z< 6+   #{�z= 6X   8�� $> UpArrow=�6�   ]� 5�      $? 
PART_Track��6$   ��. #{�z= 6S   $��1��6}   @ 5�   "   �� 5�   &   #��ZA 63   8�� 6`   B 5�   "   �� 5�   &   #��ZC 63   8�� 6b   D 5�   "   n� 5�   &   #���  6,   $> VerticalGripper=�6W   #���  6�   ���	#00F0F0F06�   5�      �� 5�      #��ZE 6+   #{�z= 6Z   $��2��6�   8�� $> 	DownArrow=�6�   $$ 0.5,0.5&�6�   z�5�   "   V� 5�   &   .~�5�   *   �� $3 -1Q�69   $4 1Q�6E   �� 5�   *   $5 0Q�68   $6 0Q�6C   �� 5�   *   $7 0Q�6:   T� 5�   *   5�   '   5�      5�       5      P� 5      � {� .  . �5  "   �� $ Bg��6?   8  
 � ��6O   5     5     5     & 5     P� 5	      �@��Orientation$ 
Horizontal=�61   . �5
     �� 
 � ��$
 Auto��6.   �� 5     
 � ��$ 0��61   �� 5     
 � ��# � ��6/   �� 5     
 � ��# � ��62   �� 5     
 � ��8  63   �� 5     
 � �� 5     �� 5     " ��6.   .R�5  "   � $  Bg��6'   #��z��63    .  5  &   �� 5  *   #��� ��6;   �� 5  *   $��0.00001* �6;   �� 5  *   #��� ��6;   .+�5  &   �� #��ZF 63   #{�z= 6b   8�� $> 	LeftArrow=�6�   ]� 5  &   $? 
PART_Track��6,   $��1��6@   #{�z= 6P   @ 5  *   �� 5  .   #��ZG 6;   8�� 6j   B 5  *   �� 5  .   #��ZH 6;   8��	 6k   D 5   *   n� 5!  .   8��
 $> HorizontalGripper=�6\   5#  '   �� 5$  &   $��2��63   #��ZI 6C   #{�z= 6s   8�� $> 
RightArrow=�6�   5%  #    5&  "   P� 5'  &    � {� .  . �5(  *   �� $ Bg��6G   8  
 � ��6W   5)  '   5+     5-     5.     50     �� 51  
   "	 ��6(   .�52     �� 
 � ��8   6+   �� 53     
 �@��IsPressAndHoldEnabled .  6=   �� 54     
 �@��IsFlicksEnabled .  67   �� 55     
 � ��# � ��6+   �� 56     
 � ��# � r�6&   �� 57     
 � ��# � r�6)   �� 58     
 � �� 59     �� 5:     " ��6&   .R�5;     � $  Bg��6   #��z��6+    .  5<     �� 5=  "   #��� q�60   �� 5>  "   $��0.00001* �60   �� 5?  "   #��� q�60   .+�5A     �� #��Z< 6+   #{�z= 6X   8�� $> UpArrow=�6�   ]� 5B     $? 
PART_Track��6$   ��. #{�z= 6S   $��1��6}   @ 5C  "   �� 5D  &   #��ZA 63   8�� 6`   B 5F  "   �� 5G  &   #��ZC 63   8�� 6b   D 5I  "   n� 5J  &   8�� $> VerticalGripper=�6T   5L     �� 5M     #��ZE 6+   #{�z= 6Z   $��2��6�   8�� $> 	DownArrow=�6�   5N      5O     P� 5P      � {� .  . �5Q  "   �� $ Bg��6?   8  
 � ��6O   5R     5T     5V     & 5W     P� 5X      �@��Orientation$ 
Horizontal=�61   . �5Y     �� 
 � ��$
 Auto��6.   �� 5Z     
 � ��$ 0��61   �� 5[     
 � ��# � ��6/   �� 5\     
 � ��# � ��62   �� 5]     
 � ��8  63   �� 5^     
 � �� 5_     �� 5`     " ��6.   .R�5a  "   � $  Bg��6'   #��z��63    .  5b  &   �� 5c  *   #��� ��6;   �� 5d  *   $��0.00001* �6;   �� 5e  *   #��� ��6;   .+�5g  &   �� #��ZF 63   #{�z= 6b   8�� $> 	LeftArrow=�6�   ]� 5h  &   $? 
PART_Track��6,   $��1��6@   #{�z= 6P   @ 5i  *   �� 5j  .   #��ZG 6;   8��	 6j   B 5l  *   �� 5m  .   #��ZH 6;   8��
 6k   D 5o  *   n� 5p  .   8�� $> HorizontalGripper=�6\   5r  '   �� 5s  &   $��2��63   #��ZI 6C   #{�z= 6s   8�� $> 
RightArrow=�6�   5t  #    5u  "   P� 5v  &    � {� .  . �5w  *   �� $ Bg��6G   8  
 � ��6W   5x  '   5z     5|     5}     5     �� 5�  
   " ��6,   .R�5�     � $
  Grid��6   #��z��6!    5�     �� 5�     $��* �6'   �� 5�     $
��Auto �6'    5�     �� 5�     $��* �6$   �� 5�     $
��Auto �6$   .+�5�     �� $J Corner��6   $��1��6,   #��� ��6<   $��1��6}   �� 5�     $!K PART_ScrollContentPresenter��6)   #L z��6N   M .  N .  #��z��6�   #��z��6�   $��0��6  #��z��6&  $��0��6I  �� 5�     $O PART_VerticalScrollBar��6   $P VerticalScrollBar��6<   $Q Arrow��6r   $��1��6�   #S zR 6�   $T 0Q�6�   $��0��6�   #y�zU 6�   #W zV 6y  ���	#FF040405#��� 
 6�  X 6  �� *VerticalOffset+$Y OneWay=�Z �� *TemplatedParent+6�  �� 5�     $O PART_HorizontalScrollBar��6   $P HorizontalScrollBar��6>   $Q Arrow��6v   $��0��6�   #S z[ 6�   $T 0Q�6�   $\ 
Horizontal=�6�   $��1��6�   #y�z] 6�   #W z^ 6�  #���  6�  X 68  �� *HorizontalOffset+$Y OneWay=�Z �� *TemplatedParent+6�  5�     5�     �� 5�  
   6!   �� 5�  
   "	 ��6'   .�5�     �� 
 � �� �#D5DFE56,   �� 5�     
 � ��$ 1q�60   �� 5�     
 � �� 5�     �� 5�     " ��6&   .R�5�     �  .  5�     �� 5�  "   $��6 �63   �� 5�  "   $
��Auto �63   �� 5�  "   $��* �63   �� 5�  "   $��6 �63    5�     �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $��* �60   �� 5�  "   $��6 �60   .+�5�     �� #��z��6<   $��4��6p   $_ 4��6�   $��1��6�   $��3��6�   ��6%   Z� ` 5�  "   `� 5�  &   $a 7��63   8b   .1�5�  *   �� $c Header��62   $d ActualWidth�6G   �� 5�  *   $d ActualWidth�62   Z 6E   �� *Self+�� 5�  *   $d ActualHeight�62   Z 6F   �� *Self+5�  '   ._�5�  "   �� #��z��6)   #��z��6U   $_ 3��6�   5�     �� 5�     $ Header��6%   $��1��65   $e 3,1,3,0q�6E   $��0��6W   $��2��6d   ._�5�  "   �� $��Header��63   ��. # z 6e   5�     �� 5�     $��2��6/   $��1��6C   #��z��6S   $��2��6v   # z 6�   5�     5�     5�     5�     �� 5�  
   "f  69   .R�5�     �  5�     �� 5�     $��26 �6'   �� 5�     $��26 �6'   �� 5�     �� 5�     $��31 �6'   .+�5�     �� $g PresetPathTB��6   $��2��60   $
��10,0q�6@   $
h Wrap=�6N   #���  6x   
���   ����	#FFBDBDBD���	#FF2F2F37$��Center=�6�   ��6b   �� *Path+6�   �� 5�     $i 
autoLoadCB��6   $�� ��6/   $��Center=�6:   $��0q�6W   $
��Auto��6b   ���	#FFDEDEDE$��Center=�6�   $# 	Auto load��6�   $��1��6�   j 6�   �� *
AutoLoad+$Y TwoWay=��� 5�     $i AutoStartCb��6   $�� ��60   $��Center=�6;   $��0q�6X   $
��Auto��6c   $��Center=�6�   ���	#FFEAEAEA$# 
Auto start��6�   j 6�   �� *	AutoStart+$Y TwoWay=��� 5�     $! BrowseButton_Copy��6   $��···��64   $��3��6B   $��0q�6R   #���  6]   $��Center=�6�   $��Center=�6�   $��28��6�   5�     5�     5�     .��5�     � k � UseLayoutRoundingk .  5�  
   �� 5�     �� 5�     $��39 �6   �� 5�     $��27 �6   . 	 (System.Windows.Interactivity.Interactionl   	Behaviorsl 5�  
   A  ;Microsoft.Expression.Interactivity.Layout.FluidMoveBehavior  5�     .+�5�  
   � -   5        $  General_Settings��5�     $��
20,30,20,4q�6)   y�6=   �� *	IsChecked+m �� 	Converter#m [ $c 
GeneralTab��.+�5�     �� $��0,0,0,4q�6   n �� Orientation$n Vertical=�6*   .+�5�     � $��Center=�6   $��31��62   $��0,4,10,4q�6>    5�     �� 5�     $��83 �6+   �� 5�     �� 5�     $��31 �6+   .+�5�     �� -   5        $g OutputDirectoryTB��5�     $��1��69   $��0,4,10,4q�6I   $
h Wrap=�6[   #���  6�   
���   ����	#FFBDBDBD���	#FF2F2F37��6o   �� *GlobalOutputDirectory+$Y TwoWay=�6�   �� 5�     -   5        $!! outputDirectoryBrowseButton��5�     $��···��6B   $��2��6P   $��0q�6`   #���  6k   $��Center=�6�   $��Center=�6�   $��28��6�   6�   �� 5�     -   5        $% 
textBlock7��5�      $��0q�64   $
��Wrap=�6?   $��Global Output��6S   ���	#FFDEDEDE$��Center=�6   5�     � 5�     $��31��6   $��	0,4,122,4q�6#   $	��Top=�66   o J� Effecto 5�     9  3Microsoft.Expression.Media.Effects.MonochromeEffect  5�     p   Color$p 	#FF818181��6.   .+�5�     �� -   5        q ��Name$q comboBox��5�       mi_flat_combo#���  61   $��Right=�6Y   $��73��6u   r �� SelectedIndex$r 0��6�   $	��0,4q�6�   s �� 
IsReadOnlys . .@�5�     �� $��curl.exe��6'   �� 5�     $��ffmpeg��6'   �� 5�     $��
powershell��6'   5�     �� 5�     -   5        $% 	textBlock��5�      $
��Left=�63   $��0q�6N   $
��Wrap=�6Y   $��Download with��6m   $��85��6�   ���	#FFF7F7F7$��Center=�6�   $D# >in raw download mode, what tool to use for downloading streams��6�   5�     d� 5�     -   5        t d�Name$t toggleButton��5�     $��Show ffmpeg window��65   $��	0,4,122,4q�6R     MiServerStyleToggle#���  6e   ���	#FFE8E6E6$��31��6�   d� 5�     -	   5        $t toggleButton_Copy��5�     $��Raw Download��6:   $��	0,4,122,4q�6Q   #���  6d   ���	#FFF3F3F3$3# -Download streams as is before processing them��6�   $��31��6�   5�     5�     � 5�  
   -
   5        $  CLW_Settings��5�     $��
20,30,10,2q�6%   y�69   �� *	IsChecked+#m [ $c CLWTab��.+�5�     �� $��0,0,0,2q�6   #���  6G   $
��Auto=�6n   .��5�     �� $n Vertical=�6   .+�5�     �� -   5        u ��Name$u gb_AutoLoadList��5�     $��Auto-Load List��68   $��0,0,10,0q�6P   $ Display=�6b   $��Stretch=�6�   $
��Auto��6�   #���  6�   ���	#FFD5D5D5���	#FF2F2F37k . .��5�     � -   5        $  
grd_wraper��5�     $��5,5,-2,5q�63   k .  5�     �� 5�  "   $��33 �60   �� 5�  "   .+�5�     � -   5        $  controls��5�  #   $��0,10,0,5q�65   k .  5�  "   �� 5�  &   $	��33* �67   �� 5�  &   $	��33* �67   �� 5�  &   $	��34* �67   �� 5�  &   $	��33* �67   �� 5�  &   $��20 �67   �� 5�  &   $��20 �67   �� 5�  &   $��20 �67   �� 5�  &   $��20 �67   .+�5�  "   �� -   5        $! addItemButt��5�  )   $��Button��6>   #��� 	 6O   ���	#FF040405���	#FF7DCD79$��Center=�6�   $	��0,1q�6�   $��7��6�   $��16��6�   $��16��6�   $��Right=�6�   $# Add new��6     fbhd.ButtonMi  5   "   -   5        v  Name$v RemoveItemButt��5   1   $��6��6I   $��Center=�6Y   $��0q�6v   $��Center=�6�   w   
iconSource$w minus-16-white.png��6�   $
��Auto��6�   $# Import list��6�   5     �� 5     -   5        x ��Name$x listBox��5  &   $��0q�67   $��1��6B   
���   ����	#FFD6D6D6#���  6�   $��30��6�   ��6y   Z� ��6�   �� *CLWPresetsDeclarations+6�   5     5     � 5     $	��229��6K   $
��Left=�6W   $��Center=�6r   $	��0,4q�6�   $��31��6�   .+�5     �� -   5        $% 
textBlock3��5  $   $
��Left=�68   $��0q�6S   $
��Wrap=�6^   $��Default Interval��6r   $	��108��6�   ���	#FFF7F7F7$��Center=�6�   $D# >in raw download mode, what tool to use for downloading streams��6�   5     � 5	     $	��229��6K   $
��Left=�6W   $��Center=�6r   $	��0,4q�6�   $��31��6�   .+�5
     �� -   5        $q 	comboBox2��5
  #   #���  66   $��Right=�6^   $��97��6z   $r 0��6�   $	��0,4q�6�   .@�5     �� $��Notification��6+   �� 5     $��Popup��6+   �� 5     $
��None��6+   5     �� 5     -   5        $% 
textBlock2��5  $   $
��Left=�68   $��0q�6S   $
��Wrap=�6^   $��Default Action��6r   $	��108��6�   ���	#FFF7F7F7$��Center=�6�   $D# >in raw download mode, what tool to use for downloading streams��6�   5     � 5     $	��229��6K   $
��Left=�6W   $��Center=�6r   $	��0,4q�6�   $��31��6�   .+�5     �� -   5        $q 	comboBox4��5  #   #���  66   $��Right=�6^   $��89��6z   $r 0��6�   $	��0,4q�6�   .@�5     �� $��Default��6+   �� 5     $��Custom..��6+   5     �� 5     -   5        $% 
textBlock4��5  $   $
��Left=�68   $��0q�6S   $
��Wrap=�6^   $��Notification Sound��6r   $	��108��6�   ���	#FFF7F7F7$��Center=�6�   $D# >in raw download mode, what tool to use for downloading streams��6�   5     5     5     5     �� 5  
   -   5        y ��Name$y TabsSwitchGrd��5     $��0,7,0,0q�6,   $n 
Horizontal=�6=   $��2��6V   .+�5       -   5        z  Name$z 
GeneralTab��5  "   #���  66   $
��Left=�6d   ���	#FF303030���	#FFF0EFF1$-8 'media/code-in-square-16-white-small.png��6�   $��General��6�   $	��4,0q�6  $
j TrueY�6B  ��6�   Z� 6B    5     -   5        $z 	SearshTab��5  "   #���  65   $
��Left=�6c   ���	#FF303030���	#FFF0EFF1$*8 $media/search-in-square-16-white2.png��6�   $��Search��6�   $	��4,0q�60  ��6�   Z� 60    5      -   5        $z CLWTab��5   "   #���  62   $
��Left=�6`   ���	#FF303030���	#FFF0EFF1$*8 $media/search-in-square-16-white2.png��6�   $	��CLW��6�   $	��4,0q�6�   $
j TrueY�67  ��6�   Z� 67    5!     -   5        $z searchViewTabSwitch_Copy1��5!  "   #���  6E   $
��Left=�6s   ���	#FF303030���	#FFF0EFF1$*8 $media/search-in-square-16-white2.png��6�   $��Server��6�   $	��4,0q�6  ��6�   Z� 6  5"     �� 5#  
   -   5        $! 
SaveConfig��5#     $
��Save��6%   $��Right=�64   $��0,0,10,0q�6P   $��1��6b   $��Center=�6o   #���  6�   $��42��6�   $��22��6�   5$     5%     
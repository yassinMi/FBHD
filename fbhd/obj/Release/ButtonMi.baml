   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.ButtonMi   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:fbhd     h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   -     >�Name$  userControl�� � UseLayoutRounding . $
��Left=�$	��Top=�$��42.525�� � 	Resources    121 �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value ��Name J� Opacity �� RelativeSource �� AncestorType   fbhd.ButtonMi  buttmicorebutt��%�  &	        &	 �    �� " ��.R�� $
 grid��$��16��$��16�����	#00040405   CommonStates��.   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
	 grid��.g�  $
 0��$ 	#00333333��U� $ (UIElement.Opacity)�$	 image��.\�  $ 0��$ 1Q�  Pressed��  Disabled��.+��� $ image��$��Hidden=�$
��None=�}�. $
 0.75Q����� *
iconSource+ �� *FindAncestor+"  �� " ��.R�� $
 grid��$��16��$��16�����	#00040405   CommonStates��.   
Normal��. �� .��U� $ (UIElement.Opacity)�$	 image��.\�  $ 0��$ 1Q�  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
	 grid��.g�  $
 0��$ 	#00333333��U� $ (UIElement.Opacity)�$	 image��.\�  $ 0��$ 1Q�  Pressed��  Disabled��.+��� $ image��$��Hidden=�$
��None=�}�. $
 0.75Q����� *
iconSource+ �� *FindAncestor+"  .��� $
��Left=�$	��Top=����	#00000000 J� Effect 4  .Microsoft.Expression.Media.Effects.BloomEffect  -   bloo��   BloomIntensity$ 1Q�   BaseSaturation$ 1Q�   BaseIntensity$ 0Q�   BloomSaturation$ 1Q�   	Threshold$ 0Q�   -   VisualStateGroup��.   -   	Hover��. �� .���� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�$	 caption��.g�  $
 0��$ White��U� $ (UIElement.Opacity)�$	 caption��.\�  $ 0��$ 1Q�U� $ (UIElement.Opacity)�$	 
coreButton��.\�  $ 0��$ 1Q�  -   
Normal��. �� .��U� $ (UIElement.Opacity)�$	 caption��.\�  $ 0��$ 1Q�  -   Pressed��. �� .��U� $ (UIElement.Opacity)�$	 caption��.\�  $ 0��$ 1Q�  -   disabled��. �� .���� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�$	 caption��.g�  $
 0��$ 	#FF656565��U� $ BloomSaturation�$
	 bloo��.\�  $ 0��$ 0Q�U� $ Opacity�$	 
coreButton��.\�  $ 0��$	 0.4Q�.+���  �� Orientation$ 
Horizontal=�$
��Left=�$	��Top=�.+��� -    ��Name$ 
coreButton��$��Button��#���  ���	#FF040405���	#FF7DCD79$��0q� J� SnapsToDevicePixels . 
 � Tag$	 mp3��$
��Left=�$��Center=�$
 0.75Q��� -	    ��Name$ caption��$
��Wrap=����	#FFD5D5D5&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=����� *textcaption+ �� ElementName$ userControl������ *captionMargin+$ userControl��y��� *captionVisibility+$ userControl��
   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.CLWControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:fbhd     h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Microsoft.Expression.Effects, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?ee4http://schemas.microsoft.com/expression/2010/effects   -     >�Name$  userControl�� � UseLayoutRounding . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�$
��Left=� � 	Resources    fbhd.boolToStringsMI   boolToStringsMI  ComboBoxFlatStyle_miVersion �� 
TargetType �� Property �� Value �� 
TargetType d�Name	 �� 	ClickMode % !ToggleButtonControlTemplateflattt
 d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly ��Name �Name � AllowsTransparency �� IsDropDownOpen �Name J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight �� CornerRadius-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers P� Property  P� Value! �� 
TargetName # ComboBoxDisabledForegroundBrush   BooleanToVisibilityConverter&    fbhd.BooleanToVisibilityInverted  BooleanToVisibilityInverted��%)  &	        &	      7  &	 �    &	 �      �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � �� �	#FFB6B6B6��  �@�FocusVisualStyle Z� ��  � �� �� " ��.R�� .+�d� $ ToggleButton��$��2��$	 Press=�|�.  #���  
���   �
 �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $ ContentSite��$��5, 3, 23, 3q� .  $
��Left=�$��Center=�#��z #��z #��z���� $ PART_EditableTextBox��$��3, 3, 23, 3q�# z $y�Visible=�
������ $
��Left=�$��Center=�|�. .������ " ��.R��� $ PART_ContentHost��|�.  .��� $ Popup��$��Bottom=�|�.   . #��z $��Slide=�.��� $ DropDown�� . #��z #��z .+��� $ DropDownBorder�����	#FF212121$��
0, 1, 0, 0q�$ 0��$��1,1,1,1q����	#FF4F4F4F�� $��4q� . .���� $ 	Contained=� P�  �@��HasItems  .  . ��� $! DropDownBorder�� � ��$ 95��P�  � {�  .  . ��� 8    � ��P�  �@��
IsGrouping  . . ���  � �� .  P�  �@��
IsEditable  . . ���  �@ 	IsTabStop .  �� $! PART_EditableTextBox�� � y�$ Visible=��� $! ContentSite�� � y�$ Hidden=���   .��� $
��Left=�.+�� -   $	 CLW��$��0q����	#00464646$��21��$��Center=�$
��Left=�.+�   fbhd.ButtonMi  -   "  Name$" 
mainButton��   fbhd.ButtonMi#   Click$# mainButton_Click��$��0q�$��Center=�$   
iconSource$$ bell-16-orange-filled.png��%   captionVisibility$% Visible=�$
��Left=�$
��Auto�����	#FF41F1F1&   captionMargin$& 1,0,0,0q�'   textcaption' �� *Name+( �� FallbackValue$( Name long qee��) J� Effect) 4  .Microsoft.Expression.Media.Effects.BloomEffect  *   BaseSaturation$* 1Q�+   	Threshold$	+ 0.5Q�,   BloomSaturation$, 0Q�-   BloomIntensity- �� *
IsWatching+. �� ConverterParameter$. 	1:0; 0:1;��/ �� 	Converter#/ [  0   BaseIntensity0 �� *
IsWatching+$. 	1:1; 0:0;��#/ [  � -   $ 	mainPopup��$	��Top=�1 � 	StaysOpen1 .  $��	8,0,-8,-1q�.���� $	��131��$��1q����	#00000000���	#FF2F2F37._�� ���	#FF0E0E0F.+��� $��
10,10,10,0q�2 �� Orientation$2 Vertical=�$	��Top=�.+�� -   $ interval��$��23��$	��0,4q�.+�   fbhd.IncreaseTextBox  -   3  Name$3 intervalIncTb��	   fbhd.IncreaseTextBox4 	  Loaded$4 intervalIncTb_Loaded��5 	  
OnDecrease$5 intervalIncTb_OnDecrease��6 	  
OnIncrease$6 intervalIncTb_OnIncrease�����	#FFB6B2B2���	#FF393944$ Display=� . 7 �� 
CaretBrush7 �	#FFEAEAEA$��Right=�8 �� TextAlignment$8 Right=�$��45����Z� ���� *IntervalAsString+.������ "  .R�� .+��� $ Border��#��z��$��1q�#��z��$ 2��9 �� Padding$9 2q�._�� : � ColumnDefinitions: �� �� $��10 �.+��� ; ��Name$; PART_ContentHost��#��z��$��Stretch=�$��0q�  SimpleScrollViewer#���  $��Stretch=�� $��1��$��1��< � RowDefinitions< �� �� $��* �.+��� = ��Name$= PART_INCREASE��$��0q�$��10��$��8��$��Center=�$��Center=����	#00000000���	#FFE4E4E4  SimpleRepeatButton#���  ��Z� .���� > ��Name$> UpIcon��$��8��$��10��$��up-tri-10x8-white.png���� $= PART_DECREASE��$��0q�$��1��$��Center=�$��Center=�$��10��$��8��#���  ���	#00000000��Z� .���� $> DownIcon��$��8��$��10��$��down-tri-10x8-white.png�� P� ? P� 
SourceName$? PART_DECREASE�� �@J�IsMouseOver  . . ��� $! DownIcon�� � ��$ down-tri-10x8-orange.png��P� $? PART_INCREASE�� �@J�IsMouseOver  . . ��� $! UpIcon�� � ��$ up-tri-10x8-orange.png��P�  � {�  .  . ��� $! Border��  DisabledBackgroundBrush# �   � ���� $! Border��# �   � ����  	 DisabledForegroundBrush# � 	  � ��.���� -   @ ��Name$@ intervallbl��$��0,0,42,0q�$
��Wrap=�$��	Interval:�����	#FFCFCFD1$��Center=�$
��Left=�� -   $ Action��$��23��$	��0,4q�.+��� -	   $@ 
actionslbl��$��0,0,42,0q�$
��Wrap=�$��Action:�����	#FFCFCFD1$��Center=�$
��Left=��� -
   A ��Name$A 	comboBox2��$��43,0,0,0q�#���  $��Center=�B �� SelectedIndex$B 0��.@��� $��Popup���� $��Sound���� $��PopupAndSound��� -   $ 	StartStop��$��26��$	��0,4q�.+��� -   C ��Name$C StartStopButt��$
��10,0q� 
 FlatButt#��� 
 $��Center=�$��23������ *
IsWatching+$. 0:Start; 1:Stop;��#/ [  � -   $ Unread��$��20��$��0,4,0,0q����	#00000000y��� *HasUnreadNews+#/ [ $( visible��$ OneWay=�.+��� -   $C UnreadNewsButt��$
��10,0q�  SimpleButton#���  ���	#00000000���	#FFDED8D8��Z� ���� " ��.R�� $
 Grid��.+��� $ Border��#��z��#��z��#��z��#9 z���� #��z��#��z��D �� ContentStringFormatE �� ContentStringFormat#E zD #��z��#��z����. #��z�� P�  �@J�IsMouseOver  . . ��� $! Border�� � �� �	#FFE59102�� $! Border�� � �� �	#FF303030P�  � ��  . . ��� $! Border�� � �� �	#FF2A2A2B�� $! Border�� � �� �	#FFC59646P�  � {�  . P�  � {�  .  . ��� $! Border��# �   � ���� $! Border��  DisabledBorderBrush# �   � ���� # � 	  � ��.��� .+��� -   $@ 
unreadInfo��$��20,1,0,2q�$
��Wrap=����	#FFFFC159$��10.667(�$
��Left=�$��Center=����� *UnreadCount+$( 0 News��F �� StringFormat$F 
{0:D} News��� -   $ bellIcon��$
��Left=�$��16��$��Center=�$��16��.+��� -   $> bellIco��$��16��$��Center=�$$��bell-16-orange-empty-shine.png��$��0q�$��Center=�$��16��� -   $ Status��$��26��$	��0,4q�.+��� -   $@ 
statusText��$��28,0,0,0q�$
��Wrap=����	#FFD6D3D2$��10.667(�$
��Left=�$��Center=����� *StatusMessage+� -   $ 
statusIcon��$
��Left=�$��10,0,0,0q�$��13��$��Center=�$��13��.+��� -   $> errorIco��$��13��$��Center=�$��media/error1.png��$��0q�$��Center=�y��� *	IsFailing+#/ [ �� -   $> infoIco��$��13��$��Center=�$%��information-b-on-w-13-large.png��$��0q�$��Center=�y��� *IsRunningSuccessfully+#/ [ 
   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.NewTaskWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:fbhd     -     � Title$  New task��$	��142��$	��296�� J� SnapsToDevicePixels .  � UseLayoutRounding .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=� � 	Resources    ButtonFolder �� 
TargetType �Name'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name � ToolTip 
 arow-8  butto-dialog-x  TextBoxStyle1multi �� 
TargetType-  'System.Windows.Input.KeyboardNavigation �� Property �� Value ��Name �� Padding �� CornerRadius ��Name  SimpleScrollViewer �� PanningMode �� Triggers P� Property P� Value  DisabledBackgroundBrush �� 
TargetName  DisabledForegroundBrush # ComboBoxDisabledForegroundBrush �� Color # ComboBoxDisabledBackgroundBrush 	 ComboBoxDisabledBorderBrush %
 !ToggleButtonControlTemplateflattt � ColumnDefinitions  F�Name  ComboBoxFlatStyle_miVersion! d�Name" �� 	ClickMode# d� 	IsChecked$ �� Mode% �� RelativeSource& ��Name' J� IsHitTestVisible( �� SelectionBoxItem) �� SelectionBoxItemTemplate* ��Name+ �� 
IsReadOnly, �� 
IsReadOnly- �Name. � AllowsTransparency/ �� IsDropDownOpen0 � ActualWidth1 �� MaxDropDownHeight2   DirectionalNavigation��%N  &	        &	 �    &	 �    &	 �    &	 �    &	 �    &		 �    &	
 �    7  7  7 	 7  &	 �
    7  �� " ��.R�� $
 grid��$��16��$��16�����	#00040405	   CommonStates��.
   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ 	#00333333���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ grid1��.g�  $ 0��$ 	#00000000��  Pressed��  Disabled��.+��� $ image��$��media/folder-16-16.png��$��Hidden=�$
��None=�}�. $ mp3 task��� $ grid1��$��0q����	#4C000000�� " ��.R�� $
 grid��$��16��$��16�����	#00040405	   CommonStates��.
   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ 	#00333333���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ grid1��.g�  $ 0��$ 	#00000000��  Pressed��  Disabled��.+��� $ image��$��media/arow8-16--16.png��$��Hidden=�$
��None=�}�. $ mp3 task��� $ grid1��$��0q����	#4C000000�� " ��.R�� $
 grid��$��16��$��16�����	#00040405	   CommonStates��.
   
Normal��  	MouseOver��. �� .���� $0 *(Panel.Background).(SolidColorBrush.Color)�$
 grid��.g�  $ 0��$ 	#00333333���� $0 *(Panel.Background).(SolidColorBrush.Color)�$ grid1��.g�  $ 0��$ 	#00000000��  Pressed��  Disabled��.+��� $ image��$��media/x-white.png��$��Hidden=�$
��None=�}�. $ mp3 task��� $ grid1��$��0q����	#4C000000�� " ��.���  �@ TabNavigation$
 None=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop . ��  � �� �� " ��.R�� .+��� $ Border��#��z��#��z��$��1q�$ 2q�$ 2��._��� $ PART_ContentHost��$��0q�#���  #��z��$��Stretch=�$��Stretch=�$ HorizontalOnly=� P�  � {� .  . ��� # �  $ Border�� � ���� # �  $ Border�� � ���� # �   � ���� $
 #888���� $
 #eee���� $
 #888���� " d�.R��  �� �� $��20 �.+��� $ Border��$��2�����	#FF2F2F37$ 0��$��
1, 1, 1, 1q�
���   ��� $ ButtonBorder��$��1��$��
1, 1, 1, 1q����	#FF2F2F37$ 
0, 0, 0, 0��$��
0, 0, 0, 0q����	#FF040404F� $  Arrow��$��1��=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$��Center=����	#FF929292$��Center=� P�  �@J�IsMouseOver . . ��� $ Border�� � �� �	#FF43434F�� $ ButtonBorder�� � �� �	#FF3A3A3AP�  �@d�	IsChecked$
 TrueY�. ��� $ ButtonBorder�� � �� �	#FF3A3A3A�� $ Arrow�� � �� �	#FFB5C1C9P�  � {� .  . ��� $ Border��8    � ���� $ ButtonBorder��8   � ���� $ ButtonBorder��8   � ���� 8   � ���� $ Arrow�� � �� �#999�� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � �� �	#FFB6B6B6��  �@�FocusVisualStyle Z� ��  � �� �� " ��.R�� .+�d� $! ToggleButton��$��2��$" Press=�|�.  #��� 
 
���   �# �� *IsDropDownOpen+$$ TwoWay=�% �� *TemplatedParent+�� $& ContentSite��$��5, 3, 23, 3q�' .  $
��Left=�$��Center=�#��z( #��z) #��z���� $* PART_EditableTextBox��$��3, 3, 23, 3q�#, z+ $y�Visible=�
������ $
��Left=�$��Center=�|�. .������ " ��.R��� $ PART_ContentHost��|�.  .��� $- Popup��$��Bottom=�|�.  . . #��z/ $��Slide=�.��� $ DropDown�� . #��z0 #��z1 .+��� $ DropDownBorder�����	#FF212121$��
0, 1, 0, 0q�$ 0��$��1,1,1,1q����	#FF4F4F4F�� $��4q� . .���� $2 	Contained=� P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 95��P�  � {� .  . ��� 8    � ��P�  �@��
IsGrouping . . ���  � �� .  P�  �@��
IsEditable . . ���  �@ 	IsTabStop .  �� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=�.���� ���	#FF898989$��1q�._�� 
���   �.+�� -   $ grd_window_head��$��20��$	��Top=�.+��� -   3 ��Name$3 x��$��Button��#���  ���	#FF040405���	#FF7DCD79$��0,0,2,0q� . 
4 � Tag$	4 mp3��$ 	Task type��$��Center=�$��Right=�5 J� RenderTransformOrigin$5 0.828,0.469&��� -   6 ��Name$6 textBlock_Copy��$
��Left=�$��5,2,0,0q�$
��Wrap=�$��Center=����	#FFB2AFAF&   System.Windows.Media.TextOptions7   TextFormattingMode$7 Display=�$��New task���� $��24,35,29,40q�8 �� Orientation$8 Vertical=�.+�� -   $ grd_url_feild��.+��� -   $6 	textBlock��$
��Left=�$��0q�$
��Wrap=�
�������$7 Display=�$��URL(s)��$��Center=��� -   $* tb_url��#���  9 �� TextWrapping$9 WrapWithOverflow=����	#FFD5D5D5���	#FF2F2F37$7 Display=� . : �� 
CaretBrush: �	#FFEAEAEA$��41,0,0,0q�$��50����Z� � -   $ grd_type��$	��Top=�$��0,7,0,0q� �� $��43 ��� .+��� -	   $6 lbl_type��$��0,3.5q�$
��Wrap=�$��Type:��$��Center=����	#FFD5D5D5$7 Display=�$
��Left=�  fbhd.TypeComboBox  -
   ;  Name$; typecommbo_type��
���   ����	#FF2F2F37#���  $ Overriding behaviour��$��Center=�$��1��$
��Left=�$��58��< �� SelectedIndex$< 0��.@��� $	��MP3��$7 Display=��� $	��MP4�����	#FFC5C5C5$7 Display=���Z� �� $	��MKV��$7 Display=��� $	��JPG��$7 Display=��� -   $3 expand_butt��$��Button��#���  ���	#FF040405���	#FF7DCD79$��115,0,106,0q� . $	4 mp3��$ 	Task type��$	��Top=�$��Center=��� -   $3 okButt��$��Ok��$��25��$��	0,0,10,10q�$��Bottom=�  FlatButt#���  $��Right=�$��76�����	#FF333333���	#FFD5D5D5�� -   $3 
CancelButt��$��Cancel��$��25��$��121,0,91,10q�$��Bottom=�#���  ���	#FF333333���	#FFD5D5D5
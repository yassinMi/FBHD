   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.NotificationWindowMi   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:fbhd     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  -     � Title$  NotificationWindowMi��$	��328�����	#FF1A1A1A � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Topmost . &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=����	#FFD8D8D8$��124.839�� � 	Resources     BooleanToVisibilityConverter��%   &	        ��  � TaskbarItemInfo *  $System.Windows.Shell.TaskbarItemInfo  .���� ���	#FF333333$��1q�._��  � RowDefinitions �� $��20 ��� .+�� $
��Auto�� � UseLayoutRounding . $	��0,4q����	#00640404$��2��.+��� $
��Auto��$��0q����	#002F2F37$��1q�._�� ���	#001C1C1C$
��Auto��$
��Auto��$	��1,0q� �� �� $��51 �.+��� -   	 ��Name$	 title��$��	10,4,17,4q�$��14.667(����	#FFD1D1D1 . $
��Wrap=�}�. 
 J� SnapsToDevicePixels
 . $��Summy title���� -    ��Name$ Actions��$��0,0,0,2q����	#00000000$��1�� �� Orientation$ 
Horizontal=�$��23��$��Bottom=�.+��� -    ��Name$ ShowNewsButt��$��10,0,0,0q�  SimpleButton#���  ���	#00000000���	#FFDED8D8$
��Left=�$	��100��$��20����Z� ����  �� 
TargetType" ��.R��  �Name$
 Grid��.+���  ��Name$ Border��#��z��#��z��#��z�� �� Padding# z���� #��z��#��z�� �� ContentStringFormat �� ContentStringFormat# z #��z��#��z����. #��z�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ Border�� �� Property � �� �� Value �	#FFE59102�� $ Border�� � �� �	#FF303030P�  � �� . . ��� $ Border�� � �� �	#FF2A2A2B�� $ Border�� � �� �	#FFC59646P�  � {� . P�  � {� .  . ��� $ Border��  DisabledBackgroundBrush# �   � ���� $ Border��  DisabledBorderBrush# �   � ����   DisabledForegroundBrush# �   � ��.��� .+��� -   $	 
unreadInfo��$��20,1,0,2q�$
��Wrap=����	#FFFFC159$��10.667(�$
��Left=�$��Center=�$��	Show News��� -   $
 bell��$
��Left=�$��16��$��Center=�$��16��.+��� -    ��Name$ bellIco��$��16��$��Center=�$$��bell-16-orange-empty-shine.png��$��0q�$��Center=�$��16���� -   $ MarkAsReadButt��$��10,0,4,0q�#���  ���	#00000000���	#FFDED8D8$��20����Z� ���� " ��.R�� $
 Grid��.+��� $ Border��#��z��#��z��#��z��# z���� #��z��#��z��# z #��z��#��z����. #��z�� P�  �@J�IsMouseOver . . ��� $ Border�� � �� �	#FFE59102�� $ Border�� � �� �	#FF303030P�  � �� . . ��� $ Border�� � �� �	#FF2A2A2B�� $ Border�� � �� �	#FFC59646P�  � {� . P�  � {� .  . ��� $ Border��# �   � ���� $ Border��# �   � ���� # �   � ��.��� .+��� -	   $	 unreadInfo1��$��20,1,0,2q�$
��Wrap=����	#FFB6B6B6$��10.667(�$
��Left=�$��Center=�$��Mark as read��� -
   $ bell1��$
��Left=�$��16��$��Center=�$��16��.+��� -   $ bellIco1��$��16��$��Center=�$��eye-smouth-16-white.png��$��0q�$��Center=�$��16�� J� Opacity$	 0.7Q�� -   $ LinkOrCount��$��21��$��	10,0,17,0q�$��1��$	��Top=�.+��� -   $	 fastLink��$��10,0,0,0q�$
��Wrap=�$��https://�����	#FF0097FF$
��Left=�$��Center=� � Cursor$
 Hand��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseLeftButtonDown��.  (System.Windows.Interactivity.TriggerBase   Actions. C  =Microsoft.Expression.Interactivity.Core.LaunchUriOrFileAction      Path  �� *Text+! �� ElementName$! fastLink���� -   $	 	countInfo��$��10,0,0,0q�$
��Wrap=�$��and 4 more..�����	#FFA2A2A2$��10.667(�$
��Left=�$��Center=�   fbhd.ButtonMi  -   "  Name$" 	CloseButt��   fbhd.ButtonMi#   Click$# CloseButt_Click��$��Right=�$��16��$��0,4,5,0q�$	��Top=�$��16��$   
iconSource$$ media/x-16-white.png��
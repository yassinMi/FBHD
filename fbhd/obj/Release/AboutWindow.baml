   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.AboutWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:fbhd     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions    � Title$  
About FBHD��$	��284��$	��300�����	#FF282828&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=����	#FFF0F0F0 � WindowStartupLocation$ CenterOwner=����	#FF6A6A6A$��1q�.���  � ColumnDefinitions ��  � RowDefinitions �� $��26 ��� �� $��55 ��� $��43 �.+�� -    �Name$ DragableHead��$��0q�
���   �$��2��.+��� -    ��Name$ 	textBlock��$
��Wrap=�$��About�����	#FF929292$
��Left=�$��Center=�$��10,0,0,0q��� -   $ nameVerison��$��	14,10,0,0q�$��1��$
��Wrap=�$��16(�$	��Top=�$��21��$
��Left=�$	��161������ *FBHD_APP_TITLE+	 �� FallbackValue$	 FBHD Downloader 1.0���� -   $ 	copyright��$��14,36,11.38,0q�$��1��$
��Wrap=�$��13.333(�$��17��$	��Top=����� *FBHD_APP_SUB_TITLE+$	 © Mi 2021 ��F� -   
 F�Name$

 line������@o@ �&���� �&	$��1��$��
14,60,22,0q�$��1�� �� Stretch$
 Fill=����	#FF454551$	��Top=�� $��21,75,10,16q�$��1�� �� $��5* ��� $	��12* � �� �� �� .+��� -   $ versionLabel��$
��Wrap=�$��Version�����	#FFB6B6B6$��0q�$
��Left=�$��Center=��� -   $ version��$��0q�$
��Wrap=����	#FFE2E2E2$��1��$
��Left=�$��Center=����� *FBHD_VERSION+�� -   $ developerLabel��$��0q�$
��Wrap=�$��
Developer:�����	#FFB6B6B6$��1��$
��Left=�$��Center=��� -	   $ 	developer��$��0q�$
��Wrap=����	#FFE2E2E2$
��Left=�$��1��$��1��$��Center=����� *FBHD_DEVELOPER+$	 Yass.Mi���� -
   $ email��$��47,3,0,2q�$
��Wrap=����	#FF0097FF$��1��$��1��$
��Left=�$��Center=����� *FBHD_DEVELOPER_EMAIL+$	 yass@gmail.com���� -   $ UI_Graphics_designerlabel��$
��Wrap=�$��UI/Graphics:�����	#FFB6B6B6$��2��$��0q�$
��Left=�$��Center=��� -   $ graphicsdesigner��$��0q�$
��Wrap=����	#FFE2E2E2$
��Left=�$��2��$��1��$��Center=����� *FBHD_GUI_DESIGNER+$	 Yass.Mi���� -   $ reportBugsLabel��$��21,6,0,0q�$
��Wrap=�$$��Report Issue or contribute at:��$
��Left=�$	��172�����	#FFB6B6B6$��2��$��19��$	��Top=��� -   $ 
githubLink��$��	21,0,0,10q�$��2��$
��Wrap=�$��2�����	#FF0097FF � Cursor$
 Hand��$��Bottom=�$��15��$
��Left=����� *FBHD_GITHUB_URL+$	 mi_github_url��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseLeftButtonDown��.  (System.Windows.Interactivity.TriggerBase   Actions. C  =Microsoft.Expression.Interactivity.Core.LaunchUriOrFileAction     Path$+ %https://github.com/UndefinedYass/fbhd���� -    ��Name$ OkButton��$��OK��$��Right=�$��0,6,15,6q�$��3��   SimpleButton#���   ���	#FFD6D6D6���	#FFD6D6D6$��71��  FlatButt#���  
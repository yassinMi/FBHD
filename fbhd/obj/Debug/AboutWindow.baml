   M S B A M L   `   `   `  ����?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  5   	       fbhd.AboutWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:fbhd     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6N     � Title$  
About FBHD��5	   	   $	��284��6   $	��300��6)   ���	#FF282828&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6L    � 
ResizeMode$ NoResize=�6u    � WindowStyle$
 None=�6�   ���	#FFF0F0F0 � WindowStartupLocation$ CenterOwner=�6�   ���	#FF6A6A6A$��1q�6�   .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $��26 �6   �� 5      �� 5      $��55 �6   �� 5      $��43 �6   .+�5   
   � -   5         �Name$ DragableHead��5      $��0q�6%   
���   �$��2��6C   .+�5      �� -   5         ��Name$ 	textBlock��5      $
��Wrap=�6+   $��About��6?   ���	#FF929292$
��Left=�6c   $��Center=�6~   $��10,0,0,0q�6�   5      �� 5   
   -   5        $ nameVerison��5      $��	14,10,0,0q�6)   $��1��6<   $
��Wrap=�6I   $��16(�6�   $	��Top=�6�   $��21��6�   $
��Left=�6�   $	��161��6�   ��6]   �� *FBHD_APP_TITLE+	 �� FallbackValue$	 FBHD Downloader 1.0��6�   �� 5   
   -   5        $ 	copyright��5      $��14,36,11.38,0q�6'   $��1��6>   $
��Wrap=�6K   $��13.333(�6�   $��17��6�   $	��Top=�6�   ��6_   �� *FBHD_APP_SUB_TITLE+$	 © Mi 2021 ��6�   F� 5   
   -   5        
 F�Name$

 line��5      ����@o@ �&���� �&	$��1��69   $��
14,60,22,0q�6D   $��1��6X    �� Stretch$
 Fill=�6e   ���	#FF454551$	��Top=�6�   � 5   
   $��21,75,10,16q�6   $��1��6$    5       �� 5!      $��5* �6#   �� 5"      $	��12* �6#    5$      �� 5%      �� 5&      �� 5'      .+�5)      �� -   5        $ versionLabel��5)      $
��Wrap=�6.   $��Version��6B   ���	#FFB6B6B6$��0q�6h   $
��Left=�6s   $��Center=�6�   �� 5*      -   5        $ version��5*      $��0q�6)   $
��Wrap=�64   ���	#FFE2E2E2$��1��6}   $
��Left=�6�   $��Center=�6�   ��6H   �� *FBHD_VERSION+6�   �� 5+      -   5        $ developerLabel��5+      $��0q�60   $
��Wrap=�6;   $��
Developer:��6O   ���	#FFB6B6B6$��1��6x   $
��Left=�6�   $��Center=�6�   �� 5,      -	   5        $ 	developer��5,      $��0q�6+   $
��Wrap=�66   ���	#FFE2E2E2$
��Left=�6�   $��1��6�   $��1��6�   $��Center=�6�   ��6J   �� *FBHD_DEVELOPER+$	 Yass.Mi��6�   �� 5-      -
   5        $ email��5-      $��47,3,0,2q�6'   $
��Wrap=�69   ���	#FF0097FF$��1��6�   $��1��6�   $
��Left=�6�   $��Center=�6�   ��6M   �� *FBHD_DEVELOPER_EMAIL+$	 yass@gmail.com��6�   �� 5.      -   5        $ UI_Graphics_designerlabel��5.      $
��Wrap=�6;   $��UI/Graphics:��6O   ���	#FFB6B6B6$��2��6z   $��0q�6�   $
��Left=�6�   $��Center=�6�   �� 5/      -   5        $ graphicsdesigner��5/      $��0q�62   $
��Wrap=�6=   ���	#FFE2E2E2$
��Left=�6�   $��2��6�   $��1��6�   $��Center=�6�   ��6Q   �� *FBHD_GUI_DESIGNER+$	 Yass.Mi��6�   50      �� 51   
   -   5        $ reportBugsLabel��51      $��21,6,0,0q�6-   $
��Wrap=�6?   $$��Report Issue or contribute at:��6S   $
��Left=�6y   $	��172��6�   ���	#FFB6B6B6$��2��6�   $��19��6�   $	��Top=�6�   �� 52   
   -   5        $ 
githubLink��52      $��	21,0,0,10q�6(   $��2��6;   $
��Wrap=�6H   $��2��6�   ���	#FF0097FF � Cursor$
 Hand��6�   $��Bottom=�6�   $��15��6�   $
��Left=�6�   ��6\   �� *FBHD_GITHUB_URL+$	 mi_github_url��.  (System.Windows.Interactivity.Interaction   Triggers 53      /  )System.Windows.Interactivity.EventTrigger  54   	      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 55   
   C  =Microsoft.Expression.Interactivity.Core.LaunchUriOrFileAction     Path$+ %https://github.com/UndefinedYass/fbhd��6#   56   
   58      �� 59   
   -   5         ��Name$ OkButton��59      $��OK��6#   $��Right=�60   $��0,6,15,6q�6L   $��3��6^      SimpleButton#���   6k   ���	#FFD6D6D6���	#FFD6D6D6$��71��6�     FlatButt#���  6�   6�   5;      5<      
   M S B A M L   `   `   `  ����?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd  5          fbhd.CLWItemPresenter   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:fbhd     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  6S   &   System.Windows.Media.TextOptions    TextFormattingMode$  Display=�5	   7    � 	Resources 5
         fbhd.EmptyTextConverter   EmptyTextConverter  MiTB_Highlightable �� 
TargetType �� 	Resources  Key �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value �� Property �� Value	 �� Triggers
 :� RoutedEvent P� Property P� Value N� EnterActions ��Name  	Highlight N� ExitActions  uNHighlight��%  &	        &	      7  7    5   
   6#   �� 5   
   " ��6+    5      ���� 5      zaga 6   �� 5      	Highlight .��5      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�63   .g�5        $ 0:0:0.1��6.   $ #FFFFFF��6@   5      5      �� 5      uNHighlight .��5      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�63   .g�5        $ 0:0:0.2��6.   $ 	#FFC1C1C1��6@   5      5      5      .�5      ��  � ��$ NoWrap=�6-   �� 5       � ��$
 None=�6-   	 5      :� 5      $
 FrameworkElement.Loaded��6   P� 5       �@J�IsMouseOver .  5      �� 5       $ Highlight_BeginStoryboard��6*   8��  6M    5"      �� 5#      8�� 6+   5%      5'      5(      .��5)      � .+�5+   
   �  � UseLayoutRounding . $��0q�6(   ���	#00640404.+�5,      �� $
��Auto��6   $��0q�6#   ���	#FF2F2F37$��1q�6F   ._�5-      � ���	#001C1C1C$
��Auto��6.   $
��Auto��6<   $	��1,0q�6I    � RowDefinitions 5.      �� 5/      �� 50      $
��Auto �6(   �� 51      $
��Auto �6(   .+�53      �� -   5         ��Name$ title��53       $
��Auto��6/   $��	10,0,23,2q�6=   $��14.667(�6�   ���	#FFD1D1D1 . $
��Wrap=�6�   }�.  J� SnapsToDevicePixels . #���  6�  ��6P   �� *Title+ �� FallbackValue$J Divezho hmozehoi hemzoihmioze zlvkjlk lzjml zmjml ezml kmlze mlhmoei �� � ToolTip 6B  �� *Text+ �� RelativeSource �� *Self+6�  �� 54      -   5        $ subTitle��54       $
��Auto��62   $��	10,2,23,2q�6@   ���	#FF929292 . $
��Wrap=�6�   }�.  . $��1��6�   $
��Left=�6  $��Center=�6!  $  Display=�6<  ��6S   �� *
SubTitle+$ 	SUB TITLE��y�6e  �� *
SubTitle+ �� ConverterParameter$
 true�� �� 	Converter# [  �� 55      -   5        $ linklbl��55       $
��Auto��61   $��	10,7,31,6q�6?   $
��Wrap=�6R   ���	#FF007ACC � Cursor$
 Hand��6�   $��2��6�   $��Center=�6�   $��32��6�   $��CharacterEllipsis=�6�   ��6f   �� *Link+$ https://abc.com/News/1�� 6  �� *Text+ �� *Self+.  (System.Windows.Interactivity.Interaction   Triggers 56      /  )System.Windows.Interactivity.EventTrigger  57   	      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 58   
   C  =Microsoft.Expression.Interactivity.Core.LaunchUriOrFileAction     Path 6#   �� *Text+ �� ElementName$ linklbl��59   
   5;      � 5<      $��Right=�6   $��16��67   $��0,10,5,0q�6C   $	��Top=�6U   $��16��6m   .+�5=      �� -   5         ��Name$ moreActionsButton��5=   !   $
��Left=�6<   $��0q�6W   $��Center=�6b     SimplerStyleMi#���  6}   ���	#00000000$
 Menu��6�   $��0q�6  ��6�   Z� .��5>      � $��16��6#   $��16��6/     � ColumnDefinitions  5?   "   �� 5@   &   $��16 �67   �� 5A   &   .+�5C   "   �� -   5        ! ��Name$! image2��5C   (   $'��!media/3dots-vertical-16-white.png��68   $��16��6c   $��	0,0,0.5,0q�6o   $��16��6�   � 5D   "   -   5        " �Name$" moreActionsPopup��5D   (   $��0,0,0,-2q�6B   $��Slide=�6T   $
��Left=�6k   # � 	StaysOpen# .  .��5E   &   �� ���	#FF5B5A5A$��1q�6E   ._�5F   *   �  5G   .   �� 5H   2   �� 5I   2   .+�5K   .   �� -   5        $ DloadButton��5K   5   $��Center=�6J   #���  6e   ���	#00000000$ Download��6�   $
��Left=�6�   $��2,2,0,2q�6�   $��0q�6�   ��6�   Z� .��5L   2   � $��16��67   ���	#00000000  5M   6   �� 5N   :   $��18 �6K   �� 5O   :   .+�5Q   6   �� -   5        $! image1��5Q   <   $#��media/dload-thin-16-white.png��6L   $��16��6s   $��16��6   $��0q�6�   $��Center=�6�   $��Center=�6�   �� 5R   6   -	   5        $ 	textBlock��5R   @   $��16��6S   $��0q�6_   $
��Wrap=�6j   $��Download��6~   $��Center=�6�   ���	#FFDEDEDE$��1��6�   5S   3   5T   /   �� 5U   .   -
   5        $ CopyUrlButt��5U   5   $��Center=�6J   #���  6e   ���	#00000000$ Copy URL to clip��6�   $
��Left=�6�   $��2,2,0,2q�6�   $��1��6  $��0q�6  ��6�   Z� .��5V   2   � $��16��67   ���	#00000000  5W   6   �� 5X   :   $��18 �6K   �� 5Y   :   .+�5[   6   �� -   5        $ 
textBlock1��5[   @   $��16��6T   $��0q�6`   $
��Wrap=�6k   $��Copy Url��6   $��Center=�6�   ���	#FFDEDEDE$��1��6�   �� 5\   6   -   5        $! image3��5\   <   $&�� media/copy-fancy-16-whte-big.png��6L   $��0q�6v   $��Center=�6�   $��Center=�6�   5]   3   5^   /   5_   +   5`   '   5a   #   5b      5c      5e      5g      5h      5i      5k      5l      
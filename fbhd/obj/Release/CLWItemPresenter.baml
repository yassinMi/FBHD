   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.CLWItemPresenter   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:fbhd     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  &   System.Windows.Media.TextOptions    TextFormattingMode$  Display=� � 	Resources    fbhd.EmptyTextConverter   EmptyTextConverter  MiTB_Highlightable �� 
TargetType �� 	Resources  Key �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value �� Property �� Value	 �� Triggers
 :� RoutedEvent P� Property P� Value N� EnterActions ��Name  	Highlight N� ExitActions  uNHighlight��%�  &	        &	      7  7    �� " �� ���� zaga �� 	Highlight .���� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�.g�  $ 0:0:0.1��$ #FFFFFF���� uNHighlight .���� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�.g�  $ 0:0:0.2��$ 	#FFC1C1C1��.���  � ��$ NoWrap=���  � ��$
 None=�	 :� $
 FrameworkElement.Loaded��P�  �@J�IsMouseOver .  �� $ Highlight_BeginStoryboard��8��   �� 8�� .��� .+��  � UseLayoutRounding . $��0q����	#00640404.+��� $
��Auto��$��0q����	#FF2F2F37$��1q�._�� ���	#001C1C1C$
��Auto��$
��Auto��$	��1,0q� � RowDefinitions �� �� $
��Auto ��� $
��Auto �.+��� -    ��Name$ title��$
��Auto��$��	10,0,23,2q�$��14.667(����	#FFD1D1D1 . $
��Wrap=�}�.  J� SnapsToDevicePixels . #���  ���� *Title+ �� FallbackValue$J Divezho hmozehoi hemzoihmioze zlvkjlk lzjml zmjml ezml kmlze mlhmoei �� � ToolTip �� *Text+ �� RelativeSource �� *Self+�� -   $ subTitle��$
��Auto��$��	10,2,23,2q����	#FF929292 . $
��Wrap=�}�.  . $��1��$
��Left=�$��Center=�$  Display=����� *
SubTitle+$ 	SUB TITLE��y��� *
SubTitle+ �� ConverterParameter$
 true�� �� 	Converter# [  �� -   $ linklbl��$
��Auto��$��	10,7,31,6q�$
��Wrap=����	#FF007ACC � Cursor$
 Hand��$��2��$��Center=�$��32��$��CharacterEllipsis=����� *Link+$ https://abc.com/News/1�� �� *Text+ �� *Self+.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ MouseLeftButtonDown��.  (System.Windows.Interactivity.TriggerBase   Actions. C  =Microsoft.Expression.Interactivity.Core.LaunchUriOrFileAction     Path �� *Text+ �� ElementName$ linklbl��� $��Right=�$��16��$��0,10,5,0q�$	��Top=�$��16��.+��� -    ��Name$ moreActionsButton��$
��Left=�$��0q�$��Center=�  SimplerStyleMi#���  ���	#00000000$
 Menu��$��0q���Z� .��� $��16��$��16��  � ColumnDefinitions  �� $��16 ��� .+��� -   ! ��Name$! image2��$'��!media/3dots-vertical-16-white.png��$��16��$��	0,0,0.5,0q�$��16��� -   " �Name$" moreActionsPopup��$��0,0,0,-2q�$��Slide=�$
��Left=�# � 	StaysOpen# .  .���� ���	#FF5B5A5A$��1q�._��  �� �� .+��� -   $ DloadButton��$��Center=�#���  ���	#00000000$ Download��$
��Left=�$��2,2,0,2q�$��0q���Z� .��� $��16�����	#00000000  �� $��18 ��� .+��� -   $! image1��$#��media/dload-thin-16-white.png��$��16��$��16��$��0q�$��Center=�$��Center=��� -	   $ 	textBlock��$��16��$��0q�$
��Wrap=�$��Download��$��Center=����	#FFDEDEDE$��1���� -
   $ CopyUrlButt��$��Center=�#���  ���	#00000000$ Copy URL to clip��$
��Left=�$��2,2,0,2q�$��1��$��0q���Z� .��� $��16�����	#00000000  �� $��18 ��� .+��� -   $ 
textBlock1��$��16��$��0q�$
��Wrap=�$��Copy Url��$��Center=����	#FFDEDEDE$��1���� -   $! image3��$&�� media/copy-fancy-16-whte-big.png��$��0q�$��Center=�$��Center=�
   M S B A M L   `   `   `  ���� ?  ;fbhd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:fbhdfbhd      fbhd.SearchItem   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $localclr-namespace:fbhd     -     >�Name$  userControl�� � UseLayoutRounding . $	��0,2q�.��� $��60��$��60�����	#FF282828.+�� -    �Name$ SearchItem_Copy��$��0q� � ColumnDefinitions �� $��76 ��� �� $��38 �.+�� $	��1,2q�
���   �.+�� $��Center=�$��Center=�$��74��$��42��.+��� -    ��Name$ 	thumb_img��$
��Fill=� J� Opacity$	 0.7Q�$��0q�$
��Left=�$	��Top=�$��42��$��74������ *$"CoreSearchElement.ThumbImageSource+ �� ElementName$ userControl��   fbhd.ButtonMi  -     Name$ 
watch_butt��$��2��$��Stretch=�$��16��$��	4,10,18,0q�   
iconSource$. (media/play-in-circle-white-16-larger.png��	   captionVisibility$	 Visible=�
   textcaption$
 Watch��$
��Auto��   captionMargin$ 4,1,0,0q�$��10.667(�$y�Hidden=�� -   $ Actions��$��1��$��0,0,2,0q�$��16��$��Center=�$��Right=�$��50��$��2�� �� �� �� $��0* � � RowDefinitions �� .+�� -   $ dload��$��16��$��Center=�$��0q�$	��Top=�.+�  -   $ download_butt��   fbhd.ButtonMi   Click$ download_butt_Click��$��Stretch=�$# media/dload-thin-16-white.png��$	 Visible=�$
  ��$��16��$��Stretch=�$ 4,0,0,0q�$��10.667(�� -   $ copyHref��$��16��$��Center=�$��0q�$	��Top=�$��1��.+�  -	   $ copHrefButt��$ copHrefButt_Click��$��Stretch=�$ media/copy-16-white.png��$	 Visible=�$
  ��$��16��$��Stretch=�$ 4,0,0,0q�$��10.667(�� -
   $
 more��$��16��$��Center=�$��0q�$��Center=�$��2��$y�Hidden=�.+�  -   $ download_butt2��$��Stretch=�$ media/x-16-white.png��$	 Visible=�$
  ��$��16��$��Stretch=�$ 4,0,0,0q�$��10.667(��� -    ��Name$ searchItemTitleOwner��$��1��$��16��$��	10,1,59,0q�$
��Wrap=�$	��Top=����	#FFC5C5C5���� *	OwnerName+ �� FallbackValue$ OWNER���� -   $ searchItemTitle��$��1��$��16��$
��10,0q�$
��Wrap=�$��Center=����	#FFC5C5C5���� *Title+$ TITLE���� -   $ searchItemInfo��$��1��$��16��$��	10,0,10,2q�$
��Wrap=�$��Bottom=����	#FF818181$��10.667(����� *DateAndViewsInfo+$ Feb 4 · 3.14K Views���� $��0,0,4,6q�$��Bottom=����	#FF2E2E2E �� Padding$ 4,0,4,2q� �� CornerRadius$ 8�����	#FF0E0E0E$��1q�$��Right=�$��18��$��31��._��� -   $ textBlock1_Copy��$
��Wrap=����	#FF96A3C5$��10.667(�$��21������ *Duration_str+$
 3:14��
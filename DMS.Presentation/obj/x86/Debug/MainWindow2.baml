   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5   	   "    DMS.Presentation.MainWindow2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DMS.Presentation     5   	   -   5          � Title$  Dairy Management System��5   	    � WindowState$ 	Maximized=�5	   	   ���	#FFEDEDED � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value	 �� RelativeSource
 �� Path   TransactionItem � 	Resources �� Source  DetailBorder �� Orientation��%U  '��       &	  �    7  �� 5   
   " ��6   .�5   
   ��  � ��$ 0q�6$   �� 5   
    � ��$ 18��6#   �� 5   
    � ��$ 10(�6%   �� 5   
    � ��$ 2q�6#   �� 5   
    � ��$ Center=�6.    5   
   P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      �� 	 �� *Self+$)
 #(Validation.Errors)[0].ErrorContent�5!      5$      �� 5(   
    5)      �� 5*      $  ../ResourceDictionary.xaml?�6%   .R�5,      �� 8��  $��2,2,2,0q�6;   ._�5-      �� .+�5.      �� $
��Bold"�6B   ��6    �� $
 DisplayName�6B   �� 5/      $��Italic$�6?   ��6    �� $
 Position�6?   �� 50      $ 
Horizontal=�6!   .+�51      �� $��Transaction Date/Time:��6$   �� 52      ��6$   �� $
 	TransTime�53      54      55      56      57      .��5<      � .+�5?   
    � -   5        $��bannerFrame��5?      $��50��6#   $	��Top=�6/   $��
20,20,20,0q�6G     � Source$ Banner.xaml?�6[   � 5B   
   .+�5C      �� -   5         ��Name$ buttonUpdate��5C      $��60��6F   $��40��6Q   $	��Top=�6]   $��
25,25,20,0q�6u   $
��Left=�6�     GlossyButton#��[ 6�   $��Update��6�   �� 5D      -   5        $ buttonSearch��5D      $��60��6F   $��40��6Q   $	��Top=�6]   $��	5,25,20,0q�6u   $
��Left=�6�   #��[ 6�   $��Search��6�   5H      �� 5L   
   -   5        $ 
buttonSave��5L      $��60��6>   $��40��6I   $��Center=�6U   $��10q�6p   $��0,565,220,34q�6}   $��Right=�6�   #��[ 6�   $
��Save��6�   �� 5P   
   -   5        $��mainTab��5P      $��0q�6%   $��70,80,350,49q�61   .@�5R      �� -   5        $��Animals��5U   "   .��5V      *   $DMS.Presentation.AnimalWorkSpaceView  5W      �� 5X      -   5        $��Calfs��5[   "   .��5\      �� $��10q�6!   5^      5_      �� 5`      -	   5        $��Milking��5c   "   .��5d      �� $��15q�6!   5f      5g      �� 5h      -
   5        $��
Medication��5k   "   .��5l      �� $��10q�6!   5n      5o      �� 5p      -   5        $��
Attendance��5s   "   .��5t      �� $��10q�6!   5v      5w      �� 5x      -   5        $��Expenditures��5{   "   .��5|      /   )DMS.Presentation.ExpenditureWorkSpaceView  5}      �� 5~      -   5        $��	Customers��5�   "   .��5�      �� $��10q�6!   5�      5�      �� 5�      -   5        $��	Employees��5�   "   5�      �� 5�      -   5        $��Insemnation��5�   "   5�      �� 5�      -   5        $��Status��5�   "   5�      5�      �� 5�   
   -   5        $��searchHeader��5�   !   $y�	Collapsed=�65   $��260,100,0,0q�6L   $	��Top=�6a   $��Center=�6y   $	��250��6�   $	��300��6�   $��Search��5�   -   .��5�       � -   5        $��frameSearch��5�      $	��250��6(   $	��200��64   $	��Top=�6A     � NavigationUIVisibility$ Hidden=�6Y   6{   5�      �� 5�   
   -   5          DisplayArea#��[ 5�   !   $��30,80,45,30q�6F   $��Right=�6[   $	��250��6w   $
��Auto��6�   $	��Top=�6�   $��Enter New Entry��5�   -   .��5�      �� #��[  6[   ��6   �� $
 LongServingEmployees� �� Mode$ OneTime=�6[   5�       � 5�   
   -   5        $��dataEntryFrame��5�      $��Right=�6&   $��0q�6B   $��20,128,25,30q�6N   $ AnimalEntryView.xaml?�6d   $	��260��6�   $ Hidden=�6�   5�      5�      5�      
   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5   	   !    DMS.Presentation.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DMS.Presentation     5   	   -   5          � Title$  Dairy Management System��5   	    � WindowState$ 	Maximized=�5	   	   ���	#FFEDEDED � 	Resources 5       �� 
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
 	TransTime�53      54      55      56      57      .��5:      � .+�5^   
    � -   5        $��bannerFrame��5^      $��50��6#   $	��Top=�6/   $��
20,20,20,0q�6G     � Source$ Banner.xaml?�6[   �� 5_   
   -   5        $��buttonRefresh��5_      $��60��6B   $��40��6M   $	��Top=�6Y   $��
25,25,20,0q�6q   $
��Left=�6�     GlossyButton#��[ 6�   ��6�   �� $
 SaveCommand�.��6�   	Refresh6�   �� 5a   
   -   5        $��mainTab��5a      $��0q�6%   $��70,80,350,30q�61   .@�5c      �� -   5        $��Animals��5f   "   .��5g      �� $��10q�6!   .��5h       � -   5        $��animalFrame��5h      $ AnimalWorkSpaceView.xaml?�6/   6S   5i      5j      �� 5k      -   5        $��Calfs��5n   "   .��5o      �� $��10q�6!   .��5p       � -   5        $��	calfFrame��5p      $ CalfWorkSpaceView.xaml?�6-   6O   5q      5r      �� 5s      -	   5        $��Milking��5v   "   .��5w      �� $��10q�6!   .��5x       � -
   5        $��milkingFrame��5x      $ MilkingWorkSpaceView.xaml?�60   6U   5y      5z      �� 5{      -   5        $��Animal Medicine Record��5~   "   .��5      �� $��10q�6!   .��5�       � -   5        $��animalMedicineRecordFrame��5�      $+ %AnimalMedicalRecordWorkSpaceView.xaml?�6=   6n   5�      5�      �� 5�      -   5        $��
Attendance��5�   "   .��5�      �� $��10q�6!   .��5�       � -   5        $��employeeAttendanceFrame��5�      $* $EmployeeAttendanceWorkSpaceView.xaml?�6;   6k   5�      5�      �� 5�      -   5        $��Expenditures��5�   "   .��5�      �� $��10q�6!   .��5�       � -   5        $��expenditureFrame��5�      $# ExpenditureWorkSpaceView.xaml?�64   6]   5�      5�      �� 5�      -   5        $��	Customers��5�   "   .��5�      �� $��10q�6!   .��5�       � -   5        $��customerFrame��5�      $  CustomerWorkSpaceView.xaml?�61   6W   5�      5�      �� 5�      -   5        $��	Employees��5�   "   .��5�      �� $��10q�6!   .��5�       � -   5        $��employeeFrame��5�      $  EmployeeWorkSpaceView.xaml?�61   6W   5�      5�      5�      �� 5�   
   -   5          DisplayArea#��[ 5�   !   $��30,80,45,30q�6F   $��Right=�6[   $	��250��6w   $
��Auto��6�   $	��Top=�6�   $��Enter New Entry��5�   -   .��5�      �� #��[  6[   ��6   �� $
 LongServingEmployees� �� Mode$ OneTime=�6[   5�       � 5�   
   -   5        $��dataEntryFrame��5�      $��Right=�6&   $��0q�6B   $��20,128,25,30q�6N   $ AnimalEntryView.xaml?�6d   $	��260��6�     � NavigationUIVisibility$ Hidden=�6�   5�      5�      5�      
   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5      (    "DMS.Presentation.EmployeeEntryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DMS.Presentation     5      -   5          � 	Resources  5         TextBoxErrorTemplate��%�   &	        �� 5      .R�5      ]� ��. .+�5      �� $��Right=�6   
��� ���$
��12pt(�5   	   !!!!6   �� 5      
��� � �$��1q�6#   ._�5      �� 5   	   5      5      5      .��5      � -   5        $��	EntryGrid��5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $
��Auto �6   �� 5'      $
��Auto �6   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   .+�5/   
   �� $��0��6   $��0��6%   $��Name:��62   �� 50   
   -   5        $��textBoxName��50      $��1��6%   $��0��65   $	��150��6y    =� ErrorTemplate# [  6�   ��6B   ��  �� Path$
 Name� �� ValidatesOnExceptions . .��6�   51      �� 53   
   $��0��6   $��1��6$   $��Father Name:��61   �� 54   
   -   5        $��textBoxFatherName��54      $��1��6+   $��1��6;   $	��150��6�   ��6H   �� $ 
FatherName� . 6�   �� 56   
   $��0��6   $��2��6$   $��Current Address:��61   �� 57   
   -   5        $��textBoxCurrentAddress��57      $��1��6/   $��2��6?   $	��150��6r   ��6L   �� $ CurrentAdddress�6r   �� 59   
   $��0��6   $��3��6$   $��Permanent Address:��61   �� 5:   
   -   5        $��textBoxPermanentAddress��5:      $��1��61   $��3��6A   $	��150��6u   ��6N   �� $ PermanentAddress�6u   �� 5<   
   $��0��6   $��4��6$   $��Role:��61   �� 5=   
   -   5        $��roleComboBox��5=      $��1��6B   $��4��6R   $	��150��6_    �� SelectedValuePath$ .��6k    �� Text 6'   �� $
 Role� �� SelectedItem 6�   �� $
 Role�6�   �� 5?   
   $��0��6   $��5��6$   $��CNIC No:��61   �� 5@   
   -   5        $��textBoxCNIC��5@      $��1��6%   $��5��65   $	��150��6`   ��6B   �� $ CNIC_No�6l   �� 5B   
   $��0��6   $��6��6$   $��Birth Date:��61   (  "System.Windows.Controls.DatePicker  5C   
   -	   5        $��datePickerDOB��5C      $��1��6*   $��6��6:   $��26��6�   $��3,3,0,5q�6�   $	��146��6�   	   SelectedDate	 6G   �� $ 	BirthDate� . 6�   �� 5E   
   $��0��6   $��7��6$   $��Joining Date:��61     5F   
   -
   5        $��datePickerJoiningDate��5F      $��1��62   $��7��6B   $��24��6y   $��3,4,0,5q�6�   $	��146��6�   	 6O   �� $ JoiningDate�6�   �� 5H   
   $��0��6   $��8��6$   $��Salary:��61   �� 5I   
   -   5        $��textBoxSalary��5I      $��1��6'   $��8��67   $	��150��6a   ��6D   �� $ Salary�6a   �� 5K   
   $��0��6   $��9��6$   $��Other Details:��61   �� 5L   
   -   5        $��textBoxDescription��5L      $��1��6,   $��9��6<   $	��150��6o   $��50��6{   ��6I   �� $ DutyDescription�6{   5P      5Q      
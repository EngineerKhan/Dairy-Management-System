   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5      '    !DMS.Presentation.MilkingEntryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DMS.Presentation     5      .��5	      � -   5          �Name$  	EntryGrid��5	       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Tag No:��61   �� 5   
   -   5         ��Name$ tagNoComboBox��5      $��1��6\   $��0��6l   $	��150��6y    �� SelectedValuePath$ .��6�    �� Text 6*   �� *" MilkingEntry.MilkingCattle.TagNo+6�   �� 5   
   $��0��6   $��1��6$   $��Milking Date:��61   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerMilking��5      $��1��6.   $��1��6>   $	��150��6K   6Y   �� 5!   
   $��0��6   $��2��6$   $��Shift:��61   �� 5"   
   -   5        $ milkingShiftComboBox��5"      $��1��61   $��2��6A   $	��150��6N   $ .��6Z   .@�5#      �� .��6   	Morning6$   �� 5$      .��6   	Evening6$   5%      �� 5'   
   $��0��6   $��3��6$   $��Milk Quantity:��61   �� 5(   
   -   5         ��Name$ textBoxQuantity��5(      $��1��6+   $��3��6;   $	��150��6b   ��6H   �� *
Quantity+6b   �� 5*   
   $��0��6   $��4��6$   $��	Comments:��61   �� 5+   
   -   5        $ textBoxComments��5+      $��1��6+   $��4��6;   $	��150��6b   $	��100��6n   ��6H   �� *
Comments+6n   5.      5/      
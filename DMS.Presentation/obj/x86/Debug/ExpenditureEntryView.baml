   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5      G CDMS.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:DMS.Entities;assembly=DMS.EntitiesDMS.Entities 5      +    %DMS.Presentation.ExpenditureEntryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DMS.Presentation     5      EEntities0clr-namespace:DMS.Entities;assembly=DMS.Entities     5      .��5
      � -   5          �Name$  	EntryGrid��5
       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��1��6$   $��Type:��61   �� 5    
   -   5         ��Name$ expenditureTypeComboBox��5       $��1��6U   $��1��6e   $	��150��6r    �� SelectedValuePath$ .��6~    �� Text 64   �� *ExpenseCategory+ �� SelectedItem 6�   �� *ExpenseCategory+5&      �� 5(   
   $��0��6   $��2��6$   $��	Sub Type:��61   �� 5)   
   -   5        $  expenditureSubTypeComboBox��5)      $��1��6W   $��2��6g   $	��150��6t   $ .��6�    67   �� *ExpenseSubType+ 6�   �� *ExpenseSubType+6�   �� 5+   
   $��0��6   $��3��6$   $��Amount:��61   �� 5,   
   -   5         ��Name$ textBoxAmount��5,      $��1��6)   $��3��69   $	��150��6^   ��6F   �� *Amount+6^   �� 53   
   $��0��6   $��4��6$   $��	Comments:��61   �� 54   
   -   5        $ textBoxComments��54      $��1��6+   $��4��6;   $	��150��6b   $	��100��6n   ��6H   �� *
Comments+6n   57      58      
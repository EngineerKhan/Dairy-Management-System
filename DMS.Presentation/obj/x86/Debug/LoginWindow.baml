   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5   	   "    DMS.Presentation.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DMS.Presentation     5   	     � Title$0  *Welcome to Khalis Dairy Management System!��5   	   $	��300��6<   $	��300��6I   .��5	      � -   5         �Name$ 	EntryGrid��5	       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��
User Name:��61   $��25,35,15,15q�6C   �� 5   
   -   5         ��Name$ textBoxUserName��5      $��1��6+   $��0��6;   $	��150��6b   $��30��6n   $��25,35,15,15q�6z   ��6H   �� *
UserName+6z   �� 5   
   $��0��6   $��1��6$   $��	Password:��61   $��25,35,15,15q�6B   G� 5   
   -   5        $��passwordBox��5      $��1��6*   $��1��6:   $	��150��6G   $��30��6S   $��25,35,15,15q�6_   6w   �� 5   
   -   5         ��Name$ LoginButton��5      $��60��6@   $��40��6K   $��4��6W   $	��Top=�6d   $��
20,15,20,0q�6|   $
��Left=�6�      GlossyButton#��[  6�   $��Login��6�   ��6�   �� *SaveCommand+6�   �� 5    
   -   5        $��checkBoxLoginSuccessful��5       $y�Hidden=�62   6H   5"      5#      
   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5      3    -DMS.Presentation.AnimalMedicalRecordEntryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DMS.Presentation     5      .��5	      � -   5          �Name$  	EntryGrid��5	       � ColumnDefinitions 5   
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
   $��0��6   $��1��6$   $��
Diagnosis:��61   �� 5   
   -   5         ��Name$ textBoxDiagnosis��5      $��1��6,   $��1��6<   $	��150��6d   ��6I   �� *	Diagnosis+6d   �� 5!   
   $��0��6   $��2��6$   $��
Treatment:��61   �� 5"   
   -   5        $ textBoxTreatment��5"      $��1��6,   $��2��6<   $	��150��6d   ��6I   �� *	Diagnosis+6d   �� 5$   
   $��0��6   $��3��6$   $��
Prognosis:��61   �� 5%   
   -   5        $ textBoxPrognosis��5%      $��1��6,   $��3��6<   $	��150��6d   ��6I   �� *	Diagnosis+6d   5*      5+      
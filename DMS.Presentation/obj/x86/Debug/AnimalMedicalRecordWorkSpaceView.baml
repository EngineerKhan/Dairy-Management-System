   M S B A M L   `   `   `  ����K  GDMS.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DMS.PresentationDMS.Presentation  5      7    1DMS.Presentation.AnimalMedicalRecordWorkSpaceView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DMS.Presentation     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��    SubDisplayArea#��[  6!   $��0��6I   $��Medical Record Entry��5   -   .��5      �� .��5      �� -   5        ��5      �� 5       �� Orientation$ 
Horizontal=�6%   $��Right=�6>   .��5      &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5         AutoGenerateColumns .     
IsReadOnly .  �� SelectedItem 6/   ��  �� Path$ CurrentMilkEntry� �� Mode$ OneWay=���6k   �� $ 
AllAnimals�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61   	   
Visibility$	 Hidden=�6c   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� $ IllAnimal.ID�6c     5      $ Tag No��61      
IsReadOnly . 
 6S   �� $ IllAnimal.TagNo�  5      $ 
Entry Date��61   
 6E   �� $ 	EntryDate�6j     5      $ 	Diagnosis��61   
 6D   �� $ 	Diagnosis�6i     5       $ 	Treatment��61   
 6D   �� $ 	Treatment�6i     5!      $ 	Prognosis��61   
 6D   �� $ 	Prognosis�6i   5$      5%      5&      5'      5(      5)      
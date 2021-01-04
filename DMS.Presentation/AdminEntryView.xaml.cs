using DMS.BusinessLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for AnimalEntryView.xaml
    /// </summary>
    public partial class AdminEntryView : UserControl, IEntryViewControl
    {

        public AdminEntryView()
        {
            InitializeComponent();

            List<ColumnTuple> tableList = new List<ColumnTuple>();

            tableList.Add(new ColumnTuple("Breed", "sp_selectAnimalBreedsAll"));
            tableList.Add(new ColumnTuple("Source", "sp_selectAnimalSourcesAll"));

            comboBoxTable.ItemsSource = tableList;

        }

		//Changed
		//Shifted code from Save Button to interface Save() method overriding
		public void Save()
		{
		}
        
        private void EntryGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

		public void Save2()
		{
			throw new NotImplementedException();
		}

        private void comboBoxTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColumnTuple queryColumn = comboBoxTable.SelectedItem as ColumnTuple;

            GlobalSettings.AdminPage.ProcedureName = queryColumn.BackEndName;

            GlobalSettings.AdminPage.Refresh();
        }

	}
}

using DMS.BusinessLayer;
using System.Windows;
using System.Windows.Controls;
using DMS.Entities;
using System;
using System.Collections.Generic;
using DMS.DataLayer;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for AdminModule.xaml
    /// </summary>
    public partial class AdminModule : UserControl, IWorkSpaceViewControl
    {

        MastersDAL mastersHandler;
        string procedureName;

        public AdminModule()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Added on March 18
        /// </summary>
        /// <param name="col">Column Name</param>
        /// <param name="param">Column Value</param>
        public void ShowFilteredList(string col, string param)
        {
            //Dont Implement it
            return;
        }

        public void Update()
        {

        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            //list.Add(new ColumnTuple("ID", "a.ID"));
            //list.Add(new ColumnTuple("Tag No", "TagNo"));
            //list.Add(new ColumnTuple("Type", "at.Description"));

            return list;
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
            mastersHandler = new MastersDAL();

            procedureName = "sp_selectAnimalBreedsAll"; 

            datagridAdminTable.ItemsSource = mastersHandler.GetMasterTablesData(procedureName);
		}

		private void datagridAdminTable_Loaded(object sender, RoutedEventArgs e)
        {
			Refresh();
        }
    }
}

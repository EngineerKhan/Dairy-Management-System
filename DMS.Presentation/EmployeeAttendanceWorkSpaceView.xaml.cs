using DMS.BusinessLayer;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Generic;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for EmployeeAttendanceWorkSpaceView.xaml
    /// </summary>
    public partial class EmployeeAttendanceWorkSpaceView : UserControl, IWorkSpaceViewControl
    {
        public EmployeeAttendanceWorkSpaceView()
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
            dataGrid.ItemsSource = new EmployeesHandler().GetEmployeeAttendances(col, param);
        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("Name", "Name"));
            list.Add(new ColumnTuple("Date", "Date"));

            return list;
        }

        public void Update()
        {

        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
			dataGrid.ItemsSource = new EmployeesHandler().GetEmployeeAttendances();
		}

		private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
			Refresh();
        }
    }
}

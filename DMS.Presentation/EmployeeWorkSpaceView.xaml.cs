using DMS.BusinessLayer;
using System.Windows;
using System.Windows.Controls;
using System;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for EmployeeWorkSpaceView.xaml
    /// </summary>
    public partial class EmployeeWorkSpaceView : UserControl//, IWorkSpaceViewControl
    {

        EmployeesHandler empHandler;

        public EmployeeWorkSpaceView()
        {
            //InitializeComponent();
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
			empHandler = new EmployeesHandler();

			datagridEmployee.ItemsSource = empHandler.GetEmployees();
		}

		private void datagridEmployee_Loaded(object sender, RoutedEventArgs e)
        {
			empHandler = new EmployeesHandler();

			datagridEmployee.ItemsSource = empHandler.GetEmployees();
		}
    }
}

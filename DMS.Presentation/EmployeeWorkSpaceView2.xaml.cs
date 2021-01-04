using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DMS.LogicLayer;
using DMS.BusinessLayer;
using DMS.Entities;

namespace DMS.Presentation
{
	/// <summary>
	/// Interaction logic for EmployeeWorkSpaceView2.xaml
	/// </summary>
	public partial class EmployeeWorkSpaceView2 : UserControl, IWorkSpaceViewControl
	{

        EmployeesHandler empHandler;
        List<Employee> employeeList;

		public EmployeeWorkSpaceView2()
		{
			InitializeComponent();
            employeeList = new List<Employee>();
		}

        /// <summary>
        /// Added on March 18
        /// </summary>
        /// <param name="col">Column Name</param>
        /// <param name="param">Column Value</param>
        public void ShowFilteredList(string col, string param)
        {
            empHandler = new EmployeesHandler();
            employeeList = empHandler.GetEmployees(col, param);
            datagridEmployee.ItemsSource = employeeList;
        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("Address", "CurrentAddress"));
            list.Add(new ColumnTuple("Name", "Name"));

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
            empHandler = new EmployeesHandler();

            datagridEmployee.ItemsSource = empHandler.GetEmployees();
		}

		private void datagridEmployee_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}

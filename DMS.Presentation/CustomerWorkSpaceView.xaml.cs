using System.Windows;
using System.Windows.Controls;
using DMS.BusinessLayer;
using System.Collections.Generic;
using System;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for CustomerWorkSpaceView.xaml
    /// </summary>
    public partial class CustomerWorkSpaceView : UserControl, IWorkSpaceViewControl
    {

        CustomersHandler customerHandler;
        public CustomerWorkSpaceView()
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
            customerHandler = new CustomersHandler();
            datagridCustomers.ItemsSource = customerHandler.GetCustomers(col, param);
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("ID", "DairyID"));
            list.Add(new ColumnTuple("Name", "Name"));
            list.Add(new ColumnTuple("Contact No", "ContactNo"));

            return list;
        }

        public void Update()
        {

        }

		public void Refresh()
		{

			customerHandler = new CustomersHandler();
			datagridCustomers.ItemsSource = customerHandler.GetCustomers();
		}

		private void datagridCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            customerHandler = new CustomersHandler();
            datagridCustomers.ItemsSource = customerHandler.GetCustomers();
        }
    }
}

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

namespace DMS.Presentation
{
	/// <summary>
	/// Interaction logic for ExpenditureWorkSpaceView2.xaml
	/// </summary>
	public partial class ExpenditureWorkSpaceView2 : UserControl, IWorkSpaceViewControl
	{

        ExpensesHandler expHandler;

		public ExpenditureWorkSpaceView2()
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
            datagridExpenditure.ItemsSource = new ExpensesHandler().GetExpenses(col, param);
        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("Type", "et.Description"));
            list.Add(new ColumnTuple("Sub-Type", "est.Description"));

            return list;
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
            expHandler = new ExpensesHandler();

            datagridExpenditure.ItemsSource = expHandler.GetExpenses();
		}

        public void Update()
        {

        }

		private void datagridExpenditure_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}

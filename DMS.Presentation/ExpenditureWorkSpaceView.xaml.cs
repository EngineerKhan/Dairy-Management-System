using DMS.LogicLayer;
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

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for ExpenditureWorkSpaceView.xaml
    /// </summary>
    public partial class ExpenditureWorkSpaceView : UserControl, IWorkSpaceViewControl
    {
        ExpensesHandler expHandler;

        public ExpenditureWorkSpaceView()
        {
            //InitializeComponent();
        }


        /// <summary>
        /// Added on March 18
        /// </summary>
        /// <param name="col">Column Name</param>
        /// <param name="param">Column Value</param>
        public void ShowFilteredList(string col, string param)
        {
            expHandler = new ExpensesHandler();
            datagridExpenditure.ItemsSource = expHandler.GetExpenses(col, param);
        }

        public void Update()
        {
        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("Day", "Day"));
            list.Add(new ColumnTuple("Day", "Day"));

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

		private void datagridExpenditure_Loaded(object sender, RoutedEventArgs e)
        {
			Refresh();
        }
    }
}

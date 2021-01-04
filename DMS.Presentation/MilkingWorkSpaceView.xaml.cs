using DMS.BusinessLayer;
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
    /// Interaction logic for MilkingWorkSpaceView.xaml
    /// </summary>
    public partial class MilkingWorkSpaceView : UserControl, IWorkSpaceViewControl
    {
        MilkingHandler milkingHandler;

        public MilkingWorkSpaceView()
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
            milkingHandler = new MilkingHandler();
            dataGrid.ItemsSource = milkingHandler.GetMilkingEntries(col, param);
        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("Date", "MilkingDate"));
            list.Add(new ColumnTuple("Quantity", "Quantity"));

            return list;
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

        public void Update()
        {
        }

		public void Refresh()
		{
			milkingHandler = new MilkingHandler();
			dataGrid.ItemsSource = milkingHandler.GetMilkingEntries();
		}

		private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
			Refresh();
        }
    }
}

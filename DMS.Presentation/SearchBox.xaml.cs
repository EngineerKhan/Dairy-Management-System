using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DMS.Entities;
using DMS.BusinessLayer;
using DMS.LogicLayer;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        List<ColumnTuple> columnsList;
        IWorkSpaceViewControl currWorkSpaceViewControl;

        public SearchBox(IWorkSpaceViewControl c)
        {
            
            InitializeComponent();
            currWorkSpaceViewControl = c;
            columnsList = currWorkSpaceViewControl.GetColumnsList();
            comboBoxColumns.ItemsSource = columnsList;
        }

        public SearchBox()
        {
            InitializeComponent();
        }

        private void textBoxValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string queryParameter = tb.Text; //Working so far
            ColumnTuple queryColumn = comboBoxColumns.SelectedItem as ColumnTuple;

            //List<object> list = new List<object>();    
            
            //Added 18 March
            currWorkSpaceViewControl.ShowFilteredList(queryColumn.BackEndName ,queryParameter);



        }


    }
}

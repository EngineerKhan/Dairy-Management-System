using DMS.BusinessLayer;
using System.Windows;
using System.Windows.Controls;
using DMS.Entities;
using System;
using System.Collections.Generic;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for CalfWorkSpaceView.xaml
    /// </summary>
    public partial class CalfWorkSpaceView : UserControl, IWorkSpaceViewControl
    {

        AnimalsHandler calfHandler;

        public CalfWorkSpaceView()
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
            calfHandler = new AnimalsHandler();
            datagridCalf.ItemsSource = calfHandler.GetCalfs(col, param);
        }

        public void Update()
        {

        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("ID", "a.ID"));
            list.Add(new ColumnTuple("Tag No", "a.TagNo"));
            list.Add(new ColumnTuple("Type", "at.Description"));
            //list.Add(new ColumnTuple("Father", "cpfd.TagNo"));
            //list.Add(new ColumnTuple("Mother", "cpmd.TagNo"));
            list.Add(new ColumnTuple("Birth Date", "a.BirthDate"));

            return list;
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
			calfHandler = new AnimalsHandler();

			datagridCalf.ItemsSource = calfHandler.GetCalfs();
		}

		private void datagridCalf_Loaded(object sender, RoutedEventArgs e)
        {
			Refresh();
        }
    }
}

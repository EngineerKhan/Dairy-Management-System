using DMS.BusinessLayer;
using System.Windows;
using System.Windows.Controls;
using DMS.Entities;
using System;
using System.Collections.Generic;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for AnimalInsemnationWorkSpaceView.xaml
    /// </summary>
    public partial class AnimalInsemnationWorkSpaceView : UserControl, IWorkSpaceViewControl
    {

        AnimalInsemnationsHandler animalInsemnationHandler;

        public AnimalInsemnationWorkSpaceView()
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
            animalInsemnationHandler = new AnimalInsemnationsHandler();
            datagridAnimalInsemnation.ItemsSource = animalInsemnationHandler.GetAnimalInsemnations(col, param);
        }

        public void Update()
        {

        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("ID", "a.ID"));
            list.Add(new ColumnTuple("Tag No", "TagNo"));
            list.Add(new ColumnTuple("Type", "at.Description"));
            list.Add(new ColumnTuple("Insem Date", "i.Date"));

            return list;
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
			animalInsemnationHandler = new AnimalInsemnationsHandler();

			datagridAnimalInsemnation.ItemsSource = animalInsemnationHandler.GetAnimalInsemnations();
		}

		private void datagridAnimalInsemnation_Loaded(object sender, RoutedEventArgs e)
        {
			Refresh();
        }
    }
}

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

using DMS.Entities;

namespace DMS.Presentation
{
	/// <summary>
	/// Interaction logic for AnimalWorkSpaceView.xaml
	/// </summary>
	public partial class AnimalWorkSpaceView : UserControl, IWorkSpaceViewControl
	{
		#region Member Objects

		AnimalsHandler animalHandler;

		#endregion

		public AnimalWorkSpaceView()
		{
			InitializeComponent();

            //Added March 14 - for Admin being able to edit rows
            //if (GlobalSettings.CurrApplictionUser.Type.ID == 1)//If it's Admin
            //{
            //    datagridAnimal.IsReadOnly = false;
            //}
		}

        /// <summary>
        /// Added on March 18
        /// </summary>
        /// <param name="col">Column Name</param>
        /// <param name="param">Column Value</param>
        public void ShowFilteredList(string col, string param)
        {
            datagridAnimal.ItemsSource = new AnimalsHandler().GetCattles(col, param);
        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("Tag Number", "TagNo"));
            list.Add(new ColumnTuple("Type", "at.Description"));
            list.Add(new ColumnTuple("Birth Date", "a.BirthDate"));

            return list;
        }

        public void Update()
        {
            try
            {
                animalHandler = new AnimalsHandler();
                List<Cattle> updatedList = datagridAnimal.Items.OfType<Cattle>().ToList();

                foreach (Cattle record in updatedList)
                {
                    animalHandler.Update(record);
                }
            }
            catch (Exception exp)
            {
                MessageBoxResult result = MessageBox.Show(exp.Message,
                    "Do you want to correct it or Restore to the original content?",
                    MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    return;
                }
                else
                {
                    Refresh();
                }


                return;
            }
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
			animalHandler = new AnimalsHandler();

			datagridAnimal.ItemsSource = animalHandler.GetCattles();
		}

		private void datagridAnimal_Loaded(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("ABC");

			this.Refresh();

			//Binding animalBinding = new Binding("AnimalView");
			//animalBinding.Source = animalHandler.GetAnimals();
			//SetBinding(DataGrid.CurrentColumnProperty , animalBinding);

		}
	}
}

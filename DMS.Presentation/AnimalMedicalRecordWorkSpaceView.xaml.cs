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

using DMS.Entities;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for AnimalMedicalRecordWorkSpaceView.xaml
    /// </summary>
    public partial class AnimalMedicalRecordWorkSpaceView : UserControl, IWorkSpaceViewControl
    {
        AnimalMedicalRecordsHandler medicalRecordHandler;

        /// <summary>
        /// Added on March 18
        /// </summary>
        /// <param name="col">Column Name</param>
        /// <param name="param">Column Value</param>
        public void ShowFilteredList(string col, string param)
        {
            medicalRecordHandler = new AnimalMedicalRecordsHandler();
            dataGrid.ItemsSource = medicalRecordHandler.GetAnimalMedicalRecords(col, param);
        }

        public AnimalMedicalRecordWorkSpaceView()
        {
            InitializeComponent();

            //Added March 14 - for Admin being able to edit rows
            if (GlobalSettings.CurrApplictionUser.Type.ID == 1)//If it's Admin
            {
                dataGrid.IsReadOnly = false;
            }
        }

        public List<ColumnTuple> GetColumnsList()
        {
            List<ColumnTuple> list = new List<ColumnTuple>();

            list.Add(new ColumnTuple("ID", "a.TagNo"));
            list.Add(new ColumnTuple("Diagnosis", "Diagnosis"));
            list.Add(new ColumnTuple("Prognosis", "Prognosis"));
            list.Add(new ColumnTuple("Treatment", "Treatment"));

            return list;
        }

		public void GetSelectedEntry()
		{
			throw new NotImplementedException();
		}


        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var grid = sender as DataGrid;
            //var data = grid.Items;
            //var currentRow = grid.SelectedItem;
            //MessageBox.Show("In :" + sender.ToString());
            try
            {
                //AnimalMedicalRecord modifiedRecord = (AnimalMedicalRecord)dataGrid.SelectedItem;

                //medicalRecordHandler = new AnimalMedicalRecordsHandler();
                //medicalRecordHandler.Update(modifiedRecord);
            }
            catch (Exception exp)
            {
                //MessageBox.Show("Sorry! Some Error Occurred");
                return;
            }
        }

        /// <summary>
        /// March 12 - Made as test for updation
        /// </summary>
        public void Update()
        {
            try
            {
                medicalRecordHandler = new AnimalMedicalRecordsHandler();
                List<AnimalMedicalRecord> updatedList = dataGrid.Items.OfType<AnimalMedicalRecord>().ToList();

                foreach (AnimalMedicalRecord record in updatedList)
                {
                    medicalRecordHandler.Update(record);
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

		public void Refresh()
		{
			medicalRecordHandler = new AnimalMedicalRecordsHandler();

			dataGrid.ItemsSource = medicalRecordHandler.GetAnimalMedicalRecords();
		}

		private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
			Refresh();
        }

        private void HeaderedContentControl_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGrid.CurrentCell.Column.ToString());
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            AnimalMedicalRecord currRecord = new AnimalMedicalRecord();

            try
            {
                currRecord = dataGrid.CurrentItem as AnimalMedicalRecord;
            }
            catch (Exception exp)
            {
                return;
            }

            if (dataGrid.CurrentCell.Column.Header.ToString() == "Tag No")
            {
                try
                {
                    string s = currRecord.IllAnimal.TagNo;
                }
                catch
                {
                    return;
                }

            }
        }
    }
}

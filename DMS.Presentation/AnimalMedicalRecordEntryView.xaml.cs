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
using DMS.LogicLayer;
using DMS.BusinessLayer;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for AnimalMedicine.xaml
    /// </summary>
    public partial class AnimalMedicalRecordEntryView : UserControl, IEntryViewControl
    {
        AnimalMedicalRecordsHandler medicalHandler;
        public AnimalMedicalRecordEntryView()
        {
            InitializeComponent();
        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
		}

		public void Save()
		{
            medicalHandler = new AnimalMedicalRecordsHandler();

            AnimalMedicalRecord medicalRecord = new AnimalMedicalRecord();

            #region Validation for valid Milking data

            //Check if all text boxes are empty

            IEnumerable<TextBox> textBoxcollection = EntryGrid.Children.OfType<TextBox>();
            IEnumerable<ComboBox> comboBoxcollection = EntryGrid.Children.OfType<ComboBox>();

            foreach (TextBox box in textBoxcollection)
            {
                if (box.Name == "textBoxComments")
                {
                    //ignore

                }

                else
                {
                    if (string.IsNullOrWhiteSpace(box.Text))
                    {
                        MessageBox.Show("Kindly Fill all the boxes.");
                        return;
                    }
                }

            }

            foreach (ComboBox box in comboBoxcollection)
            {
                if (box.SelectedIndex == -1)
                {
                    MessageBox.Show("Kindly Select the animal");
                    return;
                }
            }


            #endregion

            try
            {
                //Inserting values in Object

                medicalRecord.EntryDate = DateTime.Now;

                Cattle illCattle = new Cattle();

                illCattle.ID = ((Cattle)tagNoComboBox.SelectedItem).ID;
                illCattle.TagNo = ((Cattle)tagNoComboBox.SelectedItem).TagNo;

                medicalRecord.IllAnimal = illCattle;

                medicalRecord.Diagnosis = textBoxDiagnosis.Text;
                medicalRecord.Prognosis = textBoxPrognosis.Text;
                medicalRecord.Treatment = textBoxTreatment.Text;

                medicalHandler.Insert(medicalRecord);
            }

            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error!");
                return;
            }

            //Clear all the TextBoxes

            foreach (TextBox box in textBoxcollection)
            {
                box.Text = "";
            }

            foreach (ComboBox box in comboBoxcollection)
            {
                box.SelectedIndex = -1;
            }

			//Commented on March - 12 Talha
            
			//MessageBox.Show("Successfully Saved!");

            //Window mainwin = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

            //mainwin.Activate();
            
        }

        private void ComboBoxTagNo_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EntryGridLoaded(object sender, RoutedEventArgs e)
        {
            tagNoComboBox.ItemsSource = new AnimalsHandler().GetCattles();
        }
    }
}

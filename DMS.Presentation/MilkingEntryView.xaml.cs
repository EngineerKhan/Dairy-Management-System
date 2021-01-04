using DMS.BusinessLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for MilkingEntryView.xaml
    /// </summary>
    public partial class MilkingEntryView : UserControl, IEntryViewControl
    {

        MilkingHandler milkingHandler;
        AnimalsHandler animalHandler;

        public MilkingEntryView()
        {
            InitializeComponent();
        }

        private void ComboBoxTagNo_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                animalHandler = new AnimalsHandler();
                tagNoComboBox.ItemsSource = animalHandler.GetCattles_GivingMilk();
            }
            catch(Exception except)
            {
                MessageBox.Show("Error!", except.Message);
            }
        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{ }

		public void Save()
		{
            milkingHandler = new MilkingHandler();

            MilkingEntry milkingEntry = new MilkingEntry();

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
                        MessageBox.Show("Kindly Fill all the boxes. (Only Comments are Optional)");
                        return;
                    }
                }

            }

            foreach (ComboBox box in comboBoxcollection)
            {
                if (box.SelectedIndex == -1)
                {
                    MessageBox.Show("Kindly Select all the fields");
                    return;
                }
            }


            #endregion

            try
            {
                //Inserting values in Object

                milkingEntry.EntryTime = DateTime.Now;

                if(milkingShiftComboBox.SelectedIndex==0)
                {
                    milkingEntry.MilkingShift = "Morning";
                }

                if (milkingShiftComboBox.SelectedIndex == 1)
                {
                    milkingEntry.MilkingShift = "Evening";
                }

                //milkingEntry.MilkingShift = (MilkingShift)milkingShiftComboBox.SelectedItem;

                milkingEntry.MilkingDate = datePickerMilking.SelectedDate.Value;

                Cattle milkCattle = new Cattle();

                milkCattle = (Cattle)tagNoComboBox.SelectedItem;

                milkingEntry.MilkingCattle = milkCattle;

                milkingEntry.Quantity = Convert.ToDouble(textBoxQuantity.Text);

                milkingHandler.AddMilkingEntry(milkingEntry);
            }

            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error!");
                return;
            }

            //catch (InvalidCastException exc)
            //{
            //    MessageBox.Show(exc.Message, "Error!");
            //    return;
            //}

            //Clear all the TextBoxes

            foreach (TextBox box in textBoxcollection)
            {
                box.Text = "";
            }

            foreach (ComboBox box in comboBoxcollection)
            {
                box.SelectedIndex = -1;
            }

            //MessageBox.Show("Successfully Saved!");

        }


        private void ComboBoxTagNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

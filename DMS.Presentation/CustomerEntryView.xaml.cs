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
    /// Interaction logic for CustomerEntryView.xaml
    /// </summary>
    public partial class CustomerEntryView : UserControl, IEntryViewControl
    {
        Customer currCustomer;
        CustomersHandler custHandler;
        AnimalsHandler animalHandler; //For Animal Type
        public CustomerEntryView()
        {
            InitializeComponent();
        }

        private void EntryGrid_Loaded(object sender, RoutedEventArgs e)
        {

            animalHandler = new AnimalsHandler();
            custHandler = new CustomersHandler();

            //comboBoxMilkType.ItemsSource = animalHandler.GetAnimalTypes();
            //comboBoxPriceCategory.ItemsSource = custHandler.GetPriceCategories();
            //comboBoxTime.ItemsSource = custHandler.GetTimeCategories();
        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{ }

		public void Save()
		{
            custHandler = new CustomersHandler();

            currCustomer = new Customer();

            #region Validation for valid Expenditure data

            //Check if all text boxes are empty

            IEnumerable<TextBox> textBoxcollection = EntryGrid.Children.OfType<TextBox>();
            IEnumerable<ComboBox> comboBoxcollection = EntryGrid.Children.OfType<ComboBox>();

            foreach (TextBox box in textBoxcollection)
            {
                if (box.Name == "textBoxCNIC")
                {
                    //ignore

                }

                else
                {
                    if (string.IsNullOrWhiteSpace(box.Text))
                    {
                        MessageBox.Show("Kindly Fill all the boxes. (Only CNIC is Optional)");
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

            //Inserting values in object

            try
            {

                Time deliverTime = new Time();
                //deliverTime.ID = ((MasterTables)comboBoxTime.SelectedItem).ID;
                //AnimalType mlkType = new AnimalType();
                //mlkType.ID = ((MasterTables)comboBoxMilkType.SelectedItem).ID;
                //PriceCategory priceCat = new PriceCategory();
                //priceCat.ID = ((MasterTables)comboBoxPriceCategory.SelectedItem).ID;

                currCustomer.CNIC_No = textBoxCNIC.Text;
                currCustomer.ContactNo = textBoxContactNo.Text;
                currCustomer.CurrentAddress = textBoxAddress.Text;
                currCustomer.DairyID = textBoxID.Text;
                currCustomer.DelieveryTime = deliverTime;
                //currCustomer.MilkType = mlkType;
                currCustomer.Name = textBoxName.Text;
                //currCustomer.PriceCat = priceCat;

                //currCustomer.Quantity = Convert.ToDouble(textBoxQuantity.Text);
                currCustomer.RegistrationDate = datePickerRegistrationDate.SelectedDate.Value;

                custHandler.AddCustomer(currCustomer);
            }

            catch (ArgumentException exag)
            {
                MessageBox.Show(exag.Message, "Error!");
                return;
            }

            catch (FormatException fexp)
            {
                MessageBox.Show("Enter the Quantity in correct Numeric Format.", "Error!");
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
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

            //MessageBox.Show("Successfully Saved!");


        }

    }
}

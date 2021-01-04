using DMS.BusinessLayer;
using DMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for EmployeeEntryView.xaml
    /// </summary>
    public partial class EmployeeEntryView : UserControl, IEntryViewControl
    {
        Employee currEmployee;
        EmployeesHandler empHandler;

        public EmployeeEntryView()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            empHandler = new EmployeesHandler();
            roleComboBox.ItemsSource = empHandler.GetEmployeeRoles();
        }

        private void roleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  int a = roleComboBox.SelectedIndex + 1;
            //string b = roleComboBox.SelectedItem.ToString();

            //a = a - 1;  //test
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{ }

		public void Save()
		{
            currEmployee = new Employee();

            //string _name = textBoxName.Text;
            //string _fatherName = textBoxFatherName.Text;
            //int _salary = Convert.ToInt32(textBoxSalary.Text);

            #region Validation for valid employee data

            //Check if all text boxes are empty

            IEnumerable<TextBox> textBoxcollection = EntryGrid.Children.OfType<TextBox>();

            foreach (TextBox box in textBoxcollection)
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    MessageBox.Show("Kindly Fill all the boxes");
                    return;
                }
            }

            //CheckTextBoxes(this);


            #endregion

            try
            {

                currEmployee.Name = textBoxName.Text;
                currEmployee.FatherName = textBoxFatherName.Text;
                currEmployee.CNIC_No = textBoxCNIC.Text;
                currEmployee.CurrentAddress = textBoxCurrentAddress.Text;
                currEmployee.DutyDescription = textBoxDescription.Text;
                currEmployee.PermanentAddress = textBoxPermanentAddress.Text;
                currEmployee.Salary = Convert.ToInt32(textBoxSalary.Text);


                currEmployee.BirthDate = datePickerDOB.SelectedDate.Value;
                currEmployee.JoiningDate = datePickerJoiningDate.SelectedDate.Value;

                //This line requires some care - 26 Dec
                //currEmployee.Role = new EmployeeRole(roleComboBox.SelectedIndex + 1, roleComboBox.SelectedItem.ToString());

                //Fixed: 31st Dec. Now its non-trivial way.
                currEmployee.Role = (EmployeeRole)roleComboBox.SelectedItem;


                //Insert it into Database

                empHandler = new EmployeesHandler();

                empHandler.AddEmployee(currEmployee);
            }

            catch (FormatException fexcept)
            {
                MessageBox.Show("Kindly Enter the Salary in correct (numeric) format.", "Invalid Entry");
                return;
            }

            //Added - 01 Jan
            //For Name/Father name not containing numbers

            catch(ArgumentException aexcept)
            {
                MessageBox.Show(aexcept.Message, "Invalid Entry!");
                return;
            }

            catch (InvalidOperationException invalidexcept)
            {
                MessageBox.Show(invalidexcept.Message, "Invalid Entry!");
                return;
            }
            
            catch(Exception except)
            {
                MessageBox.Show(except.Message, "Invalid Entry!");
                return;
            }
            

            //Clear all the TextBoxes

            foreach(TextBox box in textBoxcollection)
            {
                box.Text = "";
            }


        }

        private void textBoxCNIC_TextChanged(object sender, TextChangedEventArgs e)
        {

            //Regex CNIC_Pattern = new Regex(@"^\d{5}\-\d{7}\-\d{1}");

            //int enteredCNICLength = textBoxCNIC.Text.Length;

            //if(enteredCNICLength==5 || enteredCNICLength==13)
            //{
            //    textBoxCNIC.Text += "-";
            //}

            //if (enteredCNICLength == 15)
            //{
            //    bool validCNIC = CNIC_Pattern.Match(textBoxCNIC.Text).Success;
            //}


        }

        //private void CheckTextBoxes(object obj)
        //{
        //    foreach(Control ctrl in obj)
        //    {
        //        if (ctrl is TextBox)
        //        {
        //            if((((TextBox)ctrl).Text == null) || (((TextBox)ctrl).Text == ""))
        //            {
        //                MessageBox.Show("Kindly fill all required fields");
        //            }

        //        }
        //    }
        //}

    }
}

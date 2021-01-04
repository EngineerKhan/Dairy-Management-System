using DMS.BusinessLayer;
using DMS.Entities;
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
    /// Interaction logic for EmployeeAttendanceEntryView.xaml
    /// </summary>
    public partial class EmployeeAttendanceEntryView : UserControl, IEntryViewControl
    {

        EmployeesHandler empHandler;
        public EmployeeAttendanceEntryView()
        {
            InitializeComponent();
        }

        private void EntryGridLoaded(object sender, RoutedEventArgs e)
        {
            comboBoxEmployee.ItemsSource = new EmployeesHandler().GetEmployees_AttendanceToBeMarked();
            comboBoxAttendanceStatus.ItemsSource = new EmployeesHandler().GetEmployeeAttendanceStatuses();
        }


		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{ }

		public void Save()
		{
            empHandler = new EmployeesHandler();

            EmployeeAttendance empAttendance = new EmployeeAttendance();

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
                    MessageBox.Show("Kindly Select both Employee and Attendance Status");
                    return;
                }
            }


            #endregion

            try
            {
                //Inserting values in Object

                empAttendance.AttendanceDateTime = DateTime.Now;

                Employee emp = new Employee();

                emp.ID = ((Employee)comboBoxEmployee.SelectedItem).ID;

                AttendanceStatus status = new AttendanceStatus();

                status.ID = ((MasterTables)comboBoxAttendanceStatus.SelectedItem).ID;

                empAttendance.Emp = emp;

                empAttendance.Status = status;

                empHandler.AddEmployeeAttendance(empAttendance);
            }

            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error!");
                return;
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
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

            //Refresh the Combobox

            comboBoxEmployee.ItemsSource = new EmployeesHandler().GetEmployees_AttendanceToBeMarked();

            //Window mainwin = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

            //mainwin.Activate();

        }

    }
}

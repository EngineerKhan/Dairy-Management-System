using DMS.Entities;
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

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for ExpenditureEntryView.xaml
    /// </summary>
    public partial class ExpenditureEntryView : UserControl, IEntryViewControl
    {

        ExpensesHandler expHandler;
        ExpenseCategory expCategory;
        ExpenseSubType expSubType;
        MainWindow mwin;

        public ExpenditureEntryView()
        {
            InitializeComponent();
        }

        private void ComboBoxCategory_Loaded(object sender, RoutedEventArgs e)
        {
            expHandler = new ExpensesHandler();
            expenditureTypeComboBox.ItemsSource = expHandler.GetExpenseCategories();
        }

        private void ComboBoxSubType_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
		}

		public void Save()
		{
            expHandler = new ExpensesHandler();

            Expense exp = new Expense();

            #region Validation for valid Expenditure data

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

            //Inserting values in object

            exp.Amount = Convert.ToInt32(textBoxAmount.Text);
            exp.ExpenseDate = DateTime.Now;
            exp.Comments = textBoxComments.Text;

            expCategory = (ExpenseCategory)(expenditureTypeComboBox.SelectedItem);

            expSubType = (ExpenseSubType)expenditureSubTypeComboBox.SelectedItem;
            //Below Line is Unnecessary - 1 Jan
            expSubType.ParentCategory = expCategory;
            exp.SubType = expSubType;

            User usr = GlobalSettings.CurrApplictionUser;

            try
            {
                expHandler.AddExpense(exp, usr);
            }
            catch(Exception exc)
            {
                MessageBox.Show("Database Error!", exc.Message);
                return;
            }

            //Enter into Transaction List - Added 01 Jan
            //Experimental yet - 11:25

			//Commented on March 12
            //GlobalSettings.TransList.Add(new DBTransaction(DateTime.Now, GlobalSettings.CurrApplictionUser));

            //Clear all the TextBoxes

            foreach (TextBox box in textBoxcollection)
            {
                box.Text = "";
            }

            foreach(ComboBox box in comboBoxcollection)
            {
                box.SelectedIndex = -1;
            }

            //MessageBox.Show("Successfully Saved!");

            //mwin = MainWindow.a

            //mwin.expenditureFrame.Refresh();

        }

        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            expHandler = new ExpensesHandler();
            ExpenseCategory selectedType = (ExpenseCategory)(expenditureTypeComboBox.SelectedItem);

            try
            {
                expenditureSubTypeComboBox.ItemsSource = expHandler.GetExpenseSubTypes(selectedType.ID);
            }
            catch(NullReferenceException)
            {
                return;
            }
            
        }

        private void ComboBoxSubType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

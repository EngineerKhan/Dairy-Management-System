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
using System.Threading;
using System.Globalization;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Attributes

        AnimalsHandler animalHandler;
        List<Animal> animalList;
        List<DBTransaction> transactionList;
		List<WorkSpaceViewControl> workSpaceControlList;

        User currUser;

        #endregion

        public MainWindow()
        {
            InitializeComponent();

			workSpaceControlList = new List<WorkSpaceViewControl>();
			//workSpaceControlList.Add(new AnimalWorkSpaceView());

            #region Unnecessary
            //LoginWindow loginwin = new LoginWindow();
            //loginwin.Show();

            //if (loginwin.checkBoxLoginSuccessful.IsChecked == true)
            //{
            //    InitializeComponent();
            //}
            //else
            //{
            //    return;
            //}
            #endregion
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            animalHandler = new AnimalsHandler();
            //animalList = new List<Animal>();

            //transactionList = new List<DBTransaction>();
            //transactionList.Add(new DBTransaction(DateTime.Now, GlobalSettings.CurrApplictionUser));

            //latestTransactionsItemControl.ItemsSource = transactionList;

        }

		#region Unnecessary
		private void MenuItem_Animals_Registration_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Animals_Milk_Entry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Animals_Feeding_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Animals_Health_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Animals_ScheduledMedicine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Animals_Status_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Animals_CalfRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Animals_BasicInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Animals_MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

		#endregion

		private void TabItem_Animals_GotFocus(object sender, RoutedEventArgs e)
        {
           dataEntryFrame.Source = new Uri("AnimalEntryView.xaml", UriKind.Relative);
			//dataEntryFrame.Content = workSpaceControlList[0];
        }

        private void TabItem_Milking_GotFocus(object sender, RoutedEventArgs e)
        {
			dataEntryFrame.Source = new Uri("MilkingEntryView.xaml", UriKind.Relative);
			//frame
			//dataEntryFrame.Content = workSpaceControlList[0];
        }

        private void TabItem_Customers_GotFocus(object sender, RoutedEventArgs e)
        {
            dataEntryFrame.Source = new Uri("CustomerEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_Employees_GotFocus(object sender, RoutedEventArgs e)
        {
            dataEntryFrame.Source = new Uri("EmployeeEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_Expenditures_GotFocus(object sender, RoutedEventArgs e)
        {
            dataEntryFrame.Source = new Uri("ExpenditureEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_AnimalMedicineRecord_GotFocus(object sender, RoutedEventArgs e)
        {
            dataEntryFrame.Source = new Uri("AnimalMedicalRecordEntryView.xaml", UriKind.Relative);
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            //Show About Box
            //AboutBoxDMS about = new AboutBoxDMS();
            //about.ShowDialog();
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {

			//var x = mainTab.SelectedItem as TabItem;
			//MessageBox.Show(x.Header.ToString());//shows the header
			//var t = x.Content as TextBlock;
			//MessageBox.Show(t.Text);

			//TabItem ctrl = (WorkSpaceViewControl)mainTab.SelectedContent;   // as WorkSpaceViewControl;

			//if (ctrl is AnimalWorkSpaceView)
			//{
			//	var myCtrl1 = (AnimalWorkSpaceView)ctrl;
			//	myCtrl1.MySpecificMethod();
			//}

			int a = 1;

			a++;

			foreach (UserControl uc in workSpaceControlList)
			{
				//uc.Loaded;
			}

			//var ctrlType = ctrl.GetType();

			//var x = mainTab.SelectedItem as TabItem;

			//string controlType = x.Header.ToString();

			//if (ctrl is AnimalWorkSpaceView)
			//{
			//	var myCtrl1 = (AnimalWorkSpaceView)ctrl;
			//	myCtrl1.Refresh();
			//}

			//int b = 2; //TEsting Feb 13

   //         b++;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_ArabicLocal_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ar");
        }

        private void MenuItem_UrduLocal_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ur");
        }

        private void MenuItem_FrenchLocal_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
        }

        private void TabItem_Calfs_GotFocus(object sender, RoutedEventArgs e)
        {
            dataEntryFrame.Source = new Uri("CalfEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_EmployeeAttendance_GotFocus(object sender, RoutedEventArgs e)
        {
            dataEntryFrame.Source = new Uri("EmployeeAttendanceEntryView.xaml", UriKind.Relative);
        }

        private void HeaderedContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           // new repor
        }
    }
}

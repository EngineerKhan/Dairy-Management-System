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
    public partial class MainWindow2 : Window
    {

        #region Attributes

        AnimalsHandler animalHandler;
        List<Animal> animalList;
        List<DBTransaction> transactionList;
		List<WorkSpaceViewControl> workSpaceControlList;
		List<IWorkSpaceViewControl> iworkSpaceControlList;
        SearchBox searchBox;

		User currUser;

		#endregion

		public MainWindow2()
		{
			InitializeComponent();

			iworkSpaceControlList = new List<IWorkSpaceViewControl>();

			// 0 - Animal
			iworkSpaceControlList.Add(new AnimalWorkSpaceView());

			// 1 - Milking
			iworkSpaceControlList.Add(new MilkingWorkSpaceView());

			// 2 - Customers
			iworkSpaceControlList.Add(new CustomerWorkSpaceView());

			// 3 - Employees
			iworkSpaceControlList.Add(new EmployeeWorkSpaceView2());

			// 4 - Expenditures
			iworkSpaceControlList.Add(new ExpenditureWorkSpaceView2());

			//5 - Animal Medicine
			iworkSpaceControlList.Add(new AnimalMedicalRecordWorkSpaceView());

			//6 - Calfs
			iworkSpaceControlList.Add(new CalfWorkSpaceView());

			//7 - Emp Attendance
			iworkSpaceControlList.Add(new EmployeeAttendanceWorkSpaceView());

            //Added on April-01
            //8 - Insemnation Record
            iworkSpaceControlList.Add(new AnimalInsemnationWorkSpaceView());

            //Added on April-16
            //9 - Animal Status
            iworkSpaceControlList.Add(new AnimalStatusWorkSpaceView());

            ////Added on April-04
            ////9 - Admin
            //iworkSpaceControlList.Add(new AdminModule2());


			//Since starting tab is Animals, so assign it it's object:

			//var a = mainTab.SelectedItem as TabItem;
			//a.Content = iworkSpaceControlList[0];
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
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[0];

			dataEntryFrame.Source = new Uri("AnimalEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_Milking_GotFocus(object sender, RoutedEventArgs e)
        {
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[1];

			dataEntryFrame.Source = new Uri("MilkingEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_Customers_GotFocus(object sender, RoutedEventArgs e)
        {
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[2];

			dataEntryFrame.Source = new Uri("CustomerEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_Employees_GotFocus(object sender, RoutedEventArgs e)
        {
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[3];

            //Added Mar 12
            //To avoid any problem, Refresh() is not being called by dataGrid load event. So calling instead from here
            iworkSpaceControlList[3].Refresh();

			dataEntryFrame.Source = new Uri("EmployeeEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_Expenditures_GotFocus(object sender, RoutedEventArgs e)
        {
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[4];

            //Added Mar 12
            //To avoid any problem, Refresh() is not being called by dataGrid load event. So calling instead from here
            iworkSpaceControlList[4].Refresh();

			dataEntryFrame.Source = new Uri("ExpenditureEntryView.xaml", UriKind.Relative);
        }

        private void TabItem_AnimalMedicineRecord_GotFocus(object sender, RoutedEventArgs e)
        {
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[5];

			dataEntryFrame.Source = new Uri("AnimalMedicalRecordEntryView.xaml", UriKind.Relative);
        }

		private void TabItem_Calfs_GotFocus(object sender, RoutedEventArgs e)
		{
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[6];

			dataEntryFrame.Source = new Uri("CalfEntryView.xaml", UriKind.Relative);
		}

		private void TabItem_EmployeeAttendance_GotFocus(object sender, RoutedEventArgs e)
		{
			//Added on 11-Mar, Talha
			TabItem currTab = sender as TabItem;
			currTab.Content = iworkSpaceControlList[7];

			dataEntryFrame.Source = new Uri("EmployeeAttendanceEntryView.xaml", UriKind.Relative);
		}


        private void TabItem_AnimalInsemnation_GotFocus(object sender, RoutedEventArgs e)
        {
            //Added on 01-Apr, Talha
            TabItem currTab = sender as TabItem;
            currTab.Content = iworkSpaceControlList[8];

            dataEntryFrame.Source = new Uri("AnimalInsemnationEntryView.xaml", UriKind.Relative);
        }

        //Added 16-Apr
        private void TabItem_AnimalStatus_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem currTab = sender as TabItem;
            currTab.Content = iworkSpaceControlList[9];

            dataEntryFrame.Source = new Uri("AnimalStatusEntryView.xaml", UriKind.Relative);
        }

        //Added - 04 April
        private void TabItem_Admin_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem currTab = sender as TabItem;
            currTab.Content = iworkSpaceControlList[9];

            GlobalSettings.AdminPage = (AdminModule2)iworkSpaceControlList[9];

            dataEntryFrame.Source = new Uri("AdminEntryView.xaml", UriKind.Relative);

            //buttonSave.Visibility = Visibility.Hidden;
        }

		private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            //Show About Box
            //AboutBoxDMS about = new AboutBoxDMS();
            //about.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
			IWorkSpaceViewControl control = mainTab.SelectedContent as IWorkSpaceViewControl;
            control.Update();
			//return;
        }

        private void HeaderedContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           // new repor
        }

		private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
		{

		}

		private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{

		}

		private void buttonSave_Click(object sender, RoutedEventArgs e)
		{
			IEntryViewControl control = dataEntryFrame.Content as IEntryViewControl;
			control.Save();

			IWorkSpaceViewControl workSpaceControl = mainTab.SelectedContent as IWorkSpaceViewControl;
			workSpaceControl.Refresh();
		}

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            IWorkSpaceViewControl control = mainTab.SelectedContent as IWorkSpaceViewControl;

            //Show Search Box
            searchBox = new SearchBox(control);
            frameSearch.Content = searchBox;
            searchHeader.Visibility = Visibility.Visible;
           //buttonSearch.IsEnabled = false;
        }

        private void mainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchHeader.Visibility = Visibility.Hidden;
            //buttonSearch.IsEnabled = true;
        }

	}
}

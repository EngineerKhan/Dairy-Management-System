using DMS.Entities;
using DMS.LogicLayer;
using System.Collections.Generic;
using System.Windows;

namespace DMS.Presentation
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        bool IsLoginSuccessful;
        UsersHandler userHandler;
        List<User> userList = new List<User>();
        string enteredUserName, enteredPassWord;

        public LoginWindow()
        {
            IsLoginSuccessful = false;  //Initialization
            InitializeComponent();

            userHandler = new UsersHandler();
            userList = userHandler.GetUsers();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            bool IsUserExists = false;
            string actualPassword = "";

            enteredUserName = textBoxUserName.Text;
            enteredPassWord = passwordBox.Password;

            if(userList.Count==0)
            {
                MessageBox.Show("Either No User Exists or We are not connected to DB.");
                return;
            }

            foreach (User usr in userList)
            {
                if (usr.UserName == enteredUserName)
                {
                    IsUserExists = true;
                    actualPassword = usr.PassWord;
                    //Set current user to be usr. Even if login is unsuccessful, no worry as application won't start until password entered. 
                    GlobalSettings.CurrApplictionUser = usr;
                }
            }

            //else (if name is not found in directory

            if (IsUserExists == false)
            {
                MessageBox.Show("User Name does not exist!");
                return;
            }
            else
            {
                if(enteredPassWord == actualPassword)
                {
                    MainWindow2 mw = new MainWindow2();
                    mw.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                    return;
                }
            }

        }
    }
}

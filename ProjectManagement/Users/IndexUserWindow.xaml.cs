using BLL.Interfaces;
using BLL;
using ProjectManagement.Projects;
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
using System.Windows.Shapes;

namespace ProjectManagement.Users
{
    /// <summary>
    /// Логика взаимодействия для IndexUserWindow.xaml
    /// </summary>
    public partial class IndexUserWindow : Window
    {
        IDbCrud db;
        IAddProjectService service;
        private List<UserModel> UserList;

        public IndexUserWindow(IDbCrud dbOperations, IAddProjectService addProjectService)
        {
            InitializeComponent();
            this.db = dbOperations;
            this.service = addProjectService;

            LoadUsers();
        }

        private void AddUsers(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow(db, service);
            createUserWindow.ShowDialog();

            if (createUserWindow.IsUserCreated)
            {
                LoadUsers();
            }
        }

        private void UpdateUsers(object sender, RoutedEventArgs e)
        {
            UserModel selectedUsers = (UserModel)UserDataGrid.SelectedItem;
            if (selectedUsers != null)
            {
                UpdateUserWindow updateUserWindow = new UpdateUserWindow(db, selectedUsers);
                updateUserWindow.ShowDialog();

                if (updateUserWindow.IsUserUpdated)
                {
                    LoadUsers();
                }
            }
        }

        private void DeleteUsers(object sender, RoutedEventArgs e)
        {
            UserModel selectedUser = (UserModel)UserDataGrid.SelectedItem;
            if (selectedUser != null)
            {
                db.DeleteUser(selectedUser.UserID);
                LoadUsers();
            }
        }


        private void LoadUsers()
        {
            UserList = db.GetAllUsers();
            DisplayUsers(UserList);
        }

        public void DisplayUsers(List<UserModel> users)
        {
            UserDataGrid.ItemsSource = users;
        }
    }
}

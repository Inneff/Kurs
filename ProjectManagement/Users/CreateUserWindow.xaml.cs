using BLL.Interfaces;
using BLL;
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
    /// Логика взаимодействия для CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        IDbCrud db;
        IAddProjectService service;
        public UserModel NewUser = new UserModel();
        public bool IsUserCreated { get; private set; } = false;
        public CreateUserWindow(IDbCrud dbOperations, IAddProjectService service)
        {
            InitializeComponent();
            db = dbOperations;
            this.service = service;
        }

        private void CreateUserSave(object sender, RoutedEventArgs e)
        {
            int newUserID = db.GetAllUsers().Max(user => user.UserID) + 1;
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите Имя");
                return;
            }
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите email");
                return;
            }
            string email = emailTextBox.Text;
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите пароль");
                return;
            }
            string password = passwordTextBox.Text;

            NewUser.UserID = newUserID;
            NewUser.Name = name;
            NewUser.Email = email;
            NewUser.Password = password;
            service.AddUser(NewUser);

            IsUserCreated = true;
            Close();
        }
    }
}

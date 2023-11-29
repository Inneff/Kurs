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
    /// Логика взаимодействия для UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        IDbCrud db;
        public UserModel NewUser = new UserModel();

        private int userIdToUpdate;
        public bool IsUserUpdated { get; private set; } = false;
        public UpdateUserWindow(IDbCrud dbOperations, UserModel userToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            LoadUserData(userToUpdate);
            userIdToUpdate = userToUpdate.UserID;
        }

        private void LoadUserData(UserModel user)
        {
            nameTextBox.Text = user.Name;
            emailTextBox.Text = user.Email;
            passwordTextBox.Text = user.Password;
        }

        private void UpdateUserSave(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название проекта");
                return;
            }
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание");
                return;
            }
            string email = emailTextBox.Text;
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите дату начала");
                return;
            }
            string password = passwordTextBox.Text;

            NewUser.UserID = userIdToUpdate;
            NewUser.Name = name;
            NewUser.Email = email;
            NewUser.Password = password;

            db.UpdateUser(NewUser);

            IsUserUpdated = true;
            Close();
        }
    }
}

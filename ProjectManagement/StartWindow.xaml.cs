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
using ProjectManagement.Tasks;
using ProjectManagement.Logs;
using ProjectManagement.Projects;
using ProjectManagement.Users;

namespace ProjectManagement
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        IDbCrud db;
        IAddProjectService service;
        private List<TaskModel> TasksList;

        public StartWindow(IDbCrud dbOperations, IAddProjectService addProjectService)
        {
            InitializeComponent();
            this.db = dbOperations;
            this.service = addProjectService;

            LoadTasks();
        }

        private void ShowProjects(object sender, RoutedEventArgs e)
        {
            IndexProjectWindow indexProjectWindow = new IndexProjectWindow(db, service);
            indexProjectWindow.Show();
        }

        private void ShowUsers(object sender, RoutedEventArgs e)
        {
            IndexUserWindow indexUserWindow = new IndexUserWindow(db, service);
            indexUserWindow.Show();
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            CreateTaskWindow createTaskWindow = new CreateTaskWindow(db, service);
            createTaskWindow.ShowDialog();

            if (createTaskWindow.IsTaskCreated)
            {
                LoadTasks();
            }
        }

        private void UpdateTask(object sender, RoutedEventArgs e)
        {
            TaskModel selectedTask = (TaskModel)TaskDataGrid.SelectedItem;
            if (selectedTask != null)
            {
                UpdateTaskWindow updateTaskWindow = new UpdateTaskWindow(db, selectedTask);
                updateTaskWindow.ShowDialog();

                if (updateTaskWindow.IsTaskUpdated)
                {
                    LoadTasks();
                }
            }
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            TaskModel selectedTask = (TaskModel)TaskDataGrid.SelectedItem;
            if (selectedTask != null)
            {
                db.DeleteTask(selectedTask.TaskID);
                LoadTasks();
            }
        }

        private void ShowLogs(object sender, RoutedEventArgs e)
        {
            ShowLogsWindow showLogsWindow = new ShowLogsWindow(db);
            showLogsWindow.ShowDialog();
        }

        private void LoadTasks()
        {
            TasksList = db.GetAllTasks();
            DisplayTasks(TasksList);
        }

        public void DisplayTasks(List<TaskModel> tasks)
        {
            TaskDataGrid.ItemsSource = tasks;
        }

    }
}

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

namespace ProjectManagement.Tasks
{
    /// <summary>
    /// Логика взаимодействия для CreateTaskWindow.xaml
    /// </summary>
    public partial class CreateTaskWindow : Window
    {
        IDbCrud db;
        IAddProjectService service;
        public TaskModel NewTask = new TaskModel();
        public bool IsTaskCreated { get; private set; } = false;
        public CreateTaskWindow(IDbCrud dbOperations, IAddProjectService service)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            this.service = service;
        }

        private void CreateTaskSave(object sender, RoutedEventArgs e)
        {
            int newTaskID = db.GetAllTasks().Max(task => task.TaskID) + 1;
            int projectID = ((ProjectModel)Project_ID.SelectedItem).ProjectID;
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите задачу");
                return;
            }
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание");
                return;
            }
            string description = descriptionTextBox.Text;
            if (string.IsNullOrWhiteSpace(statusTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите статус");
                return;
            }
            string status = statusTextBox.Text;
            if (string.IsNullOrWhiteSpace(priorityTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите приоритет");
                return;
            }
            string priority = priorityTextBox.Text;

            NewTask.TaskID = newTaskID;
            NewTask.ProjectID = projectID;
            NewTask.Name = name;
            NewTask.Description = description;
            NewTask.Status = status;
            NewTask.Priority = priority;
            service.AddTask(NewTask);

            IsTaskCreated = true;
            Close();
        }

        private void FillComboBox()
        {
            List<ProjectModel> projects = db.GetAllProjects();

            Project_ID.ItemsSource = projects;
        }
    }
}

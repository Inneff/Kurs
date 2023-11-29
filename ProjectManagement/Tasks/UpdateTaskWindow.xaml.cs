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
    /// Логика взаимодействия для UpdateTaskWindow.xaml
    /// </summary>
    public partial class UpdateTaskWindow : Window
    {
        IDbCrud db;
        public TaskModel NewTask = new TaskModel();
        List<ProjectModel> projects;
        private int taskIdToUpdate;
        public bool IsTaskUpdated { get; private set; } = false;
        public UpdateTaskWindow(IDbCrud dbOperations, TaskModel taskToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            FillComboBox();
            LoadTaskData(taskToUpdate);
            taskIdToUpdate = taskToUpdate.TaskID;
        }

        private void LoadTaskData(TaskModel task)
        {
            int index = projects.FindIndex(project => project.ProjectID == project.ProjectID);
            Project_ID.SelectedIndex = index;
            nameTextBox.Text = task.Name;
            descriptionTextBox.Text = task.Description;
            statusTextBox.Text = task.Status;
            priorityTextBox.Text = task.Priority;
        }

        private void UpdateTaskSave(object sender, RoutedEventArgs e)
        {
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

            NewTask.TaskID = taskIdToUpdate;
            NewTask.ProjectID = projectID;
            NewTask.Name = name;
            NewTask.Description = description;
            NewTask.Status = status;
            NewTask.Priority = priority;

            db.UpdateTask(NewTask);

            IsTaskUpdated = true;
            Close();
        }

        private void FillComboBox()
        {
            projects = db.GetAllProjects();

            Project_ID.ItemsSource = projects;
        }
    }
    
}

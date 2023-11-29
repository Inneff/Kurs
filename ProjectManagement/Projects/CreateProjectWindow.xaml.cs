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

namespace ProjectManagement.Projects
{
    /// <summary>
    /// Логика взаимодействия для CreateProjectWindow.xaml
    /// </summary>
    public partial class CreateProjectWindow : Window
    {
        IDbCrud db;
        IAddProjectService service;
        public ProjectModel NewProject = new ProjectModel();
        public bool IsProjectCreated { get; private set; } = false;
        public CreateProjectWindow(IDbCrud dbOperations, IAddProjectService service)
        {
            InitializeComponent();
            db = dbOperations;
            this.service = service;
        }

        private void CreateProjectSave(object sender, RoutedEventArgs e)
        {
            int newProjectID = db.GetAllProjects().Max(project => project.ProjectID) + 1;
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
            if (string.IsNullOrWhiteSpace(startdateTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите статус");
                return;
            }
            DateTime startdate = DateTime.Parse(startdateTextBox.Text);
            if (string.IsNullOrWhiteSpace(enddateTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите приоритет");
                return;
            }
            DateTime enddate = DateTime.Parse(enddateTextBox.Text);

            NewProject.ProjectID = newProjectID;
            NewProject.Name = name;
            NewProject.Description = description;
            NewProject.StartDate = startdate;
            NewProject.EndDate = enddate;
            service.AddProject(NewProject);

            IsProjectCreated = true;
            Close();
        }
    }
}

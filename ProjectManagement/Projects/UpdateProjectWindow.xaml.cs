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
    /// Логика взаимодействия для UpdateProjectWindow.xaml
    /// </summary>
    public partial class UpdateProjectWindow : Window
    {
        IDbCrud db;
        public ProjectModel NewProject = new ProjectModel();

        private int projectIdToUpdate;
        public bool IsProjectUpdated { get; private set; } = false;
        public UpdateProjectWindow(IDbCrud dbOperations, ProjectModel projectToUpdate)
        {
            InitializeComponent();
            db = dbOperations;
            LoadProjectData(projectToUpdate);
            projectIdToUpdate = projectToUpdate.ProjectID;
        }

        private void LoadProjectData(ProjectModel project)
        {
            nameTextBox.Text = project.Name;
            descriptionTextBox.Text = project.Description;
        }

        private void UpdateProjectSave(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название проекта");
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
                MessageBox.Show("Пожалуйста, введите дату начала");
                return;
            }
            DateTime startdate = DateTime.Parse(startdateTextBox.Text);
            if (string.IsNullOrWhiteSpace(enddateTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите дату окончания");
                return;
            }
            DateTime enddate = DateTime.Parse(enddateTextBox.Text);

            NewProject.ProjectID = projectIdToUpdate;
            NewProject.Name = name;
            NewProject.Description = description;
            NewProject.StartDate = startdate;
            NewProject.EndDate = enddate;

            db.UpdateProject(NewProject);

            IsProjectUpdated = true;
            Close();
        }

    }
}

using BLL.Interfaces;
using BLL;
using ProjectManagement.Logs;
using ProjectManagement.Tasks;
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
    /// Логика взаимодействия для IndexProjectWindow.xaml
    /// </summary>
    public partial class IndexProjectWindow : Window
    {
        IDbCrud db;
        IAddProjectService service;
        private List<ProjectModel> ProjectList;

        public IndexProjectWindow(IDbCrud dbOperations, IAddProjectService addProjectService)
        {
            InitializeComponent();
            this.db = dbOperations;
            this.service = addProjectService;

            LoadProjects();
        }

        private void AddProject(object sender, RoutedEventArgs e)
        {
            CreateProjectWindow createProjectWindow = new CreateProjectWindow(db, service);
            createProjectWindow.ShowDialog();

            if (createProjectWindow.IsProjectCreated)
            {
                LoadProjects();
            }
        }

        private void UpdateProject(object sender, RoutedEventArgs e)
        {
            ProjectModel selectedProject = (ProjectModel)ProjectDataGrid.SelectedItem;
            if (selectedProject != null)
            {
                UpdateProjectWindow updateProjectWindow = new UpdateProjectWindow(db, selectedProject);
                updateProjectWindow.ShowDialog();

                if (updateProjectWindow.IsProjectUpdated)
                {
                    LoadProjects();
                }
            }
        }

        private void DeleteProject(object sender, RoutedEventArgs e)
        {
            ProjectModel selectedProject = (ProjectModel)ProjectDataGrid.SelectedItem;
            if (selectedProject != null)
            {
                db.DeleteProject(selectedProject.ProjectID);
                LoadProjects();
            }
        }

        
        private void LoadProjects()
        {
            ProjectList = db.GetAllProjects();
            DisplayProjects(ProjectList);
        }

        public void DisplayProjects(List<ProjectModel> projects)
        {
            ProjectDataGrid.ItemsSource = projects;
        }

    }
}

using BLL;
using BLL.Interfaces;
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

namespace ProjectManagement.Logs
{
    /// <summary>
    /// Логика взаимодействия для ShowLogsWindow.xaml
    /// </summary>
    public partial class ShowLogsWindow : Window
    {
        IDbCrud db;

        public ShowLogsWindow(IDbCrud dbOperations)
        {
            InitializeComponent();
            db = dbOperations;

            DataContext = this;
            LoadLogs();
        }

        private void LoadLogs()
        {
            List<LogModel> logs = db.GetAllLogs();
            DisplayLogs(logs);
        }

        public void DisplayLogs(List<LogModel> logs)
        {
            logsListBox.ItemsSource = logs;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

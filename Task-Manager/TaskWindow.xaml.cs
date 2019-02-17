using System;
using System.Configuration;
using System.Windows;
using System.Windows.Documents;
using DataBase;
using Path = System.IO.Path;

namespace Task_Manager
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public TaskWindow()
        {
            InitializeComponent();

        }
        DataBase.DataBase dataBaseCon = new DataBase.DataBase(MainWindow.connectionStr);
       

        private void BApply_Click(object sender, RoutedEventArgs e)
        {
            MyTask superTask = new MyTask()
            {
                Name = TName.Text,
                Description = new TextRange(RDescription.Document.ContentStart,RDescription.Document.ContentEnd).Text,
                StartDate = DateTime.Parse(TStartDate.Text),
                EndDate = DateTime.Parse(TEndDate.Text),
            };
            
            dataBaseCon.AddTask(superTask);
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

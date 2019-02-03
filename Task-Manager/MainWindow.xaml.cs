using DataBase;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Controls;

namespace Task_Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Controller cont = new Controller();
        public MainWindow()
        {
            InitializeComponent();
            MyTask superTask = new MyTask()
            {
                Name = "Medium",
                Description = "Описание задачи",
                StartDate = DateTime.Now.Date.AddDays(1),
                EndDate = DateTime.Now.Date.AddDays(7),
                Priority = PriorityValue.Medium
            };

            MyTask superTask1 = new MyTask()
            {
                Name = "High",
                Description = "Описание задачи",
                StartDate = DateTime.Now.Date.AddDays(1),
                EndDate = DateTime.Now.Date.AddDays(7),
                Priority = PriorityValue.High
            };
            MyTask superTask2 = new MyTask()
            {
                Name = "Low",
                Description = "Описание задачи",
                StartDate = DateTime.Now.Date.AddDays(1),
                EndDate = DateTime.Now.Date.AddDays(7),
                Priority = PriorityValue.Low
            };

            string connectionStr = Path.Combine(Environment.CurrentDirectory,
                ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DataBase.DataBase dataBaseCon = new DataBase.DataBase(connectionStr);

            dataBaseCon.AddTask(superTask);
            dataBaseCon.AddTask(superTask1);
            dataBaseCon.AddTask(superTask2);



        }

        private void Calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)CBpriority.SelectedItem;
            PriorityValue value;
            Enum.TryParse(typeItem.Name, false, out value);
            cont.GetTasks(ref Calendar1, ref Table, value);
        }

        private void CBsort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cont.SortTasks(ref Table, ref CBsort);
        }
    }
}

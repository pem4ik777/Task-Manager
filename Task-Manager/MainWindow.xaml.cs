using DataBase;
using System;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Task_Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        Controller cont = new Controller();
        public MainWindow()
        {
            InitializeComponent();
            MyTask superTask = new MyTask()
            {
                Name = "Новая задача 16 ноября",
                Description = "Описание задачи",
                StartDate = DateTime.Now.Date.Subtract(TimeSpan.FromDays(2)),
                EndDate = DateTime.Now.Date.AddDays(7),
                Priority = PriorityValue.Medium.ToString()
            };


            string connectionStr = Path.Combine(Environment.CurrentDirectory,
                ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DataBase.DataBase dataBaseCon = new DataBase.DataBase(connectionStr);

            dataBaseCon.AddTask(superTask);
            dataBaseCon.AddTask(superTask);
            dataBaseCon.DeleteTask(superTask);
            


        }

       


        enum PriorityValue
        {
            All,
            Low,
            Medium,
            High
               
        }
       
  
        private void Calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            
        cont.GetTasks(ref Calendar1,ref Table, CBpriority.SelectedItem.ToString());
        }

        private void CBsort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Отобразить задачи с выбраным условием
        }
    }
}

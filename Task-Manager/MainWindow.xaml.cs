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
        SelectedDatesCollection dates;

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
            Low,
            Medium,
            High

        }

       

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
             dates = MyCalendar.SelectedDates;
            string connectionStr = Path.Combine(Environment.CurrentDirectory,
                ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DataBase.DataBase dataBaseCon = new DataBase.DataBase(connectionStr);

           
            var r = dataBaseCon.GetResults(dates[0].Date, dates[dates.Count-1].Date, "%");
          
                Table.Items.Clear();
         
            foreach (var item in r)
            {
                Table.Items.Add(item);
            }
        }
    }
}

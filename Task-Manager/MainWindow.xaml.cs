using DataBase;
using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace Task_Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyTask superTask = new MyTask()
            {
                Name = "Новая задача",
                Description = "Описание задачи",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
            };


            var connectionStr = Path.Combine(Environment.CurrentDirectory,
                ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DataBase.DataBase dataBaseCon = new DataBase.DataBase(connectionStr);

            dataBaseCon.AddTask(superTask);
            dataBaseCon.AddTask(superTask);
            dataBaseCon.DeleteTask(superTask);

        }
    }
}

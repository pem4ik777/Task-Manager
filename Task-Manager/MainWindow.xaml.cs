using DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            MyTask Firts = new MyTask();
            Firts.Name = "Имя";
            Firts.Description = "Описание";
            Firts.StartDate = DateTime.Now;
            Firts.EndDate = DateTime.Now.AddDays(7);
        
            DataBase DataBaseCon = new DataBase();
             DataBaseCon.AddTask(Firts);
             DataBaseCon.AddTask(Firts);

            MyTask Second = new MyTask();
            Second.TaskId = 1;

            DataBaseCon.DeleteTask(Second);
         
        }
    }
}

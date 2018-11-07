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

            Tasks ds = new Tasks("Задача о добавлении библиотеки в проект", "Суть задачи заключается в том, что нужно наконец-то добавить библиотеку в проект",DateTime.Now,DateTime.Now.AddDays(7),6);
            DataBase ss = new DataBase();
             ss.AddTask(ds);
             ss.AddTask(ds);
            ss.AddTask(ds);
            var TestTask = new Tasks(3);
            ss.DeleteTask(TestTask);
             ss.DeleteTask(ds);
        }
    }
}

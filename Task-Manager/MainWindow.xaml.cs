using DataBase;
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;

namespace Task_Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Controller cont = new Controller();
        TaskWindow window = new TaskWindow();
        public static string connectionStr = Path.Combine(Environment.CurrentDirectory,
            ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
       

        public MainWindow()
        {
            InitializeComponent();
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

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            window.Show();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataBase.DataBase dataBaseCon = new DataBase.DataBase(connectionStr);
            var items = Table.SelectedItems;
            /*

            Разобраться с этой херней

    */
            foreach (var item in items)
            {
                var b = (MyTask)item;
                dataBaseCon.DeleteTask(b);
                Table.SelectedItems.Remove(item);
            }

            Table.UpdateLayout();
        }
    }
}

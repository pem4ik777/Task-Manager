using System;
using System.Configuration;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Task_Manager
{
    public class Controller
    {
        public void GetTasks(ref Calendar Calendar1,ref DataGrid Table , string Priority)
        {
            Priority = Priority.Replace("System.Windows.Controls.ComboBoxItem: ","");
            if (Priority == "All")
                Priority = "%";

            var sdates = Calendar1.SelectedDates;
            string connectionStr = Path.Combine(Environment.CurrentDirectory,
                ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DataBase.DataBase dataBaseCon = new DataBase.DataBase(connectionStr);

            var r = dataBaseCon.GetResults(sdates[0].Date, sdates[sdates.Count - 1].Date, Priority);
                Table.Items.Clear();
            foreach (var item in r)
            {
                  Table.Items.Add(item);
            }
        }
    }
}
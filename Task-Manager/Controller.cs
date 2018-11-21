using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using DataBase;

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


        public void SortTasks(ref DataGrid Table, ref ComboBox CBsort)
        {
            var itemsCollection = Table.Items;
            List<MyTask> collectionTasks = new List<MyTask>();
            ComboBoxItem typeItem = (ComboBoxItem)CBsort.SelectedItem;
           

            foreach (var item in itemsCollection)
            {
                collectionTasks.Add(item as MyTask);
            }

            switch (typeItem.Content.ToString())
            {
                case "Date: New(upper)":
                    collectionTasks.Sort((a, b) => b.StartDate.CompareTo(a.StartDate));
                    break;
                case "Date: Old(upper)":
                    collectionTasks.Sort((a, b) => a.StartDate.CompareTo(b.StartDate));
                    break;
                case "Date: New(upper) + Priority(More)":
                    collectionTasks.OrderBy(x => x.StartDate).ThenBy(y => y.Priority);
                    break;
                case "Date: New(upper) + Priority(less)":
                    collectionTasks.OrderBy(x => x.StartDate).ThenBy(y => y.Priority);
                    break;
                case "Date: Old(upper) + Priority(More)":
                    break;
                case "Date: Old(upper) + Priority(less)":
                    break;
                default:
                    return;
            }

          

            Table.Items.Clear();

            foreach (var task in collectionTasks)
            {
                Table.Items.Add(task);
            }
        }
    }
}
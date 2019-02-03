using DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Task_Manager
{
    public class Controller
    {
        public void GetTasks(ref Calendar calendar1,ref DataGrid table , PriorityValue priority)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            var sdates = calendar1.SelectedDates;
            string connectionStr = Path.Combine(Environment.CurrentDirectory,
                ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DataBase.DataBase dataBaseCon = new DataBase.DataBase(connectionStr);

            var r = dataBaseCon.GetResults(sdates[0].Date, sdates[sdates.Count - 1].Date, priority);
                table.Items.Clear();
            foreach (var item in r)
            {
                  table.Items.Add(item);
            }
        }


        public void SortTasks(ref DataGrid table, ref ComboBox cBsort)
        {
            var itemsCollection = table.Items;
            List<MyTask> collectionTasks = new List<MyTask>();
            ComboBoxItem typeItem = (ComboBoxItem)cBsort.SelectedItem;
           

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
                case "Priority: Low(upper)":
                    collectionTasks.Sort((a, b) => a.Priority.CompareTo(b.Priority));
                    break;
                case "Priority: High(upper)":
                    collectionTasks.Sort((a, b) => b.Priority.CompareTo(a.Priority));
                    break;
                case "Date: New(upper) + Priority(More)":
                    collectionTasks = collectionTasks.OrderByDescending(x => x.StartDate).ThenByDescending(y => y.Priority).ToList();
                    break;
                case "Date: Old(upper) + Priority(More)":
                    collectionTasks = collectionTasks.OrderBy(x => x.StartDate).ThenByDescending(y => y.Priority).ToList();
                    break;
                default:
                    return;
            }

          

            table.Items.Clear();

            foreach (var task in collectionTasks)
            {
                table.Items.Add(task);
            }
        }
    }
}
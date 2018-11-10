using DataBase;
using SQLite;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager
{
    public class DataBase : IDataBase
    {
        string connStr;
        public DataBase()
        {

            connStr = Path.Combine(Environment.CurrentDirectory, ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

        }

        public bool AddTask(MyTask NewTask)
        {
            using (var dbconnect = new SQLiteConnection(connStr))
            {
                var r = dbconnect.GetTableInfo("MyTask");
                if (r.Count == 0)
                {
                    dbconnect.CreateTable<MyTask>(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK);
                }
                dbconnect.Insert(NewTask);
            }
            return true;
        }


        public bool DeleteTask(MyTask MyTask)
        {
            using (var dbconnect = new SQLiteConnection(connStr))
            {
                dbconnect.Delete(MyTask);
            }
            return true;
        }

        public bool Update(MyTask MyTask)
        {
            using (var dbconnect = new SQLiteConnection(connStr))
            {
                dbconnect.Delete(MyTask);
            }
            return true;
        }

    }
}

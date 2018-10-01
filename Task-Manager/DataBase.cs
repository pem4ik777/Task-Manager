using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager
{


    class DataBase
    {

        public SQLiteConnection DB;// new SQLite.SQLiteConnection("Data Source=TestDB.db; Version=3");


        public DataBase(SQLiteConnection DB)
        {
            this.DB = DB;
        }


        public bool AddTask(string name, string description)
        {
            try
            {
                DB.Open();

            }

            catch (Exception ex)
            {

                MessageBox.Show("Ошибка при подключении к базе данных", "Error");
            }

            return false;
        }

    }
}

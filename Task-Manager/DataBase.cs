using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_Manager
{

    public class Tasks
    {
        [PrimaryKey, SQLite.AutoIncrement]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Tasks(string Name, string Description)
        {
          
            this.Name = Name;
            this.Description = Description;
        }


        public Tasks(int TaskId)
        {

            this.TaskId = TaskId;
        }



        public Tasks( string Name, string Description, DateTime StartDate, DateTime EndDate , int TaskId=0 )
        {
            this.TaskId = TaskId;
            this.Name = Name;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

    }



    class DataBase
    {
        string DBpath = Path.Combine(Environment.CurrentDirectory, "TestDB111.db");
        public bool AddTask(Tasks NewTask)
        {
            var db = new SQLiteConnection("TestDB111.db");
            db.CreateTable<Tasks>(CreateFlags.ImplicitPK | CreateFlags.AutoIncPK);
            try
            {
                using (var DB = new SQLiteConnection(DBpath))
                {
                    DB.Insert(NewTask);
                }

                return true;
            }

            catch (Exception ex)
            {

                MessageBox.Show("Ошибка при добавлении задачи в базу данных: " + ex.Message, "Error");
                return false;
            }

        }


        public bool DeleteTask(Tasks MyTask)
        {
            try
            {
                using (var DB = new SQLiteConnection(DBpath))
                {
               //Тут нужно проверять не пустой ли ID, если пустой то удалять по другим параметрам
                    DB.Delete(MyTask);
                  
                }

                return true;
            }

            catch (Exception ex)
            {

                MessageBox.Show("Ошибка при удалении задачи из базы данных: " + ex.Message, "Error");
                return false;
            }
        }

    }
}

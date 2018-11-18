using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace DataBase
{
    public class DataBase : IDataBase
    {
        private readonly string _connStr;
        public DataBase(string connectionString)
        {

            _connStr = connectionString;
            CreateDb();
        }

        public void AddTask(MyTask newTask)
        {
            using (var connection = new SQLiteConnection(_connStr))
            {
                connection.Insert(newTask);
            }

        }


        public void DeleteTask(MyTask newTask)
        {
            using (var connection = new SQLiteConnection(_connStr))
            {
                connection.Delete(newTask);
            }

        }

        public void Update(MyTask newTask)
        {
            using (var connection = new SQLiteConnection(_connStr))
            {
                connection.Update(newTask);
            }

        }

        public List<MyTask> GetResults(DateTime StartDate, DateTime EndDate, string Priority)
        {
            List<MyTask> resultTasks = new List<MyTask>();
           
            using (var connection = new SQLiteConnection(_connStr))
            {
                resultTasks = connection.Query<MyTask>("Select * from MyTask where StartDate BETWEEN ? AND ? AND Priority LIKE ?", StartDate, EndDate, Priority);
            }

            return resultTasks;
        }

        public void CreateDb()
        {
            if (!File.Exists((_connStr)))
            {
                var connection = new SQLiteConnection(_connStr);
                connection.CreateTable<MyTask>();
                connection.Close();
            }
        }

    }
}

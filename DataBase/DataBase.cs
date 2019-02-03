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

        public List<MyTask> GetResults(DateTime startDate, DateTime endDate, PriorityValue priority)
        {
            List<MyTask> resultTasks;

            using (var connection = new SQLiteConnection(_connStr))
            {
                if (priority == PriorityValue.All)
                {
                    resultTasks = connection.Table<MyTask>().Where(x => x.StartDate >= startDate && x.StartDate <= endDate).ToList();
                }
                else
                {
                    resultTasks = connection.Table<MyTask>().Where(x => x.StartDate >= startDate && x.StartDate <= endDate && x.Priority == priority).ToList();
                }
            
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

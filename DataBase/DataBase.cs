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
                connection.Delete(newTask);
            }

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

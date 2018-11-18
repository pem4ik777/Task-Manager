using SQLite;
using System;

namespace DataBase
{
    public class MyTask
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Priority { get; set; }

    }

}



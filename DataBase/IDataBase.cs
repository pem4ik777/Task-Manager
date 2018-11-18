using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    interface IDataBase
    {
        void AddTask(MyTask newTask);
        void DeleteTask(MyTask newTask);
        void Update(MyTask newTask);
        List<MyTask> GetResults(DateTime StartDate, DateTime EndDate, string Priority);
    }
}

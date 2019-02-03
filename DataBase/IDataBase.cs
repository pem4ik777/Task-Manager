using System;
using System.Collections.Generic;

namespace DataBase
{
    interface IDataBase
    {
        void AddTask(MyTask newTask);
        void DeleteTask(MyTask newTask);
        void Update(MyTask newTask);
        List<MyTask> GetResults(DateTime StartDate, DateTime EndDate, PriorityValue Priority);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    interface IDataBase
    {
        bool AddTask(MyTask NewTask);
        bool DeleteTask(MyTask NewTask);
        bool Update(MyTask NewTask);
    }
}

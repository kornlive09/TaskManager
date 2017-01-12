using System;
using DB.Model;

namespace BL.TaskManagerModule.BL
{
    partial class TaskManager
    {
        private TaskModel FindOrExeption(long id, string exeption)
        {
            TaskModel select = this._repository.Find(id);
            if (select == null)
                throw new Exception(exeption);
            return select;
        }
    }
}

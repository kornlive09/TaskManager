using System;
using System.Linq;
using BL.TaskManagerModule.Infrastructure;
using DB.Model;
using Microsoft.SqlServer.Server;

namespace BL.TaskManagerModule.BL
{
    partial class TaskManager
    {
        public long Add(long? selectId, InsertEnum insert, string name)
        {
            TaskModel newTask = new TaskModel()
            {
                Name = name
            };
            this._repository.Add(newTask);
            this._unitOfWork.Save();

            try
            {
                this.Insert(newTask, selectId, insert);
            }
            catch (Exception exception)
            {
                this._repository.Delete(newTask);
                this._unitOfWork.Save();
                throw exception;
            }
            
            this._unitOfWork.Save();
            return newTask.Id;
        }

        

    }
}

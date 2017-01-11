using System;
using BL.TaskManagerModule;
using BL.TaskManagerModule.Infrastructure;
using DB.Model;
using DB.Repository;

namespace BL.TaskManagerModule.BL
{
    partial class Bl : ITaskManager
    {
        private UnitOfWork _unitOfWork;
        private RepositoryBase<TaskModel> _repository;

        public Bl()
        {
            this._unitOfWork = new UnitOfWork();
            this._repository = this._unitOfWork.Tasks;
        }

        public Bl(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = unitOfWork.Tasks;
        }

        public void Dispose()
        {
            this._unitOfWork.Dispose();
        }

#region Реализация интерфейса
        public void Delete(long id)
        {
            
        }



        public void Rename(long id, string newName)
        {
            throw new NotImplementedException();
        }

        public void Copy(long id)
        {
            throw new NotImplementedException();
        }

        public void Cut(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(long? idActive, InsertEnum insert, TaskModel task)
        {
            if (idActive == null)
            {
                task.Parent = null;
                task.ParentId = null;
                //task.Previous = null;
                //task.Next = null;
            }
        }
#endregion 
    }
}

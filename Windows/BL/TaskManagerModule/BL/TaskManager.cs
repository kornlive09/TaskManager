using System;
using BL.TaskManagerModule;
using BL.TaskManagerModule.Infrastructure;
using DB.Model;
using DB.Repository;

namespace BL.TaskManagerModule.BL
{
    partial class TaskManager : ITaskManager
    {
        private UnitOfWork _unitOfWork;
        private RepositoryBase<TaskModel> _repository;

        public TaskManager()
        {
            this._unitOfWork = new UnitOfWork();
            this._repository = this._unitOfWork.Tasks;
        }

        public TaskManager(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = unitOfWork.Tasks;
        }

        private TaskModel GetById(long? id)
        {
            if(id == null)
                return null;
            return GetById(id.Value);
        }

        private TaskModel GetById(long id)
        {
            TaskModel select = this._repository.Find(id);
            if (select == null)
                throw new Exception("Ошибка - TaskModel с таким id отсутствует");
            return select;
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

        

        
#endregion 
    }
}

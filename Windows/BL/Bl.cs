using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository;

namespace BL
{
    class Bl : IBl
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

        public void Add(long? parent, string name)
        {
            var newTask = new TaskModel()
            {
                ParentRefId = parent,
                Name = name
            };

            this._repository.Add(newTask);
            this._unitOfWork.Save();
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

        public void Insert(long? parent, int position)
        {
            throw new NotImplementedException();
        }
#endregion 
    }
}

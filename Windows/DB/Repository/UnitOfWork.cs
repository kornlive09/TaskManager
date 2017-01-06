using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace DB.Repository
{
    public class UnitOfWork : IDisposable
    {
        private TaskDbContext _db = new TaskDbContext();
        private TaskRepository _taskRepository;

        public TaskRepository Tasks
        {
            get
            {
                return this._taskRepository ?? (this._taskRepository = new TaskRepository(this._db));
            } 
        }

        public void Dispose()
        {
            this._db?.Dispose();
        }

        public void Save()
        {
            this._db?.SaveChanges();
        }
    }
}

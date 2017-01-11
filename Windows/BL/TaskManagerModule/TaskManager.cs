using System;
using BL.TaskManagerModule;
using BL.TaskManagerModule.BL;
using BL.TaskManagerModule.Infrastructure;
using BL.TaskManagerModule.Pattern.Commands;
using BL.TaskManagerModule.Pattern.ControlsUnits;
using BL.TaskManagerModule.Pattern.ControlsUnits.Repository;
using DB.Model;
using DB.Repository;

namespace BL.TaskManagerModule
{
    public class TaskManager : ITaskManager
    {
        private ITaskManager _bl;
        private IControlUnit _controlUnit;

        public TaskManager()
        {
            this._bl = new Bl(new UnitOfWork());
            this._controlUnit = new ControlUnit(new ListRepository());
        }

        private void Run(Command command)
        {
            this._controlUnit.StoreCommand(command);
            this._controlUnit.ExecuteCommand();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public long Add(long? selectId, InsertEnum insert, string name)
        {
            var command = new AddCommand(this._bl);
            this.Run(command);
            return command.Id;
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

        public void Insert(long? idSelect, InsertEnum insert, TaskModel task)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this._bl.Dispose();
            this._controlUnit.Dispose();
        }
    }
}

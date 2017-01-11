using BL.TaskManagerModule.Pattern.Commands;
using BL.TaskManagerModule.Pattern.ControlsUnits.Repository;

namespace BL.TaskManagerModule.Pattern.ControlsUnits
{
    class ControlUnit : IControlUnit
    {
        private readonly IRepository _repository;

        public ControlUnit(IRepository repository)
        {
            this._repository = repository;
        }


        public void StoreCommand(Command command)
        {
            this._repository.Add(command);
        }

        public void ExecuteCommand()
        {
            this._repository[_repository.Current].Execute();
        }

        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (this._repository.Current > 0)
                    this._repository[--this._repository.Current].UnExecute();
        }

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (this._repository.Current < this._repository.Count - 1)
                    this._repository[this._repository.Current++].Execute();
        }


        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}

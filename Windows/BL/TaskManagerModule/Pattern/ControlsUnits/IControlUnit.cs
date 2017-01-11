using System;
using BL.TaskManagerModule.Pattern.Commands;

namespace BL.TaskManagerModule.Pattern.ControlsUnits
{
    interface IControlUnit : IDisposable
    {
        void ExecuteCommand();
        void Redo(int levels);
        void StoreCommand(Command command);
        void Undo(int levels);
    }
}
using System;
using BL.TaskManagerModule.Pattern.Commands;

namespace BL.TaskManagerModule.Pattern.ControlsUnits.Repository
{
    interface IRepository : IDisposable
    {
        int Count { get; }
        int Current { get; set; }

        void Add(Command command);
        Command this[int index] { get; }
        
    }
}

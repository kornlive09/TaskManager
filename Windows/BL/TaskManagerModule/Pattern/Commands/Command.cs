using System;
using BL.TaskManagerModule;

namespace BL.TaskManagerModule.Pattern.Commands
{
    abstract class Command
    {
        public long Id { get; }
        protected ITaskManager Bl;

        public abstract void Execute();
        public abstract void UnExecute();
    }
}

using System;
using System.Collections.Generic;
using BL.TaskManagerModule.Pattern.Commands;

namespace BL.TaskManagerModule.Pattern.ControlsUnits.Repository
{
    class ListRepository : IRepository
    {
        private int _count;
        private readonly List<Command> _list;

        public ListRepository()
        {
            this._list = new List<Command>();
        }

#region Реализация интерфейса

        public int Count
        {
            get { return this._count; }
            private set
            {
                int total = this._count - value;

                for (int i = value; i < this._count; i++)
                {
                    this._list[i] = null;
                }

                this._count = value;
            } 
        }

        public int Current { get; set; }

        public void Add(Command command)
        {
            this._list.Add(command);
            this.Current++;
            this.Count = this.Current;
        }

        public Command this[int index]
        {
            get
            {
                if(index > this.Count - 1 || index < 0)
                    throw new Exception("Индекс вне деопазона");
                return this._list[index];
            }
        }

        public void Dispose()
        {
            
        }
    }
#endregion--------------------
}

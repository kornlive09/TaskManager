using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.TaskManagerModule.Infrastructure;
using DB.Model;

namespace BL.TaskManagerModule.BL
{
    partial class TaskManager
    {
        public void Insert(long insertedId, long? selectedId, InsertEnum insert)
        {
            this.Insert(GetById(insertedId), GetById(selectedId), insert);
        }

        public void Insert(TaskModel inserted, long? selectedId, InsertEnum insert)
        {
            this.Insert(inserted, GetById(selectedId), insert);
        }

        private TaskModel GetLastChildren(TaskModel parentTask, long? filterId)
        {
            TaskModel lastTask;
            if (parentTask == null)
            {
                lastTask = this._repository.GetAll()
                        .Where(x => x.Parent == null && x.Id != filterId)
                        .FirstOrDefault(x => x.NextId == null);
            }
            else
            {
                lastTask = parentTask.GetLastСhild();
            }
            return lastTask;
        }


        private void Insert(TaskModel insertedTask, TaskModel selectedTask, InsertEnum insert)
        {
            if (insert == InsertEnum.Inside)
            {
                TaskModel lastTask = this.GetLastChildren(selectedTask, insertedTask.Id);
                if (lastTask == null)
                {
                    insertedTask.Parent = selectedTask;
                    return;
                }
                selectedTask = lastTask;
                insert = InsertEnum.After;
            }

            if (selectedTask == null)
                    throw new Exception("переданно null как выделенный объект. Совместимо только с вставкой inside");

            //Заполнение
            insertedTask.Parent = selectedTask;
            //----------

            this.InsertLink(selectedTask, insertedTask, insert);
        }


        private void InsertLink(TaskModel selectedTask, TaskModel insertedTask, InsertEnum insert)
        {
            TaskModel previous = null;
            TaskModel next = null;

            switch (insert)
            {
                case InsertEnum.Before:
                    previous = selectedTask.Previous;
                    next = selectedTask;
                    break;
                case InsertEnum.After:
                    previous = selectedTask;
                    next = selectedTask.Next;
                    break;
            }

            insertedTask.Previous = previous;
            insertedTask.Next = next;
            if (previous != null)
                previous.Next = insertedTask;
            if (next != null)
                next.Previous = insertedTask;
        }


    }
}

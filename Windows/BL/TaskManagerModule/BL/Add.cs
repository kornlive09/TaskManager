using System;
using System.Linq;
using BL.TaskManagerModule.Infrastructure;
using DB.Model;

namespace BL.TaskManagerModule.BL
{
    partial class TaskManager
    {
        public long Add(long? selectId, InsertEnum insert, string name)
        {
            TaskModel newTask = new TaskModel()
            {
                Name = name
            };
            this._repository.Add(newTask);
            this._unitOfWork.Save();

            try
            {
                if (selectId == null)
                {
                    if (insert != InsertEnum.Inside)
                        throw new Exception("Ошибка валидации - ValidationInsertEnum()");
                    // Получить последнего на уровне NULL
                    TaskModel lastTask = this._repository.GetAll()
                        .Where(x => x.Parent == null && x.Id != newTask.Id)
                        .FirstOrDefault(x => x.NextId == null);
                    if (lastTask != null)
                    {
                        newTask.Previous = lastTask;
                        lastTask.Next = newTask;
                    }
                }
                else
                {
                    TaskModel selectTask = this.FindOrExeption(selectId.Value, "Ошибка валидации - id");

                    switch (insert)
                    {
                        case InsertEnum.Inside:
                            newTask.Parent = selectTask;
                            // Получить последнего ребенка
                            var lastChild = selectTask.GetLastСhild();
                            if (lastChild != null)
                            {
                                lastChild.Next = newTask;
                                newTask.Previous = lastChild;
                            }
                            break;

                        case InsertEnum.Before:
                            this.AddBefore(newTask, selectTask);
                            break;

                        case InsertEnum.After:
                            this.AddAfter(newTask, selectTask);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                this._repository.Delete(newTask);
                this._unitOfWork.Save();
                throw e;
            }

            this._unitOfWork.Save();
            return newTask.Id;
        }

        private void AddBefore(TaskModel newTask, TaskModel selectTask)
        {
            newTask.Parent = selectTask.Parent;
            // Получить предыдущего
            var previous = selectTask.Previous;
            if (previous != null)
            {
                newTask.Previous = previous;
                previous.Next = newTask;
                newTask.Next = selectTask;
                selectTask.Previous = newTask;
            }
            else
            {
                newTask.Next = selectTask;
                selectTask.Previous = newTask;
            }
        }

        private void AddAfter(TaskModel newTask, TaskModel selectTask)
        {
            newTask.Parent = selectTask.Parent;
            //----
            var next = selectTask.Next;
            if (next != null)
            {
                newTask.Previous = selectTask;
                newTask.Next = next;
                selectTask.Next = newTask;
                next.Previous = newTask;
            }
            else
            {
                newTask.Previous = selectTask;
                selectTask.Next = newTask;
            }
        }

    }
}

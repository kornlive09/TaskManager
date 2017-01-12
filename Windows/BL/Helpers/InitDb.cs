using BL.TaskManagerModule.Infrastructure;
using BL.TaskManagerModule;
using DB.Repository;
using BL.TaskManagerModule.BL;

namespace BL.Helpers
{
    public class InitDb
    {
        private readonly ITaskManager _taskManager;

        public InitDb()
        {
            var unitOfWork = new UnitOfWork();
            var repository = unitOfWork.Tasks;

            this._taskManager = new TaskManager(unitOfWork);
            
            FillingList(unitOfWork, 3, 3);

            //repository.Delete(repository.Find(1));
            //unitOfWork.Save();

            this._taskManager.Dispose();
        }

        private void FillingList(UnitOfWork unitOfWork, params int[] branch)
        {
            for (int i = 0; i < 3; i++)
            {
                var taskId = this._taskManager.Add((long?)null, InsertEnum.Inside, "Задача - " + i.ToString());
                //unitOfWork.Save();

                for (int k = 0; k < 3; k++)
                {
                    this._taskManager.Add(taskId, InsertEnum.Inside, "Задача - " + i.ToString() + " _ " + k.ToString());
                    //unitOfWork.Save();
                }

            }
        }

    }
}

using System;
using BL.TaskManagerModule.Infrastructure;
using DB.Model;

namespace BL.TaskManagerModule
{
    public interface ITaskManager : IDisposable
    {
        void Delete(long id);
        long Add(long? selectId, InsertEnum insert, string name);
        void Rename(long id, string newName);
        void Copy(long id);
        void Cut(long id);
        void Insert(long idPaste, long? idSelect, InsertEnum insert);
    }
}

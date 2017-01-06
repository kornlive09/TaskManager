using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data.Model;

namespace Core.Data
{
    public class DataBase : IDataBase
    {
        private TaskContext _context;

        

        public DataBase()
        {
            this._context = new TaskContext();

            TaskModel task1 = new TaskModel()
            {
                Name = "1 Задача"
            };

            TaskModel task2 = new TaskModel()
            {
                Name = "2 Задача",
                //ChildrenId = 1
                ParentId = 1
            };

            TaskModel task3 = new TaskModel()
            {
                Name = "3 Задача",
                //ChildrenId = 1
                ParentId = 1
            };

            TaskModel task4 = new TaskModel()
            {
                Name = "4 Задача",
                //ChildrenId = 1
                //ParentId = 2
            };

            

            this._context.Tasks.Add(task1);
            this._context.Tasks.Add(task2);
            this._context.Tasks.Add(task3);


            this._context.Tasks.Add(task4);
            task1.Children.Add(task4);



            this._context.SaveChanges();

            


            this._context.SaveChanges();

            this._context = new TaskContext();

            var lll = this._context.Tasks.ToList();

        }

    }
}

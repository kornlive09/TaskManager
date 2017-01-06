using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository;

namespace DB.Repository
{
    public class TaskRepository : RepositoryBase<TaskModel>
    {
        public TaskRepository(TaskDbContext context) : base(context)
        {
        }
    }
}

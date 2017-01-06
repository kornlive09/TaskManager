using System.Data.Entity;
using System.Data.Sql;

namespace Core.Data.Model
{
    class TaskContext : DbContext
    {
        public TaskContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<TaskContext>(new DropCreateDatabaseAlways<TaskContext>());
        }

        public DbSet<TaskModel> Tasks { get; set; }
        //public DbSet<ChildrensModel> Childrens { get; set; } 
    }
}

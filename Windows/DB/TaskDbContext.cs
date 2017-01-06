using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace DB
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<TaskDbContext>(new DropCreateDatabaseAlways<TaskDbContext>());
        }

        public DbSet<TaskModel> Tasks { get; set; } 
    }
}

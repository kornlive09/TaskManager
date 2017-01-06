using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Model
{
    //[Table("Tasks")]
    class TaskModel
    {

        public TaskModel()
        {
            this.Children = new List<TaskModel>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        public long? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public TaskModel Parent { get; set; }


        public ICollection<TaskModel> Children { get; set; } 
    }

}

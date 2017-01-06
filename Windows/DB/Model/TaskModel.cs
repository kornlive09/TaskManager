using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    public class TaskModel
    {
        [Key]
        public long Id { get; set; } 
        [Required]
        public string Name { get; set; }
        //[ForeignKey()]
        public long? ParentRefId { get; set; }
        [ForeignKey("ParentRefId")]
        public TaskModel Parent { get; set; }

        public ICollection<TaskModel> Children { get; set; } 
    }
}

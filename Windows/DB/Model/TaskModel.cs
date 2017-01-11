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
        public TaskModel()
        {
            this.Children = new List<TaskModel>();
        }

        [Key]
        public long Id { get; set; } 
        [Required]
        public string Name { get; set; }

        public bool IsMinimized { get; set; }

        public long? PreviousId { get; set; }
        [ForeignKey("PreviousId")]
        public TaskModel Previous { get; set; }
        
        public long? NextId { get; set; }
        [ForeignKey("NextId")]
        public TaskModel Next { get; set; }

        public long? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public TaskModel Parent { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<TaskModel> Children { get; set; }

        [InverseProperty("Previous")]
        public virtual ICollection<TaskModel> Previouss { get; set; }

        [InverseProperty("Next")]
        public virtual ICollection<TaskModel> Nexts { get; set; }

        public TaskModel GetLastСhild()
        {
            return this.Children.FirstOrDefault(x => x.NextId == null);
        }
    }
}

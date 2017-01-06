using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Model
{
    class Standard
    {
        [Key]
        public long Id { get; set; }

        //public int StandardId { get; set; }

        //[InverseProperty("Parent")]
        //public ICollection<TaskModel> NewColl { get; set; }
    }
}

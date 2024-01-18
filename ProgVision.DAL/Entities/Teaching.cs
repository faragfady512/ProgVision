using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Teaching : BaseEntity
    {
        // Foreign keys
        public int CourseId { get; set; }

        public int TrainerId { get; set; }


        // Navigation properties
        public virtual Courses Course { get; set; }
        public virtual Trainers Trainer { get; set; }
    }
}

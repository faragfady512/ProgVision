using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Exam : BaseEntity
    {
       
        public int CourseId { get; set; }
        public virtual Courses Course { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Revision> Revisions { get; set; }
    }
}

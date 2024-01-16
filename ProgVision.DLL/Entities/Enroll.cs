using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Enroll : BaseEntity
    {

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public virtual Courses Course { get; set; }

       
        public virtual Students Student { get; set; }


     
    }
}

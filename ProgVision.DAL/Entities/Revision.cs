using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Revision : BaseEntity
    {
        
        public float Grade { get; set; }
        public float TotalRightDegree { get; set; }
        public float TotalWrongDegree { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public int StudentId { get; set; }
        public virtual Students Student { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Questions : BaseEntity
    {
        [Required]
        public string Content { get; set; }
        public string Answer { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

    }
}

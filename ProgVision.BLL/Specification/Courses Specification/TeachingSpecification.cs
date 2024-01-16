using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Specification.Courses_Specification
{
    public class TeachingSpecification : BaseSpecification<Teaching>
    {

        // Constructor: Initializes the specification with a condition to match the specified course ID.
        public TeachingSpecification(int courseId)
        : base(t => t.CourseId == courseId)
        {

        }
    }
}

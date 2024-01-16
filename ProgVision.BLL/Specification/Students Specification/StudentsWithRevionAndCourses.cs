using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Specification.Students_Specification
{
    public class StudentsWithRevionAndCourses : BaseSpecification<Students>
    {
        public StudentsWithRevionAndCourses()
        {
            Includes.Add(x => x.Revisions);
          



        }


    }
}

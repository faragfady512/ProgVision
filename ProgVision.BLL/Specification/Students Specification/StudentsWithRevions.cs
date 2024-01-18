using ProgVision.BLL.Features.Students.Queries.GetAllStudents;
using ProgVision.BLL.Features.Students.Queries.GetStudentDetails;
using ProgVision.BLL.Interfaces;
using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Specification.Students_Specification
{
    public class StudentsWithRevions : BaseSpecification<Students>
    {
        public StudentsWithRevions(GetAllStudentsQuery query)
           : base(s =>
           (query.StudentId == 0 || s.Id == query.StudentId) &&
           (string.IsNullOrEmpty(query.StudentName) || s.Name.Contains(query.StudentName))
           )  

        {
            Includes.Add(x => x.Revisions);

      
            ApplySorting(query.Sort);
           
        }


        public StudentsWithRevions(int Id): base(C => C.Id == Id)
        {
            Includes.Add(x => x.Revisions);
        }








        // Apply sorting to the specification based on the provided criteria.
        // Sort by name in ascending order.
        // Sort by email in ascending order.
        // Sort by the sum of grades in descending order.
        // Sort by the sum of total right degrees in descending order.
        // Sort by the sum of total wrong degrees in descending order.
        // Sort by ID in ascending order.

        private void ApplySorting(string sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "name":
                        AddOrderBy(s => s.Name);
                        break;

                    case "email":
                        AddOrderBy(s => s.Email);
                        break;

                    case "grade":
                        AddOrderByDescending(s => s.Revisions.Sum(r=>r.Grade));
                        break;

                    case "total_right_degree":
                        AddOrderByDescending(s => s.Revisions.Sum(r => r.TotalRightDegree));
                        break;

                    case "total_wrong_degree":
                        AddOrderByDescending(s => s.Revisions.Sum(r => r.TotalWrongDegree));
                        break;

                    case "id":
                        AddOrderBy(s => s.Id);
                        break;


                    default:
                        // Default sorting (e.g., by name ascending)
                        AddOrderBy(c => c.Name);
                        break;
                }

            }
        }


    }


}

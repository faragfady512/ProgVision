using Microsoft.EntityFrameworkCore.Query;
using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Specification
{





    public class CoursesWithCategoriesAndTraniers : BaseSpecification<Courses>
    {
        public CoursesWithCategoriesAndTraniers(string sort, int categoryId, int trainerId , string courseName ,string categoryName , int? pageIndex, int? pageSize)
            :base(c =>
            (categoryId == 0 || c.CategoryId == categoryId) &&
            (trainerId == 0 || c.Teachings.Any(t => t.TrainerId == trainerId))&&
            (string.IsNullOrEmpty(courseName) || c.Name.Contains(courseName))&&
            (string.IsNullOrEmpty(categoryName) || c.Category.Name.Contains(categoryName))

        )
        {
           
            Includes.Add(c => c.Category);
            Includes.Add(c => c.Teachings);
            ApplySorting(sort);
            //ApplyPaging(pageIndex, pageSize);

        }



        public CoursesWithCategoriesAndTraniers(int id) : base(C => C.Id == id)
        {


            Includes.Add(c => c.Category);
            Includes.Add(c => c.Teachings);


        }


        private void ApplySorting(string sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    case "name":
                        AddOrderBy(c => c.Name);
                        break;

                    case "level":
                        AddOrderBy(c => c.Level);
                        break;

                    case "createdate":
                        AddOrderBy(c => c.CreatedAt);
                        break;

                    case "createdat_desc":
                        AddOrderByDescending(c => c.CreatedAt);
                        break;

                    // Add other cases for additional sorting options

                    default:
                        // Default sorting (e.g., by name ascending)
                        AddOrderBy(c => c.Name);
                        break;
                }

            }
        }
    }
}


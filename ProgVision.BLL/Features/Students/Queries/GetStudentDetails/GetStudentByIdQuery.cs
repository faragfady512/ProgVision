using MediatR;
using ProgVision.BLL.Features.Students.Queries.GetAllStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Features.Students.Queries.GetStudentDetails
{
    public class GetStudentByIdQuery: IRequest<IReadOnlyList<StudentsQueryDto>>
    {
        public int Id { get; set; }


    }
}

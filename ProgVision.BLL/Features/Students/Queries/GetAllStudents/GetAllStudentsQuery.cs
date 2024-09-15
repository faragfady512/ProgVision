using MediatR;
using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<IReadOnlyList<StudentsQueryDto>>
    {

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string Sort { get; set; }

    }
}

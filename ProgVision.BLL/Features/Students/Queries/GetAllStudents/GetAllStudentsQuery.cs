using MediatR;
using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<StudentsQueryDto>>
    {

    }
}

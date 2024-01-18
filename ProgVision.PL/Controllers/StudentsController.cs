using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgVision.BLL.Features.Students.Queries.GetAllStudents;
using ProgVision.BLL.Features.Students.Queries.GetStudentDetails;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProgVision.PL.Controllers
{

    public class StudentsController : BaseApiController
    {


        private readonly ISender _sender;
        public StudentsController(ISender sender)
        {
            _sender = sender;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StudentsQueryDto>>> GetAllStudents([FromQuery] GetAllStudentsQuery query)
        {
            var Students = await _sender.Send(query);

            return Ok(Students);

        }

        [HttpGet("id")]
        public async Task<ActionResult<IReadOnlyList<StudentsQueryDto>>> GetStudentsById([FromQuery] GetStudentByIdQuery query)
        {
            var Student = await _sender.Send(query);

            return Ok(Student);

        }





    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgVision.BLL.Features.Students.Queries.GetAllStudents;
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
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _sender.Send(new GetAllStudentsQuery());

            return Ok(result);

        }



    }
}

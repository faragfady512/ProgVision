using AutoMapper;
using MediatR;
using ProgVision.BLL.Interfaces;
using ProgVision.BLL.Specification;
using ProgVision.BLL.Specification.Students_Specification;
using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgVision.BLL.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery,List<StudentsQueryDto>>
    {
        private readonly IGenericRepository<DAL.Entities.Students> _studentsRepo;
        private readonly IMapper _mapper;



        public GetAllStudentsQueryHandler(IGenericRepository<DAL.Entities.Students> studentsRepo, IMapper mapper)
        {
            _studentsRepo = studentsRepo;
            _mapper = mapper;
        }

        public async Task<List<StudentsQueryDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
    
           

            var spec = new StudentsWithRevionAndCourses();

            var students = await _studentsRepo.GetAllWithSpecAsync(spec);

            var studentDtos = _mapper.Map<List<StudentsQueryDto>>(students);

           

            return studentDtos.ToList();
        }
    }
}

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
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IReadOnlyList<StudentsQueryDto>>
    {
        private readonly IGenericRepository<DAL.Entities.Students> _studentsRepo;
        private readonly IMapper _mapper;



        public GetAllStudentsQueryHandler(IGenericRepository<DAL.Entities.Students> studentsRepo, IMapper mapper)
        {
            _studentsRepo = studentsRepo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<StudentsQueryDto>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
        {

            var spec = new StudentsWithRevions(query);

            var students = await _studentsRepo.GetAllWithSpecAsync(spec);

            var studentDtos = _mapper.Map<IReadOnlyList<StudentsQueryDto>>(students);

            return studentDtos;
        }
    }
}



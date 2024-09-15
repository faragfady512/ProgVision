using AutoMapper;
using MediatR;
using ProgVision.BLL.Features.Students.Queries.GetAllStudents;
using ProgVision.BLL.Interfaces;
using ProgVision.BLL.Specification.Students_Specification;
using ProgVision.BLL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgVision.BLL.Features.Students.Queries.GetStudentDetails
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, IReadOnlyList<StudentsQueryDto>>
    {
       
        #region Properties

        private readonly IGenericRepository<DAL.Entities.Students> _studentsRepo;
        private readonly IMapper _mapper;

        #endregion


        #region Constractur
        public GetStudentByIdQueryHandler(IGenericRepository<DAL.Entities.Students> studentsRepo, IMapper mapper)
        {
            _studentsRepo = studentsRepo;
            _mapper = mapper;
        }
        #endregion


        public async Task<IReadOnlyList<StudentsQueryDto>> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {

            var spec = new StudentsWithRevions(query.Id);

            var students = await _studentsRepo.GetAllWithSpecAsync(spec);

            //ImageUtilities.ConvertByteArrayToImageUrl(students);

            var studentDtos = _mapper.Map<IReadOnlyList<StudentsQueryDto>>(students);



            return studentDtos;

        }
    }
}

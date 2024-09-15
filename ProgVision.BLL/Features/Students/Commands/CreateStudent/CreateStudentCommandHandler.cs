using AutoMapper;
using MediatR;
using ProgVision.BLL.Interfaces;
using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProgVision.DAL.Entities;
using ProgVision.BLL.Utilities;
using Microsoft.AspNetCore.Http;
namespace ProgVision.BLL.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateSudentCommand,int>
    {
        private readonly IGenericRepository<DAL.Entities.Students> _studentsRepo;
        private readonly IMapper _mapper;



        public CreateStudentCommandHandler(IGenericRepository<DAL.Entities.Students> studentsRepo, IMapper mapper)
        {
            _studentsRepo = studentsRepo;
            _mapper = mapper;
        }


        public async Task<int> Handle(CreateSudentCommand request, CancellationToken cancellationToken)
        {

            byte[] imageData = await ConvertIFormFileToByteArray.Convert(request.Image);


            //var student = _mapper.Map<DAL.Entities.Students>(request);

            var student = new DAL.Entities.Students
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone,
                Collage = request.Collage,
                CreatedAt = DateTime.UtcNow,

                Image = imageData,
            };

            ImageUtilities.SaveImage(request.Image);





            _studentsRepo.Add(student);


            // Return the student ID or any relevant information
            return student.Id;
        }


    }
}

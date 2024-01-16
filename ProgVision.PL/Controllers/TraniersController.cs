using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgVision.BLL.Interfaces;
using ProgVision.DAL.Entities;
using System.Collections.Generic;
using ProgVision.PL.Dtos;
using System.Threading.Tasks;

namespace ProgVision.PL.Controllers
{

    public class TraniersController : BaseApiController
    {
        private readonly IGenericRepository<Trainers> _trainersRepo;
        private readonly IMapper _mapper;
        public TraniersController(IGenericRepository<Trainers> trainersRepo, IMapper mapper)
        {
            _trainersRepo = trainersRepo;
            _mapper = mapper;

        }

        [HttpGet("Traniers")]
        public async Task<ActionResult<IReadOnlyList<Trainers>>> GetAllTraniers()
        {
            var Traniers = await _trainersRepo.GetAllAsync();

            var TrainerReturnDto = _mapper.Map<List<TrainerReturnDto>>(Traniers);

            return Ok(TrainerReturnDto);

        }


        //[HttpPost("{TranireId}")]
        //public async Task<ActionResult<IReadOnlyList<Trainers>>> AddTranier(Trainers trainer)
        //{
        //    //var TrainerReturnDto = _mapper.Map<List<TrainerReturnDto>>(Traniers);

        //    var Traniers = await _trainersRepo.Add(trainer);





        //    return Ok(TrainerReturnDto);

        //}

        [HttpPut("{TranireId}")]
        public async Task<ActionResult<IEnumerable<Trainers>>> UpdateTranier( int tranireId)
        {
            var Traniers = await _trainersRepo.GetByIdAsync( tranireId);

            var TrainerReturnDto = _mapper.Map<List<TrainerReturnDto>>(Traniers);

            return Ok(TrainerReturnDto);

        }


    }
}

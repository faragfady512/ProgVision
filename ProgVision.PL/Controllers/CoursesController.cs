using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProgVision.BLL.Interfaces;
using ProgVision.BLL.Specification;
using ProgVision.BLL.Specification.Courses_Specification;
using ProgVision.DAL.Context;
using ProgVision.DAL.Entities;
using ProgVision.PL.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgVision.PL.Controllers
{



    public class CoursesController : BaseApiController
    {
        private readonly IGenericRepository<Courses> _coursesRepo;
        private readonly IGenericRepository<Trainers> _trainersRepo;
        private readonly IGenericRepository<Categories> _categoriesRepo;
        private readonly IGenericRepository<Teaching> _teachingRepo;
        //private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISender _sender;


        public CoursesController(IGenericRepository<Teaching> teachingRepo, IGenericRepository<Courses> coursesRepo, IGenericRepository<Trainers> trainersRepo, IGenericRepository<Categories> categoriesRepo, IMapper mapper , ISender sender)
        {
            _coursesRepo = coursesRepo;
            _categoriesRepo = categoriesRepo;
            _trainersRepo = trainersRepo;
            _mapper = mapper;
            _teachingRepo = teachingRepo;
            _sender = sender;
            //_dbContext = dbContext;


        }

        // This End Point send all courses 
        // Sort by [Name,Level,CreatedDateAsc,CreatedDateDesc]
        //Filtration Data by Courses CategoryID, TranierId 
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Courses>>> GetAllCourses(string sort, int categoryId, int trainerId, string courseName, string categoryName, int? pageIndex, int? pageSize)
        {


            var spec = new CoursesWithCategoriesAndTraniers(sort, categoryId, trainerId, courseName, categoryName, pageIndex, pageSize);

            var courses = await _coursesRepo.GetAllWithSpecAsync(spec);

            var courseDtos = _mapper.Map<List<CoursesReturnDto>>(courses);

            return Ok(courseDtos);

        }



        [HttpGet("id")]
        public async Task<ActionResult<IReadOnlyList<Courses>>> GetCoursesbyid(int id)
        {
            var spec = new CoursesWithCategoriesAndTraniers(id);

            var courses = await _coursesRepo.GetAllWithSpecAsync(spec);

            var courseDtos = _mapper.Map<List<CoursesReturnDto>>(courses);

            return Ok(courseDtos);
        }



        [HttpGet("Catogories")]
        public async Task<ActionResult<IReadOnlyList<Categories>>> GetAllCategories()
        {
            var Categories = await _categoriesRepo.GetAllAsync();

            var CategoriesDtos = _mapper.Map<List<CategoriesReturnDto>>(Categories);

            return Ok(CategoriesDtos);

        }



        [HttpPost]
        public async Task<ActionResult<CoursesReturnDto>> CreateCourse([FromBody] CoursesCreateDto createDto)
        {
            if (createDto == null)
            {
                return BadRequest("Invalid data provided");
            }



            var Courses = _mapper.Map<Courses>(createDto);



            _coursesRepo.Add(Courses);

            var courseId = Courses.Id;

            //var teachingEntity = _mapper.Map<Teaching>(createDto);

            var teaching = _mapper.Map<Teaching>(createDto);

            teaching.CourseId = courseId;


            _teachingRepo.Add(teaching);

            return Ok(Courses);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CoursesReturnDto>> UpdateCourse(int id, [FromBody] CoursesCreateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid data provided");
            }

            // Fetch the existing Courses entity from the repository
            var existingCourse = await _coursesRepo.GetByIdAsync(id);

            if (existingCourse == null)
            {
                return NotFound($"Course with ID {id} not found");
            }

            // Map the properties from the updateDto to the existingCourses entity
            _mapper.Map(updateDto, existingCourse);

            // Update the existingCourses entity in the repository
            _coursesRepo.Update(existingCourse);

            // Update the Teaching entity associated with the course

            var existingTeaching = await _teachingRepo.GetEntityWithSpec(new TeachingSpecification(existingCourse.Id));

            if (existingTeaching != null)
            {
                _mapper.Map(updateDto, existingTeaching);

                // Update the existingTeaching entity in the repository
                _teachingRepo.Update(existingTeaching);

            }



            // Map the updated Courses entity to CoursesReturnDto for response
            var updatedCourseDto = _mapper.Map<CoursesReturnDto>(existingCourse);

            return Ok(updatedCourseDto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            // Fetch the existing Courses entity from the repository
            var existingCourse = await _coursesRepo.GetByIdAsync(id);

            if (existingCourse == null)
            {
                return NotFound($"Course with ID {id} not found");
            }

            // Fetch the Teaching entity associated with the course
            var existingTeaching = await _teachingRepo.GetEntityWithSpec(new TeachingSpecification(existingCourse.Id));

            if (existingTeaching != null)
            {
                // Delete the existingTeaching entity from the repository
                _teachingRepo.Delete(existingTeaching);
            }

            // Delete the existingCourses entity from the repository
            _coursesRepo.Delete(existingCourse);

            return Ok($"Course with ID {id} is deleted successfully.");
        }













    }
}

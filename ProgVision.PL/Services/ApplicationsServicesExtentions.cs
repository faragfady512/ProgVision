using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProgVision.BLL.Features.Students.Queries.GetAllStudents;
using ProgVision.BLL.Interfaces;
using ProgVision.BLL.Repositories;
using ProgVision.PL.Helpers;
using System.Text.Json.Serialization;

namespace ProgVision.PL.Services
{
    public static class ApplicationsServicesExtentions
    {


            public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            // Add the generic repository and its implementation

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));








            /*services.AddCors();*/ // Enable CORS

            //services.AddControllers()
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //    options.JsonSerializerOptions.MaxDepth = 256; 
            //});




            services.AddAutoMapper(typeof(MappingProfile)); //  AutoMapper for mapping Dto to Entities


                //// Configure API behavior options to handle invalid model states and return detailed error messages
                //services.Configure<ApiBehaviorOptions>(Options =>
                //{
                //    Options.InvalidModelStateResponseFactory = (actionContext) =>
                //    {
                //        var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count > 0)
                //                                             .SelectMany(M => M.Value.Errors)
                //                                              .Select(E => E.ErrorMessage)
                //                                              .ToArray();


                //        // Create a ValidationErrorsMessagecs object with the extracted errors
                //        var ValidationErrorsMessages = new ValidationErrorsMessagecs()
                //        {
                //            Errors = errors


                //        };

                //        return new BadRequestObjectResult(ValidationErrorsMessages);
                //    };
                //});

                return services;

            }
        }
}

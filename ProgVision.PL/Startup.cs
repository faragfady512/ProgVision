using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProgVision.DAL.Context;
using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgVision.PL.Services;
using MediatR;
using ProgVision.BLL.Features.Students.Queries.GetAllStudents;
using ProgVision.BLL.Features.Students.Commands.CreateStudent;
using System.Reflection;
using ProgVision.BLL.Features.Students.Queries.GetStudentDetails;

namespace ProgVision.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProgVision.PL", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("ConnectionString")));


            services.AddMediatR(typeof(GetAllStudentsQueryHandler).Assembly);

            /*   services.AddMediatR(typeof(Startup)); // Make sure to include the assembly where your handlers */

            services.AddTransient<IRequestHandler<CreateSudentCommand, int>, CreateStudentCommandHandler>();

            //services.AddTransient<IRequestHandler<GetStudentByIdQuery, IReadOnlyList<StudentsQueryDto>>, GetStudentByIdQueryHandler>();





            services.AddApplicationServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProgVision.PL v1"));
            }

            app.UseStaticFiles();


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

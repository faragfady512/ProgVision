
﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace ProgVision.BLL.Features.Students.Commands.CreateStudent
{
    public class CreateSudentCommand : IRequest<int>
    {
        [Required]
        public string Name { get; set; }

        [Required] 
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Collage { get; set; }

        public IFormFile Image { get; set; }

    }
}

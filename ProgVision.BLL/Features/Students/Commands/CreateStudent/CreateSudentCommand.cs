<<<<<<< HEAD
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
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Features.Students.Commands.CreateStudent
{
    internal class CreateSudentCommand
    {
>>>>>>> 76131d9934d7f032ac6c417102247dc234308d62
    }
}

using ProgVision.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Features.Students.Queries.GetAllStudents
{
    public class StudentsQueryDto
    {
        public int ID { get; set; }
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


        public byte[] Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public float Student_grade { get; set; }

        public float Total_Right_Degree { get; set; }

        public float Total_Wrong_Degree { get; set; }




    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Runtime.Serialization;

namespace ProgVision.PL.Dtos
{
    public class CoursesCreateDto
    {
       
 

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name must not exceed 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Level is required.")]
        public string Level { get; set; }

        public string ImageUrl { get; set; }

        //[JsonFormat(DateTimeFormat = "yyyy-MM-dd")]

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public int TraniersId { get; set; }
    }
}

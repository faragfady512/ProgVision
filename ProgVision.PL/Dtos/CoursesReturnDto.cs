using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace ProgVision.PL.Dtos
{
    public class CoursesReturnDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name must not exceed 255 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Level is required.")]
        public string Level { get; set; }

        public string Image { get; set; }

        public DateTime CreatedAt { get; set; } 

        public string CategoryName { get; set; }

        public string TraniersName { get; set; }



    }
}

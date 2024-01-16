using System.ComponentModel.DataAnnotations;

namespace ProgVision.PL.Dtos
{
    public class TrainerReturnDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "TrainerName is required")]
        [StringLength(100, ErrorMessage = "TrainerName must be at most 100 characters")]
        public string Name { get; set; }
    }
}

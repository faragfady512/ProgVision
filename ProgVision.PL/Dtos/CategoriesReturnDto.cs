using System;
using System.ComponentModel.DataAnnotations;

namespace ProgVision.PL.Dtos
{
    public class CategoriesReturnDto
    {
        public int CategoriesId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}

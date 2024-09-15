using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Courses : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public int TeachingsId { get; set; }

        [JsonIgnore]
        public virtual Categories Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<Enroll> Enrollments { get; set; }

        [JsonIgnore]
        public virtual ICollection<Teaching> Teachings { get; set; }

        [JsonIgnore]
        public virtual ICollection<Exam> Exams { get; set; }
        

    }
}

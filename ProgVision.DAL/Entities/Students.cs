using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Students :BaseEntity
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


        public byte[] Image { get; set; }

        public DateTime CreatedAt { get; set; }



        [JsonIgnore]
        public virtual ICollection<Revision> Revisions { get; set; }

        [JsonIgnore]
        public virtual ICollection<Enroll> Enrollments { get; set; }
        


    }
}

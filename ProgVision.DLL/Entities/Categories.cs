using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{
    public class Categories : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
    }
}

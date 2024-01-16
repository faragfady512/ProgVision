using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.DAL.Entities
{

        public class Admin :BaseEntity
        {
            [Required]
            public string Name { get; set; }
            
           [Required]
            public string Role { get; set; }
            public byte[] Image { get; set; }
        }
    
}

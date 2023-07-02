using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedesingApi.Shared
{
    public record LoginDto
    {
        [Required]
         public string email {get;set;}
        [Required]
        public string Password {get;set;}
    }
}
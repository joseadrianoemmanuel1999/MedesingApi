using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedesingApi.Dto
{
    public class RegisterDto
    {
         public Guid id {get;set;}
        [Required]
        public EmailAddressAttribute email {get;set;}
        [Required]
        public string Password {get;set;}
        [Required]
        public 
    }
}
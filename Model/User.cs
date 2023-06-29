using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedesingApi.Model
{
    public class User
    {
        [Required]
        public Guid id {get;set;}
        [Required]
        public EmailAddressAttribute email {get;set;}
        [Required]
        public string Password {get;set;}

    }
}
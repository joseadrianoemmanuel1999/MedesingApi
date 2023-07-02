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
         public string FirstName {get;set;}
         [Required]
          public string SurName {get;set;}
        [Required,EmailAddress]
        public string email {get;set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
       [Required]
       public ICollection<Post>Posts {get;set;}
       [Required]
       public Roles Roles {get;set;}

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MedesingApi.Model
{
    public class Post
    {
        [Required]
        public Guid id {get;set;}
        [Required]
        public string Text {get;set;}
        [Required]
        public DateTime CreatedTimestamp {get;set;}
        [Required]
        public ICollection<User>user {get;set;}

    }
}
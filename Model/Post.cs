using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MedesingApi.Model
{
    public class Post
    {
        [Required]
        public Guid id {get;set;}
        [Required]
        public string Title {get;set;}
        
        [Required]
        public string Text {get;set;}
        [Required]
        public DateTime CreatedTimestamp {get;set;}
        [ForeignKey(nameof(User))]
        [Required]
        public Guid UserId {get;set;}
        [Required]
        public User User {get;set;}

       

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedesingApi.Model;

namespace MedesingApi.Shared
{
    public record PostDto
    {
           [Required]
        public string Title {get;set;}
        
        [Required]
        public string Text {get;set;}
        [Required]
        public DateTime CreatedTimestamp {get;set;} = DateTime.Now;
       
        
    }
}
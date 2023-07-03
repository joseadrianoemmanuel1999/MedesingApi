using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedesingApi.Shared
{
    public record EditpostDto
    {
        public Guid id{get;set;}
        public string? Title {get;set;}=string.Empty;
        public string? Text {get;set;}=string.Empty;
        
    }
}
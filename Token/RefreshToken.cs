using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedesingApi.Token
{
    public class RefreshToken
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
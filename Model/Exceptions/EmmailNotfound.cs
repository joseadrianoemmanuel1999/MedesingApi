using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedesingApi.Model.Exceptions
{
   
      public sealed class EmmailNotfound : NotFoundException
    {
        public EmmailNotfound(User email)
        : base ($"The email with id: {email} doesn't exist in the database.")
        {
            
        }
    }
}
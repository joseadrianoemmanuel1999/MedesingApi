using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedesingApi.Db
{
    public class Appcontext : DbContext
    {
         private const string ConnectionString =@"server=localhost; database=MeDesign; Integrated Security=true;TrustServerCertificate=true";
 protected override void OnConfiguring(
 DbContextOptionsBuilder optionsBuilder)
 {
 optionsBuilder
 .UseSqlServer(connectionString:"appsettings");
 }
        
    }
}
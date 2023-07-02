using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedesingApi.Model;
namespace MedesingApi.Db
{
    public class Appcontext : DbContext
    {
         protected readonly IConfiguration Configuration;

    public Appcontext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"));
    }
    public DbSet<User> Users {get;set;}
    public DbSet<Post> Posts {get;set;}
    }

}
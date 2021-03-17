using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.Models.Dashboard.Models;

namespace Theater.Context
{
    public class DataContext : DbContext
    {
        public static Microsoft.Extensions.Configuration.IConfiguration Configuration { get; private set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Play> Plays { get; set; }
        public DbSet<PlayActor> PlayActors { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            string Path = "appsettings.json";

            Configuration = new ConfigurationBuilder()
               .Add(new JsonConfigurationSource { Path = Path, Optional = false, ReloadOnChange = true })
               .Build();
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration[string.Join(":", new string[] { "ConnectionStrings", "SQLDb" })]);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlayActor>().HasKey(pa => new { pa.PkFkActorId, pa.PkFkPlayId });


            ActorsSeed(modelBuilder);
        }



        private void ActorsSeed(ModelBuilder modelBuilder)
        {
            var actors = new List<Actor>()
            {
                new Actor(){Id=1,FirstName="William",LastName="Shakespeare"},
                new Actor(){Id=2,FirstName="Michael",LastName="Ball"},
                new Actor(){Id=3,FirstName="Bal",LastName="Dhuri"},
                new Actor(){Id=4,FirstName="Harrison",LastName="Chad"},
                new Actor(){Id=5,FirstName="Leah",LastName="Clark"},
            };

            modelBuilder.Entity<Actor>().HasData(actors);
        }

    }
}

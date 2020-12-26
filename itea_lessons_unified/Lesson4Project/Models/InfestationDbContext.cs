using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Models
{
    public class InfestationDbContext : DbContext
    {
        
        public DbSet<Human> Humans { get; set; }
        public DbSet<Country> Countries { get; set; }

        private IConfiguration configuration { get; }

        public InfestationDbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-9C7TTKC\\SQLSERVER;Database=Infestation;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("InfestationDbConnectionNew")).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                   new  { Id = 1, Name = "US", Population = 328200000, SickCount = 17860634, DeadCount = 317729, RecoveredCount = 16800450, Vaccine = false },
                   new  { Id = 2, Name = "India", Population = 1353150536, SickCount = 10055560, DeadCount = 145810, RecoveredCount = 9606111, Vaccine = false },
                   new  { Id = 3, Name = "Brazil", Population = 209500000, SickCount = 7238600, DeadCount = 186764, RecoveredCount = 6409986, Vaccine = false });

            modelBuilder.Entity<Human>().HasData(
                new Human { Id = 1, FirstName = "Obi-wan", LastName = "Kenobi", Age = 38, IsSick = false, Gender = "Male", CountryId = 1 },
                new Human { Id = 2, FirstName = "Sanwise", LastName = "Gamgee", Age = 54, IsSick = false, Gender = "Male", CountryId = 1},
                new Human { Id = 3, FirstName = "Hose", LastName = "Rodriges", Age = 30, IsSick = true, Gender = "Male", CountryId = 3 },
                new Human { Id = 4, FirstName = "Consuela", LastName = "Tridana", Age = 43, IsSick = false, Gender = "Female", CountryId = 3},
                new Human { Id = 5, FirstName = "Ana", LastName = "Cormelia", Age = 25, IsSick = true, Gender = "Female", CountryId = 3 },
                new Human { Id = 6, FirstName = "Thomas", LastName = "Edison", Age = 84, IsSick = true, Gender = "Male", CountryId = 1 });
        }


    }
}

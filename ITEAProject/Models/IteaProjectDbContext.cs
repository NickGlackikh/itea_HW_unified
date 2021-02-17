using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITEAProject.Models
{
    public class IteaProjectDbContext:IdentityDbContext
    {
        public IteaProjectDbContext(DbContextOptions<IteaProjectDbContext> options) : base(options) { }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
                        .HasOne(p => p.Owner)
                        .WithMany(t => t.Pets)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, Address=  "1 Sobornyj ave. Zaporizhzhya", Phone="+380661112233" },
                new Branch { Id = 2, Address = "2 Yavornytskogo ave. Dnipro", Phone="+380994445566" },
                new Branch { Id = 3, Address = "3 Khreschshatyk str. Kyiv", Phone="+380507778899" });

            modelBuilder.Entity<Breed>().HasData(
                new Breed { Id = 1, BreedName="German Shepherd", BreedDescription="Description1"},
                new Breed { Id = 2, BreedName = "Bigl", BreedDescription = "Description2" },
                new Breed { Id = 3, BreedName = "French Bulldog", BreedDescription = "Description3" });

            modelBuilder.Entity<Owner>().HasData(
                new Owner { Id = 1, Address = "23, Yablochnaya Street, Zaporizhzhya", OwnerName = "Ivanov I.I.", Phone = "+380661234567" },
                new Owner { Id = 2, Address = "35, Myra Street, Vinnitsya",  OwnerName = "Petrov A.I.", Phone = "+380950001144" },
                new Owner { Id = 3, Address = "90, Shevchenko Street, Kharkiv", OwnerName = "Golovanova I.O.", Phone = "+380939339393" }
                );

            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, Age = 3, BranchId = 1, BreedId = 2, Gender=Gender.Female,   PetName= "Berta" },
                new Pet { Id = 2, Age = 1, BranchId = 1, BreedId = 1, Gender = Gender.Male,   PetName = "Joe" },
                new Pet { Id = 3, Age = 2, BranchId = 2, BreedId = 3, Gender = Gender.Male,   PetName = "Nick" },
                new Pet { Id = 4, Age = 3, BranchId = 2, BreedId = 1, Gender = Gender.Male,   PetName = "Rex", OwnerId=1 },
                new Pet { Id = 5, Age = 3, BranchId = 3, BreedId = 2, Gender = Gender.Female, PetName = "Knopa"},
                new Pet { Id = 6, Age = 3, BranchId = 3, BreedId = 2, Gender = Gender.Male,   PetName = "Toby" }
               );
        }
    }
}

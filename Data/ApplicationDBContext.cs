using EF_test_01.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDBContext()
        //{ }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base (options)
        { }
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Identity needs this line
            base.OnModelCreating(mb);

            //Define the composite key in the join table
            mb.Entity<PersonLanguage>().HasKey(sc => new { sc.PersonId, sc.LanguageId });

            mb.Entity<PersonLanguage>()
            .HasOne<Person>(sc => sc.Person)
            .WithMany(s => s.PersonLanguage)
            .HasForeignKey(sc => sc.PersonId);


            mb.Entity<PersonLanguage>()
            .HasOne<Language>(sc => sc.Langauge)
            .WithMany(s => s.PersonLanguage)
            .HasForeignKey(sc => sc.LanguageId);
            //------------------------------------------------------------------------

            //Seeding countries
            mb.Entity<Country>().HasData(new Country(1,"Romania"));
            mb.Entity<Country>().HasData(new Country(2,"Polen"));         
            mb.Entity<Country>().HasData(new Country(3,"Sweden"));


            //Seeding cities
            mb.Entity<City>().HasData(new City(1, 1,"Bucharest"));
            mb.Entity<City>().HasData(new City(2, 1, "Brasov"));
            mb.Entity<City>().HasData(new City(3, 1, "Timisoara"));
            mb.Entity<City>().HasData(new City(4, 2, "Warsaw"));
            mb.Entity<City>().HasData(new City(5, 2, "Krakow"));
            mb.Entity<City>().HasData(new City(6, 2, "Bolowitze"));
            mb.Entity<City>().HasData(new City(7, 3, "Stockholm"));
            mb.Entity<City>().HasData(new City(8, 3, "Göteborg"));
            mb.Entity<City>().HasData(new City(9, 3, "Malmö"));


            //Seeding people
            mb.Entity<Person>().HasData(new Person(1, "Josh Gomez", "123 456", 1));
            mb.Entity<Person>().HasData(new Person(2, "Miguel Alonso", "234 567", 1));
            mb.Entity<Person>().HasData(new Person(3, "Andreas Kvarnblom", "345 678", 1));
            mb.Entity<Person>().HasData(new Person(4, "Tore Kindwall", "456 789", 2));
            mb.Entity<Person>().HasData(new Person(5, "Helena Danielsson", "567 890", 2));
            mb.Entity<Person>().HasData(new Person(6, "Maria Persson", "678 901", 2));

            //Seeding languages before seeding PersonLanguages
            mb.Entity<Language>().HasData(new Language(1, "Romanian"));
            mb.Entity<Language>().HasData(new Language(2, "French"));
            mb.Entity<Language>().HasData(new Language(3, "German"));
            mb.Entity<Language>().HasData(new Language(4, "Swedish"));
            mb.Entity<Language>().HasData(new Language(5, "English"));

            //Seeding PersonLanguages
            mb.Entity<PersonLanguage>().HasData(new PersonLanguage(2, 1));
            mb.Entity<PersonLanguage>().HasData(new PersonLanguage(2, 2));
            mb.Entity<PersonLanguage>().HasData(new PersonLanguage(2, 3));

            //Crete Guid for user, role and user role
            string roleId1 = Guid.NewGuid().ToString();
            string roleId2 = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            //Seeding roles
            mb.Entity<IdentityRole>().HasData(new IdentityRole 
            {
                Id=roleId1,
                Name="Admin",
                NormalizedName="ADMIN",
            });
            mb.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId2,
                Name = "User",
                NormalizedName = "USER",
            });

            //Create an admin user so we can do stuff unrestricted
            //But first use the password hasher
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            mb.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email="admin@admin.com",
                NormalizedEmail="ADMIN@ADMIN.COM",
                UserName="Admin@admin.com",
                NormalizedUserName= "ADMIN@ADMIN.COM",
                FirstName="Admin",
                LastName="Adminsson",
                DateOfBirth=DateTime.Now,
                PasswordHash = ph.HashPassword(null,"xxx")
            });

            mb.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId= userId,
                RoleId=roleId1
            });

        }
    }
}

using EF_test_01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Data
{
    public class ApplicationDBContext : DbContext
    {
        //public ApplicationDBContext()
        //{ }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base (options)
        { }
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
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

        }
    }
}

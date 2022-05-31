using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Models
{
    public class Country
    {
        public Country()
        {

        }
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
            Cities = new List<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
 
    }
}

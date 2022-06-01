using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Models
{
    public class City
    {
        public City()
        {

        }
        public City(int id, int countryId, string name)
        {
            Id = id;
            CountryId = countryId;
            Name = name;
            Residents = new List<Person>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "City name is missing")]
        [Display(Name = "City name")]
        public string Name { get; set; }
        public List<Person> Residents { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}

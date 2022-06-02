using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Models
{
    public class Person
    {
        public Person()
        { }
        public Person(int id, string name, string phone, int cityid)
        {
            Id = id;
            Name = name;
            PhoneNumber = phone;
            CityId = cityid;           
        }

 
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is missing")]
        [Display(Name = "Full name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is missing")]
        [Display(Name = "Phone no: ")]
        public string PhoneNumber { get; set; }
     
        public City City { get; set; }

        [Required(ErrorMessage = "A city must be selected")]
        public int CityId { get; set; }

        public IList<PersonLanguage> PersonLanguage { get; set; }

    }
}

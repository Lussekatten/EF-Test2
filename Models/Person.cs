using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Models
{
    public class Person
    {
        public Person()
        { 
        
        }
        public Person(int id, string name, string phone, string city)
        {
            Id = id;
            Name = name;
            PhoneNumber = phone;
            City = city;
            //FluentInLanguages = new List<Language>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste ange ett namn")]
        [Display(Name = "Förnamn och eftrnamn: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Du måste ange ett telefon nummer")]
        [Display(Name = "Telefon nr: ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Du måste ange en stad")]
        [Display(Name = "Stad")]
        public string City { get; set; }

        //public List<Language> FluentInLanguages { get; set; }
    }
}

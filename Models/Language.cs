using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Models
{
    public class Language
    {
        public Language()
        {

        }
        public Language(int id, string name)
        {
            Id = id;           
            Name = name;
            //PersonLanguage = new List<PersonLanguage>();
        }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of the language is missing")]
        public string Name { get; set; }
        public IList<PersonLanguage> PersonLanguage { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Models
{
    public class PersonLanguage
    {
        public PersonLanguage()
        {

        }
        public PersonLanguage(int personId, int languageId)
        {
            PersonId = personId;
            LanguageId = languageId;
        }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int LanguageId { get; set; }
        public Language Langauge { get; set; }
    }
}

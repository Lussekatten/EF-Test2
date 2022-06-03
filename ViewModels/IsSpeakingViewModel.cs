using EF_test_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.ViewModels
{
    public class IsSpeaking
    {
        public IsSpeaking()
        {
            PersLang = new PersonLanguage();
        }
        public string Message { get; set; }
        public PersonLanguage PersLang { get; set; }

        
    }
}

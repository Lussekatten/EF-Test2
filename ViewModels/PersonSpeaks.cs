using EF_test_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.ViewModels
{
    public class PersonSpeaks
    {
        public Person Person { get; set; }
        public List<string> Languages { get; set; }
    }
}

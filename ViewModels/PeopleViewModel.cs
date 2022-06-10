using EF_test_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.ViewModels
{
    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
        }

        public string PageTitle { get; set; } = "List of people";
        public string SearchText { get; set; } = "";
        public List<Person> PeopleList { get; set; } 

    }
}

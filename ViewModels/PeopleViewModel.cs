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
            //CreateStartingData();
            //PersonFactory = new CreatePersonViewModel();
        }
        public string PageTitle { get; set; } = "List of people";
        public string SearchText { get; set; } = "";
        public List<Person> PeopleList { get; set; } 

        //private void CreateStartingData()
        //{
        //    PeopleList = new List<Person>() {
        //    new Person(1, "Antonia Cristea", "123 456", 1),
        //    new Person(2, "Miguel Alonso", "234 567", 1),
        //    new Person(3, "Håkan Hellström", "345 678", 2)  };
        //}
    }
}

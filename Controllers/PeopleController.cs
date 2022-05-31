using EF_test_01.Data;
using EF_test_01.Models;
using EF_test_01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDBContext _context;

        public PeopleController(ApplicationDBContext context)
        {
            _context = context;
        }
        //public ApplicationDBContext db = new ApplicationDBContext();
        public IActionResult ViewPeople()
        {
            ViewBag.CityNames = new SelectList(_context.Cities,"Id", "Name");
            List<Person> people = _context.People.ToList();
            //Get the city names using the Ids
            foreach (var item in people)
            {
                item.City = _context.Cities.Find(item.CityId);
            }
            PeopleViewModel m = new PeopleViewModel();
            m.PeopleList = people;
            return View(m);
        }


        [HttpPost]
        public IActionResult AddPerson(Person p, int cityId)
        {
            p.CityId = cityId;
            if (ModelState.IsValid)
            {
                _context.People.Add(p);
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(ViewPeople));
        }

        [HttpPost]
        public IActionResult RemovePerson(int id)
        {
            //Logic
            if (ModelState.IsValid)
            {
                var person = _context.People.Find(id);
                _context.People.Remove(person);
                _context.SaveChanges();
                //return RedirectToAction(nameof(ViewPeople));
            }
            return RedirectToAction(nameof(ViewPeople));
        }

        [HttpPost]
        public IActionResult Search(PeopleViewModel m)
        {
            if (!String.IsNullOrEmpty(m.SearchText))
            {
                var result = _context.People.Where(q => (q.Name)
                    .ToLower()
                    .Contains(m.SearchText.ToLower()))
                    .ToList();
                //Create a new instance of the viewmodel and send it to the view
                PeopleViewModel modelWithSearch = new PeopleViewModel();
                modelWithSearch.SearchText = m.SearchText;
                modelWithSearch.PeopleList = result;
                //m.PeopleList = result;
                return View("ViewPeople", modelWithSearch);
            }
            else
            {
                //Redirect so that we read the full datalist
                return RedirectToAction(nameof(ViewPeople));
            }
        }
    }
}

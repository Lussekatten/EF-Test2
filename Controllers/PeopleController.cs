using EF_test_01.Data;
using EF_test_01.Models;
using EF_test_01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult IsSpeaking()
        {
            var m = new IsSpeaking();
            ViewBag.People = new SelectList(_context.People, "Id", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "Id", "Name");
            //Select all people with respective language. The model becomes a list of people
            //var personAndLanguage = _context.People.Include(p => p.PersonLanguage).ThenInclude(pl=>pl.Langauge).ToList();

            //Or using a projection
            var personAndLanguage = _context.People.Select(p => new { Person = p, Languages = p.PersonLanguage.Select(pl => pl.Langauge) });
            ViewBag.PoL = personAndLanguage;

            return View(personAndLanguage);
        }
        [HttpPost]
        public IActionResult IsSpeaking(int personId, int languageId)
        {
            if (personId > 0 && languageId > 0)
            {
                //If the language already exists items will return a row. Don't save. Duplicate key error!
                var items = _context.PersonLanguages.Where(p => p.PersonId == personId && p.LanguageId == languageId).ToList();
                if (items.Count == 0)
                {
                    PersonLanguage m = new PersonLanguage();
                    m.PersonId = personId;
                    m.LanguageId = languageId;
                    _context.PersonLanguages.Add(m);
                    _context.SaveChanges();
                    ViewBag.Message = "";
                }
                else
                {
                    ViewBag.Message = "Language already known by this person";
                }
            }

            return RedirectToAction(nameof(IsSpeaking));
        }

        [HttpPost]
        public IActionResult AddPerson(Person p, int cityId)
        {
            p.CityId = cityId;
            if (ModelState.IsValid && cityId > 0)
            {
                _context.People.Add(p);
                _context.SaveChanges();
                return RedirectToAction(nameof(ViewPeople));
            }
            ViewBag.CityNames = new SelectList(_context.Cities, "Id", "Name");
            return View(p);
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
                //Redirect without filtering
                return RedirectToAction(nameof(ViewPeople));
            }
        }
    }
}

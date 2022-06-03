using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_test_01.Data;
using EF_test_01.Models;

namespace EF_test_01.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CountriesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Countries
        public IActionResult Index()
        {
            return View(_context.Countries.ToList());
        }

        // GET: Countries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country =  _context.Countries
                .FirstOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }
    
        [HttpPost]
        public IActionResult Edit(int id, Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(country);
                _context.SaveChanges();               
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _context.Countries
                .FirstOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var country = _context.Countries.Find(id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_test_01.Data;
using EF_test_01.Models;
using Microsoft.AspNetCore.Authorization;

namespace EF_test_01.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CitiesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Cities
        public IActionResult Index()
        {
            var applicationDBContext = _context.Cities.Include(c => c.Country);
            return View(applicationDBContext.ToList());
        }

        // GET: Cities/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _context.Cities
                .Include(c => c.Country)
                .FirstOrDefault(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(city);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", city.CountryId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            return View(city);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(city);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _context.Cities
                .Include(c => c.Country)
                .FirstOrDefault(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var city = _context.Cities.Find(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}

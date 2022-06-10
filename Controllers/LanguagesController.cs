using EF_test_01.Data;
using EF_test_01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguagesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public LanguagesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Cities
        public IActionResult Index()
        {
            var languages = _context.Languages.ToList();
            return View(languages);
        }

        public IActionResult Create()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult Create( Language lang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lang);
                _context.SaveChanges();         
            }
            else
            {
                ViewBag.ErrMessage = "Model state invalid for some reason. Language not added";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

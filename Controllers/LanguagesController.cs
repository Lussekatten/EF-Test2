using EF_test_01.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_test_01.Controllers
{
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
        
    }
}

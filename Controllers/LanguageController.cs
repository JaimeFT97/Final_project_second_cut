using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSecondCut.Domain;
using FinalProjectSecondCut.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectSecondCut.Controllers
{
    public class LanguageController : Controller
    {
        private ArtistDBContext builder;

        public LanguageController(ArtistDBContext artistDBContext)
        {
            builder = artistDBContext;
        }
        public IActionResult Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Language language)
        {
            if (ModelState.IsValid)
            {
                builder.Language.Add(language);
                int count = builder.SaveChanges();
                int id = language.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, language.Id });
                }
            }

            ViewBag.IsSuccess = false;
            ViewBag.id = 0;
            return View(language);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSecondCut.Domain;
using FinalProjectSecondCut.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectSecondCut.Controllers
{
    public class GenderController : Controller
    {
        private ArtistDBContext builder;

        public GenderController(ArtistDBContext artistDBContext)
        {
            builder = artistDBContext;
        }
        public IActionResult Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                builder.Gender.Add(gender);
                int count = builder.SaveChanges();
                int id = gender.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, gender.Id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.id = 0;

            return View(gender);
        }
    }
}
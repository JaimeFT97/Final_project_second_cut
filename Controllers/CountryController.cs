using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSecondCut.Domain;
using FinalProjectSecondCut.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectSecondCut.Controllers
{
    public class CountryController : Controller
    {
        private ArtistDBContext builder;

        public CountryController(ArtistDBContext artistDBContext)
        {
            builder = artistDBContext;
        }
        public IActionResult Create(bool isSuccess= false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                builder.Country.Add(country);
                builder.SaveChanges();
                int id = country.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, country.Id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.id = 0;
            
            
            return View(country);
        }
    }
}
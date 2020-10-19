using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSecondCut.Domain;
using FinalProjectSecondCut.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectSecondCut.Controllers
{
    public class ArtistController : Controller
    {
        private ArtistDBContext builder;

        public ArtistController(ArtistDBContext artistDBContext)
        {
            builder = artistDBContext;
        }
        public async Task<IActionResult> Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.Country = new SelectList(await GetCountry(), "Id", "Country_name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Country = new SelectList(await GetCountry(), "Id", "Country_name");
                builder.Artist.Add(artist);
                builder.SaveChanges();
                int id = artist.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, artist.Id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.id = 0;

            return View(artist);
        }
        public async Task<List<Country>> GetCountry()
        {
            return await builder.Country.Select(c => new Country()
            {
                Id = c.Id,
                Country_name = c.Country_name
            }).ToListAsync();
        }
    }
}
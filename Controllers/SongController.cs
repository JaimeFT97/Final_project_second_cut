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
    public class SongController : Controller
    {
        private ArtistDBContext builder;

        public SongController(ArtistDBContext artistDBContext)
        {
            builder = artistDBContext;
        }
        public async Task<IActionResult> Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.Gender = new SelectList(await GetGender(), "Id", "Gender_name");
            ViewBag.Language = new SelectList(await GetLanguage(), "Id", "Language_name");
            ViewBag.Country = new SelectList(await GetCountry(), "Id", "Country_name");
            ViewBag.Album = new SelectList(await GetAlbum(), "Id", "Album_name");
            ViewBag.Artist = new SelectList(await GetArtist(), "Id", "Artistic_name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Song song)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Gender = new SelectList(await GetGender(), "Id", "Gender_name");
                ViewBag.Language = new SelectList(await GetLanguage(), "Id", "Language_name");
                ViewBag.Country = new SelectList(await GetCountry(), "Id", "Country_name");
                ViewBag.Album = new SelectList(await GetAlbum(), "Id", "Album_name");
                ViewBag.Artist = new SelectList(await GetArtist(), "Id", "Artistic_name");
                builder.Song.Add(song);
                builder.SaveChanges();
                int id = song.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, song.Id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.id = 0;

            return View(song);
        }
        public async Task<List<Gender>> GetGender()
        {
            return await builder.Gender.Select(c => new Gender()
            {
                Id = c.Id,
                Gender_name = c.Gender_name
            }).ToListAsync();
        }
        public async Task<List<Language>> GetLanguage()
        {
            return await builder.Language.Select(c => new Language()
            {
                Id = c.Id,
                Language_name = c.Language_name
            }).ToListAsync();
        }
        public async Task<List<Country>> GetCountry()
        {
            return await builder.Country.Select(c => new Country()
            {
                Id = c.Id,
                Country_name = c.Country_name
            }).ToListAsync();
        }
        public async Task<List<Album>> GetAlbum()
        {
            return await builder.Album.Select(c => new Album()
            {
                Id = c.Id,
                Album_name = c.Album_name
            }).ToListAsync();
        }
        public async Task<List<Artist>> GetArtist()
        {
            return await builder.Artist.Select(c => new Artist()
            {
                Id = c.Id,
                Artistic_name = c.Artistic_name
            }).ToListAsync();
        }
    }
}
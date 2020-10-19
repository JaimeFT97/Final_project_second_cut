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
    public class AlbumController : Controller
    {
        private ArtistDBContext builder;

        public AlbumController(ArtistDBContext artistDBContext)
        {
            builder = artistDBContext;
        }
        public async Task<IActionResult> Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.Artist = new SelectList(await GetArtist(), "Id", "Artistic_name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Album album)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Artist = new SelectList(await GetArtist(), "Id", "Artistic_name");
                builder.Album.Add(album);
                builder.SaveChanges();
                int id = album.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, album.Id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.id = 0;

            return View(album);
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
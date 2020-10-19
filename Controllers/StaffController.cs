using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSecondCut.Domain;
using FinalProjectSecondCut.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectSecondCut.Controllers
{
    public class StaffController : Controller
    {
        private ArtistDBContext builder;

        public StaffController(ArtistDBContext artistDBContext)
        {
            builder = artistDBContext;
        }
        public IActionResult Create(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                builder.Staff.Add(staff);
                int count = builder.SaveChanges();
                int id = staff.Id;
                if (id > 0)
                {
                    return RedirectToAction(nameof(Create), new { isSuccess = true, staff.Id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.id = 0;

            return View(staff);
        }
    }
}
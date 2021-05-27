using Microsoft.AspNetCore.Mvc;
using shabat2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using shabat2.ViewModel;

namespace shabat2.Controllers
{
    public class HostController : Controller
    {
        public IActionResult Index()
        {
            // טען מהדטאבייס את הנתונים ותחזיר לוויו
            List<Category> categories = DAL.Get.Categories.Include(c=>c.Foods).ToList();
            List<Guest> guests = DAL.Get.Guests.Include(g=>g.Foods).ToList();
            VMHostMain vm = new VMHostMain
            {
                Categories = categories,
                Guests = guests
            };
            return View(vm);
        }
    }
}

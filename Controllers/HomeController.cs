using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shabat2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Category> categories=DAL.Get.Categories.ToList();
            return View(categories);
        }

        public IActionResult Connect()
        {// התחברות
            return View(new Guest());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Connect(Guest guest)
        {
            // בדוק שהמייל והסיסמא נכונים
            Guest guest1 = DAL.Get.Guests.ToList().Find(g => g.Mail == guest.Mail && g.Password == guest.Password); ;
            if (guest1 == null) return View(); // ודא קבלת ערך
            DAL.Get.Guest = guest1;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Guest guest)
        {// הרשמה
            DAL.Get.Guests.Add(guest);
            DAL.Get.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

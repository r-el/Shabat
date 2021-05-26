using Microsoft.AspNetCore.Mvc;
using shabat2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Controllers
{
    public class HostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

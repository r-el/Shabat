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
            List<Category> categories = DAL.Get.Categories.Include(c=>c.Foods).ToList();
            List<Guest> guests = DAL.Get.Guests.Include(g=>g.Foods).ToList();
            VMHostMain vm = new VMHostMain{ Categories = categories, Guests = guests };
            return View(vm);
        }

        public IActionResult CategoryDetails(int? id)
        {// פרטי קבוצה
            if (id == null) return RedirectToAction(nameof(Index));

            Category category = DAL.Get.Categories.Include(c => c.Foods).ToList().Find(c => c.ID == id);
            if (category == null) return RedirectToAction(nameof(Index));
            return View(category);
        }

        public IActionResult FoodDetails(int? id)
        {// פרטי מאכל
            if (id == null) return RedirectToAction(nameof(Index));

            Food food = DAL.Get.Foods.ToList().Find(f => f.ID == id);
            if (food == null) return RedirectToAction(nameof(Index));
            return View(food);
        }

        public IActionResult AddCategory()
        {// הוספת קבוצה
            VMAddCategory vm = new VMAddCategory { Category = new Category() };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(VMAddCategory vm)
        {
            if (vm.Food != string.Empty) vm.Category.AddFood(vm.Food, vm.FoodFile);
            vm.Category.SetPhoto = vm.File;
            DAL.Get.Categories.Add(vm.Category);
            DAL.Get.SaveChanges();
            return View("CategoryDetails", vm.Category);
        }

        public IActionResult AddFood(int? id)
        {// הוספת מאכל
            if (id == null) return RedirectToAction(nameof(Index));
            List<Category> categories = DAL.Get.Categories.Include(c => c.Foods).ToList();
            Category category = categories.Find(c => c.ID == id);
            if (category == null) return RedirectToAction(nameof(Index));
            VMAddFood vm = new VMAddFood
            {
                Categories = categories,
                Category = category,
                CategoryId = category.ID,
                Food = new Food()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFood(VMAddFood vm)
        {
            DAL.Get.Categories.ToList().Find(c => c.ID == vm.CategoryId).AddFood(vm.Food);
            vm.Food.SetPhoto = vm.File;
            DAL.Get.SaveChanges();
            return RedirectToAction(nameof(CategoryDetails), new { id = vm.CategoryId });
        }
    }
}

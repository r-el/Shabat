using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Models
{
    // קטגוריה
    public class Category
    {
        public Category() { Foods = new List<Food>(); }
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם קבוצה")]
        public string CategoryName { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Photo { get; set; }

        // מאכלים
        public List<Food> Foods { get; set; }

        // המרת התמונה לבייטים
        public IFormFile SetPhoto { set { Photo = new ParsePhoto().Get(value); } }

        // יצירה והוספה של מאכל חדש
        public void AddFood(string name, IFormFile file)
        {
            AddFood(new Food() { FoodName = name, SetPhoto = file });
        }

        // הוספת מאכל קיים
        public void AddFood(Food food)
        {
            Foods.Add(food);
            food.Category = this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using shabat2.Models;

namespace shabat2.ViewModel
{
    public class VMAddFood
    {
        public VMAddFood() { Categories = new List<Category>(); }

        public Category Category { get; set; }          // קבוצה
        public int CategoryId { get; set; }             // מזהה קטגוריה
        public List<Category> Categories { get; set; }  // רשימת קבוצות
        public string Food { get; set; }                // מאכל
        [Display(Name = "הוספת תמונה")]
        public IFormFile File { get; set; }             // תמונה
    }
}
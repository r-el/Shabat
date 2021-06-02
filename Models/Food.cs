using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Models
{
    // מאכל
    public class Food
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "שם מאכל")]
        public string FoodName { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Photo { get; set; }

        // רשימת מאכלים
        public List<FoodByGuest> Guests { get; set; }

        // המרת התמונה לבייטים
        public IFormFile SetPhoto { set { if (value != null) Photo = new ParsePhoto().Get(value); } }

        // קטגוריה 
        public Category Category { get; set; }
    }
}

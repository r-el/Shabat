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

        [Display(Name = "שם מאכל")]
        public string FoodName { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Photo { get; set; }


        // המרת התמונה לבייטים
        public IFormFile SetPhoto { set { Photo = new ParsePhoto().Get(value); } }
    }
}

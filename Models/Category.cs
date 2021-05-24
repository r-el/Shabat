using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Models
{
    public class Category
    {
        public Category() { Foods = new List<Food>(); }
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם קבוצה")]
        public string CategoryNmae { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Photo { get; set; }

        // מאכלים
        public List<Food> Foods { get; set; }

        // המרת התמונה לבייטים
        public IFormFile SetPhoto { set { Photo = new ParsePhoto().Get(value); } }
    }
}

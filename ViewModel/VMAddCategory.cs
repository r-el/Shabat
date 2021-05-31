using Microsoft.AspNetCore.Http;
using shabat2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.ViewModel
{
    public class VMAddCategory
    {
        public VMAddCategory() { }

        public Category Category { get; set; }

        [Display(Name = "הוסף תמונה")]
        public IFormFile File { get; set; }

        [Display(Name = "שם מאכל")]
        public string Food { get; set; }

        public IFormFile FoodFile { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using shabat2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.ViewModel
{
    public class VMEditFood
    {
        public VMEditFood() {}
        public Food Food { get; set; }          // מאכל
        public int FoodID { get; set; }         // מזהה מאכל
        [Display(Name ="החלף תמונה")]
        public IFormFile File { get; set; }     // תמונה

    }
}

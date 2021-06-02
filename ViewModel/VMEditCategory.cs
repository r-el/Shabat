using Microsoft.AspNetCore.Http;
using shabat2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.ViewModel
{
    public class VMEditCategory
    {
        public VMEditCategory(){}
        public Category Category { get; set; }      // קבוצה
        public int CategoryID { get; set; }         // מזהה קטגוריה
        [Display(Name="החלף תמונה")]
        public IFormFile File { get; set; }         // תמונה
    }
}

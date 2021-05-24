using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Models
{
    // אורח
    public class Guest
    {
        public Guest() {}
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם פרטי")]
        public string FirstName { get; set; }

        [Display(Name= "שם משפחה")]
        public string LastName { get; set; }

        [Display(Name = "שם מלא")]
        public string FullName { get { return FirstName + " " + LastName ; } }

        [Display(Name = "תמונה")]
        public byte[] Photo { get; set; }

        [Display(Name = "כתובת מייל")]
        [EmailAddress(ErrorMessage ="נא הכנס כתובת מייל נכונה")]
        public string Mail { get; set; }
        
        // רשימת מאכלים
        public List<FoodByGuest> Foods { get; set; }

        // המרת התמונה לבייטים
        public IFormFile SetPhoto { set { Photo = new ParsePhoto().Get(value); } }

        // הוספת מאכל לרשימת מאכלים
        public void AddFood(Food food)
        {
            Foods.Add(new FoodByGuest() { Food = food, Guest = this });
        }
    }
}

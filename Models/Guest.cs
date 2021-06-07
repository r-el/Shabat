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
        public Guest() { Foods = new List<FoodByGuest>(); }
        [Key]
        public int ID { get; set; }

        [Display(Name = "שם פרטי")]
        [Required(ErrorMessage = "הזן שם פרטי")]
        public string FirstName { get; set; }

        [Display(Name= "משפחה")]
        [Required(ErrorMessage = "הזן משפחה")]
        public string LastName { get; set; }

        [Display(Name = "שם מלא")]
        public string FullName { get { return FirstName + " " + LastName ; } }

        //[Display(Name = "תמונה")]
        //public byte[] Photo { get; set; }

        [Display(Name = "כתובת מייל")]
        [Required(ErrorMessage = "הזן כתובת מייל")]
        [EmailAddress(ErrorMessage ="נא הכנס כתובת מייל נכונה")]
        public string Mail { get; set; }

        [Display(Name = "סיסמא")]
        [Required(ErrorMessage = "הזן סיסמא")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "אימות סיסמא")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfrimPassword { get; set; }

        // רשימת מאכלים
        public List<FoodByGuest> Foods { get; set; }

        // המרת התמונה לבייטים
        //public IFormFile SetPhoto { set {if(value!=null) Photo = new ParsePhoto().Get(value); } }

        // הוספת מאכל לרשימת מאכלים
        public void AddFood(Food food)
        {
            Foods.Add(new FoodByGuest() { Food = food, Guest = this });
        }
    }
}

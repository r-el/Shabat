using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Models
{
    // שכבת נתונים
    public class DAL : DbContext
    {
        private static DAL Data;
        // חיבור פרטי. גישה לדטאבייס מוגבלת 
        private DAL() : base("data source=localhost\\SQLEXPRESS;"
                                + " initial catalog = ShabatCore2;"
                                + " user id = sa; password = 1234;")
        {
            // תמחק ותיצור את מסד הנתונים מחדש אם המודלים השתנו
            Database.SetInitializer<DAL>(new DropCreateDatabaseIfModelChanges<DAL>());

            // אם אין נתונים בדטאבייס, תוסיף נתונים
            if (Categories.Count() == 0) Seed();
        }

        // איפשור גישה לדטאבייס
        public static DAL Get
        {
            // תן גישה לדטאבייס
            // אם אין נתונים בדטאבייס תאתחל נתונים (ע"י Seed)
            get{ if (Data == null) Data = new DAL(); return Data; }
        }

        // זריעה של נתונים לדטאבייס
        private void Seed()
        {
            Category category = new Category { CategoryName = "שתיה קלה" };
            Categories.Add(category);
            Guests.Add(new Guest { FirstName = "אברהם", LastName = "קהאן" });
            SaveChanges();
        }

        // יצירת טבלאות
        public DbSet<Category> Categories { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodByGuest> FoodByGuest { get; set; }
    }
}

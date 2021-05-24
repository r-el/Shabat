using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Models
{
    // מאכל של אורח
    public class FoodByGuest
    {
        public FoodByGuest() { }
        [Key]
        public int ID { get; set; }

        // שיוך למאכל
        public Food Food { get; set; }

        // שיוך לאורח
        public Guest Guest { get; set; }
    }
}

using shabat2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.ViewModel
{
    public class VMHostMain
    {
        public VMHostMain(){ }
        public List<Category> Categories { get; set; }
        public List<Guest> Guests { get; set; }
    }
}

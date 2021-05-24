using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace shabat2.Models
{
    // המרת תמונה
    public class ParsePhoto
    {
        public byte[] Get(IFormFile file)
        {

            // אם לא קיבלת כלום תחזיר null
            if (file == null) return null;

            // סטרים שומר איזשהו קובץ בזיכרון 
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);

            // תמיר ותחזיר אותו למערך בייטים
            return stream.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Constants
{
    public static class Patterns
    {
        public static Regex Email = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        public static Regex Phone = new Regex(@"\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})");
        public static Regex ZipCode = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
        public static Regex Text = new Regex(@"^[A-Za-z]+$");
        public static Regex Numbers = new Regex(@"^[0-9]+$");
        public static Regex TextNumSym = new Regex(@"^[A-Za-z0-9#\s]+$");
    }
}

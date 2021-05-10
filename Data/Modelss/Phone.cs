using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Modelss
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public string Phone1 { get; set; }
        public int StudentId { get; set; }
        public int PhoneType { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Student Student { get; set; }
    }
}

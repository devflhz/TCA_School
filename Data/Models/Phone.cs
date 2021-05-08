using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Phone
    {
        public string Phone1 { get; set; }
        public int StudentId { get; set; }
        public int PhoneType { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string PhoneLink
        {
            get { return CountryCode + Phone1; }
        }

        public virtual Student Student { get; set; }
    }
}

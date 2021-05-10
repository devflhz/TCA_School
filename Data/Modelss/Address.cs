using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Modelss
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int StudentId { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string ZipPostcode { get; set; }
        public string State { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Student Student { get; set; }
    }
}

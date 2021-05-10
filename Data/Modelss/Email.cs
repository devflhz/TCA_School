using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Modelss
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public string Email1 { get; set; }
        public int StudentId { get; set; }
        public int EmailType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Student Student { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Modelss
{
    public partial class Student
    {
        public Student()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
            Phones = new HashSet<Phone>();
        }

        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}

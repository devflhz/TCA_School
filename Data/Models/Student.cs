using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
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
        public int Gender { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string GetGender()
        {
            return Gender switch
            {
                1 => "Hombre",
                2 => "Mujer",
                3 => "Bigenero",
                4 => "Trans",
                5 => "No binario",
                _ => "Otro"
            };
        }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}

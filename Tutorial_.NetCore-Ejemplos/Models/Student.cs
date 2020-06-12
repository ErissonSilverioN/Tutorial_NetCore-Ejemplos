using System;
using System.Collections.Generic;

namespace Tutorial_.NetCore_Ejemplos.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentAddress = new HashSet<StudentAddress>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StandardId { get; set; }

        public virtual ICollection<StudentAddress> StudentAddress { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Tutorial_.NetCore_Ejemplos.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Schedule { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}

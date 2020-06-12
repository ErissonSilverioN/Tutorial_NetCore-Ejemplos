using System;
using System.Collections.Generic;

namespace Tutorial_.NetCore_Ejemplos.Models
{
    public partial class StudentCourse
    {
        public int StudentCourse1 { get; set; }
        public string StudentName { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}

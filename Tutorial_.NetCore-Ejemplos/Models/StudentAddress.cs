using System;
using System.Collections.Generic;

namespace Tutorial_.NetCore_Ejemplos.Models
{
    public partial class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Direccion { get; set; }
        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}

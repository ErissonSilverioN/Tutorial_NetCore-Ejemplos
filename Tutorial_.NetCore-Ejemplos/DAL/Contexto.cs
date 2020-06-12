using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tutorial_.NetCore_Ejemplos.Models;

namespace Tutorial_.NetCore_Ejemplos.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Student> students  { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<StudentAddress> studentAddresses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = SchoolDB; Trusted_Connection = True; ");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

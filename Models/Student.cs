using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
//henslw-mvc1
//Created student class
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
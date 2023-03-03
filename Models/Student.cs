using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
//henslw-mvc1
//Created student class
    public class Student : Person
    {
        //henslw-mvc5
        //Added data type date attribute and displayformat attribute
        //Added max string length attribute
        //Added required attribiute
        //Added displayname attributes

        //henslw-mvc9
        //Added inheritance from person class
        // removed dupicate fields
        
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
      
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
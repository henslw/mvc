using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ContosoUniversity.Models.SchoolViewModels
{
    //henslw-mvc7
    //created New veiw model called Assigned Course data
    public class AssignedCourseData
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}

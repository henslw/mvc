namespace ContosoUniversity.Models
{
    //henslw-mvc1
    //created grade enum
    public enum Grade
    {
        A, B, C, D, F
    }
    //henslw-mvc1
    //created Enrollment class
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
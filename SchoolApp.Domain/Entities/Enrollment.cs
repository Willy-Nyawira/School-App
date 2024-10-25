namespace SchoolApp.Domain.Entities
{
    public class Enrollment : Entity
    {
        public int StudentId { get; private set; } 
        public int CourseId { get; private set; } 
        public Student Student { get; private set; }
        public Course Course { get; private set; }
        public DateTime EnrollmentDate { get; private set; }

        public Enrollment(int id, int studentId, int courseId, DateTime enrollmentDate)
            : base(id)
        {
            StudentId = studentId; 
            CourseId = courseId; 
            EnrollmentDate = enrollmentDate;
        }
    }
}

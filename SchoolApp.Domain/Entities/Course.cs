namespace SchoolApp.Domain.Entities
{
    public class Course : Entity
    {
        public string CourseName { get; private set; }
        public string CourseCode { get; private set; }
        public int Credits { get; private set; }
        public int TeacherId { get; private set; }
        public Teacher AssignedTeacher { get; private set; }
        private readonly List<Enrollment> _enrollments;
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        // Updated constructor
        public Course(int id, string courseName, string courseCode, int credits, int teacherId)
            : base(id)
        {
            CourseName = courseName;
            CourseCode = courseCode;
            Credits = credits;
            TeacherId = teacherId;
            _enrollments = new List<Enrollment>();
        }

        public void AssignTeacher(Teacher teacher)
        {
            AssignedTeacher = teacher;
            TeacherId = teacher.Id; 
        }

        public void EnrollStudent(Student student, DateTime enrollmentDate)
        {
            var enrollment = new Enrollment(_enrollments.Count + 1, student.Id, this.Id, enrollmentDate);
            _enrollments.Add(enrollment);
        }
    }
}

using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Domain.Entities
{
    public class Teacher : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public EmailAddress Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string SubjectSpecialization { get; private set; }

        public List<Course> Courses { get; private set; } = new List<Course>();
        public Teacher() : base(0) { }

        public Teacher(int id, string firstName, string lastName, EmailAddress email, PhoneNumber phoneNumber, string subjectSpecialization)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            SubjectSpecialization = subjectSpecialization;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            return $"{GetFullName()}, Email: {Email.Value}, Phone: {PhoneNumber.Value}, Specialization: {SubjectSpecialization}";
        }
    }
}

using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Domain.Entities
{
    public class Student : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public EmailAddress Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public List<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();

        public Student() : base(0) { }



        public Student(int id, string firstName, string lastName, EmailAddress email, PhoneNumber phoneNumber, DateTime dateOfBirth)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            return $"{GetFullName()}, Email: {Email.Value}, Phone: {PhoneNumber.Value}, DOB: {DateOfBirth.ToShortDateString()}";
        }
    }
}

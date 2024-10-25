using SchoolApp.Domain.Entities;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Application.ServiceInterfaces
{
    public interface IStudentService
    {
        Task<Student> RegisterStudent(string firstName, string lastName, EmailAddress email, PhoneNumber phoneNumber, DateTime dateOfBirth);
        Task EnrollStudentInCourse(int studentId, int courseId);
        Task DeleteStudent(int studentId);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetByIdAsync(int id);
        Task UpdateStudent(Student student);

    }
}

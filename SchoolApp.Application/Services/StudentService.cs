using SchoolApp.Application.ServiceInterfaces;
using SchoolApp.Application.UseCases;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoryInterfaces;
using SchoolApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly RegisterStudentUseCase _registerStudentUseCase;
        private readonly EnrollStudentInCourseUseCase _enrollStudentInCourseUseCase;
        private readonly IStudentRepository _studentRepository; 

        public StudentService(RegisterStudentUseCase registerStudentUseCase, EnrollStudentInCourseUseCase enrollStudentInCourseUseCase, IStudentRepository studentRepository)
        {
            _registerStudentUseCase = registerStudentUseCase;
            _enrollStudentInCourseUseCase = enrollStudentInCourseUseCase;
            _studentRepository = studentRepository; // Initialize repository
        }

        public async Task EnrollStudentInCourse(int studentId, int courseId)
        {
            await _enrollStudentInCourseUseCase.Execute(studentId, courseId);
        }

        public async Task<Student> RegisterStudent(string firstName, string lastName, EmailAddress email, PhoneNumber phoneNumber, DateTime dateOfBirth)
        {
            return await _registerStudentUseCase.Execute(firstName, lastName, email, phoneNumber, dateOfBirth);
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id); 
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task DeleteStudent(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task UpdateStudent(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }
    }
}

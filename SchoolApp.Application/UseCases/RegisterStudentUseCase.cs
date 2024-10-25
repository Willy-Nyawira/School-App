using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoryInterfaces;
using SchoolApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.UseCases
{
    public class RegisterStudentUseCase
    {
        private readonly IStudentRepository _studentRepository;

        public RegisterStudentUseCase(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> Execute(string firstName, string lastName, EmailAddress email, PhoneNumber phoneNumber, DateTime dateOfBirth)
        {
            var student = new Student(0, firstName, lastName, email, phoneNumber, dateOfBirth);
            await _studentRepository.AddAsync(student);
            return student;
        }
    }
}

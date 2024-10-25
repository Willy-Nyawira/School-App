using SchoolApp.Application.ServiceInterfaces;
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
    public class TeacherService :ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> RegisterTeacher(string firstName, string lastName, EmailAddress email, PhoneNumber phoneNumber, string subject)
        {
            var teacher = new Teacher(0, firstName, lastName, email, phoneNumber, subject); // Include all required parameters
            await _teacherRepository.AddAsync(teacher);
            return teacher;
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task DeleteTeacher(int id)
        {
            await _teacherRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Teacher>> SearchTeachersByName(string firstName, string lastName)
        {
            return await _teacherRepository.SearchByNameAsync(firstName, lastName);
        }
    }
}


using SchoolApp.Domain.Entities;
using SchoolApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.ServiceInterfaces
{
    public interface ITeacherService
    {
        Task<Teacher> RegisterTeacher(string firstName, string lastName, EmailAddress email, PhoneNumber phoneNumber, string subject);
        Task<Teacher?> GetByIdAsync(int id);
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task UpdateTeacher(Teacher teacher);
        Task DeleteTeacher(int id);
        Task<IEnumerable<Teacher>> SearchTeachersByName(string firstName, string lastName);
    }
}

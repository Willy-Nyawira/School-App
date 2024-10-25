using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.ServiceInterfaces
{
    public interface ICourseService
    {
        Task<Course> CreateCourse(string courseCode, string courseName, int credits, int teacherId);
        Task<Course?> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task UpdateCourse(Course course);
        Task DeleteCourse(int id);
        Task<IEnumerable<Course>> SearchCoursesByName(string courseName);
    }
}

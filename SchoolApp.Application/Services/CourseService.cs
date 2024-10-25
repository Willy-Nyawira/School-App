using SchoolApp.Application.ServiceInterfaces;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> CreateCourse(string name, string courseCode, int credits, int teacherId)
        {
            var course = new Course(0, name, courseCode, credits, teacherId);
            await _courseRepository.AddAsync(course);
            return course;
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task UpdateCourse(Course course)
        {
            await _courseRepository.UpdateAsync(course);
        }

        public async Task DeleteCourse(int id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Course>> SearchCoursesByName(string courseName)
        {
            return await _courseRepository.SearchByNameAsync(courseName);
        }
    }
}

using SchoolApp.Domain.Entities;
using SchoolApp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.UseCases
{
    public class EnrollStudentInCourseUseCase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollStudentInCourseUseCase(IStudentRepository studentRepository,IEnrollmentRepository enrollmentRepository,ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
            _courseRepository = courseRepository;
        }

        public async Task Execute(int studentId, int courseId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null) throw new Exception("Student not found.");

            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null) throw new Exception("Course not found.");

            var enrollment = new Enrollment(0, studentId, courseId, DateTime.Now);
            await _enrollmentRepository.AddAsync(enrollment);
        }
    }
}

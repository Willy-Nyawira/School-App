using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Application.DTOs;
using SchoolApp.Application.ServiceInterfaces;
using SchoolApp.Application.Services;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        public CourseController(ICourseService courseService,ITeacherService teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto courseDto)
        {
            var teacher = await _teacherService.GetByIdAsync(courseDto.TeacherId);
            if (teacher == null) return NotFound("Teacher not found");
            var course = await _courseService.CreateCourse(courseDto.CourseCode, courseDto.CourseName,
    courseDto.Credits, teacher.Id);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        
    }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto courseDto)
        {
            var teacher = await _teacherService.GetByIdAsync(courseDto.TeacherId);
            if (teacher == null) return NotFound("Teacher not found");

            var course = new Course(id, courseDto.CourseCode, courseDto.CourseName, courseDto.Credits, teacher.Id); // Change this line to use teacher.Id
            await _courseService.UpdateCourse(course);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}


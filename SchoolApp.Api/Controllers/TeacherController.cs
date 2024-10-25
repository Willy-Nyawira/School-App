using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Application.DTOs;
using SchoolApp.Application.ServiceInterfaces;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterTeacher([FromBody] TeacherDto teacherDto)
        {
            var teacher = await _teacherService.RegisterTeacher(
                teacherDto.FirstName,
                teacherDto.LastName,
                new EmailAddress(teacherDto.Email), 
                new PhoneNumber(teacherDto.PhoneNumber), 
                teacherDto.SubjectSpecialization);

            return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDto teacherDto)
        {
            var teacher = new Teacher(id, teacherDto.FirstName, teacherDto.LastName,
                new EmailAddress(teacherDto.Email),
                new PhoneNumber(teacherDto.PhoneNumber),
                teacherDto.SubjectSpecialization);
            await _teacherService.UpdateTeacher(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _teacherService.DeleteTeacher(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Teacher>>> SearchTeachers(string firstName, string lastName)
        {
            var teachers = await _teacherService.SearchTeachersByName(firstName, lastName);
            return Ok(teachers);
        }
    }
}


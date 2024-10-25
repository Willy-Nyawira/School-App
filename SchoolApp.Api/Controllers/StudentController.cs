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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentDto studentDto)
        {
            var email = new EmailAddress(studentDto.Email);
            var phoneNumber = new PhoneNumber(studentDto.PhoneNumber); // Convert string to PhoneNumber object
            var student = await _studentService.RegisterStudent(
                studentDto.FirstName, studentDto.LastName, email, phoneNumber, studentDto.DateOfBirth);

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            var email = new EmailAddress(studentDto.Email);
            var phoneNumber = new PhoneNumber(studentDto.PhoneNumber); // Convert string to PhoneNumber object
            var student = new Student(id, studentDto.FirstName, studentDto.LastName, email, phoneNumber, studentDto.DateOfBirth);
            await _studentService.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}

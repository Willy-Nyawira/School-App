using SchoolApp.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Application.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [PastDate]
        public DateTime DateOfBirth { get; set; }
    }
}

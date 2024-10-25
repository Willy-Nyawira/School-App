using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.DTOs
{
    public class CourseDto
    {
        [Required]
        public string CourseName { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int TeacherId
        {
            get; set;
        }
    }
}

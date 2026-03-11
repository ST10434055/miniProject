using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProgrammeManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public int YearOfStudy { get; set; }
    }
}

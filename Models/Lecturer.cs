using System.ComponentModel.DataAnnotations;

namespace ProgrammeManagementSystem.Models
{
    public class Lecturer
    {
        [Key]
        public int LecturerID { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String Department { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammeManagementSystem.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }

        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; }

        public int ModuleID { get; set; }

        [ForeignKey("ModuleID")]
        public Module Module { get; set; }
    }
}

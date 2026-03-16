using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammeManagementSystem.Models
{
    public class ModuleAssignment
    {
        [Key]
        public int AssignmentID { get; set; }

        public int LecturerID { get; set; }
        [ForeignKey("LecturerID")]
        public Lecturer? Lecturer { get; set; }

        public int ModuleID { get; set; }
        [ForeignKey("ModuleID")]
        public Module? Module { get; set; }
    }
}

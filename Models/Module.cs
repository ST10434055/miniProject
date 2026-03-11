using System.ComponentModel.DataAnnotations;

namespace ProgrammeManagementSystem.Models
{
    public class Module
    {
        [Key]
        public int ModuleID { get; set; }
        public String ModuleName { get; set; }
        public int ModuleCode { get; set; }
        public int Credits { get; set; }
        public int AcademicYear { get; set; }
    }
}

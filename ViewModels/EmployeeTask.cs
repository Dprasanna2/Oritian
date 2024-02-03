using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OritainAPI.ViewModels
{
    public class EmployeeTask
    {
        [Key]
        [Required]
        public int TaskID { get; set; }
        [Required]
        public string? TaskName { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public string? Priority { get; set; }
        [ForeignKey("ID")]
        public int PersonID { get; set; }
    }
}

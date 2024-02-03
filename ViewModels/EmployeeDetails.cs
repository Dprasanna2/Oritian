using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OritainAPI.ViewModels
{
    public class EmployeeDetails
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? EmailAddress { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}

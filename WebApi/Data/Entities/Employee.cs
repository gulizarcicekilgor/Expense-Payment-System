using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entities
{
    public class Employee
    {   [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
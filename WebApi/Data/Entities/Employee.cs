using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Data.Entities
{
    public class Employee
    {  [Key][JsonIgnore][DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //id otmatik artsın
        public int EmployeeId { get; set; }
        [Required] [MaxLength(50)]
        public string FirstName { get; set; }
        [Required][MaxLength(50)]
        public string LastName { get; set; }
        [Required][MaxLength(100)]
        public string Email { get; set; }
        [Required][MaxLength(100)]
        public string UserName { get; set; }
        [Required][MaxLength(10)]
        public string Password { get; set; }
        [Required]
        public string EmployeeType {get; set; }
    }
}
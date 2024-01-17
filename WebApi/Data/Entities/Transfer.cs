using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Data.Entities
{
    public class Transfer
    {   [Key][JsonIgnore][DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //id otmatik artsın
        public int TransferId { get; set; }
        public int FromAccountNumber{ get; set; }
        public int ToAccountNumber{ get; set; }
        public double Balance{ get; set; }
        public string Description{ get; set; }

    }
}
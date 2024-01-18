using System.ComponentModel.DataAnnotations;

namespace WebApi.TokenOperations
{
    public class Token
    {   [Required]
        public string AccessToken { get; set; }
        [Required]
        public DateTime Expiration { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
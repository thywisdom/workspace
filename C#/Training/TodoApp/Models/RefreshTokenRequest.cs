using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}

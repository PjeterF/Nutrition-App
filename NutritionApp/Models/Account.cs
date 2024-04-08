using System.ComponentModel.DataAnnotations;

namespace NutritionApp.Models
{
    public class Account
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NutritionApp.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

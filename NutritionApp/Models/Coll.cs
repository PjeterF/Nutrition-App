using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutritionApp.Models
{
    public class Coll
    {
        [Key("Id")]
        public int Id { get; set; }
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public List<int> foodIds { get; set; } 

    }
}

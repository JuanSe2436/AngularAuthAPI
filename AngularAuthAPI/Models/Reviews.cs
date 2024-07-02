using System.ComponentModel.DataAnnotations;

namespace AngularAuthAPI.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; } 
        public int UserId { get; set; } 
    }
}

using System.ComponentModel.DataAnnotations;

namespace AngularAuthAPI.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? Summary { get; set; }
        public string? IMG { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace bloginterior.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string imageurl { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}

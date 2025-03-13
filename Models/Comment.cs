using System.ComponentModel.DataAnnotations;

namespace bloginterior.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; } 
        public string content { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public string author { get; set; }
      
    }
}

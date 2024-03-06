using System.ComponentModel.DataAnnotations;

namespace WebApplicationYeni.Models
{
    public class Books
    {
        [Key] 
        public int Id { get; set; }
        public string BookName  { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
        
        public bool Deleted { get; set; }
    }
}

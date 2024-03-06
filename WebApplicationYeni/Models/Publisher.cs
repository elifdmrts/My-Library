using System.ComponentModel.DataAnnotations;

namespace WebApplicationYeni.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string PublisherName { get; set; }
   
        public bool Deleted { get; set; }
    }
}

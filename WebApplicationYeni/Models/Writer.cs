using System.ComponentModel.DataAnnotations;

namespace WebApplicationYeni.Models
{
    public class Writer
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
     
        public bool Deleted { get; set; }
    }
}

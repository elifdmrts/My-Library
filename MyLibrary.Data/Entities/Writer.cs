using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Data.Entities
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

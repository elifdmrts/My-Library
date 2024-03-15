using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Data.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string PublisherName { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

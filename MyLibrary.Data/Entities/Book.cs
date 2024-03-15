using MyLibrary.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public BookStatuses BookStatus { get; set; }        
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }

    }
}

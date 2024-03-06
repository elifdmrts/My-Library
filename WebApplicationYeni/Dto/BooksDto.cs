using WebApplicationYeni.Models;

namespace WebApplicationYeni.Dto
{
    public class BooksDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
     

    }
}

using WebApplicationYeni.Models;

namespace WebApplicationYeni.Dto
{
    public class BooksCreateDto
    {
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
       
    }
}

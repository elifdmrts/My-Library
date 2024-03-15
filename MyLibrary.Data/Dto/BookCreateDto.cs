namespace MyLibrary.Data.Dto
{
    public class BookCreateDto
    {
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
       
    }
}

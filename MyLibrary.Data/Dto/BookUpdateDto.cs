namespace MyLibrary.Data.Dto
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public int WriterId { get; set; }
        public int PublisherId { get; set; }
     

    }
}

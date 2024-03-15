using MyLibrary.Data;
using MyLibrary.Data.Dto;
using MyLibrary.Data.Entities;

namespace MyLibrary.Business.Services
{
    public interface IBooksService
    {
        List<Book> GetAll();
        Book GetById(int id);
        Book Create(BookCreateDto model);
        void Update(BookUpdateDto model);
        void Delete(int id);
    }

    public class BooksService : IBooksService
    {

        public readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public Book Create(BookCreateDto model)
        {
            var books = new Book()
            {

                Deleted = false,
                BookName = model.BookName,
                NumberOfPages = model.NumberOfPages,
                WriterId = model.WriterId,
                PublisherId = model.PublisherId,
            };

            _context.Books.Add(books);
            _context.SaveChanges();

            return books;
        }

        public void Delete(int id)
        {
            try
            {
                var books = _context.Books.FirstOrDefault(x => !x.Deleted && x.Id == id);
                if (books == null)
                {
                    throw new Exception("Book not found");
                }
                books.Deleted = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Book Get(int id)
        {
            var books = _context.Books.FirstOrDefault(x => !x.Deleted && x.Id == id);
            return books;
        }

        public List<Book> GetAll()
        {
            var list = _context.Books.Where(x => !x.Deleted).ToList();
            return list;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BookUpdateDto model)
        {
            var books = _context.Books.FirstOrDefault(x => !x.Deleted && x.Id == model.Id);
            if (books == null)
            {
                throw new Exception("Director not found");
            }

            books.BookName = model.BookName;
            books.NumberOfPages = model.NumberOfPages;
            books.WriterId = model.WriterId;
            books.PublisherId = model.PublisherId;


            _context.SaveChanges();
        }


    }
}








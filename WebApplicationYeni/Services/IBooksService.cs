using Microsoft.EntityFrameworkCore;
using System.IO;
using WebApplicationYeni.Dto;
using WebApplicationYeni.Models;

namespace WebApplicationYeni.Services
   

{
    public interface IBooksService
    {
        List<Books> GetAll();
        Books GetById(int id);
        Books Create(BooksCreateDto model);
        void Update(BooksDto model);
        void Delete (int id);
    } 

    public class BooksService: IBooksService
    {

        public readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public Books Create(BooksCreateDto model)
        {
            var books = new Books()
            {
              
                Deleted = false,
                BookName = model.BookName,
                NumberOfPages = model.NumberOfPages,
                WriterId=model.WriterId,
                PublisherId=model.PublisherId,
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
        public Books Get(int id)
        {
            var books = _context.Books.FirstOrDefault(x => !x.Deleted && x.Id == id);
            return books;
        }

        public List<Books> GetAll()
        {
            var list = _context.Books.Where(x => !x.Deleted).ToList();
            return list;
        }

        public Books GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BooksDto model)
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








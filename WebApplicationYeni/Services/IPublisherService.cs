using WebApplicationYeni.Dto;
using WebApplicationYeni.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplicationYeni.Services
{
    public interface IPublisherService
    {
        List<Publisher> GetAll();
        Publisher GetById(int id);
        Publisher Create(PublisherCreateDto model);
        void Update(PublisherDto model);
        void Delete(int id);
    }

    public class PublisherService : IPublisherService
    {

        public readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher Create(PublisherCreateDto model)
        {
            var publisher = new Publisher()
            {

                Deleted = false,
                PublisherName=model.PublisherName,
            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return publisher;
        }



        public void Delete(int id)
        {
            try
            {
                var publisher = _context.Publishers.FirstOrDefault(x => !x.Deleted && x.Id == id);
                if (publisher == null)
                {
                    throw new Exception("Book not found");
                }
                publisher.Deleted = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Publisher Get(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(x => !x.Deleted && x.Id == id);
            return publisher;
        }



        public List<Publisher> GetAll()
        {
            var list = _context.Publishers.Where(x => !x.Deleted).ToList();
            return list;
          
        }

        public Publisher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PublisherDto model)
        {
            var publisher = _context.Publishers.FirstOrDefault(x => !x.Deleted && x.Id == model.Id);
            if (publisher == null)
            {
                throw new Exception("Director not found");
            }

            publisher.PublisherName = model.PublisherName;


            _context.SaveChanges();
        }

       
    }

       
    }
    

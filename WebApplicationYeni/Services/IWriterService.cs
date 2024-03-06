using WebApplicationYeni.Dto;
using WebApplicationYeni.Models;

namespace WebApplicationYeni.Services
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        Writer GetById(int id);
        Writer Create(WriterCreateDto model);
        void Update(WriterDto model);
        void Delete(int id);
    }
    public class WriterService : IWriterService
    {

        public readonly AppDbContext _context;

        public WriterService(AppDbContext context)
        {
            _context = context;
        }

        public Writer Create(WriterCreateDto model)
        {
            var writer = new Writer()
            {
                Name = model.Name,
                Surname = model.Surname,
                Deleted = false,
            };

            _context.Writers.Add(writer);
            _context.SaveChanges();


            return writer;
            
        }

        public void Delete(int id)
        {
            try
            {
                var writer = _context.Writers.FirstOrDefault(x => !x.Deleted && x.Id == id);
                if (writer == null)
                {
                    throw new Exception("Book not found");
                }
                writer.Deleted = true;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Writer> GetAll()
        {

            var list = _context.Writers.Where(x => !x.Deleted).ToList();
            return list;
        }

        public Writer Get(int id)
        {
            var writer = _context.Writers.FirstOrDefault(x => !x.Deleted && x.Id == id);
            return writer;
        }


        public Writer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(WriterDto model)
        {
            var writer = _context.Writers.FirstOrDefault(x => !x.Deleted && x.Id == model.Id);
            if (writer == null)
            {
                throw new Exception("Writer not found");
            }

            writer.Name= model.Name;
            writer.Surname= model.Surname;

            _context.SaveChanges();
        }
    }
    }


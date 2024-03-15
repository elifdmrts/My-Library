using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Data.Dto;
using MyLibrary.Data.Entities;
using MyLibrary.Data.Enums;

namespace MyLibrary.Business.Services
{
    public interface ILoanService
    {
        Task<List<Loan>> GetAll();
        Task LoanedBook(LoanedDto model);
        Task BorrowBook(BorrowDto model);
    }

    public class LoanService : ILoanService
    {
        private readonly AppDbContext _context;

        public LoanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAll()
        {
            try
            {
                var list = await _context.Loans
                    .Include(x => x.Book)
                    .ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Ödünç verme işlemi
        /// </summary>
        /// <param name="model"></param>        
        public async Task LoanedBook(LoanedDto model)
        {
            // kitap kaydını bul
            // kitap aktif mi?
            // kitap rafta mı?
            // loan kaydet
            // kitabın statusunu güncelle

            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == model.BookId && !x.Deleted);

                if (book == null)
                {
                    throw new Exception("Kitap bulunamadı.");
                }
                if (!book.IsActive)
                {
                    throw new Exception("Kitap aktif değil.");
                }
                if (book.BookStatus != BookStatuses.OnTheShelf)
                {
                    throw new Exception("Kitap ödünç vermeye uygun değildir.");
                }
                var loan = new Loan
                {
                    BookId = model.BookId,
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(15),
                    LoanStatus = LoanStatuses.Loaned,
                    UserId = model.UserId
                };

                await _context.Loans.AddAsync(loan);

                book.BookStatus = BookStatuses.InUser;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Ödünç alma işlemi
        /// </summary>
        /// <param name="model"></param>
        public async Task BorrowBook(BorrowDto model)
        {
            // ödünç kaydını bul
            // ödünç kaydı varsa kullanıcı ile teslim eden kullanıcı ile aynı mı?
            // günün tarihi DueDate ten sonra mı önce mi?
            // loan kaydını güncelle
            // kitap kaydını güncelle
            try
            {
                var loan = await _context.Loans.FindAsync(model.LoanId);

                if (loan == null)
                {
                    throw new Exception("Ödünç kaydı bulunamadı.");
                }
                var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == loan.BookId && !x.Deleted);

                if (book == null)
                {
                    throw new Exception("Kitap bulunamadı.");
                }
                if (loan.UserId != model.UserId)
                {
                    throw new Exception("Ödünç alan kullanıcı ile teslim eden kullanıcı aynı değil.");
                }
                if (loan.DueDate < DateTime.Now)
                {
                    var differenceDay = DateTime.Now - loan.DueDate;
                    throw new Exception($"Kitap {differenceDay.Days} gün gecikmiştir.");
                }

                loan.LoanStatus = LoanStatuses.Borrowed;
                loan.DeliveryDate = DateTime.Now;

                book.BookStatus = BookStatuses.OnTheShelf;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

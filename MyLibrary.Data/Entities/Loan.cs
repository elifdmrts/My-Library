using MyLibrary.Data.Enums;

namespace MyLibrary.Data.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public LoanStatuses LoanStatus { get; set; }
        public DateTime CreatedDate { get; set; } // kayıt tarihi
        public DateTime DueDate { get; set; } // beklenen(hesaplanan) tarih
        public DateTime? DeliveryDate { get; set; } // teslim tarihi
    }
}

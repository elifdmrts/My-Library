using MyLibrary.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Surname { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
        
        public UserTypes UserType { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public bool IsActive { get; set; }
        
        public bool Deleted { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}

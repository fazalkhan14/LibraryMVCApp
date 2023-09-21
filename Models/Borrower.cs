using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVCApp.Models
{
    public class Borrower
    {
        public int Id { get; set; }
        public DateTime BorrowedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public ICollection<Book> books { get; set; }
    }
}
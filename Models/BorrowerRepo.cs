using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVCApp.Models
{
    public class BorrowerRepo
    {
         private readonly LibraryContext _context;
        public BorrowerRepo(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Borrower> GetById(int id)
        {
            Borrower borrower = await _context.Borrowers.FindAsync(id);
            return borrower;
        }

        public async Task<List<Borrower>> GetAll()
        {
            return await _context.Borrowers.ToListAsync();
        }

        public bool Add(Borrower borrower)
        {
            if(borrower != null)
            {
                _context.Borrowers.Add(borrower);
                int rowsEffected = _context.SaveChanges();
                if(rowsEffected > 0)
                    return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            Borrower borrower = _context.Borrowers.Find(id);
            if(borrower != null)
            {
                _context.Borrowers.Remove(borrower);
                int rowsEffected = _context.SaveChanges();
                if(rowsEffected > 0)
                    return true;
            }
            return false;
        }

        public bool Update(int id,Borrower borrower)
        {
            if(borrower != null)
            {
                Borrower borrowerToUpdate = _context.Borrowers.Find(id);
                if(borrowerToUpdate != null)
                {
                    borrowerToUpdate.BorrowedOn = borrower.BorrowedOn;
                    borrowerToUpdate.ReturnedOn = borrower.ReturnedOn;
                    borrowerToUpdate.ReturnDate = borrower.ReturnDate;
                    borrowerToUpdate.BookId = borrower.BookId;
                    int rowsEffected = _context.SaveChanges();
                    if(rowsEffected > 0)
                        return true;
                }
            }
            return false;
        }
    }
}
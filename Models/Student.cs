using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVCApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
    }
}
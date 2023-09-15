using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVCApp.Models
{
    public class StudentRepo
    {
        private readonly LibraryContext _context;
        public StudentRepo(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Student> GetById(int id)
        {
            Student student = await _context.Students.FindAsync(id);
            return student;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public bool Add(Student student)
        {
            if(student != null)
            {
                _context.Students.Add(student);
                int rowsEffected = _context.SaveChanges();
                if(rowsEffected > 0)
                    return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            Student student = _context.Students.Find(id);
            if(student != null)
            {
                _context.Students.Remove(student);
                int rowsEffected = _context.SaveChanges();
                if(rowsEffected > 0)
                    return true;
            }
            return false;
        }

        public bool Update(int id,Student student)
        {
            if(student != null)
            {
                Student StudentToUpdate = _context.Students.Find(id);
                if(StudentToUpdate != null)
                {
                    StudentToUpdate.Name = student.Name;
                    StudentToUpdate.DepartmentName = student.DepartmentName;
                    StudentToUpdate.BorrowerId = student.BorrowerId;
                    int rowsEffected = _context.SaveChanges();
                    if(rowsEffected > 0)
                        return true;
                }
            }
            return false;
        }
    }
}
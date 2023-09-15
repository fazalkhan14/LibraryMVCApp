using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVCApp.Models
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        bool Add(T value);
        bool Remove(int id);
        bool Update(int id, T value);
    }
}
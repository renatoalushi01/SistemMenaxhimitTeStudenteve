using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.Services
{
    public interface ILendetService
    {
        Task<IEnumerable<Lendet>> GetAll();
        Task AddAsync(Lendet lendet);
        Task<Lendet> GetAsync(int id);
        Task UpdateAsync(Lendet lendet);
        Task DeleteAsync(int id);
    }
}

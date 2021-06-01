using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.Services
{
    public interface IStudentLendService
    {
        Task<IEnumerable<StudentLend>> GetAll();
        Task AddAsync(StudentLend studentLend);
        Task<StudentLend> GetAsync(int id);
        Task UpdateAsync(StudentLend studentLend);
        Task DeleteAsync(int id);
    }
}

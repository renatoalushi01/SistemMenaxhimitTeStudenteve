using SistemMenaxhimitTeStudenteve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Repository.Commin;

namespace SistemMenaxhimitTeStudenteve.Services
{
    public class StudentLendService : IStudentLendService
    {
        private readonly StudentLendRepository _studentLendRepositoryl;
        public StudentLendService(StudentLendRepository studentLendRepository)
        {
            _studentLendRepositoryl = studentLendRepository;
        }
        public async Task AddAsync(StudentLend studentLend)
        {
            await _studentLendRepositoryl.AddAsync(studentLend);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentLendRepositoryl.RemoveAsync(id);
        }

        public Task<IEnumerable<StudentLend>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentLend> GetAsync(int id)
        {
            return await _studentLendRepositoryl.GetAsync(id);
        }

        public async Task UpdateAsync(StudentLend studentLend)
        {
            await _studentLendRepositoryl.UpdateAsync(studentLend);
        }
    }
}

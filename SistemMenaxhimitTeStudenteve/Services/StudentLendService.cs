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
        private readonly StudentLendRepository _studentLendRepository;
        public StudentLendService(StudentLendRepository studentLendRepository)
        {
            _studentLendRepository = studentLendRepository;
        }
        public async Task AddAsync(StudentLend studentLend)
        {
            await _studentLendRepository.AddAsync(studentLend);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentLendRepository.RemoveAsync(id);
        }

        public async Task<List<StudentLend>> GetAllLendStudent(int studentId)
        {
            return await _studentLendRepository.GetAllStudentLend(studentId);
        }

        public int TotalLend(int studentId)
        {
            return _studentLendRepository.TotalLend(studentId);
        }

        public async Task<StudentLend> GetAsync(int id)
        {
            return await _studentLendRepository.GetAsync(id);
        }

        public async Task UpdateAsync(StudentLend studentLend)
        {
            await _studentLendRepository.UpdateAsync(studentLend);
        }

        public async Task<IEnumerable<StudentLend>> GetStudentLends(int studentId)
        {
            return await _studentLendRepository.GetStudentLendsAsync(studentId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.Repository.Commin
{
    public class StudentLendRepository : BaseRepository<StudentLend>
    {
        private readonly DatabaseContext _context;

        public StudentLendRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<StudentLend>> GetAllStudentLend(int studentId)
        {
            return await _context.StudentLends.Where(x => x.StudentId == studentId).ToListAsync();
        }

        public async Task<List<StudentLend>> TotalStudentLend(int studentId)
        {
            return await _context.StudentLends.Where(x => x.StudentId == studentId && x.Subscribe).ToListAsync();
        }

        public async Task<IEnumerable<StudentLend>> GetStudentLendsAsync(int studentId)
        {
            return await _context.StudentLends.Include(x => x.Lendet).Where(x => x.StudentId == studentId && x.Subscribe).ToListAsync();
        }
    }
}

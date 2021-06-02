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

        public int TotalLend(int studentId)
        {
            return _context.StudentLends.Where(x => x.StudentId == studentId && x.Subscribe).Select(x => x.LendId).Count();
        }
    }
}

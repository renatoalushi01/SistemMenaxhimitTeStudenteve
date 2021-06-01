using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.Repository.Commin
{
    public class StudentRepository : BaseRepository<Student>
    {
        private readonly DatabaseContext _context;

        public StudentRepository(DatabaseContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfExist(string nId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.NID == nId);
            return student == null ? true : false;

        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetIfExist(string nId)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.NID == nId);
        }
        public async Task<Student> GetStudentForEdit(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

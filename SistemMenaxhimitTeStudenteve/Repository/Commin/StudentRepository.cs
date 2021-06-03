using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemMenaxhimitTeStudenteve.Models;
using SistemMenaxhimitTeStudenteve.Repository.Extensions;

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

        public async Task<PaginatedList<Student>> GetPaginatedAsync(int page,int pageSize)
        {
            var result = _context.Students.OrderBy(x => x.Emer);
            return await PaginatedList<Student>.CreateAsync(result, page, pageSize);
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

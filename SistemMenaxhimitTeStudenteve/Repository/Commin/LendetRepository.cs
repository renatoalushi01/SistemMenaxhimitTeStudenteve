using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.Repository.Commin
{
    public class LendetRepository : BaseRepository<Lendet>
    {
        private readonly DatabaseContext _context;

        public LendetRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lendet>> GetAll()
        {
            return await _context.Lendet.ToListAsync();
        }
    }
}

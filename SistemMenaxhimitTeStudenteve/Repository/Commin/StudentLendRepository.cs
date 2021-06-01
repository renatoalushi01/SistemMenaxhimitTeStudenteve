using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


    }
}

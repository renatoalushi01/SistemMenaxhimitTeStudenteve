using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Repository;

namespace SistemMenaxhimitTeStudenteve.Models
{
    public class StudentLend : BaseEntity
    {
        public int StudentId { get; set; }
        public int LendId { get; set; }
        public bool Subscribe { get; set; }
        public DateTime Data { get; set; }
        public virtual Student Student { get; set; }
        public virtual Lendet Lendet { get; set; }
    }
}

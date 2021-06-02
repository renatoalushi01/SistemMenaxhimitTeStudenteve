using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Repository;

namespace SistemMenaxhimitTeStudenteve.Models
{
    public class Student : BaseEntity
    {
        public string NID { get; set; }
        public string Emer { get; set; }
        public string Mbiemer { get; set; }
        public double NotaMesartare { get; set; }
        public string ProfesioniDeshiruar { get; set; }
        public string TedhenaTePergj { get; set; }
        public string Fjalkalimi { get; set; }
        public List<StudentLend> StudentLend { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.ViewModels
{
    public class StudentDetails
    {
        public Student Student { get; set; }
        public IEnumerable<StudentLend> StudentLends { get; set; }
    }
}

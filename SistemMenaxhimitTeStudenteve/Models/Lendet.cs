using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Repository;

namespace SistemMenaxhimitTeStudenteve.Models
{
    public class Lendet : BaseEntity
    {
        public string Emer { get; set; }

        public string Info { get; set; }
    }
}

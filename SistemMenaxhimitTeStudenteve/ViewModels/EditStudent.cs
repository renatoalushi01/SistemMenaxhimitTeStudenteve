using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;

namespace SistemMenaxhimitTeStudenteve.ViewModels
{
    public class EditStudent
    {
        public int Id { get; set; }
        [Required]
        public string NID { get; set; }
        [Required]
        public string Emer { get; set; }
        [Required]
        public string Mbiemer { get; set; }
        public string Fjalkalimi { get; set; }
        [Display(Name = "Nota Mesartare")]
        public double NotaMesartare { get; set; }
        [Display(Name = "Profesioni i Deshiruar")]
        public string ProfesioniDeshiruar { get; set; }
        [Display(Name = "Te dhena te pergjithshme")]
        public string TedhenaTePergj { get; set; }
        public IEnumerable<Lendet> Lendet { get; set; }
        
    }
}

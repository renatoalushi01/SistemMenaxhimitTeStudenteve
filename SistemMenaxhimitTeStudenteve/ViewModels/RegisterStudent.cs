using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemMenaxhimitTeStudenteve.ViewModels
{
    public class RegisterStudent
    {
        [Required]
        public string NID { get; set; }
        public string Emer { get; set; }
        public string Mbiemer { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Fjalkalimi")]
        [MinLength(6)]
        public string Fjalkalimi { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Konfirmo Fjallalimin")]
        [Compare("Fjalkalimi", ErrorMessage = "Fjalkalimet nuk jane te njejte.")]
        public string KonfirmFjallalimin { get; set; }
    }
}

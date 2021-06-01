using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemMenaxhimitTeStudenteve.ViewModels
{
    public class LoginStudent
    {
        [Required]
        [Display(Name = "NID Studenti")]
        public string NID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Fjalkalimi")]
        public string Fjalkalimi { get; set; }
        [Display(Name = "Me mbaj mend")]
        public bool MeMbajMend { get; set; }
    }
}

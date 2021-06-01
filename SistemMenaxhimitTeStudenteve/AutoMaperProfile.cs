using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemMenaxhimitTeStudenteve.Models;
using SistemMenaxhimitTeStudenteve.ViewModels;
using AutoMapper;

namespace SistemMenaxhimitTeStudenteve
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<RegisterStudent, Student>().ReverseMap();
            CreateMap<EditStudent, Student>().ReverseMap();
        }
        
    }
}

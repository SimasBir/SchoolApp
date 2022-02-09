using AutoMapper;
using SchoolsAppSPA_BE.Dtos;
using SchoolsAppSPA_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsAppSPA_BE.Automapper
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, CreateSchool>().ReverseMap();
            CreateMap<School, ViewSchool>();
            CreateMap<Student, CreateStudent>().ReverseMap();
            CreateMap<Student, ViewStudent>();
        }
    }
}

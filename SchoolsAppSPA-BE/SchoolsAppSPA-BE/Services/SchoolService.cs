using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolsAppSPA_BE.Data;
using SchoolsAppSPA_BE.Dtos;
using SchoolsAppSPA_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsAppSPA_BE.Services
{
    public class SchoolService
    {
        private readonly IMapper _mapper;
        private DataContext _context;
        public SchoolService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ViewSchool>> GetSchoolsAsync()
        {
            List<School> allSchools = await _context.Schools.Include(s=>s.Students).ToListAsync();
            List<ViewSchool> schools = new List<ViewSchool>();
            foreach (var school in allSchools)
            {
                schools.Add(_mapper.Map<ViewSchool>(school));
            }
            return schools;
        }


    }
}

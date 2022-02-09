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
            List<ViewSchool> viewSchools = new List<ViewSchool>();
            foreach (var school in allSchools)
            {
                viewSchools.Add(_mapper.Map<ViewSchool>(school));
            }
            return viewSchools;
        }
        public async Task<ViewSchool> GetSchoolAsync(int id)
        {
            School school = await _context.Schools.Include(s => s.Students).Where(i=>i.Id == id).FirstOrDefaultAsync();
            if (school == null)
            {
                return null;
            }
            ViewSchool viewSchool = _mapper.Map<ViewSchool>(school);
            return viewSchool;
        }
        public async Task<int> PostSchool(CreateSchool createSchool)
        {

        }
        public async Task<int> PutSchool(int id, CreateSchool createSchool)
        {

        }
        public async Task<int> DeleteSchool(int id)
        {

        }



    }
}

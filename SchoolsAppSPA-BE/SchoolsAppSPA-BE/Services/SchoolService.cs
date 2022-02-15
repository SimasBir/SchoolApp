using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolsAppSPA_BE.Data;
using SchoolsAppSPA_BE.Dtos;
using SchoolsAppSPA_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<ViewSchool> viewSchools = _mapper.Map<List<ViewSchool>>(allSchools);
            return viewSchools;
        }

        public async Task<ViewSchool> GetSchoolAsync(int id)
        {
            School school = await _context.Schools.Include(s => s.Students).Where(i=>i.Id == id).FirstOrDefaultAsync();
            if (school == null)
            {
                throw new ArgumentException($"School {id} not found");
            }
            ViewSchool viewSchool = _mapper.Map<ViewSchool>(school);
            return viewSchool;
        }

        public async Task<int> PostSchoolAsync(CreateSchool createSchool)
        {
            School school = _mapper.Map<School>(createSchool);
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();
            return school.Id;
        }

        public async Task<int> PutSchoolAsync(int id, CreateSchool createSchool)
        {
            var school = await _context.Schools.FirstOrDefaultAsync(t => t.Id == id);
            if (school == null)
            {
                throw new ArgumentException($"School with the id {id} was not found");
            }
            school.Name = createSchool.Name;
            _context.Update(school);
            await _context.SaveChangesAsync();
            return school.Id;
        }

        public async Task<int> DeleteSchoolAsync(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                throw new ArgumentException($"Id {id} was not found");
            }
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return school.Id;
        }
    }
}

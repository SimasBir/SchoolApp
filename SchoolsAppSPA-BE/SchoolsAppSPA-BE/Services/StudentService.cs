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
    public class StudentService
    {
        private readonly IMapper _mapper;
        private DataContext _context;

        public StudentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ViewStudent>> GetStudentsAsync()
        {
            List<Student> allStudents = await _context.Students.Include(s => s.School).ToListAsync();
            List<ViewStudent> viewStudents = _mapper.Map<List<ViewStudent>>(allStudents);
            return viewStudents;
        }

        public async Task<ViewStudent> GetStudentAsync(int id)
        {
            Student student = await _context.Students.Include(s => s.School).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                throw new ArgumentException($"Student {id} not found");
            }
            ViewStudent viewStudent = _mapper.Map<ViewStudent>(student);
            return viewStudent;
        }

        public async Task<int> PostStudentAsync(CreateStudent createStudent)
        {
            Student student = _mapper.Map<Student>(createStudent);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }

        public async Task<int> PutStudentAsync(int id, CreateStudent createStudent)
        {
            var student = await _context.Students.FirstOrDefaultAsync(t => t.Id == id);
            if (student == null)
            {
                throw new ArgumentException($"Student with the id {id} was not found");
            }

            student.Name = createStudent.Name;
            student.Surname = createStudent.Surname;
            student.SchoolId = createStudent.SchoolId;

            _context.Update(student);

            await _context.SaveChangesAsync();
            return student.Id;
        }

        public async Task<int> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new ArgumentException($"Id {id} was not found");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }
    }
}

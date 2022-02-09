using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolsAppSPA_BE.Data;
using SchoolsAppSPA_BE.Models;
using SchoolsAppSPA_BE.Services;

namespace SchoolsAppSPA_BE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        //{
        //    return await _context.Students.ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Student>> GetStudent(int id)
        //{
        //    var student = await _context.Students.FindAsync(id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return student;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStudent(int id, Student student)
        //{
        //    if (id != student.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(student).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult<Student>> PostStudent(Student student)
        //{
        //    _context.Students.Add(student);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStudent(int id)
        //{
        //    var student = await _context.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Students.Remove(student);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.Id == id);
        //}
    }
}

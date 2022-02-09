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
    public class SchoolController : ControllerBase
    {
        private SchoolService _schoolService;
        public SchoolController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<ActionResult> GetSchools()
        {
            var schoolList = await _schoolService.GetSchoolsAsync();
            return Ok(schoolList);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetSchool(int id)
        //{
        //    var school = await _context.Schools.FindAsync(id);

        //    if (school == null)
        //    {
        //        return NotFound();
        //    }

        //    return school;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSchool(int id, School school)
        //{
        //    if (id != school.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(school).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SchoolExists(id))
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
        //public async Task<ActionResult<School>> PostSchool(School school)
        //{
        //    _context.Schools.Add(school);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSchool", new { id = school.Id }, school);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSchool(int id)
        //{
        //    var school = await _context.Schools.FindAsync(id);
        //    if (school == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Schools.Remove(school);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SchoolExists(int id)
        //{
        //    return _context.Schools.Any(e => e.Id == id);
        //}
    }
}

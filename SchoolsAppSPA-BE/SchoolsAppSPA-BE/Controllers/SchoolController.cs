using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolsAppSPA_BE.Dtos;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSchool(int id)
        {
            try
            {
                var school = await _schoolService.GetSchoolAsync(id);
                return Ok(school);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostSchool(CreateSchool createSchool)
        {
            try
            {
                var createdId = await _schoolService.PostSchoolAsync(createSchool);
                return Created("School has been created. Id: ", createdId);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(int id, CreateSchool createSchool)
        {
            try
            {
                var createdId = await _schoolService.PutSchoolAsync(id, createSchool);
                return Created("School has been updated. Id: ", createdId);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            try
            {
                await _schoolService.DeleteSchoolAsync(id);
                return Ok(id + " has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

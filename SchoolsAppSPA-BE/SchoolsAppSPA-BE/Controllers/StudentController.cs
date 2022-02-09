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
    public class StudentController : ControllerBase
    {
        private StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var studentList = await _studentService.GetStudentsAsync();
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            try
            {
                var student = await _studentService.GetStudentAsync(id);
                return Ok(student);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostStudent(CreateStudent createStudent)
        {
            try
            {
                var createdId = await _studentService.PostStudentAsync(createStudent);
                return Created("Student has been created. Id: ", createdId);
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
        public async Task<IActionResult> PutStudent(int id, CreateStudent createStudent)
        {
            try
            {
                var createdId = await _studentService.PutStudentAsync(id, createStudent);
                return Created("Student has been updated. Id: ", createdId);
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
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return Ok(id + " has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

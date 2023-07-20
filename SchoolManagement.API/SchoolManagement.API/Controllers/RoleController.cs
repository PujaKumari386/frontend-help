using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.API.Repository;
using SchoolManagement.API.ViewModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository RoleRepository)
        {
            _roleRepository = RoleRepository;
        }

//Api Call for Student Table

        [HttpGet("student")]

        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _roleRepository.GetAllStudents();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("student/{id}")]

        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student = await _roleRepository.GetStudentbyId(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("st/{firstName}")]

        public async Task<IActionResult> GetStudentByName([FromRoute] string firstName)
        {
            var student = await _roleRepository.GetStudentbyName(firstName);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpPost("student/add")]

        public async Task<IActionResult> AddNewStudent([FromBody] StudentModel studentModel)
        {
            var id = await _roleRepository.AddStudent(studentModel);
            return CreatedAtAction(nameof(GetStudentById), new { id = id, controller = "Student" }, id);
        }


        [HttpPut("student/up/{id}")]

        public async Task<IActionResult> UpdateStudent([FromBody] StudentModel studentModel, [FromRoute] int id)
        {
            await _roleRepository.UpdateStudent(id, studentModel);
            return Ok();
        }


        [HttpPatch("student/patch/{id}")]

        public async Task<IActionResult> UpdateStudentPatch([FromBody] JsonPatchDocument studentModel, [FromRoute] int id)
        {
            await _roleRepository.UpdateStudentPatch(id, studentModel);
            return Ok();
        }

        [HttpDelete("student/delete/{id}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            await _roleRepository.DeleteStudent(id);
            return Ok();
        }
//Api Call for Teachers Table

        [HttpGet("teacher")]

        public async Task<IActionResult> GetAllTeacher()
        {
            var teachers = await _roleRepository.GetAllTeachers();
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }

        [HttpGet("teacher/{id}")]

        public async Task<IActionResult> GetTeacherById([FromRoute] int id)
        {
            var teacher = await _roleRepository.GetTeacherbyId(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        /*[HttpGet("teacher/{name}")]

        public async Task<IActionResult> GetTeacherByName([FromRoute] int firstName)
        {
            var teacher = await _roleRepository.GetTeacherbyName(firstName);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        */

        [HttpPost("teacher/add")]

        public async Task<IActionResult> AddNewTeacher([FromBody] TeacherModel teacherModel)
        {
            var id = await _roleRepository.AddTeacher(teacherModel);
            return CreatedAtAction(nameof(GetTeacherById), new { id = id, controller = "teachers" }, id);
        }

        [HttpPut("teacher/up/{id}")]

        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherModel teacherModel, [FromRoute] int id)
        {
            await _roleRepository.UpdateTeacher(id, teacherModel);
            return Ok();
        }


        [HttpPatch("teacher/patch/{id}")]

        public async Task<IActionResult> UpdateTeacherPatch([FromBody] JsonPatchDocument teacherModel, [FromRoute] int id)
        {
            await _roleRepository.UpdateTeacherPatch(id, teacherModel);
            return Ok();
        }

        [HttpDelete("teacher/delete/{id}")]

        public async Task<IActionResult> DeleteTeacher([FromRoute] int id)
        {
            await _roleRepository.DeleteTeacher(id);
            return Ok();
        }

        //Class Api's

       /* [HttpGet("class")]

        public async Task<IActionResult> GetAllclass()
        {
            var classes = await _roleRepository.GetAllClasses();
            if (classes == null)
            {
                return NotFound();
            }
            return Ok(classes);
        }

        [HttpGet("class/{id}")]

        public async Task<IActionResult> GetClassById([FromRoute] int id)
        {
            var _class = await _roleRepository.GetClassbyId(id);
            if (_class == null)
            {
                return NotFound();
            }
            return Ok(_class);
        }

        [HttpPost("class/add")]

        public async Task<IActionResult> AddNewClass([FromBody] ClassTable _class)
        {
            var id = await _roleRepository.AddClass(_class);
            return CreatedAtAction(nameof(GetClassById), new { id = id, controller = "classes" }, id);
        }

        /*[HttpDelete("class/delete/{id}")]

        public async Task<IActionResult> DeleteClass([FromRoute] int id)
        {
            await _roleRepository.DeleteClass(id);
            return Ok();
        }*/


        /*[HttpGet("Notice")]

        public async Task<IActionResult> GetAllNotice()
        {
            var notices = await _roleRepository.GetAllNotices();
            if (notices == null)
            {
                return NotFound();
            }
            return Ok(notices);
        }
       

        [HttpGet("notice/{id}")]
        public async Task<IActionResult> GetNoticeById([FromRoute] int id)
        {
            var notice = await _roleRepository.GetNoticebyId(id);
            if (notice == null)
            {
                return NotFound();
            }
            return Ok(notice);
        }

        

        [HttpPost("notice/add")]

        public async Task<IActionResult> AddNewNotice([FromBody] NoticeTable notice)
        {
            var id = await _roleRepository.AddNotice(notice);
            return CreatedAtAction(nameof(GetNoticeById), new { id = id, controller = "notices" }, id);
        }

        [HttpDelete("notice/delete/{id}")]

        public async Task<IActionResult> DeleteNotice([FromRoute] int id)
        {
            await _roleRepository.DeleteNotice(id);
            return Ok();
        }*/
    }
}

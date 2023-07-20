using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Models;
using SchoolManagement.API.ViewModel;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolManagement.API.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MydatabaseContext db;
        private readonly IMapper _mapper;

        public RoleRepository(MydatabaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<List<StudentModel>> GetAllStudents()
        {
            if (db != null)
            {
                var records = await db.StudentTables.ToListAsync();
                return _mapper.Map<List<StudentModel>>(records);
            }
            return null;

        }

        public async Task<StudentModel> GetStudentbyId(int studentId)
        {
            var student = await db.StudentTables.FindAsync(studentId);
            return _mapper.Map<StudentModel>(student);
        }

        public async Task<StudentModel> GetStudentbyName(string firstName)
        {
           // return db.StudentTables.FirstOrDefault(s => s.FirstName == firstName);
            var record = await db.StudentTables.Where(x => x.FirstName == firstName).Select(x => new StudentModel()
            {
                StudentId = x.StudentId,
                EmailId = x.EmailId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Dob = x.Dob,
                Phone = x.Phone,
                Address = x.Address,
                Password = x.Password
            }).FirstOrDefaultAsync();
            return record;
        }

        public async Task<StudentTable> AddStudent(StudentModel studentModel)
        {
            var record = new LoginTable()
            {
                LoginEmailId = studentModel.EmailId,
                Password = studentModel.Password,
                IsVerified = true,
                IsUser = "student",
                Token = null,
                TokenExpired = false,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
            };
            db.LoginTables.Add(record);
            await db.SaveChangesAsync();

            var studentdata = new StudentTable()
            {
                EmailId = studentModel.EmailId,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Dob = studentModel.Dob,
                Phone = studentModel.Phone,
                Address = studentModel.Address,
                Password = studentModel.Password
            };
            db.StudentTables.Add(studentdata);
            await db.SaveChangesAsync();

            return studentdata;

        }

        public async Task UpdateStudent(int StudentId, StudentModel studentModel)
        {
            var record = new StudentTable()
            {
                StudentId = StudentId,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                EmailId = studentModel.EmailId,
                Dob = studentModel.Dob,
                Phone = studentModel.Phone,
                Address = studentModel.Address,
                Password = studentModel.Password
            };
            db.StudentTables.Update(record);
            await db.SaveChangesAsync();

        }

        public async Task UpdateStudentPatch(int StudentId, JsonPatchDocument studentModel)
        {
            var record = await db.StudentTables.FindAsync(StudentId);
            if (record != null)
            {
                studentModel.ApplyTo(record);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteStudent(int StudentId)
        {
            var record = new StudentTable()
            { StudentId = StudentId };
            db.StudentTables.Remove(record);
            await db.SaveChangesAsync();

        }

        public async Task<List<TeacherModel>> GetAllTeachers()
        {
            if (db != null)
            {
                var data = await db.TeacherTables.ToListAsync();
                return _mapper.Map<List<TeacherModel>>(data);
            }
            return null;
        }

        public async Task<TeacherModel> GetTeacherbyId(int teacherId)
        {
            var teacher = await db.TeacherTables.FindAsync(teacherId);
            return _mapper.Map<TeacherModel>(teacher);

        }

        public async Task<TeacherTable> AddTeacher(TeacherModel teacherModel)
        {
            var record = new LoginTable()
            {
                LoginEmailId = teacherModel.EmailId,
                Password = teacherModel.Password,
                IsVerified = true,
                IsUser = "teacher",
                Token = null,
                TokenExpired = false,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
            };
            db.LoginTables.Add(record);
            await db.SaveChangesAsync();

            var data = new TeacherTable()
            {
                TeacherId = teacherModel.TeacherId,
                FirstName = teacherModel.FirstName,
                LastName = teacherModel.LastName,
                EmailId = teacherModel.EmailId,
                Dob = teacherModel.Dob,
                Phone = teacherModel.Phone,
                Address = teacherModel.Address,
                Salary = teacherModel.Salary,
                Password = teacherModel.Password
            };
            db.TeacherTables.Add(data);
            await db.SaveChangesAsync();

            return data;

        }

        public async Task UpdateTeacher(int TeacherId, TeacherModel teacherModel)
        {
            var data = new TeacherTable()
            {
                TeacherId = teacherModel.TeacherId,
                FirstName = teacherModel.FirstName,
                LastName = teacherModel.LastName,
                EmailId = teacherModel.EmailId,
                Dob = teacherModel.Dob,
                Phone = teacherModel.Phone,
                Address = teacherModel.Address,
                Salary = teacherModel.Salary,
                Password = teacherModel.Password
            };
            db.TeacherTables.Update(data);
            await db.SaveChangesAsync();
        }

        public async Task UpdateTeacherPatch(int TeacherId, JsonPatchDocument teacherModel)
        {
            var data = await db.TeacherTables.FindAsync(TeacherId);
            if (data != null)
            {
                teacherModel.ApplyTo(data);
                await db.SaveChangesAsync();

            }
        }

        public async Task DeleteTeacher(int TeacherId)
        {
            var data = new TeacherTable()
            { TeacherId = TeacherId };
            db.TeacherTables.Remove(data);
            await db.SaveChangesAsync();
        }


        /*
         var records = await db.Students.FindAsync(StudentId);
            if (records != null)
            {
                _mapper.Map<Student>(records);
                await db.SaveChangesAsync();

            }

        //UpdateStudent
        var records = await db.Students.FindAsync(StudentId);
             if (records != null)
             {
                 _mapper.Map<Student>(records);
                 await db.SaveChangesAsync();

             }
        public async Task<List<Class>> GetAllClasses()
        {
            if (db != null)
            {
                var data = await db.ClassTables.ToListAsync();
                return _mapper.Map<List<Class>>(data);
            }
            return null;

        }

       public async Task<Class> GetClassbyId(int classId)
        {
            var _class = await db.ClassTables.FindAsync(classId);
            return _mapper.Map<Class>(_class);
        }


        public async Task<int> AddClass(ClassTable _class)
        {
            var record = new ClassTable();
            { };
            db.ClassTables.Add(_class);
            await db.SaveChangesAsync();

            return record.ClassId;
        }
        public async Task DeleteClass(int ClassId)
        {
            var record = new ClassTable()
            { ClassId = ClassId };
            db.ClassTables.Remove(record);
            await db.SaveChangesAsync();

        }


        public async Task<List<NoticeTable>> GetAllNotices()
        {
            if (db != null)
            {
                var data = await db.NoticeTables.ToListAsync();
                return _mapper.Map<List<NoticeTable>>(data);
            }
            return null;

        }

        /*public async Task<List<Leave>> GetAllLeaves()
        {
            if (db != null)
            {
                var data = await db.Leaves.ToListAsync();
                return _mapper.Map<List<Leave>>(data);
            }
            return null;

        }*/

     
 
        /*public async Task<NoticeTable> GetNoticebyId(int noticeId)
        {
            var notice = await db.NoticeTables.FindAsync(noticeId);
            return _mapper.Map<NoticeTable>(notice);
        }

        
        public async Task<int> AddNotice(NoticeTable notice)
        {
            var data = new NoticeTable();
            { };
            db.NoticeTables.Add(notice);
            await db.SaveChangesAsync();

            return data.NoticeId;

        }

        public async Task DeleteNotice(int NoticeId)
        {
            var data = new NoticeTable()
            { NoticeId = NoticeId };
            db.NoticeTables.Remove(data);
            await db.SaveChangesAsync();

        }*/

    }
}

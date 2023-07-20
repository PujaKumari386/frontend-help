using Microsoft.AspNetCore.JsonPatch;
using SchoolManagement.API.Models;
using SchoolManagement.API.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.API.Repository
{
    public interface IRoleRepository
    {
        Task<List<StudentModel>> GetAllStudents();
        Task<StudentModel> GetStudentbyId(int studentId);
        Task<StudentModel> GetStudentbyName(string firstName);
        Task<StudentTable> AddStudent(StudentModel studentModel);
        Task UpdateStudent(int StudentId, StudentModel studentModel);
        Task UpdateStudentPatch(int StudentId, JsonPatchDocument studentModel);
        Task DeleteStudent(int StudentId);

        Task<List<TeacherModel>> GetAllTeachers();
        Task<TeacherModel> GetTeacherbyId(int teacherId);
        Task<TeacherTable> AddTeacher(TeacherModel teacherModel);
        Task UpdateTeacher(int TeacherId, TeacherModel teacherModel);
        Task UpdateTeacherPatch(int TeacherId, JsonPatchDocument teacherModel);
        Task DeleteTeacher(int TeacherId);

       /* Task<List<ClassTable>> GetAllClasses();
        Task<List<NoticeTable>> GetAllNotices();
        
        Task<NoticeTable> GetNoticebyId(int noticeId);
        Task<ClassTable> GetClassbyId(int classId);
        Task<int> AddClass(ClassTable _class);
        Task<int> AddNotice(NoticeTable notice);
        Task DeleteNotice(int NoticeId);*/
        



    }
}

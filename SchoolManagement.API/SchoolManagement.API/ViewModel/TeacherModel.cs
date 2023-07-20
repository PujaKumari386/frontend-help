using System;

namespace SchoolManagement.API.ViewModel
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string Password { get; set; }
    }
}

using System;

namespace SchoolManagement.API.ViewModel
{
    public class AttendanceModel
    {
        public int AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

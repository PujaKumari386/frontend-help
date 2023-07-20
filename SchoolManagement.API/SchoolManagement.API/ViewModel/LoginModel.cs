using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SchoolManagement.API.ViewModel
{
    public class LoginModel
    {
        public int LoginId { get; set; }
        public string LoginEmailId { get; set; }
        public string Password { get; set; }
        public bool? IsVerified { get; set; }
        public string IsUser { get; set; }
        public string Token { get; set; }
        public bool? TokenExpired { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}

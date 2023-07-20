using Microsoft.AspNetCore.JsonPatch;
using SchoolManagement.API.Models;
using SchoolManagement.API.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.API.Repository
{
    public interface ILoginRepository
    {
        Task<int> AddNewLogin(LoginModel loginModel);
        Task<LoginTable> AddAuthentication(LoginModel role);
        Task<List<LoginModel>> GetAllLogins();
        Task<LoginModel> GetLoginbyId(int loginId);
        //Task UpdateLogin(int LoginId, LoginModel loginModel);
        //Task UpdateLoginPatch(int LoginId, JsonPatchDocument loginModel);
        // Task DeleteLogin(int LoginId);
    }
}

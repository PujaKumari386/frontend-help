using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Models;
using SchoolManagement.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MydatabaseContext db;
        private readonly IMapper _mapper;

        public LoginRepository(MydatabaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public async Task<int> AddNewLogin(LoginModel loginModel)
        {
            var record = new LoginTable()
            {
                LoginEmailId = loginModel.LoginEmailId,
                Password = loginModel.Password,
                IsVerified = true,
                IsUser = null,
                Token = loginModel.Token,
                TokenExpired = false,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
            };
            db.LoginTables.Add(record);

            return record.LoginId;

        }

        public async Task<LoginTable> AddAuthentication(LoginModel role)
        {
            var role_obj = await db.LoginTables.Where(x => x.LoginEmailId == role.LoginEmailId && x.Password == role.Password).Select(x => new LoginTable()
            {
                LoginEmailId = x.LoginEmailId,
                Password = x.Password,
                IsUser =x.IsUser,

            })
                .FirstOrDefaultAsync();

            return role_obj;
        }

        public async Task<List<LoginModel>> GetAllLogins()
        {
            if (db != null)
            {
                var records = await db.LoginTables.ToListAsync();
                return _mapper.Map<List<LoginModel>>(records);
            }
            return null;

        }
        public async Task<LoginModel> GetLoginbyId(int loginId)
        {
            var login = await db.LoginTables.FindAsync(loginId);
            return _mapper.Map<LoginModel>(login);
        }




    }
}





/*
    public int GetLoginId(string email)
   {
       if (db != null)
       {
           LoginModel loginInfo = db.LoginTables.FirstOrDefault(LoginModel => LoginModel.LoginEmailId == LoginEmailId);
           return loginInfo.LoginId;
       }
       return -1;
   }

   public async Task UpdateLogin(int LoginId, LoginModel loginModel)
   {
       /*var records = await db.Students.FindAsync(StudentId);
       if (records != null)
       {
           _mapper.Map<Student>(records);
           await db.SaveChangesAsync();

       }
       var record = new LoginTable()
       {
           LoginId = LoginId,
           LoginEmailId = loginModel.LoginEmailId,
           Password = loginModel.Password
       };
       db.LoginTables.Update(record);
       await db.SaveChangesAsync();

   }

   public async Task UpdateLoginPatch(int LoginId, JsonPatchDocument loginModel)
   {
       var record = await db.LoginTables.FindAsync(LoginId);
       if (record != null)
       {
           loginModel.ApplyTo(record);
           await db.SaveChangesAsync();
       }
   }

   public async Task DeleteLogin(int LoginId)
   {
       var record = new LoginTable()
        { LoginId = LoginId };
       db.LoginTables.Remove(record);
       await db.SaveChangesAsync();

   }*/
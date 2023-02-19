using Microsoft.AspNetCore.Http;
using skillServices.BOL.Models;
using skillServices.DAL.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillServices.BLL
{
    public class UserRegService
    {
        private readonly _IUserRegRepoDAL _urd;
        public UserRegService(_IUserRegRepoDAL urd)
        {
            _urd= urd;
        }
        public async Task<object> GetAllUsers()
        {
               return await _urd.GetAllUsers();
        }
        public async Task<object> GetUserById(int Id)
        {
            return await _urd.GetUserById(Id);
        }
        public async Task<object> AddUsersReg(UsersRegBOL urb)
        {
               return await _urd.AddUser(urb);
        }
        public async Task<object> AuthenticateUser(UsersLoginBOL ulb)
        {
            return await _urd.UserAuthenticate(ulb);
        }
        public async Task<object> UpdateUsers(UpdateUser uu)
        {
            return await _urd.UpdateUser(uu);
        }
    }
}

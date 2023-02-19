using skillServices.BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillServices.DAL.Repositries
{
    public interface _IUserRegRepoDAL
    {
        Task<object> GetAllUsers();
        Task<object> GetUserById(int Id);
        Task<object> AddUser(UsersRegBOL urb);
        Task<object> UserAuthenticate(UsersLoginBOL ulb);
        Task<object> UpdateUser(UpdateUser uu);
        Task<object> DeleteUser(int Id);
        void Save();
    }
}

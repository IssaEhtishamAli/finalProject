using Microsoft.EntityFrameworkCore;
using skillServices.BOL.Models;
using skillServices.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillServices.DAL.Repositries
{
    public class UserRegRepoDAL : _IUserRegRepoDAL
    {
        private readonly ApplicationDbContext _context;
        public UserRegRepoDAL(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<object> AddUser(UsersRegBOL urb)
        {
            try
            {
                await _context.userReg.AddAsync(urb);
                this.Save();
                return "user added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> DeleteUser(int Id)
        {
            try
            {
                var result= await _context.userReg.FirstOrDefaultAsync(x=>x.Id==Id);
                if(result != null)
                {
                    _context.userReg.Remove(result);
                    this.Save();
                }
                return "User record deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> GetAllUsers()
        {
            try
            {
                var result = await _context.userReg.ToListAsync();
                if(result.Count > 0)
                {
                    return result;
                }
                return "All users get successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> GetUserById(int Id)
        {
            try
            {
                var result= await _context.userReg.Where(x=>x.Id==Id).Distinct().FirstOrDefaultAsync();
                if(result != null)
                {
                    return result;
                }
                return "Users get by id successfull";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UpdateUser(UpdateUser uu)
        {
            try
            {
                var result = await _context.userReg.Where(x=>x.email == uu.email ).FirstOrDefaultAsync();
                if(result != null)
                {
                    result.password = uu.password;
                    this.Save();
                    return "Users updated successfully";
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<object> UserAuthenticate(UsersLoginBOL ulb)
        {
            try
            {
                var _data = await _context.userReg.Where(x => x.email == ulb.email && x.password == ulb.password).FirstOrDefaultAsync();
                if (_data == null)
                {
                    return _data;
                }
                else
                {
                    var _resultdata = (from _user in _context.userReg
                                       join _usertype in _context.usertype on _user.usrtypid equals _usertype.Id
                                       where _user.Id == _data.Id
                                       select new
                                       {
                                           Id = _user.Id,
                                           user_name = _user.username,
                                           email = _user.email,
                                           contact_no = _user.contact_no,
                                           user_type= _usertype.user_type,
                                           password = _user.password,
                                       }
                                     ).FirstOrDefault();
                    return _resultdata;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void Save()
        {
             _context.SaveChangesAsync();
        }

    }
}

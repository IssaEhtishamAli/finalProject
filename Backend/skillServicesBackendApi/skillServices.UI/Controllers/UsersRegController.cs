using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using skillServices.BLL;
using skillServices.BOL.Models;
using skillServices.DAL.Repositries;

namespace skillServices.UI.Controllers
{
    [Route("api/usersregcontroller")]
    [ApiController]
    public class UsersRegController : ControllerBase
    {
        private readonly UserRegService _urs;
        public UsersRegController(UserRegService urs)
        {
            _urs = urs;
        }
        [HttpGet("getall")]
        public async Task<object>GetAllUsers()
        {
            try
            {
                var _data =await _urs.GetAllUsers();
                    var modl = new
                    {
                        statusCode = 200,
                        message = "Users record get successfully",
                        result = _data
                    };
                if(_data == null)
                {
                    var model = new
                    {
                        statsuCode = 404,
                        message = "Resource referenced by the specified URL was not found"
                    };
                    return(model);
                }
                return Ok(modl);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reteriving data from database");
            }
        }
        [HttpGet("GetById")]
        public async Task<object> GetUserById(int Id)
        {
            try
            {
                var _data = await _urs.GetUserById(Id);
                var modl = new
                {
                    statsuCode = 200,
                    message = "User record fetch successfully",
                    result = _data
                };
                return Ok(modl);
                if(_data == null)
                {
                    var model = new
                    {
                        statsuCode = 404,
                        message = "Resource refrenced by the specified URL Was `not found"
                    };
                    return (model);
                }
            }
            catch (Exception)
            {
                return (StatusCodes.Status500InternalServerError, "Error in reteriving data from database ");
            }
        }
        [HttpPost("AaddUser")]
        public async Task<object> AddUsers(UsersRegBOL urb)
        {
            try
            {
                    var _data = await _urs.AddUsersReg(urb);
                    var modl = new
                    {
                        statsuCode = 200,
                        message = "User registration successfully",
                        result = _data
                    };
                    return Ok(modl);
                    if(_data == null)
                    {
                        var model = new
                        {
                            statsuCode = 404,
                            message = "Resource referenced by the specified URL was not found"
                        };
                        return(model);
                    }
            }
            catch (Exception)
            {
                return (StatusCodes.Status500InternalServerError, "Error in reteriving data from database");
            }
        }
        [HttpPost("authuser")]
        public async Task<object> AuthenticateUser(UsersLoginBOL ulb)
        {
            try
            {
                var _data = await _urs.AuthenticateUser(ulb);
                if (_data == null)
                {
                    var modl = new
                    {
                        statusCode = 409,
                        message = "This response is sent when a request conflicts with the current state of the server.\r\n\r\n",
                        result = _data
                    };
                    return modl;
                }
                else
                {
                    var modl = new
                    {
                        statusCode = 200,
                        message = "User login sucessfully",
                        result = _data
                    };
                    return Ok(modl);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in retriving Data from Database");
            }
        }
        [HttpPut("Updateuser")]
        public async Task<object> UpdateUsers(UpdateUser uu)
        {
            try
            {
                    var _data = await _urs.UpdateUsers(uu);
                    var modl = new
                    {
                        statsuCode = 200,
                        message = "Users profile updated successfull",
                        result = _data
                    };
                    return Ok(modl);
                    if(_data == null)
                    {
                        var model = new
                        {
                            statsusCode = 404,
                            message = "Resources referenced by the specified URL was not found"
                        };
                        return(model);
                    }
            }
            catch (Exception)
            {
                return (StatusCodes.Status500InternalServerError, "Error in reteriving data from database");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using bpkbAPI.Data;
using bpkbAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bpkbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ReturnStatusLogin> Register(user user)
        {
            try
            {
                var findData = _context.ms_user.Where(e => e.user_name == user.user_name).Count();

                if (findData == 0)
                {
                    _context.ms_user.Add(new ms_user
                    {
                        user_name = user.user_name,
                        password = user.password,
                        is_active = true
                    });
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ReturnStatusLogin
                    {
                        IsSuccess = false,
                        username = user.user_name,
                        Message = "User Sudah Ada!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ReturnStatusLogin
                {
                    IsSuccess = false,
                    Message = "Error!"
                };
            }

            return new ReturnStatusLogin
            {
                IsSuccess = true,
                username = user.user_name,
                Message = "User Created!"
            };
        }

        [HttpPost("login")]
        public async Task<ReturnStatusLogin> Login(user userLogin)
        {
            try { 
                var user = await _context.ms_user.FirstOrDefaultAsync(u => u.user_name == userLogin.user_name && u.password == userLogin.password);
                if (user == null)
                {
                    return new ReturnStatusLogin
                    {
                        IsSuccess = false,
                        username = userLogin.user_name,
                        Message = "Username atau Password Salah!"
                    };
                }
                else
                {
                    return new ReturnStatusLogin
                    {
                        IsSuccess = true,
                        username = userLogin.user_name,
                        Message = "User Berhasil Login!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ReturnStatusLogin
                {
                    IsSuccess = false,
                    Message = "Error!"
                };
            }

            return new ReturnStatusLogin
            {
                IsSuccess = true,
                username = userLogin.user_name,
                Message = "User Login!"
            };

        }

    }
}

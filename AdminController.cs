using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservationsystem_WebAPI.Data;
using Railway_Reservationsystem_WebAPI.Models;

namespace Railway_Reservationsystem_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly LoginDbContext _context;
        public AdminController(LoginDbContext loginDbContext)
        {
            _context = loginDbContext;

        }
        [HttpPost("login")]
        public IActionResult AdminLogin([FromBody] Admin loginObj)
        {
            if (loginObj == null)
            {
                return BadRequest();
            }
            else
            {
                //Compare the information sent by the user from login form
                var user = _context.AdminDetailModels.Where(a =>
                a.Name == loginObj.Name
                && a.Password == loginObj.Password).FirstOrDefault();
                if (user != null)
                {
                    //if user found sent back success object
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged in Sucessfully",
                        UserData = loginObj.Name
                    });
                }
                else
                {
                    //if user not found sent back not found object
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }

            }
        }

       

    }
}

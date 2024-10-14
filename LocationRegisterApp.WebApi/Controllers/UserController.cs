using LocationRegisterApp.Application.Services.Interfaces;
using LocationRegisterApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocationRegisterApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            var userCreated = await userService.Create(user);

            return Ok();
        }
    }
}

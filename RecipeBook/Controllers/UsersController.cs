using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Common.Models.Incoming;
using RecipeBook.Common.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterUserRequest user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.Username,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            if (result.Succeeded)
            {
                return Created($"api/users/{identityUser.Id}", null);
            }

            if (result.Errors.Any(identityError => identityError.Code.Equals(ErrorCodes.DuplicateUserErrorCode, StringComparison.InvariantCultureIgnoreCase)))
            {
                return Conflict();
            }

            return BadRequest();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Revendoo.Api.Auth;
using Revendoo.Api.Inputs;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revendoo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AuthSettings _authSettings;

        public AuthController(SignInManager<IdentityUser> signInManager,
                            UserManager<IdentityUser> userManager,
                            IOptions<AuthSettings> authSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authSettings = authSettings.Value;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserInput registerUser)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var user = new IdentityUser
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok(GenerateToken());
                }

                return BadRequest(string.Join(",", result.Errors.Select(s => s.Description)));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult> Login(LoginUserInput loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(GenerateToken());
            }
            if (result.IsLockedOut)
            {
                return BadRequest("Usuário temporariamente bloqueado por tentativas inválidas");
            }

            return BadRequest("Usuário ou Senha incorretos");
        }
        private string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _authSettings.Issuer,
                Audience = _authSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_authSettings.ExpiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
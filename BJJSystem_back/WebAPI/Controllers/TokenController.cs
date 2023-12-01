using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.InputModels;
using WebAPI.Token;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel inputModel)
        {
            if (string.IsNullOrWhiteSpace(inputModel.Login) || string.IsNullOrWhiteSpace(inputModel.Senha))
            {
                return Unauthorized();
            }
            var result = await _signInManager.PasswordSignInAsync(inputModel.Login, inputModel.Senha, false, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("secret_key-12345678"))
                    .AddSubject("Sistema gerenciamento BJJ")
                    .AddIssuer("Teste.Securiry.Bearer")
                    .AddClaim("UsuarioAPINumero", "1")
                    .AddAudience("Teste.Securiry.Bearer")
                    .AddExpiry(5)
                    .Builder();
                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebAPI.Models;
using WebAPI.Models.InputModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademiaController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AcademiaController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarUsuario")]
        public async Task<IActionResult> AdicionaAcademia([FromBody] AcademiaLogin academiaLogin)
        {
            if (string.IsNullOrWhiteSpace(academiaLogin.Email) || string.IsNullOrWhiteSpace(academiaLogin.UsuarioLogin)
                || string.IsNullOrWhiteSpace(academiaLogin.SenhaHash))
            {
                return Ok("Falta alguns dados");
            }

            var user = new ApplicationUser
            {
                Email = academiaLogin.Email,
                UserName = academiaLogin.UsuarioLogin,
                Nome = academiaLogin.Nome,
            };

            var result = await _userManager.CreateAsync(user, academiaLogin.SenhaHash);

            if (result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            //Geração de confirmação de email
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var response_return = await _userManager.ConfirmEmailAsync(user, code);

            if (response_return.Succeeded)
            {
                return Ok("Usuário cadastrado");
            }
            else
            {
                return Ok("Erro ao confirmar cadastro");
            }

        }
    }
}

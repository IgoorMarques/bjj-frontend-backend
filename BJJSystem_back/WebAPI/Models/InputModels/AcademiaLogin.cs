namespace WebAPI.Models
{
    public class AcademiaLogin
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string UsuarioLogin { get; set; }
        public string SenhaHash { get; set; }
    }
}

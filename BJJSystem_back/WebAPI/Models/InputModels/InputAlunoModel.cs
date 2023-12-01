namespace WebAPI.Models.InputModels
{
    public class InputAlunoModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Faixa { get; set; }
        public string? Descricao { get; set; }
        public int Graus { get; set; }
    }
}

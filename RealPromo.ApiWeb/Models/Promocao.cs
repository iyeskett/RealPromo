namespace RealPromo.ApiWeb.Models
{
    public class Promocao
    {
        public string Empresa { get; set; } = null!;
        public string Chamada { get; set; } = null!;
        public string Regras { get; set; } = null!;
        public string EnderecoURL { get; set; } = null!;
    }
}
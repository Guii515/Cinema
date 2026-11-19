namespace CinemaApp.Models
{
    public class FilmeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Classificacao { get; set; } = string.Empty;
        public string NomeGenero { get; set; } = string.Empty;
        public int Duracao { get; set; }
    }
}

namespace CinemaApp.Models
{
    public class SessaoViewModel
    {
        public int Id { get; set; }
        public string NomeFilme { get; set; } = string.Empty;
        public int NumeroSala { get; set; }
        public DateTime Data { get; set; }
        public decimal Preco { get; set; }
    }
}

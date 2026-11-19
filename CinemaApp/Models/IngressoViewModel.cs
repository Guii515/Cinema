namespace CinemaApp.Models
{
    public class IngressoViewModel
    {
        public int Id { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string NomeFilme { get; set; } = string.Empty;
        public DateTime DataSessao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaPagamento { get; set; } = string.Empty;
        public DateTime DataCompra { get; set; }
    }
}

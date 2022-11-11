namespace FundaVida.ViewModel
{
    public class HorarioViewModel
    {
        public int horarioId { get; set; }
        public string? cursonombre { get; set; }
        public byte[]? cursoimagen { get; set; }
        public TimeSpan? horainicio { get; set; }
        public TimeSpan? horafin { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace FundaVida.Entity;

public partial class Vacante
{
    public int VacanteId { get; set; }

    public DateTime? Dia { get; set; }

    public TimeSpan? HoraInicio { get; set; }

    public TimeSpan? HoraFin { get; set; }

    public bool? EnEspera { get; set; }

    public int? DuracionTotal { get; set; }

    public virtual ICollection<Horario> Horarios { get; } = new List<Horario>();
}

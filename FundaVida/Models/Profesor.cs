using System;
using System.Collections.Generic;

namespace FundaVida.Models;

public partial class Profesor
{
    public int ProfesorId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public virtual ICollection<Horario> Horarios { get; } = new List<Horario>();
}

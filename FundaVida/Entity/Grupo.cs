using System;
using System.Collections.Generic;

namespace FundaVida.Entity;

public partial class Grupo
{
    public int GrupoId { get; set; }

    public string? GrupoNombre { get; set; }

    public virtual ICollection<Horario> Horarios { get; } = new List<Horario>();
}

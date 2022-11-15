using System;
using System.Collections.Generic;

namespace FundaVida.Entity;

public partial class Estudiante
{
    public int EstudianteId { get; set; }

    public string EstudianteNombre { get; set; } = null!;

    public string EstudianteApellidos { get; set; } = null!;

    public string EstudianteCorreo { get; set; } = null!;

    public virtual ICollection<Horario> Horarios { get; } = new List<Horario>();
}

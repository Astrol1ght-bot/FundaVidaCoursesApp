using System;
using System.Collections.Generic;

namespace FundaVida.Models;

public partial class Horario
{
    public int HorarioId { get; set; }

    public int? CursoId { get; set; }

    public int? GrupoId { get; set; }

    public int? ProfesorId { get; set; }

    public int? VacanteId { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual Grupo? Grupo { get; set; }

    public virtual Profesor? Profesor { get; set; }

    public virtual Vacante? Vacante { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; } = new List<Estudiante>();
}

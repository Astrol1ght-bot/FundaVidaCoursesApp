using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FundaVida.Models;

public partial class Horario
{
    public int HorarioId { get; set; }
    

    public int? CursoId { get; set; }

    
    public int? GrupoId { get; set; }

    
    public int? ProfesorId { get; set; }

    
    public int? VacanteId { get; set; }

    [ForeignKey("CursoID")]
    public virtual Curso? Curso { get; set; }

    [ForeignKey("GrupoID")]

    public virtual Grupo? Grupo { get; set; }

    [ForeignKey("ProfesorID")]

    public virtual Profesor? Profesor { get; set; }

    [ForeignKey("VacanteID")]

    public virtual Vacante? Vacante { get; set; }


    public virtual ICollection<Estudiante> Estudiantes { get; } = new List<Estudiante>();
}
